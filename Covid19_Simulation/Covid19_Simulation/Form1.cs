using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;
using System.Windows.Media.Imaging;
using iText.Kernel.Colors;

namespace Covid19_Simulation
{
    public partial class Form1 : Form
    {
        Hospital hospital;
        Community community;
        SimulationTime simulationTime;
        Stopwatch stopwatch;
        HeatSeries hs;
        HeatSeries hs1;
        LineSeries ls;
        Axis aX;Axis aY;Axis aX1;Axis aY1;Axis lX;Axis lY;
        int trigger;
        bool inputType = false;
        List<int> customCommunity;

        //read through ctrl m+o

        public Form1()
        {
            InitializeComponent();
            fillListBoxes();
            this.bt_save.Enabled = false;
            this.gb_lockdownPolicy.Enabled = false;
            this.gb_time.Enabled = false;
            simulationTime = new SimulationTime();
            initializeHeatMaps();
            initializeCurveGraph();
            
            //Selecting default values in optional groupbox
            listBox_culture.SelectedIndex = 1;
            listBox_doctorPercentage.SelectedIndex = 3;
            listBox_areaSize.SelectedIndex = 4;
            listBox_herdPercentage.SelectedIndex = 2;
            listBox_nursePercentage.SelectedIndex = 5;
        }

