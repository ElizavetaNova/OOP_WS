using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP;

namespace TestLogicOOP
{
    [TestClass]
    public class UnitTest1
    {
        Engine engine = new Engine("nimbus1", 20, 2, 3);
        [TestMethod]
        public void VolumeEngine()
        {
            Engine engine = new Engine("nimbus2001", 250, 5, 9);

            double volume = engine.VolumeEngine();

            Assert.AreEqual(volume, 45);
        }
        [TestMethod]
        public void CheckSpeedUp()
        {            
            Car car = new Car("lada", 50, "kia ria", engine);
            car.Gas();
            car.Gas();
            double speed = car.GetSpeedNow();
            Assert.AreEqual(speed, 40);
        }
        [TestMethod]
        public void CheckSpeedDown()
        {            
            Car car = new Car("lada", 100, "kia ria", engine);
            car.Gas();
            car.Gas();
            car.Brake();
            double speed = car.GetSpeedNow();
            Assert.AreEqual(speed, 60);
        }

    }
}
