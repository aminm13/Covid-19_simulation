using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    [Serializable]
    public class Hospital
    {
        private int budget;
        private int population;
        private int initialBudget;
        private int initialPopulation;
        private int districtCount;
        private int doctorSalary = 3000;
        private int nurseSalary = 1500;
        private int deceased = 0;
        private int recovered = 0;
        private double doctorPercentage;
        private double nursePercentage;
        private double potentialDoctors;
        private double potentialNurses;
        protected ILockdownPolicy instancePolicy;
        private Random rnd;
        private List<Doctor> doctors;
        private List<Nurse> nurses;
        private List<Patient> patients;
        private List<HM_object> hm;
        private List<double> history;

        public Hospital(int population, int budget, ILockdownPolicy initialPolicy)
        {
            this.rnd = new Random();
            this.population = population;
            this.budget = budget;
            this.instancePolicy = initialPolicy;
            this.doctors = new List<Doctor>();
            this.nurses = new List<Nurse>();
            this.patients = new List<Patient>();
            this.history = new List<double>();
            initialBudget = budget;
            initialPopulation = population;
        }

        public bool initiateHospitalList(int districtCount, Qualification q)
        {
            this.districtCount = districtCount;
            potentialDoctors = ((double)population / 100) * doctorPercentage;
            potentialNurses = ((double)population / 100) * nursePercentage;
            if (hireDoctor(q) && hireNurse())
                return true;
            else return false;
        }

        public bool hireNurse()
        {
            if ((budget - nurseSalary > 0) && (nurses.Count < (int)potentialNurses))
            {
                Nurse nus = new Nurse(Faker.Name.FullName(),
                                      rnd.Next(1, 3),
                                      rnd.Next(25, 80),
                                      rnd.Next(1, (districtCount + 1)));
                nurses.Add(nus);
                budget -= nurseSalary;
                return true;
            }
            else return false;
        }

        public bool hireDoctor(Qualification q)
        {
            if ((budget - doctorSalary > 0) && (doctors.Count < (int)potentialDoctors))
            {
                Doctor doc = new Doctor(Faker.Name.FullName(),
                                        rnd.Next(1, 3),
                                        rnd.Next(30, 80),
                                        rnd.Next(1, (districtCount + 1)),
                                        q);
                doctors.Add(doc);
                budget -= doctorSalary;
                return true;
            }
            else return false;
        }

        public List<Member> socialEvent(List<Member> list, String culture, int density, int districts)
        {
            return this.instancePolicy.socialEvent(list, culture, density, districts, this.patients.Count());
        }

        public void newPolicy(ILockdownPolicy policy)
        {
            this.instancePolicy = policy;
        }

        public int getPatientCount()
        {
            return this.patients.Count();
        }

        public void updateRecords(List<Member> list, int admissionDay)
        {
            double count = 0;
            foreach (Member m in list)
            {
                if (m.getInfectedStatus() == true && m.getHospitalizedStatus() == false)
                {
                    m.setHospitalizedStatus(true);
                    Patient p = new Patient(m.getName(), m.getGender(), m.getAge(), m.getAddress(), rnd.Next(1,5));
                    p.setAddmissionDay(admissionDay);
                    patients.Add(p);
                    count++;
                }
            }
            history.Add(count);

            foreach (Patient p in patients)
            {
                if (p.getPositive())
                {
                    if ((p.getAge() < 20) && ((admissionDay - p.getAddmissionDay()) >= 3))
                    {
                        p.setPositive(false);
                        recovered++;
                    }
                    else if ((p.getAge() > 20 && p.getAge() < 40) && ((admissionDay - p.getAddmissionDay()) >= 5))
                    {
                        int conditional = rnd.Next(1, 11);
                        if (conditional == 10)
                        {
                            p.setPositive(false);
                            deceased++;
                        }
                        else
                        {
                            p.setPositive(false);
                            recovered++;
                        }
                    }
                    else if (p.getAge() > 40 && ((admissionDay - p.getAddmissionDay()) >= 7))
                    {
                        int conditional = rnd.Next(1, 3);
                        if (conditional % 2 == 0)
                        {
                            p.setPositive(false);
                            deceased++;
                        }
                        else
                        {
                            p.setPositive(false);
                            recovered++;
                        }
                    }
                }
            }
        }
       
        public bool checkForMoreStaff()
        {
            if (budget > 0)
            {
                if ((doctors.Count * 10) < patients.Count)
                {
                    Qualification q = Qualification.CriticalCare;
                    if (!hireDoctor(q))
                        budget = 0;
                }
                if (!((doctors.Count * 2) < nurses.Count))
                {
                    if (!hireNurse())
                        budget = 0;
                }
                return true;
            }
            return false;
        }

        public void setDoctorPercentage(double percentage)
        {
            this.doctorPercentage = percentage;
        }

        public double getDoctorPercentage()
        {
            return this.doctorPercentage;
        }

        public void setNursePercentage(double percentage)
        {
            this.nursePercentage = percentage;
        }

        public int getNrOfDocs()
        {
            return doctors.Count();
        }

        public int getNrOfNurses()
        {
            return nurses.Count();
        }

        public int getBudget()
        {
            return this.budget;
        }
        
        public int getPopulation()
        {
            return this.population;
        }
       
        public int getInitialBudget()
        {
            return this.initialBudget;
        }
        
        public int getInitialPopulation()
        {
            return this.initialPopulation;
        }
       
        public int getPotentialDoctors()
        {
            return (int)potentialDoctors;
        }

        public int getPotentialNurses()
        {
            return (int)potentialNurses;
        }
        
        public double getNursePercentage()
        {
            return nursePercentage;
        }

        public List<HM_object> reportHMStatus()
        {
            hm = new List<HM_object>();

            int counter = 0;
            for (int i = 1; (i * i) - districtCount <= 0; i++)
            {
                counter = i;
            }

            int weight = 0;
            int nrCopy = districtCount;

            for (int x = 0; x < counter; x++)
            {
                for (int y = 0; y < counter; y++)
                {
                    foreach (Patient p in patients)
                    {
                        if (p.getRecovered() == false && p.getAddress() == nrCopy)
                        {
                            weight++;
                        }
                    }
                    HM_object sponge = new HM_object(x, y, weight);
                    hm.Add(sponge);
                    nrCopy -= 1;
                    weight = 0;
                }
            }

            //square matrix overflow
            int remaining = districtCount - (counter * counter);
            if (remaining > 0)
            {
                int topRow = counter;
                int leftColumn = counter;
                int lastInQueue = (int)hm.Last().getY() + 1;
                int lastInQueue2 = (int)hm.Last().getX() + 1;

                for (int z = 0; z < remaining; z++)
                {
                    foreach (Patient p in patients)
                    {
                        if (p.getRecovered() == false && p.getAddress() == nrCopy)
                        {
                            weight++;
                        }
                    }
                    if (topRow != 0)
                    {
                        HM_object sponge = new HM_object(counter - topRow, lastInQueue, weight);
                        hm.Add(sponge);
                        topRow -= 1;
                        nrCopy -= 1;
                        weight = 0;
                    }
                    else
                    {
                        HM_object sponge = new HM_object(lastInQueue2, counter - leftColumn, weight);
                        hm.Add(sponge);
                        leftColumn -= 1;
                        nrCopy -= 1;
                        weight = 0;
                    }
                }
            }
            return hm;
        }

        public List<double> getHistory()
        {
            return this.history;
        }

        public int getDeceased()
        {
            return this.deceased;
        }

        public int getRecovered()
        {
            return this.recovered;
        }
    }
}
