using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    [Serializable]
    public class Community
    {
        Random rnd;
        private int population;
        private int herdSufficiency = 60;
        private int areaDensity = 500;
        private double numberOfSquares;
        private String cultureType = "Median";
        private List<Member> members;
        private List<HM_object> hm;
        private List<int> custom;

        public Community(int population)
        {
            this.rnd = new Random();
            this.population = population;
            this.members = new List<Member>();
        }

        public Community(int population, List<int> custom)
        {
            this.rnd = new Random();
            this.population = population;
            this.members = new List<Member>();
            this.custom = custom;
        }
        public int getPopulation()
        {
            return this.population;
        }
        public (double f, double m) getGenderPercentages()
        {
            int match = 0;
            foreach(Member m in members)
            {
                if (m.getGender() == 1)
                    match+=1;
            }
            double f = ((double)match / population) * 100;
            return (f, 100 - f);
        }

        public (double y, double a, double o) getAgePercentages()
        {
            int match_y = 0;
            int match_o = 0;
            foreach (Member m in members)
            {
                int temp = m.getAge();
                if (temp <= 20)
                    match_y += 1;
                else if (temp >= 60)
                    match_o += 1;
            }
            double y = ((double)match_y / population) * 100;
            double o = ((double)match_o / population) * 100;
            return (y, (100 - y - o), o);
        }

        public double calculateBlockCount()
        {
            if (population / areaDensity < 1)
                return 1;
            else
                return population/areaDensity;
        }

        public List<HM_object> reportHMStatus()
        {
            hm = new List<HM_object>();

            int counter = 0;
            for (int i = 1; (i*i)-(int)numberOfSquares <= 0; i++)
            {
                counter = i;
            }

            int weight = 0;
            int nrCopy = (int)numberOfSquares;

            for (int x = 0; x < counter; x++ )
            {
                for (int y = 0; y < counter; y++)
                {
                    foreach (Member m in members)
                    {
                        if (m.getAddress() == nrCopy)
                        {
                            weight++;
                        }
                    }
                    HM_object sponge = new HM_object(x, y, weight);
                    hm.Add(sponge);
                    nrCopy-= 1;
                    weight = 0;
                }
            }

            //square matrix overflow
            int remaining = (int)numberOfSquares - (counter * counter);
            if (remaining > 0)
            {
                int topRow = counter;
                int leftColumn = counter;
                int lastInQueue = (int)hm.Last().getY() + 1;
                int lastInQueue2 = (int)hm.Last().getX() + 1;

                for (int z = 0; z < remaining; z++)
                {
                    foreach (Member m in members)
                    {
                        if (m.getAddress() == nrCopy)
                        {
                            weight++;
                        }
                    }
                    if (topRow != 0)
                    {
                        HM_object sponge = new HM_object(counter - topRow, lastInQueue ,weight);
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

        public int getDistrictCount()
        {
            return (int)numberOfSquares;
        }

        public void populateMemberList()
        {
            members.Clear();

            numberOfSquares = calculateBlockCount();
            for (int i = 0; i < population; i++)
            {
                Member mem = new Member(Faker.Name.FullName(),
                                        rnd.Next(1, 3),
                                        rnd.Next(1, 100),
                                        rnd.Next(1, (int)numberOfSquares + 1));
                members.Add(mem);
            }
        }

        public void populateMemberListCustom()
        {
            members.Clear();

            numberOfSquares = custom.Count;
            for (int i = 0; i < custom.Count; i++)
            {
                for (int x = 0; x < custom[i]; x++)
                {
                    Member mem = new Member(Faker.Name.FullName(),
                                        rnd.Next(1, 3),
                                        rnd.Next(1, 100),i+1);
                    members.Add(mem);
                }
            }
        }

        public void setHerdSufficiency(int percentage)
        {
            this.herdSufficiency = percentage;
        }

        public void setAreaDensity(int peoplePerSquareKilometer)
        {
            this.areaDensity = peoplePerSquareKilometer;
        }

        public void setCultureType(String type)
        {
            this.cultureType = type;
        }

        public int getMemberListSize()
        {
            return this.members.Count();
        }

        public int getNumberOfSquares()
        {
            return (int)numberOfSquares;
        }

        public int getTransmitedNr()
        {
            int count = 0;
            foreach (Member m in members)
            {
                if (m.getTransmitedStatus())
                    count++;
            }
            return count;
        }

        public String getMemberDescription(int index)
        {
            return members[index].getMemberDescription();
        }

        public int getHerdSufficiency()
        {
            return herdSufficiency;
        }

        public int getAreaDensity()
        {
            return areaDensity;
        }

        public String getCultureType()
        {
            return cultureType;
        }
        
        public (List<Member> list, String culture, int density, int districts) getEventCircumstances()
        {
            return (this.members, this.cultureType, this.areaDensity, (int)this.numberOfSquares);
        }
    }
}
