using NUnit.Framework;
using CarManager;
using System;
namespace Tests
{
    public class CarTests
    {
        private Car car;
        [Test]
        public void ConstructorExceptions()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "SomeModel", 5, 50));
            Assert.Throws<ArgumentException>(() => new Car("", "SomeModel", 5, 50));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", null, 5, 50));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", "", 5, 50));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", "SomeModel", 0, 50));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", "SomeModel", -5, 50));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", "SomeModel", 5, 0));
            Assert.Throws<ArgumentException>(() => new Car("SomeMake", "SomeModel", 5, -50));
        }
        [Test]
        public void GettersAndSetter()
        {
            string make = "TestMake";
            string model = "TestModel";
            double testfc = 10;
            double testtank = 100;
            Car testcar = new Car(make, model, testfc, testtank);
            Assert.That(make == testcar.Make);
            Assert.That(model == testcar.Model);
            Assert.That(testfc == testcar.FuelConsumption);
            Assert.That(testtank == testcar.FuelCapacity);
        }
        [Test]
        public void WorkingConstructor()
        {
            Assert.AreNotEqual(null, new Car("SomeMake", "SomeModel", 5, 50));
        }
        [Test]
        public void RefuelTest()
        {
            Assert.AreEqual(car.FuelAmount, 0);
            car.Refuel(7);
            Assert.AreEqual(car.FuelAmount, 7);
        }
        [Test]
        public void OverFuel()
        {
            Assert.AreEqual(car.FuelAmount, 0);
            car.Refuel(car.FuelCapacity+10);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void NegativeRefueling()
        {
            Assert.AreEqual(car.FuelAmount, 0);
            car.Refuel(20);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.Throws<ArgumentException>(() => car.Refuel(-5));
        }
        [Test]
        public void DrivingTest()
        {
            car.Refuel(50);
            double distancetotravel = 100;
            double expectedfuel = car.FuelAmount - ((distancetotravel / 100) * car.FuelConsumption);
            car.Drive(distancetotravel);
            Assert.AreEqual(car.FuelAmount, expectedfuel);
        }
        [Test]
        public void UnsufficientFuelforDrive()
        {
            car.Refuel(2);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
            car.Refuel(7);
            Assert.DoesNotThrow(() => car.Drive(100));
        }
        //[Test]
        //public void NegativeDistance()
        //{
        //    car.Refuel(20);
        //    Assert.Throws<Exception>(() => car.Drive(-5));
        //}


        [SetUp]
        public void Setup()
        {
            car = new Car("SomeMake", "SomeModel", 5, 50);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}