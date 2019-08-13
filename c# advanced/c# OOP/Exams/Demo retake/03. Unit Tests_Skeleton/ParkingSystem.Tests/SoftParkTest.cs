namespace ParkingSystem.Tests
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private SoftPark parking;
        private List<Car> testcars = new List<Car>();

        [Test]
        public void ParkOnEmptySpotSuccessfuly()
        {
            string parkingspot = "A1";
            Assert.IsNull(parking.Parking[parkingspot]);
            Assert.AreEqual(parking.ParkCar(parkingspot, testcars[1]), $"Car:{testcars[1].RegistrationNumber} parked successfully!");
            Assert.AreEqual(parking.Parking[parkingspot], testcars[1]);
        }
        [Test]
        public void ParkOnTakenSpot()
        {
            string parkingSpot = "A1";
            parking.ParkCar(parkingSpot, testcars[1]);
            Assert.Throws<ArgumentException>(() => parking.ParkCar("A1", testcars[3]), "Parking spot is already taken!");
        }
        [Test]
        public void ParkOnNonExistentSpot()
        {
            Assert.Throws<ArgumentException>(() => parking.ParkCar("AAA", testcars[5]), "Parking spot doesn't exists!");
        }
        [Test]
        public void ParkAlreadyParkedCar()
        {
            parking.ParkCar("A1", testcars[2]);
            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("B1", testcars[2]), "Car is already parked!");
            Assert.Throws<InvalidOperationException>(() => parking.ParkCar("A3", new Car("Somemake", testcars[2].RegistrationNumber)), "Car is already parked!");
        }
        [Test]
        public void SuccessfulCarRemoval()
        {
            string spot = "B1";
            parking.ParkCar(spot, testcars[1]);
            Assert.AreEqual(parking.Parking[spot], testcars[1]);
            Assert.AreEqual(parking.RemoveCar(spot, testcars[1]),$"Remove car:{testcars[1].RegistrationNumber} successfully!");
            Assert.IsNull(parking.Parking[spot]);
        }
        [Test]
        public void RemoveFromNonExistingSpot()
        {
            Assert.Throws<ArgumentException>(() => parking.RemoveCar("BBB", testcars[5]), "Parking spot doesn't exists!");
        }
        [Test]
        public void RemoveFromEmptySpot()
        {
            string spot = "C1";
            Assert.IsNull(parking.Parking[spot]);
            Assert.Throws<ArgumentException>(() => parking.RemoveCar(spot, testcars[10]), $"Car for that spot doesn't exists!");
        }
        [Test]
        public void RemoveWrongCarFromSpot()
        {
            string spot = "C1";
            parking.ParkCar(spot, testcars[6]);
            Assert.IsNotNull(parking.Parking[spot]);
            Assert.Throws<ArgumentException>(() => parking.RemoveCar(spot, testcars[9]), $"Car for that spot doesn't exists!");
        }
        [Test]
        public void WorkingDictionary()
        {
            Assert.IsNotNull(parking.Parking);
            Assert.That(parking.Parking.Count==12);
        }

        [SetUp]
        public void Setup()
        {
            parking = new SoftPark();
            for (int i = 0; i < 15; i++) testcars.Add(new Car($"Car{i}", $"{i * 101}"));
        }

        [Test]
        public void Test1()
        {
            
        }
    }
}