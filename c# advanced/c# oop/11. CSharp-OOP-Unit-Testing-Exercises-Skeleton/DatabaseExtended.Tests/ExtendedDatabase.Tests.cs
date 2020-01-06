using NUnit.Framework;
using ExtendedDatabas;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private List<Person> testpeople;

        //Add function tests
        #region 
        [Test]
        public void TestAddDuplicate()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.That(() => database.Add(person), Throws.InvalidOperationException);
        }
        [Test]
        public void TestAddDuplicateName()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.That(() => database.Add(new Person(333, "Gosho")), Throws.InvalidOperationException);
        }
        public void TestAddDuplicateId()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.That(() => database.Add(new Person(123, "Pesho")), Throws.InvalidOperationException);
        }
        [Test]
        public void ArrayCapacityis16()
        {
            for (int i = 0; i < 16; i++) Assert.That(() => database.Add(testpeople[i]), !Throws.InvalidOperationException);
            Assert.That(database.Count == 16);
            Assert.Throws<InvalidOperationException>(() => database.Add(testpeople[17]));
        }
        [Test]
        public void SuccessfullAdd()
        {
            Person person = new Person(123, "Gosho");
            Assert.DoesNotThrow(() => database.Add(person));
            Assert.AreEqual(person, database.FindById(123));
            Assert.AreEqual(person, database.FindByUsername("Gosho"));
            Assert.That(database.Count == 1);
        }
        #endregion 
        //Find function tets
        #region
        [Test]
        public void FindByMissingUserName()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Pesho"));
            Assert.DoesNotThrow(() => database.FindByUsername("Gosho"));
        }
        [Test]
        public void NullName()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(""));
        }
        [Test]
        public void FindByMissingID()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.FindById(125));
            Assert.DoesNotThrow(() => database.FindById(123));
        }
        [Test]
        public void NegativeID()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
        [Test]
        public void ProperReturns()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.That(database.FindById(123)==person);
            Assert.That(database.FindByUsername("Gosho") ==person);
        }
        #endregion


        //RemoveTesting
        #region
        [Test]
        public void RemoveFromEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        public void RemoveFromSonething()
        {
            Person person = new Person(123, "Gosho");
            database.Add(person);
            Assert.DoesNotThrow(() => database.Remove());
        }
        #endregion

        [Test]
        public void ConstructorTest()
        {
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(testpeople.ToArray()));
        }
        
        [Test]
        public void ArrayTest()
        {
            Person[] testarray = { testpeople[1], testpeople[2], testpeople[3], testpeople[4], testpeople[5] };
            Assert.DoesNotThrow(() => database = new ExtendedDatabase(testarray));
            Assert.AreEqual(testarray.Length, database.Count);
            for (int i = 0; i < 5; i++) Assert.AreEqual(testarray[i], database.FindById(testarray[i].Id));
        }
        [Test]
        public void CountTester()
        {
            Assert.AreEqual(0, database.Count);
            for (int i = 0; i < 3; i++) database.Add(testpeople[i]);
            Assert.AreEqual(3, database.Count);
            Assert.DoesNotThrow(() => database.FindById(testpeople[2].Id));
            database.Remove();
            Assert.AreEqual(2, database.Count);
            Assert.Throws<InvalidOperationException>(() => database.FindById(testpeople[2].Id));
        }
        [Test]
        public void WorkingConstructor()
        {
            Assert.AreNotEqual(null, database);
        }
        






        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
            testpeople = new List<Person>();
            for (int i = 0; i < 20; i++) testpeople.Add(new Person(i, $"Gosho{i}"));
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}