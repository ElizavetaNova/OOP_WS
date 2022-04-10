using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP;
using System;

namespace TestLogicOOP
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void VolumeEngine()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);

            double extendedVolume = 5*3;
            //Act
            double actualVolume = engine.VolumeEngine();
            //Assert
            Assert.AreEqual(extendedVolume, actualVolume);
        }
        [TestMethod]
        public void CheckSpeedBoostEngine()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "common";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            int expectedSpeedBoostEngine = 20;
            //Act
            int speedBoostEngine = engine.getSpeedBoost();
            //Assert
            Assert.AreEqual(expectedSpeedBoostEngine, speedBoostEngine);
        }

        [TestMethod]
        public void CheckSpeedUp()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);            
            double maxSpeed = 200;
            Car car = new Car("lada", maxSpeed, "kia rio", engine);
            double extendedSpeed = 80;
            //Act
            car.Gas();
            car.Gas();            
            double speed = car.GetSpeedNow();
            //Assert
            Assert.AreEqual(extendedSpeed, speed);
        }
        [TestMethod]
        public void CheckSpeedUpMax()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 50;
            Car car = new Car("lada", maxSpeed, "kia rio", engine);
            //Act
            try
            {
                car.Gas();
                car.Gas();
                Assert.Fail("Должно быть исключение");
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual("Нельзя превысить максимальную скорость", ex.Message);
            }
        }

        [TestMethod]
        public void DegreeWearEngineUp()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 40;
            Car car = new Car("lada", maxSpeed, "kia rio", engine);

            int exeptedDegreeWearEngine = 40;
            //Act
            car.Gas();

            //Assert
            Assert.AreEqual(exeptedDegreeWearEngine, car.GetEngineCar().getDegreeWearEngine());            
        }

        private void reachingMaxSpeedForSportType(Car car, int speedDown)
        {            
            car.Gas();
            car.Brake(speedDown);
        }

        [TestMethod]
        public void DegreeWearEngineMax()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 40;
            Car car = new Car("lada", maxSpeed, "kia rio", engine);
            int speedDown = 40;
            //Act
            try
            {
                reachingMaxSpeedForSportType(car, speedDown);
                reachingMaxSpeedForSportType(car, speedDown);
                reachingMaxSpeedForSportType(car, speedDown);
                car.Gas();
                Assert.Fail("Должно быть исключение");
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual("Двигатель умер, машина больше не поедет", ex.Message);
            }            
        }
        [TestMethod]
        public void CheckSpeedDown()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 100;
            Car car = new Car("lada", maxSpeed, "kia ria", engine);
            int expectedSpeed = 60;
            int speedDown = 20;
            //Act
            car.Gas();
            car.Gas();
            car.Brake(speedDown);
            double actualSpeed = car.GetSpeedNow();
            //Assert
            Assert.AreEqual(expectedSpeed, actualSpeed);
        }
        [TestMethod]
        public void CheckBrakeWhenCarStop()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 100;
            Car car = new Car("lada", maxSpeed, "kia ria", engine);
            try
            {
                //Act
                car.Brake(20);
                Assert.Fail("Должно быть исключение");
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual("Машина и так стоит", ex.Message);
            }            
        }

        [TestMethod]
        public void CheckBrakeWhenSpeedSmall()
        {
            //Arrange
            string modelEngine = "nimbus2001";
            double horsepower = 250;
            int numberOfCylinders = 5;
            double volumeOfCylinder = 3;
            string typeEngine = "sport";
            Engine engine = new Engine(modelEngine, horsepower, numberOfCylinders, volumeOfCylinder, typeEngine);
            double maxSpeed = 100;
            Car car = new Car("lada", maxSpeed, "kia ria", engine);
            int speedDown = 50;
            //Act
            try
            {
                car.Gas();
                car.Brake(speedDown);
                Assert.Fail("Должно быть исключение");
            }
            catch(Exception ex)
            {
                //Assert
                Assert.AreEqual("Машина не может затормозить на такое значение", ex.Message);
            }
        }
    }
}
