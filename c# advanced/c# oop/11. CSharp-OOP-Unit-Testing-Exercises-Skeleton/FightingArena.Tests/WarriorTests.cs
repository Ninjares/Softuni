using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const string TestName = "Ares";
        private const int TestDmg = 40;
        private const int TestHP = 100;
        //Mnogo proverki v edin unittest ne e dobra praktika
        private Warrior warrior;



        [Test]
        public void TestEmptyName()
        {
            Assert.That(() => new Warrior("", 50, 50), Throws.ArgumentException);
            Assert.Throws<ArgumentException>(() => new Warrior(null, 50, 50));
            Assert.That(() => new Warrior("       ", 50, 50), Throws.ArgumentException);
        }
        [Test]
        public void Test0Dmg()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("somename", 0, 50));
        }
        [Test]
        public void TestNegativeDmg()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("somename", -20, 50));
        }
        [Test]
        public void TestNegativeHP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("somename", 20, -50));
        }
        [Test]
        public void ConstructorWorks()
        {
            Assert.AreEqual(TestName, warrior.Name);
            Assert.AreEqual(TestHP, warrior.HP);
            Assert.AreEqual(TestDmg, warrior.Damage);
        }
        [Test]
        public void GetterSetterTests()
        {
            Assert.That(warrior.Damage, Is.EqualTo(TestDmg));
            Assert.That(warrior.HP, Is.EqualTo(TestHP));
            Assert.That(warrior.Name, Is.EqualTo(TestName));
        }
        [Test]
        public void FunctionTestsExceptions()
        {
            Assert.That(() => warrior.Attack(new Warrior("Weak warrior", 10, 20)), Throws.InvalidOperationException); //attack weak
            Assert.That(() => warrior.Attack(new Warrior("Weak warrior", 120, 300)), Throws.InvalidOperationException); //attack strong
            Warrior someotherwarrior = new Warrior("slayer", 75, 75);
            someotherwarrior.Attack(warrior);
            Assert.That(() => someotherwarrior.Attack(warrior), Throws.InvalidOperationException); //get attacked while under 30
        }
        [Test]
        public void TestAttackSubtractors()
        {
            Warrior attacker1 = new Warrior("Attacker 1", 30, 50);
            Warrior attacker2 = new Warrior("Attacker 2", 80, 120);
            attacker1.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(TestHP - attacker1.Damage));
            attacker2.Attack(warrior);
            Assert.That(warrior.HP, Is.EqualTo(0));
        }
        [Test]
        public void TestIfAttackWorks()
        {
            int expectedAHP = 95;
            int expectedDHP = 80;
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);
            attacker.Attack(defender);
            Assert.AreEqual(expectedAHP, attacker.HP);
            Assert.AreEqual(expectedDHP, defender.HP);
        }
        [Test]
        public void AttackWithLowHP()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior defender = new Warrior("Gosho", 5, 45);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        [Test]
        public void AttackEnemyWithLowHP()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior defender = new Warrior("Gosho", 5, 25);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        public void AttackStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior defender = new Warrior("Gosho", 40, 100);
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }
        [Test]
        public void KillingEnemy()
        {
            int ExpectedAHP = 55;
            int ExpectedDHP = 0;
            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior defender = new Warrior("Gosho", 45, 40);
            attacker.Attack(defender);
            Assert.AreEqual(ExpectedAHP, attacker.HP);
            Assert.AreEqual(ExpectedDHP, defender.HP);
        }

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(TestName, TestDmg, TestHP);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}