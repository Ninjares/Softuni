using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitRider rider;
        private UnitMotorcycle motorcycle;
        private RaceEntry raceEntry;
        [Test]
        public void SuccessfulAdd()
        {
            Assert.That(raceEntry.Counter == 0);
            Assert.AreEqual($"Rider {rider.Name} added in race.", raceEntry.AddRider(rider));
            Assert.That(raceEntry.Counter == 1);
        }
        [Test]
        public void AddExistingRider()
        {
            Assert.DoesNotThrow(() => raceEntry.AddRider(rider));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider), $"Rider {rider.Name} is already added.");
        }
        [Test]
        public void AddNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null), "Rider cannot be null.");
        }
        [Test]
        public void SuccessfulHPcalculation()
        {
            UnitRider anotherRider = new UnitRider("Brap Hunta", new UnitMotorcycle("Nekva troshka", 75, 40));
            raceEntry.AddRider(anotherRider);
            raceEntry.AddRider(rider);
            Assert.AreEqual(
                (anotherRider.Motorcycle.HorsePower + rider.Motorcycle.HorsePower) / 2d, 
                raceEntry.CalculateAverageHorsePower()
                );

        }
        [Test]
        public void InsufficientRiders()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
            raceEntry.AddRider(rider);
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
            raceEntry.AddRider(new UnitRider("Name", new UnitMotorcycle("Motor", 80, 40)));
            Assert.DoesNotThrow(() => raceEntry.CalculateAverageHorsePower());
        }
        
        [SetUp]
        public void Setup()
        {
            motorcycle = new UnitMotorcycle("Nekkav Motor", 100, 50);
            rider = new UnitRider("Domemenik", motorcycle);
            raceEntry = new RaceEntry();
        }
    }
}