        /* main buttons */

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (this.tb_budget.Text == "" || this.tb_population.Text == "")
            {
                MessageBox.Show("Required parameters missing.");
            }
            else
            {
                int chb, chp;
                if (int.TryParse(this.tb_budget.Text, out chb) && int.TryParse(this.tb_population.Text, out chp))
                {
                    stopwatch = Stopwatch.StartNew();

                    this.inputType = false;
                    this.tb_budget.ReadOnly = true;
                    this.tb_population.ReadOnly = true;
                    this.bt_start.Enabled = false;
                    this.bt_custom_start.Enabled = false;

                    ILockdownPolicy terra = new Policy_none();
                    community = new Community(chp);
                    hospital = new Hospital(chp, chb, terra);

                    accountForOptionalInput();
                    community.populateMemberList();
                    Qualification q = Qualification.InfectiousDisease;
                    if (!hospital.initiateHospitalList(community.getDistrictCount(), q))
                    {
                        if (chb > 4500)
                            MessageBox.Show("Simulation failure: population too small.");
                        else
                            MessageBox.Show("Simulation failure: budget too small.");
                        this.tb_budget.ReadOnly = false;
                        this.tb_population.ReadOnly = false;
                        this.bt_start.Enabled = true;
                        this.bt_custom_start.Enabled = true;
                        restateOptionalInput();
                    }
                    else
                    {
                        this.timer_general.Enabled = true;
                        this.gb_time.Enabled = true;
                        this.gb_lockdownPolicy.Enabled = true;
                        this.rb_noLockdown.Select();
                        this.bt_save.Enabled = true;
                        this.timer_label_updator.Enabled = true;
                        update_labels();
                        this.timer_socialEvent.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Parameter format invalid.");
                }
            }
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            //TODO serialize hospital, community, simulationTime, stopwatch objects
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "csimsave";
                sfd.AddExtension = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fileStream = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, hospital);
                        binaryFormatter.Serialize(fileStream, community);
                        binaryFormatter.Serialize(fileStream, simulationTime);
                    }
                }
            }
        }
       
        private void bt_load_Click(object sender, EventArgs e)
        {
            //TODO deserialize hospital, community, simulationTime, stopwatch objects
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Save files (*.csimsave)|*.csimsave";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fileStream = null;
                    try
                    {
                        fileStream = new FileStream(ofd.FileName, FileMode.OpenOrCreate);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        object h = binaryFormatter.Deserialize(fileStream);
                        if (h is Hospital)
                        {
                            hospital = (Hospital)h;
                        }
                        object c = binaryFormatter.Deserialize(fileStream);
                        if (c is Community)
                        {
                            community = (Community)c;
                        }
                        object st = binaryFormatter.Deserialize(fileStream);
                        if (st is SimulationTime)
                        {
                            simulationTime = (SimulationTime)st;
                        }
                    }
                        #pragma warning disable 0168
                    catch (SerializationException ex) { }
                        #pragma warning restore 0168
                        #pragma warning disable 0168
                    catch (IOException ex) { }
                        #pragma warning restore 0168

                    finally { fileStream.Close(); }
                }
            }
            UpdateGUI();
        }
       
        private void bt_custom_start_Click(object sender, EventArgs e)
        {
            if (this.tb_budget.Text == "")
            {
                MessageBox.Show("Required budget parameter missing.");
            }
            else
            {
                int chb, chp = 0;
                if (int.TryParse(this.tb_budget.Text, out chb))
                {
                    customCommunity = new List<int>();
                    var fileContent = string.Empty;
                    var filePath = string.Empty;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = @"..\..\"; //"c:\\";
                        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.RestoreDirectory = true;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = openFileDialog.FileName;
                            var fileStream = openFileDialog.OpenFile();
                            using (StreamReader reader = new StreamReader(fileStream))
                            {
                                while (!reader.EndOfStream)
                                {
                                    var line = reader.ReadLine();
                                    var values = line.Split(',');
                                    foreach (var v in values)
                                    {
                                        int temp;
                                        if (int.TryParse(v, out temp))
                                            customCommunity.Add(temp);
                                        else
                                        { MessageBox.Show("Expecting correct comma separated values file."); }
                                    }
                                }
                            }
                        }
                    }
                    foreach (int i in customCommunity)
                    {
                        chp += i;
                    }
                    MessageBox.Show($"District count {customCommunity.Count.ToString()}. " +
                        $"\nTotal population {chp}.\nClose to begin.", "Custom Map Read Successful");

                    this.inputType = true;
                    //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
                    stopwatch = Stopwatch.StartNew();
                    this.tb_budget.ReadOnly = true;
                    this.tb_population.ReadOnly = true;
                    this.bt_start.Enabled = false;
                    this.bt_custom_start.Enabled = false;
                    ILockdownPolicy terra = new Policy_none();
                    //community = new Community(chp);
                    community = new Community(chp, customCommunity);
                    hospital = new Hospital(chp, chb, terra);
                    accountForOptionalInput();
                    community.populateMemberListCustom();
                    Qualification q = Qualification.InfectiousDisease;
                    if (!hospital.initiateHospitalList(community.getDistrictCount(), q))
                    {
                        if (chb > 4500)
                            MessageBox.Show("Simulation failure: population too small.");
                        else
                            MessageBox.Show("Simulation failure: budget too small.");
                        this.tb_budget.ReadOnly = false;
                        this.tb_population.ReadOnly = false;
                        this.bt_start.Enabled = true;
                        this.bt_custom_start.Enabled = true;
                        restateOptionalInput();
                    }
                    else
                    {
                        this.timer_general.Enabled = true;
                        this.gb_time.Enabled = true;
                        this.gb_lockdownPolicy.Enabled = true;
                        this.rb_noLockdown.Select();
                        this.bt_save.Enabled = true;
                        this.timer_label_updator.Enabled = true;
                        update_labels();
                        this.timer_socialEvent.Enabled = true;
                    }

                }
                else
                {
                    MessageBox.Show("Parameter format invalid.");
                }
            }
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* timers to distribute loop workload */

        private void timer_general_Tick(object sender, EventArgs e)
        {
            simulationTime.incrementSimulationTime(this.trackBar_time.Value);
            this.lb_sim_time.Text = simulationTime.getSimulationTimeString();
            this.lb_app_time.Text = stopwatch.Elapsed.ToString();
        }

        private void timer_label_updator_Tick(object sender, EventArgs e)
        {
            update_labels();
            activateHeatMapC(community.reportHMStatus());
            activateHeatMapH(hospital.reportHMStatus());
        }

        private void timer_socialEvent_Tick(object sender, EventArgs e)
        {
            if (simulationTime.getDays() != trigger)
            {
                (List<Member> tempList, String culture, int density, int districts) = community.getEventCircumstances();
                hospital.updateRecords(hospital.socialEvent(tempList, culture, density, districts), simulationTime.getDays());
                activateCurve(hospital.getHistory());
                //
                List<double> success = hospital.getHistory();
                if (success.Count > 3)
                {
                    if (success[success.Count-1] == 0 && success[success.Count - 2] == 0 && success[success.Count - 3] == 0)
                    {
                        this.tabControl1.SelectTab(tabPage2);
                        this.tabPage2.Select();
                        stopSimulation();
                        DialogResult dr = MessageBox.Show("No new infections for three consecutive days. An assumption can be" +
                            " made that society in this community has adapted to virus.\nGenerate instance report on your desktop?", "Simulation Completed", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            Cursor.Hide();
                            Cursor.Position = new Point(0, 0);
                            generateReport(true, "Curve has flattened out, as there were no new infections for three days");
                            Cursor.Show();
                        }
                    }
                }
            }
            trigger = simulationTime.getDays();
            if (!hospital.checkForMoreStaff())
            {
                this.tabControl1.SelectTab(tabPage2);
                this.tabPage2.Select();
                stopSimulation();
                DialogResult dr = MessageBox.Show("Budget depleted when attemping to hire hospital personnel.\nGenerate instance report on your desktop?", "Simulation Failure", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Cursor.Hide();
                    Cursor.Position = new Point(0, 0);
                    generateReport(false, "Insufficient funds to hire required hospital personnel");
                    Cursor.Show();
                }
            }
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* GUI element methods */

        private void fillListBoxes()
        {
            this.listBox_herdPercentage.Items.Add("50");
            this.listBox_herdPercentage.Items.Add("55");
            this.listBox_herdPercentage.Items.Add("60");
            this.listBox_herdPercentage.Items.Add("65");
            this.listBox_herdPercentage.Items.Add("70");
            this.listBox_herdPercentage.Items.Add("75");
            //---------------------------------------------
            this.listBox_doctorPercentage.Items.Add("0.5");
            this.listBox_doctorPercentage.Items.Add("1");
            this.listBox_doctorPercentage.Items.Add("1.5");
            this.listBox_doctorPercentage.Items.Add("2");
            this.listBox_doctorPercentage.Items.Add("2.5");
            this.listBox_doctorPercentage.Items.Add("3");
            //---------------------------------------------
            this.listBox_nursePercentage.Items.Add("0.5");
            this.listBox_nursePercentage.Items.Add("1");
            this.listBox_nursePercentage.Items.Add("1.5");
            this.listBox_nursePercentage.Items.Add("2");
            this.listBox_nursePercentage.Items.Add("2.5");
            this.listBox_nursePercentage.Items.Add("3");
            //---------------------------------------------
            this.listBox_areaSize.Items.Add("100");
            this.listBox_areaSize.Items.Add("200");
            this.listBox_areaSize.Items.Add("300");
            this.listBox_areaSize.Items.Add("400");
            this.listBox_areaSize.Items.Add("500");
            this.listBox_areaSize.Items.Add("600");
            this.listBox_areaSize.Items.Add("700");
            this.listBox_areaSize.Items.Add("800");
            this.listBox_areaSize.Items.Add("900");
            this.listBox_areaSize.Items.Add("1000");
            //---------------------------------------------
            this.listBox_culture.Items.Add("Close");
            this.listBox_culture.Items.Add("Median");
            this.listBox_culture.Items.Add("Remote");
        }

        private void accountForOptionalInput()
        {
            if (this.listBox_herdPercentage.SelectedItem != null)
                community.setHerdSufficiency(Int32.Parse(this.listBox_herdPercentage.SelectedItem.ToString()));
            if (this.listBox_doctorPercentage.SelectedItem != null)
                hospital.setDoctorPercentage(Convert.ToDouble(this.listBox_doctorPercentage.SelectedItem.ToString()));
            if (this.listBox_nursePercentage.SelectedItem != null)
                hospital.setNursePercentage(Convert.ToDouble(this.listBox_nursePercentage.SelectedItem.ToString()));
            if (this.listBox_areaSize.SelectedItem != null)
                community.setAreaDensity(Int32.Parse(this.listBox_areaSize.SelectedItem.ToString()));
            if (this.listBox_culture.SelectedItem != null)
                community.setCultureType(this.listBox_culture.SelectedItem.ToString());

            this.listBox_herdPercentage.Enabled = false;
            this.listBox_doctorPercentage.Enabled = false;
            this.listBox_nursePercentage.Enabled = false;
            this.listBox_areaSize.Enabled = false;
            this.listBox_culture.Enabled = false;
        }

        private void restateOptionalInput()
        {
            this.listBox_herdPercentage.Enabled = true;
            this.listBox_doctorPercentage.Enabled = true;
            this.listBox_nursePercentage.Enabled = true;
            this.listBox_areaSize.Enabled = true;
            this.listBox_culture.Enabled = true;
        }

        private void update_labels()
        {
            this.lb_comm_pop_status.Text = $"Number of Members: {community.getMemberListSize()}";
            (double f, double m) = community.getGenderPercentages();
            this.lb_comm_gender.Text = $"Gender Distribution: {f.ToString("F2")}% Females, {m.ToString("F2")}% Males.";
            (double y, double a, double o) = community.getAgePercentages();
            this.bl_comm_age_distr.Text = $"Age Distribution: {y.ToString("F2")}% [0-20], {a.ToString("F2")}% [20-60], {o.ToString("F2")}% [60+].";
            this.lb_remainingBudget.Text = $"Remaining Budget: {hospital.getBudget()}";
            this.lb_hosp_nrOfDocs.Text = $"Number of Doctors: {hospital.getNrOfDocs()}";
            this.lb_hosp_nrOfNurses.Text = $"Number of Nurses: {hospital.getNrOfNurses()}";
            this.lb_hosp_potDoc.Text = $"Potential Doctors: {hospital.getPotentialDoctors()}";
            this.lb_hosp_potNus.Text = $"Potential Nurses: {hospital.getPotentialNurses()}";
            this.lb_hm_nrOfSq.Text = $"Number of Districts: {community.getDistrictCount()} (Population/Density)";
            this.lb_host_nrPat.Text = "Number of Patients: " + hospital.getPatientCount().ToString();
            this.lb_hosp_yCaseNr.Text = "Yesterday's Cases: " + (community.getTransmitedNr()).ToString();
            this.lbl_dece_pat.Text = "Deceased Patients: " + (hospital.getDeceased().ToString());
            this.lbl_recov_pat.Text = "Recovered Patients: " + (hospital.getRecovered().ToString());
        }

        private void UpdateGUI()
        {
            tb_budget.Text = hospital.getInitialBudget().ToString();
            tb_population.Text = hospital.getInitialPopulation().ToString();
            //if (this.listBox_herdPercentage.SelectedItem != null)
            //{
            listBox_herdPercentage.SelectedItem = community.getHerdSufficiency().ToString();
            //}
            //if (this.listBox_doctorPercentage.SelectedItem != null)
            //{
            listBox_doctorPercentage.SelectedItem = hospital.getDoctorPercentage().ToString();
            //}
            //if (this.listBox_nursePercentage.SelectedItem != null)
            //{
            listBox_nursePercentage.SelectedItem = hospital.getNursePercentage().ToString();
            //}
            //if (this.listBox_areaSize.SelectedItem != null)
            //{
            listBox_areaSize.SelectedItem = community.getAreaDensity().ToString();
            //}
            //if (this.listBox_culture.SelectedItem != null)
            //{
            listBox_culture.SelectedItem = community.getCultureType().ToString();
            //}
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* run-time changes required by client */

        private void rb_noLockdown_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_noLockdown.Checked == true)
            {
                ILockdownPolicy noP = new Policy_none();
                hospital.newPolicy(noP);
                simulationTime.markPolicy(stopwatch, 1);
            }
        }

        private void rb_herdImu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_herdImu.Checked == true)
            {
                ILockdownPolicy hiP = new Policy_HI();
                hospital.newPolicy(hiP);
                simulationTime.markPolicy(stopwatch, 2);
            }
        }

        private void rb_lightPolicy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_lightPolicy.Checked == true)
            {
                ILockdownPolicy miP = new Policy_mild();
                hospital.newPolicy(miP);
                simulationTime.markPolicy(stopwatch, 3);
            }
        }

        private void rb_strictPolicy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb_strictPolicy.Checked == true)
            {
                ILockdownPolicy stP = new Policy_strict();
                hospital.newPolicy(stP);
                simulationTime.markPolicy(stopwatch, 4);
            }
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* visuals required by client */

        private void activateHeatMapC(List<HM_object> hmo)
        {
            hs.Values.Clear();
            for (int i = 0; i < hmo.Count; i++)
                hs.Values.Add(new HeatPoint(hmo[i].getX(), hmo[i].getY(), hmo[i].getW()));
        }

        private void activateHeatMapH(List<HM_object> hmo)
        {
            hs1.Values.Clear();
            for (int i = 0; i < hmo.Count; i++)
                hs1.Values.Add(new HeatPoint(hmo[i].getX(), hmo[i].getY(), hmo[i].getW()));
        }

        private void activateCurve(List<double> history)
        {
            ls.Values.Clear();
            for (int i = 0; i < history.Count; i++)
                if (history[i] != 0)
                    ls.Values.Add(history[i]);
        }

        public void initializeHeatMaps()
        {
            hs = new HeatSeries { Values = new ChartValues<HeatPoint> { new HeatPoint(0, 0, 0) }, DataLabels = false };
            hs.Title = "Community";
            aX = new Axis { };
            aX.Title = "Longitude";
            aY = new Axis { };
            aY.Title = "Latitude";
            HeatMap.Series.Add(hs);
            HeatMap.AxisX.Add(aX);
            HeatMap.AxisY.Add(aY);
            hs1 = new HeatSeries
            {
                Values = new ChartValues<HeatPoint> { new HeatPoint(0, 0, 0) },
                DataLabels = false,
                GradientStopCollection = new GradientStopCollection {   new GradientStop(System.Windows.Media.Color.FromRgb(96, 74, 75), 0),
                                                                        new GradientStop(System.Windows.Media.Color.FromRgb(95, 58, 61), 0.25),
                                                                        new GradientStop(System.Windows.Media.Color.FromRgb(94, 45, 44), 0.5),
                                                                        new GradientStop(System.Windows.Media.Color.FromRgb(112, 30, 27), 0.75),
                                                                        new GradientStop(System.Windows.Media.Color.FromRgb(226, 11, 7), 1.0)}
            };
            hs1.Title = "Patients";
            aX1 = new Axis { };
            aX1.Title = "Longitude";
            aY1 = new Axis { };
            aY1.Title = "Latitude";
            HeatMap2.Series.Add(hs1);
            HeatMap2.AxisX.Add(aX1);
            HeatMap2.AxisY.Add(aY1);
        }

        public void initializeCurveGraph()
        {
            ls = new LineSeries { Values = new ChartValues<double> { 0 } };
            lX = new Axis { };
            lX.Title = "Days";
            lY = new Axis { };
            lY.Title = "Registered Patients";
            Curve.Series.Add(ls);
            Curve.AxisX.Add(lX);
            Curve.AxisY.Add(lY);
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* pause/restart functionality */

        public void stopSimulation()
        {
            this.timer_general.Dispose();
            this.timer_label_updator.Dispose();
            this.timer_socialEvent.Dispose();
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

        /* create pdf document upon request */
        
        public void captureHeatMap(Control c, String fileName)
        {
            Bitmap bm = new Bitmap(c.Width, c.Height);
            Graphics gg = Graphics.FromImage(bm);
            Rectangle rect = c.RectangleToScreen(c.ClientRectangle);
            gg.CopyFromScreen(rect.Location, Point.Empty, c.Size);
            bm.Save(fileName);
        }

        public void generateReport(bool outcome, string reason)
        {
            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String documentName = $"Covid-19 Simulation Report on {(DateTime.Now).ToString("yyyy-MM-dd")} at {(DateTime.Now).ToString("hh-mm")}.pdf";
            var exportFile = System.IO.Path.Combine(exportFolder, documentName);
            using (var writer = new PdfWriter(exportFile)) {
                using (var pdf = new PdfDocument(writer)) {
                    var doc = new Document(pdf);
                    String result = outcome ? "Successful" : "Failure";
                    String result1 = inputType ? "Custom" : "Basic";
                    Paragraph header = new Paragraph($"Simulation Report - {result}");
                    header.SetTextAlignment(TextAlignment.CENTER).SetBold().SetFontSize(20);
                    Paragraph subheaderC = new Paragraph("" +
                        $"Simulated time: {simulationTime.getDays()} days, {simulationTime.getHours()} hours and {simulationTime.getMinutes()} minutes" +
                        $". \nElapsed time: {stopwatch.Elapsed.Hours} hours, {stopwatch.Elapsed.Minutes} minutes. \nConclusion: '{reason}'." +
                        $" \nInput type was: '{result1}'. Initial user provided parameters were: " +
                        "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(header);
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    doc.Add(ls);
                    doc.Add(subheaderC);
                    Table table = new Table(2, false).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    Cell cell_0 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Budget"));
                    Cell cell_00 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(this.tb_budget.Text));
                    Cell cell_1 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Population"));
                    Cell cell_11 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(this.tb_population.Text));
                    Cell cell_2 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Doctor %"));
                    Cell cell_22 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(hospital.getDoctorPercentage().ToString()));
                    Cell cell_3 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Nurse %"));
                    Cell cell_33 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(hospital.getNursePercentage().ToString()));
                    Cell cell_4 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Herd %"));
                    Cell cell_44 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(community.getHerdSufficiency().ToString()));
                    Cell cell_5 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Density"));
                    Cell cell_55 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(community.getAreaDensity().ToString()));
                    Cell cell_6 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Culture"));
                    Cell cell_66 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(community.getCultureType().ToString()));
                    table.AddCell(cell_0);
                    table.AddCell(cell_00);
                    table.AddCell(cell_1);
                    table.AddCell(cell_11);
                    table.AddCell(cell_2);
                    table.AddCell(cell_22);
                    table.AddCell(cell_3);
                    table.AddCell(cell_33);
                    table.AddCell(cell_4);
                    table.AddCell(cell_44);
                    table.AddCell(cell_5);
                    table.AddCell(cell_55);
                    table.AddCell(cell_6);
                    table.AddCell(cell_66);
                    doc.Add(table);
                    Paragraph subheaderCB = new Paragraph("" +
                       $"\nDue to the fact that simulation was '{result1}' the following community population heat map was generated.\n" +
                       "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(subheaderCB);
                    captureHeatMap(HeatMap, "comm_stats.bmp");
                    captureHeatMap(HeatMap2, "hosp_stats.bmp");
                    this.tabControl1.SelectTab(tabPage3);
                    this.tabPage3.Select();
                    Cursor.Show();
                    MessageBox.Show("Report generated.", "Status", MessageBoxButtons.OK);
                    Cursor.Hide();
                    Cursor.Position = new Point(0, 0);
                    Image img = new Image(ImageDataFactory
                            .Create(@"..\..\bin\Debug\comm_stats.bmp")).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    doc.Add(img);
                    doc.Add(new AreaBreak());
                    doc.Add(ls);
                    Paragraph subheaderH = new Paragraph("" +
                       $"\nProvided budget and medical personnel availability constraints allowed hospital to recruit" +
                       $" {hospital.getNrOfDocs()} doctors (out of {hospital.getPotentialDoctors()}) and {hospital.getNrOfNurses()} nurses " +
                       $"(out of {hospital.getPotentialNurses()}). Patient table is: \n" +
                       "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(subheaderH);
                    Table table1 = new Table(2, false).SetTextAlignment(TextAlignment.CENTER).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    Cell Ccell_0 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Total"));
                    Cell Ccell_00 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(hospital.getPatientCount().ToString()));
                    Cell Ccell_1 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Recovered"));
                    Cell Ccell_11 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(hospital.getRecovered().ToString()));
                    Cell Ccell_2 = new Cell(1, 1).SetBackgroundColor(ColorConstants.GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("Deceased"));
                    Cell Ccell_22 = new Cell(1, 1).SetBackgroundColor(ColorConstants.WHITE)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph(hospital.getDeceased().ToString()));
                    table1.AddCell(Ccell_0);
                    table1.AddCell(Ccell_00);
                    table1.AddCell(Ccell_1);
                    table1.AddCell(Ccell_11);
                    table1.AddCell(Ccell_2);
                    table1.AddCell(Ccell_22);
                    doc.Add(table1);
                    Paragraph subheaderHB = new Paragraph("" +
                       $"\nDue to the fact that simulation was '{result1}' the following infected patient distribution in the community heat map was generated.\n" +
                       "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(subheaderHB);
                    Image img1 = new Image(ImageDataFactory
                        .Create(@"..\..\bin\Debug\hosp_stats.bmp")).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    doc.Add(img1);
                    doc.Add(new AreaBreak());
                    doc.Add(ls);
                    Paragraph lcktbl = new Paragraph("" +
                        $"User made {simulationTime.getNumberDecision()} lockdown decisions:\n " +
                        "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(lcktbl);
                    Table table2 = new Table(simulationTime.getNumberDecision(), false).SetTextAlignment(TextAlignment.CENTER).UseAllAvailableWidth();
                    //assume that no one ever will want to do more than 5 lockdown decisions, as that basically means chaotic no policy
                    Cell CCcell_0 = new Cell(1, 1).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                       .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("1. " + simulationTime.getDecision(0)));
                    table2.AddCell(CCcell_0);
                    Paragraph dec1 = new Paragraph($"1. App time: {simulationTime.getStr(0)}. Sim time: {simulationTime.getPolicyTimestamp(0)} [DD:HH:MM:SS]").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(13);
                    doc.Add(dec1);
                    if (simulationTime.getNumberDecision() > 1) {
                        Cell CCcell_00 = new Cell(1, 1).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                            .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("2. " + simulationTime.getDecision(1)));
                        table2.AddCell(CCcell_00);
                        Paragraph dec2 = new Paragraph($"2. App time: {simulationTime.getStr(1)}. Sim time: {simulationTime.getPolicyTimestamp(1)} [DD:HH:MM:SS]").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(13);
                        doc.Add(dec2); }
                    if (simulationTime.getNumberDecision() > 2) {
                        Cell CCcell_000 = new Cell(1, 1).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("3. " + simulationTime.getDecision(2)));
                        table2.AddCell(CCcell_000);
                        Paragraph dec3 = new Paragraph($"3. App time: {simulationTime.getStr(2)}. Sim time: {simulationTime.getPolicyTimestamp(2)} [DD:HH:MM:SS]").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(13);
                        doc.Add(dec3); }
                    if (simulationTime.getNumberDecision() > 3) {
                        Cell CCcell_0000 = new Cell(1, 1).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("4. " + simulationTime.getDecision(3)));
                        table2.AddCell(CCcell_0000);
                        Paragraph dec4 = new Paragraph($"4. App time: {simulationTime.getStr(3)}. Sim time: {simulationTime.getPolicyTimestamp(3)} [DD:HH:MM:SS]").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(13);
                        doc.Add(dec4); }
                    if (simulationTime.getNumberDecision() > 4) {
                        Cell CCcell_00000 = new Cell(1, 1).SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                        .SetTextAlignment(TextAlignment.CENTER).Add(new Paragraph("5. " + simulationTime.getDecision(4)));
                        table2.AddCell(CCcell_00000);
                        Paragraph dec5 = new Paragraph($"5. App time: {simulationTime.getStr(4)}. Sim time: {simulationTime.getPolicyTimestamp(4)} [DD:HH:MM:SS]").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(13);
                        doc.Add(dec5); }
                    if (simulationTime.getNumberDecision() > 5) {
                        Paragraph warning  = new Paragraph("" +
                            $"It is an unseen practice to do so many lockdown decisions in a short time span. Only the first five are displayed.\n" +
                            "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15).SetFontColor(ColorConstants.RED);
                        doc.Add(warning); }
                    doc.Add(table2);
                    Paragraph subheaderC1 = new Paragraph("" +
                       $"\nOverall patient infection rate curve (new patients per day):\n" +
                       "").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(subheaderC1);
                    captureHeatMap(Curve, "curve.bmp");
                    Image img2 = new Image(ImageDataFactory
                        .Create(@"..\..\bin\Debug\curve.bmp")).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    doc.Add(img2);
                    Paragraph last = new Paragraph($"Remaining budget: {hospital.getBudget()}").SetTextAlignment(TextAlignment.JUSTIFIED).SetFontSize(15);
                    doc.Add(last);
                    doc.Add(ls);
                    // perror flush
                    /*int n = pdf.GetNumberOfPages();
                    for (int i = 1; i <= n; i++) {
                        doc.ShowTextAligned(new Paragraph(String
                           .Format("page " + i + " of " + n)),
                            559, 806, i, TextAlignment.RIGHT,
                            VerticalAlignment.TOP, 0); }*/
                    doc.Close();
                }
            }
        }
        //---------------------------------------------------------------------------


        //---------------------------------------------------------------------------

    }
}
