namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;
        [Test]
        public void WorkingConstructor()
        {
            string make = "CorrectMake";
            string model = "CorrectModel";
            phone = new Phone(make, model);
            Assert.IsNotNull(phone);
            Assert.AreEqual(phone.Make, make);
            Assert.AreEqual(phone.Model, model);
            Assert.That(phone.Count == 0);
        }
        [Test]
        public void NullOrEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "CorrectModel"));
            Assert.Throws<ArgumentException>(() => new Phone("", "CorrectModel"));
            Assert.DoesNotThrow(() => new Phone("          ", "CorrectModel"));
        }
        [Test]
        public void NullOrEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone("CorrectMake", ""));
            Assert.Throws<ArgumentException>(() => new Phone("CorrectMake", null));
            Assert.DoesNotThrow(() => new Phone("CorrectMake", "     "));
        }
        [Test]
        public void SuccessfulContactAdd()
        {
            Phone phone = new Phone("CorrectMake", "CorrectModel");
            Assert.That(phone.Count == 0);
            Assert.DoesNotThrow(() => phone.AddContact("WorkingName", "+359000000"));
            Assert.That(phone.Count == 1);
        }
        [Test]
        public void AddExistingContact()
        {
            phone.AddContact("yeet", "yeet");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("yeet", "yoot"), "Person already exists!");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("yeet", "yeet"), "Person already exists!");
            Assert.DoesNotThrow(() => phone.AddContact("yoot", "yeet"), "Person already exists!");
        }
        [Test]
        public void MakeCallSuccessful()
        {
            string contactName = "Yeeter";
            string contactNumber = "+35988888888";
            phone.AddContact(contactName, contactNumber);
            Assert.AreEqual(phone.Call(contactName), $"Calling {contactName} - {contactNumber}...");
        }
        [Test]
        public void CallNonexistingContact()
        {
            string contactName = "Yeeter";
            string contactNumber = "+35988888888";
            phone.AddContact(contactName, contactNumber);
            Assert.Throws<InvalidOperationException>(() => phone.Call("Yooter"), "Person doesn't exists!");
            Assert.DoesNotThrow(() => phone.Call(contactName));
        }
        [SetUp]
        public void Start()
        {
            phone = new Phone("Make", "Model");
        }
        [TearDown]
        public void End()
        {

        }
    }
}