using NUnit.Framework;
using System;
using RandomShit; // use add reference

namespace NqkkuvUnitTest
{
    
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount bankAccount;
        [Test]
        public void TestNewBankAccount()
        {
            var bankAccount = new BankAccount(100m);
            Assert.That(bankAccount.Balance, Is.EqualTo(100m));
        }
        [Test]
        public void TestNewBankAccountWithNegativeBalance()
        {
            Assert.That(() => new BankAccount(-100m), Throws.ArgumentException.With.Message.EqualTo("Balance cannot be negative"));
        }
        [Test]
        public void TestDeposit()
        {
            bankAccount.Deposit(100m);
            Assert.That(bankAccount.Balance, Is.EqualTo(200m));
        }
        public void TestNegativeDeposit()
        {
            Assert.That(() => bankAccount.Deposit(-50m), Throws.ArgumentException);
        }
        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }
        [TearDown]
        public void DestroyBankAccount()
        {
            bankAccount = null;
        }
    }
}
