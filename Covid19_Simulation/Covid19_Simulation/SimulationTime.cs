using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    [Serializable]
    public class SimulationTime
    {
        private int minutes;
        private int hours;
        private int days;
        private List<PolicyTracker> pt;

        public SimulationTime()
        {
            pt = new List<PolicyTracker>();
        }

        public void incrementSimulationTime(int incrementation)
        {
            this.minutes += incrementation;
            if (minutes >= 60) { hours++; minutes -= 60; }
            if (hours == 24) { days++; hours = 0; }
        }

        public (int day, int hour, int minute) getSimulationTime()
        {
            return (days, hours, minutes);
        }

        public int getHours()
        {
            return this.hours;
        }

        public int getMinutes()
        {
            return this.minutes;
        }

        public string getSimulationTimeString()
        {
            String minutesStr = (minutes < 10) ? $":0{minutes}" : $":{minutes}";
            String hoursStr = (hours < 10) ? $"0{hours}" : $"{hours}";
            return $"{days}:{hoursStr}{minutesStr}:00";
        }

        public int getDays()
        {
            return this.days;
        }

        public void markPolicy(Stopwatch sw, int temp)
        {
            PolicyTracker tpt = new PolicyTracker(sw.Elapsed.Hours, sw.Elapsed.Minutes, temp, getSimulationTimeString());
            pt.Add(tpt);
        }

        public int getNumberDecision()
        {
            return pt.Count;
        }

        public string getDecision(int nr)
        {
            if (pt[nr].getSelection() == 1)
            {
                return "No policy";
            }
            else if (pt[nr].getSelection() == 2)
            {
                return "Herd Imu";
            }
            else if (pt[nr].getSelection() == 3)
            {
                return "Mild policy";
            }
            else
            {
                return "Strict policy";
            }
        }

        public string getPolicyTimestamp(int nr)
        {
            return pt[nr].getSimTemp();
        }

        public string getStr(int nr)
        {
            return pt[nr].getStr();
        }
    }

    public class PolicyTracker
    {
        private int hour;
        private int minute;
        private int selection;
        private string simtemp;

        public PolicyTracker(int hour, int minute, int selection, string simtemp)
        {
            this.hour = hour;
            this.minute = minute;
            this.selection = selection;
            this.simtemp = simtemp;
        }

        public string getStr()
        {
            String minuteStr = (minute < 10) ? $":0{minute}" : $":{minute}";
            String hourStr = (hour < 10) ? $"0{hour}" : $"{hour}";
            return $"{hourStr}{minuteStr} [HH:MM]";
        }

        public int getSelection()
        {
            return this.selection;
        }

        public string getSimTemp()
        {
            return simtemp;
        }
    }
}
