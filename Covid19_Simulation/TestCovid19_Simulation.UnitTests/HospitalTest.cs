using System;
using Covid19_Simulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCovid19_Simulation.UnitTests
{
    [TestClass]
    public class HospitalTest
    {
        [TestMethod]
        public void checkForMoreStaff_If_buget_more_then_0_ReturnsTrue()
        {
            //Arrange
            ILockdownPolicy policy = new Policy_none();
            Hospital hospital = new Hospital(5000, 10000, policy);

            //Act
            var result = hospital.checkForMoreStaff();
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void getBudget_Returns100000()
        {
            //Arrange
            ILockdownPolicy policy = new Policy_none();
            Hospital hospital = new Hospital(5000, 10000, policy);
            int buget = 10000;
            //Act
            var result = hospital.getBudget();
            //Assert
            Assert.AreEqual(result, buget);
        }

        [TestMethod]
        public void getPopulation_Returns5000()
        {
            //Arrange
            ILockdownPolicy policy = new Policy_none();
            Hospital hospital = new Hospital(5000, 1000000, policy);
            int population = 5000;
            //Act
            var result = hospital.getPopulation();
            //Assert
            Assert.AreEqual(result, population);
        }
    }
}
