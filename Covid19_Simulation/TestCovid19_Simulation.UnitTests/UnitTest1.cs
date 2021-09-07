using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Covid19_Simulation;

namespace TestCovid19_Simulation.UnitTests
{
    [TestClass]
    public class CalculateBlockCountTest
    {

        [TestMethod]
        public void calculateBlockCount_PopulationDividedByAreaDensityLessThan1_Returns1()
        {
            //Arrange
            var community = new Community(1);
            //Act
            var result = community.calculateBlockCount();
            //Assert
            Assert.AreEqual(result, 1);
        }
    }
    [TestClass]
    public class CalculateBlockCount2Test
    {

        [TestMethod]
        public void calculateBlockCount_PopulationDividedByAreaDensityLessMoreOrEqualTo1_ReturnsPopulationDividedByAreaDensity()
        {
            //Arrange
            var community = new Community(1000);
            //Act
            var result = community.calculateBlockCount();
            //Assert
            Assert.AreEqual(result, community.getPopulation()/community.getAreaDensity());
        }
    }
    [TestClass]
    public class GetNameTest
    {

        [TestMethod]
        public void getName_NameIsEqualToName_ReturnsName()
        {
            //Arrange
            var person = new Person("Name",1,20);
            //Act
            var result = person.getName();
            //Assert
            Assert.AreEqual(result, "Name");
        }
    }
    [TestClass]
    public class GetAgeTest
    {

        [TestMethod]
        public void getAge_AgeIsEqualToAge_ReturnsAge()
        {
            //Arrange
            var person = new Person("Name", 1, 20);
            //Act
            var result = person.getAge();
            //Assert
            Assert.AreEqual(result, 20);
        }
    }

    [TestClass]
    public class GetGenderTest
    {
        //1 - F, 2 - M
        [TestMethod]
        public void getGender_GenderIsEqualTo1_ReturnsGender()
        {
            //Arrange
            var person = new Person("Name", 1, 20);
            //Act
            var result = person.getGender();
            //Assert
            Assert.AreEqual(result, 1);
        }
    }

}
