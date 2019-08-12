using NUnit.Framework;
using System;
using Databas;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        [Test]
        public void ArrayCapacityis16()
        {
            for (int i = 0; i < 16; i++) Assert.That(() => database.Add(i), !Throws.InvalidOperationException);
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void RemoveFromEmptyArray()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FetchIsArray() //not on extended
        {
            Assert.That(() => database.Fetch() is int[]);
        }
        [Test]
        public void ConstructorTest()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }
        [Test]
        public void ArrayTest()
        {
            int[] testarray = { 1, 2, 3, 4, 5 };
            database = new Database(testarray);
            Assert.AreEqual(testarray, database.Fetch());
            Assert.AreEqual(testarray.Length, database.Count);
        }
        [Test]
        public void CountTester()
        {
            for (int i = 0; i < 3; i++) database.Add(i);
            Assert.AreEqual(3, database.Count);
            database.Remove();
            Assert.AreEqual(2, database.Count);
        }

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}