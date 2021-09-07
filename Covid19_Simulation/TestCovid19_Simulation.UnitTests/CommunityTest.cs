using System;
using Covid19_Simulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCovid19_Simulation.UnitTests
{
    [TestClass]
    public class CommunityTest
    {
        [TestMethod]
        public void getHerdSufficiency_60()
        {
            //Arrange
            var community = new Community(10000);
            int herdSufficiency = 60;
            //Act
            var result = community.getHerdSufficiency();
            //Assert
            Assert.AreEqual(result, herdSufficiency);
        }

        [TestMethod]
        public void getAreaDensity_500()
        {
            //Arrange
            var community = new Community(10000);
            int areaDensity = 500;
            //Act
            var result = community.getAreaDensity();
            //Assert
            Assert.AreEqual(result, areaDensity);
        }

        [TestMethod]
        public void getCultureType_declared_value_Median()
        {
            //Arrange
            var community = new Community(10000);
            string cultureType = "Median";
            //Act
            var result = community.getCultureType();
            //Assert
            Assert.AreEqual(result, cultureType);
        }

        [TestMethod]
        public void getPopulation_10000()
        {
            //Arrange
            var community = new Community(10000);
            int population = 10000;
            //Act
            var result = community.getPopulation();
            //Assert
            Assert.AreEqual(result, population);
        }


    }
}
