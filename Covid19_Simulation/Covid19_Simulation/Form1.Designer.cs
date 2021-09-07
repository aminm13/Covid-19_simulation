namespace Covid19_Simulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gb_required = new System.Windows.Forms.GroupBox();
            this.bt_custom_start = new System.Windows.Forms.Button();
            this.bt_start = new System.Windows.Forms.Button();
            this.lb_population = new System.Windows.Forms.Label();
            this.tb_population = new System.Windows.Forms.TextBox();
            this.tb_budget = new System.Windows.Forms.TextBox();
            this.lb_budget = new System.Windows.Forms.Label();
            this.gb_optional = new System.Windows.Forms.GroupBox();
            this.listBox_culture = new System.Windows.Forms.ListBox();
            this.lb_culture = new System.Windows.Forms.Label();
            this.listBox_areaSize = new System.Windows.Forms.ListBox();
            this.lb_density = new System.Windows.Forms.Label();
            this.listBox_nursePercentage = new System.Windows.Forms.ListBox();
            this.lb_propOfNurses = new System.Windows.Forms.Label();
            this.listBox_doctorPercentage = new System.Windows.Forms.ListBox();
            this.lb_propOfDoctors = new System.Windows.Forms.Label();
            this.listBox_herdPercentage = new System.Windows.Forms.ListBox();
            this.lb_herd_size_input = new System.Windows.Forms.Label();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_load = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gb_lockdownPolicy = new System.Windows.Forms.GroupBox();
            this.rb_strictPolicy = new System.Windows.Forms.RadioButton();
            this.rb_lightPolicy = new System.Windows.Forms.RadioButton();
            this.rb_herdImu = new System.Windows.Forms.RadioButton();
            this.rb_noLockdown = new System.Windows.Forms.RadioButton();
            this.gb_commStats = new System.Windows.Forms.GroupBox();
            this.lb_hm_nrOfSq = new System.Windows.Forms.Label();
            this.bl_comm_age_distr = new System.Windows.Forms.Label();
            this.lb_comm_gender = new System.Windows.Forms.Label();
            this.lb_comm_pop_status = new System.Windows.Forms.Label();
            this.gb_hospitalStats = new System.Windows.Forms.GroupBox();
            this.lb_hosp_yCaseNr = new System.Windows.Forms.Label();
            this.lb_host_nrPat = new System.Windows.Forms.Label();
            this.lb_hosp_potNus = new System.Windows.Forms.Label();
            this.lb_hosp_potDoc = new System.Windows.Forms.Label();
            this.lb_remainingBudget = new System.Windows.Forms.Label();
            this.lb_hosp_nrOfNurses = new System.Windows.Forms.Label();
            this.lb_hosp_nrOfDocs = new System.Windows.Forms.Label();
            this.gb_time = new System.Windows.Forms.GroupBox();
            this.label_1 = new System.Windows.Forms.Label();
            this.label_60 = new System.Windows.Forms.Label();
            this.lb_app_lb = new System.Windows.Forms.Label();
            this.lb_sim_lb = new System.Windows.Forms.Label();
            this.lb_format_lb = new System.Windows.Forms.Label();
            this.lb_app_time = new System.Windows.Forms.Label();
            this.lb_timeExlp = new System.Windows.Forms.Label();
            this.lb_sim_time = new System.Windows.Forms.Label();
            this.trackBar_time = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_hospHM = new System.Windows.Forms.GroupBox();
            this.HeatMap2 = new LiveCharts.WinForms.CartesianChart();
            this.gb_commHM = new System.Windows.Forms.GroupBox();
            this.HeatMap = new LiveCharts.WinForms.CartesianChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lb_curve_expl = new System.Windows.Forms.Label();
            this.Curve = new LiveCharts.WinForms.CartesianChart();
            this.timer_general = new System.Windows.Forms.Timer(this.components);
            this.timer_label_updator = new System.Windows.Forms.Timer(this.components);
            this.timer_socialEvent = new System.Windows.Forms.Timer(this.components);
            this.lbl_recov_pat = new System.Windows.Forms.Label();
            this.lbl_dece_pat = new System.Windows.Forms.Label();
            this.gb_required.SuspendLayout();
            this.gb_optional.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gb_lockdownPolicy.SuspendLayout();
            this.gb_commStats.SuspendLayout();
            this.gb_hospitalStats.SuspendLayout();
            this.gb_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gb_hospHM.SuspendLayout();
            this.gb_commHM.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_required
            // 
            this.gb_required.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gb_required.Controls.Add(this.bt_custom_start);
            this.gb_required.Controls.Add(this.bt_start);
            this.gb_required.Controls.Add(this.lb_population);
            this.gb_required.Controls.Add(this.tb_population);
            this.gb_required.Controls.Add(this.tb_budget);
            this.gb_required.Controls.Add(this.lb_budget);
            this.gb_required.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_required.Location = new System.Drawing.Point(4, 4);
            this.gb_required.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_required.Name = "gb_required";
            this.gb_required.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_required.Size = new System.Drawing.Size(110, 147);
            this.gb_required.TabIndex = 0;
            this.gb_required.TabStop = false;
            this.gb_required.Text = "Required";
            // 
            // bt_custom_start
            // 
            this.bt_custom_start.Location = new System.Drawing.Point(5, 114);
            this.bt_custom_start.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_custom_start.Name = "bt_custom_start";
            this.bt_custom_start.Size = new System.Drawing.Size(98, 23);
            this.bt_custom_start.TabIndex = 7;
            this.bt_custom_start.Text = "Custom Start";
            this.bt_custom_start.UseVisualStyleBackColor = true;
            this.bt_custom_start.Click += new System.EventHandler(this.bt_custom_start_Click);
            // 
            // bt_start
            // 
            this.bt_start.BackColor = System.Drawing.SystemColors.Control;
            this.bt_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_start.Location = new System.Drawing.Point(5, 90);
            this.bt_start.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(98, 23);
            this.bt_start.TabIndex = 6;
            this.bt_start.Text = "Basic Start";
            this.bt_start.UseVisualStyleBackColor = false;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // lb_population
            // 
            this.lb_population.AutoSize = true;
            this.lb_population.Location = new System.Drawing.Point(5, 51);
            this.lb_population.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_population.Name = "lb_population";
            this.lb_population.Size = new System.Drawing.Size(67, 13);
            this.lb_population.TabIndex = 5;
            this.lb_population.Text = "Population";
            // 
            // tb_population
            // 
            this.tb_population.Location = new System.Drawing.Point(5, 64);
            this.tb_population.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_population.Name = "tb_population";
            this.tb_population.Size = new System.Drawing.Size(81, 20);
            this.tb_population.TabIndex = 4;
            // 
            // tb_budget
            // 
            this.tb_budget.Location = new System.Drawing.Point(4, 27);
            this.tb_budget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_budget.Name = "tb_budget";
            this.tb_budget.Size = new System.Drawing.Size(81, 20);
            this.tb_budget.TabIndex = 2;
            // 
            // lb_budget
            // 
            this.lb_budget.AutoSize = true;
            this.lb_budget.Location = new System.Drawing.Point(4, 15);
            this.lb_budget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_budget.Name = "lb_budget";
            this.lb_budget.Size = new System.Drawing.Size(47, 13);
            this.lb_budget.TabIndex = 3;
            this.lb_budget.Text = "Budget";
            // 
            // gb_optional
            // 
            this.gb_optional.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gb_optional.Controls.Add(this.listBox_culture);
            this.gb_optional.Controls.Add(this.lb_culture);
            this.gb_optional.Controls.Add(this.listBox_areaSize);
            this.gb_optional.Controls.Add(this.lb_density);
            this.gb_optional.Controls.Add(this.listBox_nursePercentage);
            this.gb_optional.Controls.Add(this.lb_propOfNurses);
            this.gb_optional.Controls.Add(this.listBox_doctorPercentage);
            this.gb_optional.Controls.Add(this.lb_propOfDoctors);
            this.gb_optional.Controls.Add(this.listBox_herdPercentage);
            this.gb_optional.Controls.Add(this.lb_herd_size_input);
            this.gb_optional.Controls.Add(this.bt_save);
            this.gb_optional.Controls.Add(this.bt_load);
            this.gb_optional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_optional.Location = new System.Drawing.Point(4, 157);
            this.gb_optional.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_optional.Name = "gb_optional";
            this.gb_optional.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gb_optional.Size = new System.Drawing.Size(110, 308);
            this.gb_optional.TabIndex = 1;
            this.gb_optional.TabStop = false;
            this.gb_optional.Text = "Optional";
            // 
            // listBox_culture
            // 
            this.listBox_culture.FormattingEnabled = true;
            this.listBox_culture.Location = new System.Drawing.Point(4, 271);
            this.listBox_culture.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_culture.Name = "listBox_culture";
            this.listBox_culture.Size = new System.Drawing.Size(87, 30);
            this.listBox_culture.TabIndex = 17;
            // 
            // lb_culture
            // 
            this.lb_culture.AutoSize = true;
            this.lb_culture.Location = new System.Drawing.Point(4, 256);
            this.lb_culture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_culture.Name = "lb_culture";
            this.lb_culture.Size = new System.Drawing.Size(79, 13);
            this.lb_culture.TabIndex = 16;
            this.lb_culture.Text = "Culture Type";
            // 
            // listBox_areaSize
            // 
            this.listBox_areaSize.FormattingEnabled = true;
            this.listBox_areaSize.Location = new System.Drawing.Point(4, 225);
            this.listBox_areaSize.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_areaSize.Name = "listBox_areaSize";
            this.listBox_areaSize.Size = new System.Drawing.Size(87, 30);
            this.listBox_areaSize.TabIndex = 15;
            // 
            // lb_density
            // 
            this.lb_density.AutoSize = true;
            this.lb_density.Location = new System.Drawing.Point(2, 209);
            this.lb_density.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_density.Name = "lb_density";
            this.lb_density.Size = new System.Drawing.Size(97, 13);
            this.lb_density.TabIndex = 14;
            this.lb_density.Text = "Density (p/km2)";
            // 
            // listBox_nursePercentage
            // 
            this.listBox_nursePercentage.FormattingEnabled = true;
            this.listBox_nursePercentage.Location = new System.Drawing.Point(4, 178);
            this.listBox_nursePercentage.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_nursePercentage.Name = "listBox_nursePercentage";
            this.listBox_nursePercentage.Size = new System.Drawing.Size(87, 30);
            this.listBox_nursePercentage.TabIndex = 13;
            // 
            // lb_propOfNurses
            // 
            this.lb_propOfNurses.AutoSize = true;
            this.lb_propOfNurses.Location = new System.Drawing.Point(2, 163);
            this.lb_propOfNurses.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_propOfNurses.Name = "lb_propOfNurses";
            this.lb_propOfNurses.Size = new System.Drawing.Size(67, 13);
            this.lb_propOfNurses.TabIndex = 12;
            this.lb_propOfNurses.Text = "Nurses (%)";
            // 
            // listBox_doctorPercentage
            // 
            this.listBox_doctorPercentage.FormattingEnabled = true;
            this.listBox_doctorPercentage.Location = new System.Drawing.Point(4, 131);
            this.listBox_doctorPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_doctorPercentage.Name = "listBox_doctorPercentage";
            this.listBox_doctorPercentage.Size = new System.Drawing.Size(87, 30);
            this.listBox_doctorPercentage.TabIndex = 11;
            // 
            // lb_propOfDoctors
            // 
            this.lb_propOfDoctors.AutoSize = true;
            this.lb_propOfDoctors.Location = new System.Drawing.Point(2, 116);
            this.lb_propOfDoctors.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_propOfDoctors.Name = "lb_propOfDoctors";
            this.lb_propOfDoctors.Size = new System.Drawing.Size(72, 13);
            this.lb_propOfDoctors.TabIndex = 10;
            this.lb_propOfDoctors.Text = "Doctors (%)";
            // 
            // listBox_herdPercentage
            // 
            this.listBox_herdPercentage.FormattingEnabled = true;
            this.listBox_herdPercentage.Location = new System.Drawing.Point(4, 85);
            this.listBox_herdPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_herdPercentage.Name = "listBox_herdPercentage";
            this.listBox_herdPercentage.Size = new System.Drawing.Size(87, 30);
            this.listBox_herdPercentage.TabIndex = 9;
            // 
            // lb_herd_size_input
            // 
            this.lb_herd_size_input.AutoSize = true;
            this.lb_herd_size_input.Location = new System.Drawing.Point(2, 69);
            this.lb_herd_size_input.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_herd_size_input.Name = "lb_herd_size_input";
            this.lb_herd_size_input.Size = new System.Drawing.Size(83, 13);
            this.lb_herd_size_input.TabIndex = 8;
            this.lb_herd_size_input.Text = "Herd Size (%)";
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(5, 43);
            this.bt_save.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(98, 23);
            this.bt_save.TabIndex = 1;
            this.bt_save.Text = "Save";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_load
            // 
            this.bt_load.Location = new System.Drawing.Point(5, 15);
            this.bt_load.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.bt_load.Name = "bt_load";
            this.bt_load.Size = new System.Drawing.Size(98, 23);
            this.bt_load.TabIndex = 0;
            this.bt_load.Text = "Load";
            this.bt_load.UseVisualStyleBackColor = true;
            this.bt_load.Click += new System.EventHandler(this.bt_load_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(118, 19);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 432);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gb_lockdownPolicy);
            this.tabPage1.Controls.Add(this.gb_commStats);
            this.tabPage1.Controls.Add(this.gb_hospitalStats);
            this.tabPage1.Controls.Add(this.gb_time);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(756, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Statistics";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gb_lockdownPolicy
            // 
            this.gb_lockdownPolicy.Controls.Add(this.rb_strictPolicy);
            this.gb_lockdownPolicy.Controls.Add(this.rb_lightPolicy);
            this.gb_lockdownPolicy.Controls.Add(this.rb_herdImu);
            this.gb_lockdownPolicy.Controls.Add(this.rb_noLockdown);
            this.gb_lockdownPolicy.Location = new System.Drawing.Point(350, 8);
            this.gb_lockdownPolicy.Margin = new System.Windows.Forms.Padding(2);
            this.gb_lockdownPolicy.Name = "gb_lockdownPolicy";
            this.gb_lockdownPolicy.Padding = new System.Windows.Forms.Padding(2);
            this.gb_lockdownPolicy.Size = new System.Drawing.Size(402, 53);
            this.gb_lockdownPolicy.TabIndex = 3;
            this.gb_lockdownPolicy.TabStop = false;
            this.gb_lockdownPolicy.Text = "Lockdown Policy";
            // 
            // rb_strictPolicy
            // 
            this.rb_strictPolicy.AutoSize = true;
            this.rb_strictPolicy.Location = new System.Drawing.Point(305, 23);
            this.rb_strictPolicy.Margin = new System.Windows.Forms.Padding(2);
            this.rb_strictPolicy.Name = "rb_strictPolicy";
            this.rb_strictPolicy.Size = new System.Drawing.Size(93, 17);
            this.rb_strictPolicy.TabIndex = 3;
            this.rb_strictPolicy.TabStop = true;
            this.rb_strictPolicy.Text = "Strict Policy";
            this.rb_strictPolicy.UseVisualStyleBackColor = true;
            this.rb_strictPolicy.CheckedChanged += new System.EventHandler(this.rb_strictPolicy_CheckedChanged);
            // 
            // rb_lightPolicy
            // 
            this.rb_lightPolicy.AutoSize = true;
            this.rb_lightPolicy.Location = new System.Drawing.Point(215, 23);
            this.rb_lightPolicy.Margin = new System.Windows.Forms.Padding(2);
            this.rb_lightPolicy.Name = "rb_lightPolicy";
            this.rb_lightPolicy.Size = new System.Drawing.Size(86, 17);
            this.rb_lightPolicy.TabIndex = 2;
            this.rb_lightPolicy.TabStop = true;
            this.rb_lightPolicy.Text = "Mild Policy";
            this.rb_lightPolicy.UseVisualStyleBackColor = true;
            this.rb_lightPolicy.CheckedChanged += new System.EventHandler(this.rb_lightPolicy_CheckedChanged);
            // 
            // rb_herdImu
            // 
            this.rb_herdImu.AutoSize = true;
            this.rb_herdImu.Location = new System.Drawing.Point(106, 23);
            this.rb_herdImu.Margin = new System.Windows.Forms.Padding(2);
            this.rb_herdImu.Name = "rb_herdImu";
            this.rb_herdImu.Size = new System.Drawing.Size(105, 17);
            this.rb_herdImu.TabIndex = 1;
            this.rb_herdImu.TabStop = true;
            this.rb_herdImu.Text = "Herd Immunity";
            this.rb_herdImu.UseVisualStyleBackColor = true;
            this.rb_herdImu.CheckedChanged += new System.EventHandler(this.rb_herdImu_CheckedChanged);
            // 
            // rb_noLockdown
            // 
            this.rb_noLockdown.AutoSize = true;
            this.rb_noLockdown.Location = new System.Drawing.Point(23, 23);
            this.rb_noLockdown.Margin = new System.Windows.Forms.Padding(2);
            this.rb_noLockdown.Name = "rb_noLockdown";
            this.rb_noLockdown.Size = new System.Drawing.Size(79, 17);
            this.rb_noLockdown.TabIndex = 0;
            this.rb_noLockdown.TabStop = true;
            this.rb_noLockdown.Text = "No Policy";
            this.rb_noLockdown.UseVisualStyleBackColor = true;
            this.rb_noLockdown.CheckedChanged += new System.EventHandler(this.rb_noLockdown_CheckedChanged);
            // 
            // gb_commStats
            // 
            this.gb_commStats.Controls.Add(this.lb_hm_nrOfSq);
            this.gb_commStats.Controls.Add(this.bl_comm_age_distr);
            this.gb_commStats.Controls.Add(this.lb_comm_gender);
            this.gb_commStats.Controls.Add(this.lb_comm_pop_status);
            this.gb_commStats.Location = new System.Drawing.Point(350, 76);
            this.gb_commStats.Margin = new System.Windows.Forms.Padding(2);
            this.gb_commStats.Name = "gb_commStats";
            this.gb_commStats.Padding = new System.Windows.Forms.Padding(2);
            this.gb_commStats.Size = new System.Drawing.Size(403, 323);
            this.gb_commStats.TabIndex = 2;
            this.gb_commStats.TabStop = false;
            this.gb_commStats.Text = "Community Statistics";
            // 
            // lb_hm_nrOfSq
            // 
            this.lb_hm_nrOfSq.AutoSize = true;
            this.lb_hm_nrOfSq.Location = new System.Drawing.Point(4, 55);
            this.lb_hm_nrOfSq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hm_nrOfSq.Name = "lb_hm_nrOfSq";
            this.lb_hm_nrOfSq.Size = new System.Drawing.Size(168, 13);
            this.lb_hm_nrOfSq.TabIndex = 3;
            this.lb_hm_nrOfSq.Text = "Number of Districts: pending";
            // 
            // bl_comm_age_distr
            // 
            this.bl_comm_age_distr.AutoSize = true;
            this.bl_comm_age_distr.Location = new System.Drawing.Point(4, 95);
            this.bl_comm_age_distr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bl_comm_age_distr.Name = "bl_comm_age_distr";
            this.bl_comm_age_distr.Size = new System.Drawing.Size(150, 13);
            this.bl_comm_age_distr.TabIndex = 2;
            this.bl_comm_age_distr.Text = "Age Distribution: pending";
            // 
            // lb_comm_gender
            // 
            this.lb_comm_gender.AutoSize = true;
            this.lb_comm_gender.Location = new System.Drawing.Point(4, 75);
            this.lb_comm_gender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_comm_gender.Name = "lb_comm_gender";
            this.lb_comm_gender.Size = new System.Drawing.Size(169, 13);
            this.lb_comm_gender.TabIndex = 1;
            this.lb_comm_gender.Text = "Gender Distribution: pending";
            // 
            // lb_comm_pop_status
            // 
            this.lb_comm_pop_status.AutoSize = true;
            this.lb_comm_pop_status.Location = new System.Drawing.Point(4, 35);
            this.lb_comm_pop_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_comm_pop_status.Name = "lb_comm_pop_status";
            this.lb_comm_pop_status.Size = new System.Drawing.Size(176, 13);
            this.lb_comm_pop_status.TabIndex = 0;
            this.lb_comm_pop_status.Text = "Number of Members: pending ";
            // 
            // gb_hospitalStats
            // 
            this.gb_hospitalStats.Controls.Add(this.lbl_dece_pat);
            this.gb_hospitalStats.Controls.Add(this.lbl_recov_pat);
            this.gb_hospitalStats.Controls.Add(this.lb_hosp_yCaseNr);
            this.gb_hospitalStats.Controls.Add(this.lb_host_nrPat);
            this.gb_hospitalStats.Controls.Add(this.lb_hosp_potNus);
            this.gb_hospitalStats.Controls.Add(this.lb_hosp_potDoc);
            this.gb_hospitalStats.Controls.Add(this.lb_remainingBudget);
            this.gb_hospitalStats.Controls.Add(this.lb_hosp_nrOfNurses);
            this.gb_hospitalStats.Controls.Add(this.lb_hosp_nrOfDocs);
            this.gb_hospitalStats.Location = new System.Drawing.Point(2, 76);
            this.gb_hospitalStats.Margin = new System.Windows.Forms.Padding(2);
            this.gb_hospitalStats.Name = "gb_hospitalStats";
            this.gb_hospitalStats.Padding = new System.Windows.Forms.Padding(2);
            this.gb_hospitalStats.Size = new System.Drawing.Size(343, 323);
            this.gb_hospitalStats.TabIndex = 1;
            this.gb_hospitalStats.TabStop = false;
            this.gb_hospitalStats.Text = "Hospital Statistics";
            // 
            // lb_hosp_yCaseNr
            // 
            this.lb_hosp_yCaseNr.AutoSize = true;
            this.lb_hosp_yCaseNr.Location = new System.Drawing.Point(177, 95);
            this.lb_hosp_yCaseNr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hosp_yCaseNr.Name = "lb_hosp_yCaseNr";
            this.lb_hosp_yCaseNr.Size = new System.Drawing.Size(163, 13);
            this.lb_hosp_yCaseNr.TabIndex = 7;
            this.lb_hosp_yCaseNr.Text = "Yesterday\'s Cases: pending";
            // 
            // lb_host_nrPat
            // 
            this.lb_host_nrPat.AutoSize = true;
            this.lb_host_nrPat.Location = new System.Drawing.Point(4, 95);
            this.lb_host_nrPat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_host_nrPat.Name = "lb_host_nrPat";
            this.lb_host_nrPat.Size = new System.Drawing.Size(168, 13);
            this.lb_host_nrPat.TabIndex = 6;
            this.lb_host_nrPat.Text = "Number of Patients: pending";
            // 
            // lb_hosp_potNus
            // 
            this.lb_hosp_potNus.AutoSize = true;
            this.lb_hosp_potNus.Location = new System.Drawing.Point(177, 75);
            this.lb_hosp_potNus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hosp_potNus.Name = "lb_hosp_potNus";
            this.lb_hosp_potNus.Size = new System.Drawing.Size(157, 13);
            this.lb_hosp_potNus.TabIndex = 5;
            this.lb_hosp_potNus.Text = "Potential Nurses: pending ";
            // 
            // lb_hosp_potDoc
            // 
            this.lb_hosp_potDoc.AutoSize = true;
            this.lb_hosp_potDoc.Location = new System.Drawing.Point(177, 55);
            this.lb_hosp_potDoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hosp_potDoc.Name = "lb_hosp_potDoc";
            this.lb_hosp_potDoc.Size = new System.Drawing.Size(162, 13);
            this.lb_hosp_potDoc.TabIndex = 4;
            this.lb_hosp_potDoc.Text = "Potential Doctors: pending ";
            // 
            // lb_remainingBudget
            // 
            this.lb_remainingBudget.AutoSize = true;
            this.lb_remainingBudget.Location = new System.Drawing.Point(4, 35);
            this.lb_remainingBudget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_remainingBudget.Name = "lb_remainingBudget";
            this.lb_remainingBudget.Size = new System.Drawing.Size(167, 13);
            this.lb_remainingBudget.TabIndex = 3;
            this.lb_remainingBudget.Text = "Remaining Budget: pending ";
            // 
            // lb_hosp_nrOfNurses
            // 
            this.lb_hosp_nrOfNurses.AutoSize = true;
            this.lb_hosp_nrOfNurses.Location = new System.Drawing.Point(4, 75);
            this.lb_hosp_nrOfNurses.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hosp_nrOfNurses.Name = "lb_hosp_nrOfNurses";
            this.lb_hosp_nrOfNurses.Size = new System.Drawing.Size(161, 13);
            this.lb_hosp_nrOfNurses.TabIndex = 3;
            this.lb_hosp_nrOfNurses.Text = "Number of Nurses: pending";
            // 
            // lb_hosp_nrOfDocs
            // 
            this.lb_hosp_nrOfDocs.AutoSize = true;
            this.lb_hosp_nrOfDocs.Location = new System.Drawing.Point(4, 55);
            this.lb_hosp_nrOfDocs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_hosp_nrOfDocs.Name = "lb_hosp_nrOfDocs";
            this.lb_hosp_nrOfDocs.Size = new System.Drawing.Size(170, 13);
            this.lb_hosp_nrOfDocs.TabIndex = 3;
            this.lb_hosp_nrOfDocs.Text = "Number of Doctors: pending ";
            // 
            // gb_time
            // 
            this.gb_time.Controls.Add(this.label_1);
            this.gb_time.Controls.Add(this.label_60);
            this.gb_time.Controls.Add(this.lb_app_lb);
            this.gb_time.Controls.Add(this.lb_sim_lb);
            this.gb_time.Controls.Add(this.lb_format_lb);
            this.gb_time.Controls.Add(this.lb_app_time);
            this.gb_time.Controls.Add(this.lb_timeExlp);
            this.gb_time.Controls.Add(this.lb_sim_time);
            this.gb_time.Controls.Add(this.trackBar_time);
            this.gb_time.Location = new System.Drawing.Point(5, 6);
            this.gb_time.Margin = new System.Windows.Forms.Padding(2);
            this.gb_time.Name = "gb_time";
            this.gb_time.Padding = new System.Windows.Forms.Padding(2);
            this.gb_time.Size = new System.Drawing.Size(341, 70);
            this.gb_time.TabIndex = 0;
            this.gb_time.TabStop = false;
            this.gb_time.Text = "Time";
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_1.Location = new System.Drawing.Point(210, 49);
            this.label_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(14, 13);
            this.label_1.TabIndex = 8;
            this.label_1.Text = "1";
            // 
            // label_60
            // 
            this.label_60.AutoSize = true;
            this.label_60.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_60.Location = new System.Drawing.Point(310, 49);
            this.label_60.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_60.Name = "label_60";
            this.label_60.Size = new System.Drawing.Size(21, 13);
            this.label_60.TabIndex = 7;
            this.label_60.Text = "60";
            // 
            // lb_app_lb
            // 
            this.lb_app_lb.AutoSize = true;
            this.lb_app_lb.Location = new System.Drawing.Point(4, 50);
            this.lb_app_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_app_lb.Name = "lb_app_lb";
            this.lb_app_lb.Size = new System.Drawing.Size(29, 13);
            this.lb_app_lb.TabIndex = 6;
            this.lb_app_lb.Text = "App";
            // 
            // lb_sim_lb
            // 
            this.lb_sim_lb.AutoSize = true;
            this.lb_sim_lb.Location = new System.Drawing.Point(4, 35);
            this.lb_sim_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sim_lb.Name = "lb_sim_lb";
            this.lb_sim_lb.Size = new System.Drawing.Size(27, 13);
            this.lb_sim_lb.TabIndex = 5;
            this.lb_sim_lb.Text = "Sim";
            // 
            // lb_format_lb
            // 
            this.lb_format_lb.AutoSize = true;
            this.lb_format_lb.Location = new System.Drawing.Point(4, 18);
            this.lb_format_lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_format_lb.Name = "lb_format_lb";
            this.lb_format_lb.Size = new System.Drawing.Size(45, 13);
            this.lb_format_lb.TabIndex = 4;
            this.lb_format_lb.Text = "Format";
            // 
            // lb_app_time
            // 
            this.lb_app_time.AutoSize = true;
            this.lb_app_time.Location = new System.Drawing.Point(52, 50);
            this.lb_app_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_app_time.Name = "lb_app_time";
            this.lb_app_time.Size = new System.Drawing.Size(99, 13);
            this.lb_app_time.TabIndex = 3;
            this.lb_app_time.Text = "[DD:HH:MM:SS]";
            // 
            // lb_timeExlp
            // 
            this.lb_timeExlp.AutoSize = true;
            this.lb_timeExlp.Location = new System.Drawing.Point(52, 18);
            this.lb_timeExlp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_timeExlp.Name = "lb_timeExlp";
            this.lb_timeExlp.Size = new System.Drawing.Size(99, 13);
            this.lb_timeExlp.TabIndex = 2;
            this.lb_timeExlp.Text = "[DD:HH:MM:SS]";
            // 
            // lb_sim_time
            // 
            this.lb_sim_time.AutoSize = true;
            this.lb_sim_time.Location = new System.Drawing.Point(52, 35);
            this.lb_sim_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sim_time.Name = "lb_sim_time";
            this.lb_sim_time.Size = new System.Drawing.Size(99, 13);
            this.lb_sim_time.TabIndex = 0;
            this.lb_sim_time.Text = "[DD:HH:MM:SS]";
            // 
            // trackBar_time
            // 
            this.trackBar_time.Location = new System.Drawing.Point(203, 17);
            this.trackBar_time.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar_time.Maximum = 60;
            this.trackBar_time.Minimum = 1;
            this.trackBar_time.Name = "trackBar_time";
            this.trackBar_time.Size = new System.Drawing.Size(128, 45);
            this.trackBar_time.TabIndex = 1;
            this.trackBar_time.TickFrequency = 10;
            this.trackBar_time.Value = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gb_hospHM);
            this.tabPage2.Controls.Add(this.gb_commHM);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(756, 406);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Heatmap";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gb_hospHM
            // 
            this.gb_hospHM.Controls.Add(this.HeatMap2);
            this.gb_hospHM.Location = new System.Drawing.Point(388, 4);
            this.gb_hospHM.Name = "gb_hospHM";
            this.gb_hospHM.Size = new System.Drawing.Size(360, 388);
            this.gb_hospHM.TabIndex = 5;
            this.gb_hospHM.TabStop = false;
            this.gb_hospHM.Text = "Hospital (Patients/District)";
            // 
            // HeatMap2
            // 
            this.HeatMap2.Location = new System.Drawing.Point(5, 31);
            this.HeatMap2.Margin = new System.Windows.Forms.Padding(2);
            this.HeatMap2.Name = "HeatMap2";
            this.HeatMap2.Size = new System.Drawing.Size(350, 352);
            this.HeatMap2.TabIndex = 1;
            this.HeatMap2.Text = "cartesianChart1";
            // 
            // gb_commHM
            // 
            this.gb_commHM.Controls.Add(this.HeatMap);
            this.gb_commHM.Location = new System.Drawing.Point(5, 6);
            this.gb_commHM.Name = "gb_commHM";
            this.gb_commHM.Size = new System.Drawing.Size(376, 386);
            this.gb_commHM.TabIndex = 4;
            this.gb_commHM.TabStop = false;
            this.gb_commHM.Text = "Community (Members/District)";
            // 
            // HeatMap
            // 
            this.HeatMap.Location = new System.Drawing.Point(5, 29);
            this.HeatMap.Margin = new System.Windows.Forms.Padding(2);
            this.HeatMap.Name = "HeatMap";
            this.HeatMap.Size = new System.Drawing.Size(366, 352);
            this.HeatMap.TabIndex = 0;
            this.HeatMap.Text = "cartesianChart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lb_curve_expl);
            this.tabPage3.Controls.Add(this.Curve);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(756, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Curve";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lb_curve_expl
            // 
            this.lb_curve_expl.AutoSize = true;
            this.lb_curve_expl.Location = new System.Drawing.Point(236, 2);
            this.lb_curve_expl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_curve_expl.Name = "lb_curve_expl";
            this.lb_curve_expl.Size = new System.Drawing.Size(254, 13);
            this.lb_curve_expl.TabIndex = 1;
            this.lb_curve_expl.Text = "Curve Representing Virus Infections by Day";
            // 
            // Curve
            // 
            this.Curve.Location = new System.Drawing.Point(4, 28);
            this.Curve.Margin = new System.Windows.Forms.Padding(2);
            this.Curve.Name = "Curve";
            this.Curve.Size = new System.Drawing.Size(748, 347);
            this.Curve.TabIndex = 0;
            this.Curve.Text = "cartesianChart1";
            // 
            // timer_general
            // 
            this.timer_general.Interval = 1000;
            this.timer_general.Tick += new System.EventHandler(this.timer_general_Tick);
            // 
            // timer_label_updator
            // 
            this.timer_label_updator.Interval = 10000;
            this.timer_label_updator.Tick += new System.EventHandler(this.timer_label_updator_Tick);
            // 
            // timer_socialEvent
            // 
            this.timer_socialEvent.Interval = 5000;
            this.timer_socialEvent.Tick += new System.EventHandler(this.timer_socialEvent_Tick);
            // 
            // lbl_recov_pat
            // 
            this.lbl_recov_pat.AutoSize = true;
            this.lbl_recov_pat.Location = new System.Drawing.Point(4, 115);
            this.lbl_recov_pat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_recov_pat.Name = "lbl_recov_pat";
            this.lbl_recov_pat.Size = new System.Drawing.Size(172, 13);
            this.lbl_recov_pat.TabIndex = 8;
            this.lbl_recov_pat.Text = "Recovered Patients: pending";
            // 
            // lbl_dece_pat
            // 
            this.lbl_dece_pat.AutoSize = true;
            this.lbl_dece_pat.Location = new System.Drawing.Point(4, 135);
            this.lbl_dece_pat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_dece_pat.Name = "lbl_dece_pat";
            this.lbl_dece_pat.Size = new System.Drawing.Size(167, 13);
            this.lbl_dece_pat.TabIndex = 9;
            this.lbl_dece_pat.Text = "Deceased Patients: pending";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(886, 468);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gb_optional);
            this.Controls.Add(this.gb_required);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Covid-19 Simulator";
            this.gb_required.ResumeLayout(false);
            this.gb_required.PerformLayout();
            this.gb_optional.ResumeLayout(false);
            this.gb_optional.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gb_lockdownPolicy.ResumeLayout(false);
            this.gb_lockdownPolicy.PerformLayout();
            this.gb_commStats.ResumeLayout(false);
            this.gb_commStats.PerformLayout();
            this.gb_hospitalStats.ResumeLayout(false);
            this.gb_hospitalStats.PerformLayout();
            this.gb_time.ResumeLayout(false);
            this.gb_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gb_hospHM.ResumeLayout(false);
            this.gb_commHM.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_required;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Label lb_population;
        private System.Windows.Forms.TextBox tb_population;
        private System.Windows.Forms.TextBox tb_budget;
        private System.Windows.Forms.Label lb_budget;
        private System.Windows.Forms.GroupBox gb_optional;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_load;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timer_general;
        private System.Windows.Forms.GroupBox gb_time;
        private System.Windows.Forms.TrackBar trackBar_time;
        private System.Windows.Forms.Label lb_sim_time;
        private System.Windows.Forms.Label lb_timeExlp;
        private System.Windows.Forms.GroupBox gb_hospitalStats;
        private System.Windows.Forms.GroupBox gb_commStats;
        private System.Windows.Forms.Label lb_app_lb;
        private System.Windows.Forms.Label lb_sim_lb;
        private System.Windows.Forms.Label lb_format_lb;
        private System.Windows.Forms.Label lb_app_time;
        private System.Windows.Forms.ListBox listBox_herdPercentage;
        private System.Windows.Forms.Label lb_herd_size_input;
        private System.Windows.Forms.ListBox listBox_nursePercentage;
        private System.Windows.Forms.Label lb_propOfNurses;
        private System.Windows.Forms.ListBox listBox_doctorPercentage;
        private System.Windows.Forms.Label lb_propOfDoctors;
        private System.Windows.Forms.ListBox listBox_areaSize;
        private System.Windows.Forms.Label lb_density;
        private System.Windows.Forms.ListBox listBox_culture;
        private System.Windows.Forms.Label lb_culture;
        private System.Windows.Forms.GroupBox gb_lockdownPolicy;
        private System.Windows.Forms.RadioButton rb_lightPolicy;
        private System.Windows.Forms.RadioButton rb_herdImu;
        private System.Windows.Forms.RadioButton rb_noLockdown;
        private System.Windows.Forms.RadioButton rb_strictPolicy;
        private System.Windows.Forms.Label lb_comm_pop_status;
        private System.Windows.Forms.Label lb_comm_gender;
        private System.Windows.Forms.Timer timer_label_updator;
        private System.Windows.Forms.Label bl_comm_age_distr;
        private System.Windows.Forms.Label lb_remainingBudget;
        private System.Windows.Forms.Label lb_hosp_nrOfNurses;
        private System.Windows.Forms.Label lb_hosp_nrOfDocs;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label_60;
        private System.Windows.Forms.Label lb_hosp_potNus;
        private System.Windows.Forms.Label lb_hosp_potDoc;
        private LiveCharts.WinForms.CartesianChart HeatMap;
        private System.Windows.Forms.Label lb_hm_nrOfSq;
        private System.Windows.Forms.Timer timer_socialEvent;
        private System.Windows.Forms.Label lb_host_nrPat;
        private LiveCharts.WinForms.CartesianChart HeatMap2;
        private System.Windows.Forms.Label lb_hosp_yCaseNr;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lb_curve_expl;
        private LiveCharts.WinForms.CartesianChart Curve;
        private System.Windows.Forms.GroupBox gb_commHM;
        private System.Windows.Forms.GroupBox gb_hospHM;
        private System.Windows.Forms.Button bt_custom_start;
        private System.Windows.Forms.Label lbl_dece_pat;
        private System.Windows.Forms.Label lbl_recov_pat;
    }
}

