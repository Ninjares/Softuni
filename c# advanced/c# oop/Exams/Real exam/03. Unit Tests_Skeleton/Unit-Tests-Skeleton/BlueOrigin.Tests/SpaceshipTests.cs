namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private Astronaut astronaut = new Astronaut("Yuri Gagarin", 80);
        [Test]
        public void SuccessfulAdd()
        {
            Assert.That(spaceship.Count == 0);
            Assert.DoesNotThrow(() => spaceship.Add(astronaut));
            Assert.That(spaceship.Count == 1);
        }
        [Test]
        public void AddExistingAstronaut()
        {
            Assert.DoesNotThrow(() => spaceship.Add(astronaut));
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut), $"Astronaut {astronaut.Name} is already in!");
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut(astronaut.Name, 60)), $"Astronaut {astronaut.Name} is already in!");
            Assert.DoesNotThrow(() => spaceship.Add(new Astronaut("Armstrong", astronaut.OxygenInPercentage)));
        }
        [Test]
        public void AddAtFullCapacity()
        {
            for (int i = 0; i < spaceship.Capacity; i++) Assert.DoesNotThrow(() => spaceship.Add(new Astronaut($"Name{i}", i * 10d)));
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut), "Spaceship is full!");
        }
        [Test]
        public void SuccessfulAstronautRemoval()
        {
            spaceship.Add(astronaut);
            Assert.That(spaceship.Count == 1);
            Assert.That(spaceship.Remove(astronaut.Name));
            Assert.That(spaceship.Count == 0);
        }
        [Test]
        public void RemoveMissingAstronaut()
        {
            Assert.That(spaceship.Count == 0);
            Assert.That(!spaceship.Remove(astronaut.Name));
        }
        [Test]
        public void NullOrEmptySpaceshipName()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10), "Invalid spaceship name!");
            Assert.Throws<ArgumentNullException>(() => new Spaceship("", 10), "Invalid spaceship name!");
        }
        [Test]
        public void NegativeSpaceshipCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("RealName", -1));
            Assert.DoesNotThrow(() => new Spaceship("RealName", 01));
        }
        [Test]
        public void SuccessfulConstructorOperation()
        {
            Spaceship newspaceship = null;
            Assert.IsNull(newspaceship);
            Assert.DoesNotThrow(() => newspaceship = new Spaceship("Kerbal X", 3));
            Assert.IsNotNull(newspaceship);
        }
        [SetUp]
        public void Start()
        {
            spaceship = new Spaceship("Neberkenezer", 10);
        }
    }
}