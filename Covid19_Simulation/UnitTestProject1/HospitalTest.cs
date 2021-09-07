using System;
using Covid19_Simulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class HospitalTest
    {
        [TestMethod]
        public void initiateHospitalList_Test_Success_Policy_None()
        {
            // Asssemble
            ILockdownPolicy policy = new Policy_none();
            Hospital hospital = new Hospital(5000, 1000000, policy);
            bool expectedResult = true;
            Qualification q = Qualification.InfectiousDisease;
            // hospital.hireDoctor(q);
            //hospital.hireNurse();

            // Act
            // bool actualResult = hospital.initiateHospitalList(1000000, q);
            bool actualResult = hospital.hireDoctor(q);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
