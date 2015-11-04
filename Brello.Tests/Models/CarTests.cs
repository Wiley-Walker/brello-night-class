using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;

namespace Brello.Tests.Models
{
    [TestClass]
    public class CarTests
    {

        [TestMethod]
        public void CarEnsureICanCreateInstance()
        {
            Car mycar = new Car();
            Assert.IsNotNull(mycar);
        }
        [TestMethod]
        public void CarEnsureMyCarCanHonk()
        {
            Car mycar = new Car();
            Assert.AreEqual("HONK!", mycar.Horn());
        }
        [TestMethod]
        public void CarEnsureICanMockMyCarHorn()
        {
            Mock<Car> mock_car = new Mock<Car>();
            mock_car.Setup(x => x.Horn()).Returns("BEEP!");
            Assert.AreEqual("BEEP!", mock_car.Object.Horn());
        }
        [TestMethod]
        public void CarEnsureICanMockInterface()
        {
            Mock<ICar> mock_car = new Mock<ICar>();
            mock_car.Setup(x => x.Honk()).Returns("BEEP!");
            Assert.AreEqual("BEEP!", mock_car.Object.Honk());
        }
    }
}
