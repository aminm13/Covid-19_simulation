using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    // base
    [Serializable]
    public class Person
    {
        private String name;
        private int gender; //1-F, 2-M
        private int age;

        public Person(String name, int gender, int age)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
        }

        public String getName() { return this.name; }
        public int getGender() { return this.gender; }
        public int getAge() { return this.age; }
    }

    // member of community
    [Serializable]
    public class Member : Person
    {
        private int address;
        private bool infected = false;
        private bool hospitalized = false;
        //private bool immune = false;
        private bool transmited = false;

        public Member(String name, int gender, int age, int address) : base (name, gender, age)
        {
            this.address = address;
        }

        public int getAddress()
        {
            return this.address;
        }

        public bool getTransmitedStatus()
        {
            return this.transmited;
        }

        public void setTransmitedStatus(bool value)
        {
            this.transmited = value;
        }

        public bool getHospitalizedStatus()
        {
            return this.hospitalized;
        }

        public void setHospitalizedStatus(bool value)
        {
            this.hospitalized = value;
        }

        public bool getInfectedStatus()
        {
            return this.infected;
        }

        public void setInfectedStatus(bool value)
        {
            this.infected = value;
        }

        public String getMemberDescription()
        {
            String gender = (this.getGender() == 1) ? "Female" : "Male";
            return $"{this.getName()}, {gender}, {this.getAge()}";
        }
    }

    // patient of hospital
    [Serializable]
    public class Patient : Member
    {
        private int bloodType;
        private int addmitedOnDay;
        private bool recovered = false;
        private bool positive = true;

        public Patient(String name, int gender, int age, int address, int bloodType) : base (name, gender, age, address)
        {
            this.bloodType = bloodType;
        }

        public void setPositive(bool value)
        {
            this.positive = value;
        }

        public bool getPositive()
        {
            return this.positive;
        }

        public bool getRecovered()
        {
            return this.recovered;
        }

        public void setAddmissionDay(int day)
        {
            this.addmitedOnDay = day;
        }

        public int getAddmissionDay()
        {
            return this.addmitedOnDay;
        }
    }

    public enum Qualification
    {
        Allergist,
        Anesthesiologist,
        Cardiologist,
        CriticalCare,
        Dermatologist,
        Endocrinologist,
        Gastroenterologist,
        Hematologist,
        InfectiousDisease,
        Neurologist,
        Oncologist,
        Pediatrician,
        Physiatrist,
        Psychiatrist
    }
    [Serializable]
    public class Doctor : Member
    {
        private Qualification qualification;
        //private bool equiped = false; 

        public Doctor(String name, int gender, int age, int address, Qualification qualification) : base (name, gender, age, address)
        {
            this.qualification = qualification;
        }
    }
    [Serializable]
    public class Nurse : Member 
    {
        //private bool equiped = false;

        public Nurse(String name, int gender, int age, int address) : base(name, gender, age, address)
        {
            
        }
    }
    [Serializable]
    public class HM_object
    {  
        private int x { get; set; }
        private int y { get; set; }
        private int weight { get; set; }

        public HM_object(int x, int y, int w)
        {
            this.x = x;
            this.y = y;
            this.weight = w;
        }

        public double getX()
        { return this.x; }
        public double getY()
        { return this.y; }
        public double getW()
        { return this.weight; }
    }

}
