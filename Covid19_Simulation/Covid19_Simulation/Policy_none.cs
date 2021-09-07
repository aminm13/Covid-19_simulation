using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    [Serializable]
    public class Policy_none : ILockdownPolicy
    {
        private Random rnd = new Random();
        
        //r0
        private int macroForCloseCulture = 5;
        private int macroForMedianCulture = 3;
        private int macroForRemoteCulture = 1;
        private int macroForHighDensity = 5;
        private int macroForMediumDensity = 3;
        private int macroForLowDensity = 1;
        private int solitaryLifestyleAssumption = 5; //2-50%, 5-25% -- 1/4 that person will not transmit at all
        private int pureChance = 2; //2-50% -- 1/2 that particular transmission is not contracted

        private int inputEffect(String culture, int density)
        {
            if (culture == "Close")
            {
                if (density < 350)
                    return macroForCloseCulture + macroForLowDensity;
                else if (density > 650)
                    return macroForCloseCulture + macroForHighDensity;
                else
                    return macroForCloseCulture + macroForMediumDensity;
            }
            else if (culture == "Median")
            {
                if (density < 350)
                    return macroForMedianCulture + macroForLowDensity;
                else if (density > 650)
                    return macroForMedianCulture + macroForHighDensity;
                else
                    return macroForMedianCulture + macroForMediumDensity;
            }
            else
            {
                if (density < 350)
                    return macroForRemoteCulture + macroForLowDensity;
                else if (density > 650)
                    return macroForRemoteCulture + macroForHighDensity;
                else
                    return macroForRemoteCulture + macroForMediumDensity;
            }
        }

        // Lockdown policy 'none' does not account for reduced transmission between districts, 
        // and new cases are added randomly everywhere in the location.
        public List<Member> socialEvent(List<Member> members, String culture, int density, int districts, int nrPatients)
        {
            List<int> infectedAfterSocialEvent = new List<int>();
            int socialEventCircumstance = inputEffect(culture, density);
            if (nrPatients == 0)
            {
                for (int i = 0; i < socialEventCircumstance; i++)
                {
                    int random_recipient = rnd.Next(0, members.Count);
                    if (members[random_recipient].getInfectedStatus() == false)
                        members[random_recipient].setInfectedStatus(true);
                }
            }
            else
            {
                foreach (Member m in members)
                {
                    if (!m.getTransmitedStatus() && m.getInfectedStatus())
                    {
                        int isolation = rnd.Next(0, solitaryLifestyleAssumption);
                        if (isolation != 0)
                        {
                            for (int i = 0; i < socialEventCircumstance; i++)
                            {
                                int possibility = rnd.Next(0, pureChance);
                                if (possibility == 1)
                                {
                                    int random_recipient = rnd.Next(0, members.Count());
                                    if (members[random_recipient].getInfectedStatus() == false)
                                        infectedAfterSocialEvent.Add(random_recipient);
                                }
                            }
                        }
                        m.setTransmitedStatus(true);
                    }
                }
            }
            // to avoid foreach adjustment fallacy
            foreach (int i in infectedAfterSocialEvent)
            {
                members[i].setInfectedStatus(true);
            }
            return members;
        }
    }
}
