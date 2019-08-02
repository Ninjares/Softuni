using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [Test]
        public void EnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);
            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }
        [Test]
        public void EnrollExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);
            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
            
        }
        [Test]
        public void CountValidator()
        {
            int currentcount = arena.Warriors.Count;
            Warrior warrior = new Warrior("Pesho", 10, 100);
            arena.Enroll(warrior);
            Assert.AreEqual(currentcount + 1, arena.Warriors.Count);
        }

        [Test]
        public void FightWorksCorrectly()
        {
            int expAHP = 95;
            int expDHP = 40;
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);
            Assert.AreEqual(attacker.HP, expAHP);
            Assert.AreEqual(defender.HP, expDHP);
        }
        [Test]
        public void MissingFighter()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);
            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
        }



        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
