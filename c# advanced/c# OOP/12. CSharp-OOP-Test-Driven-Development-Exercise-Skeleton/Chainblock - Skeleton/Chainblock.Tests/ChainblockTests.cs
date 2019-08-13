using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Models;
using NUnit.Framework;
using Chainblock.Contracts;

namespace Chainblock.Tests
{
    class ChainblockTests
    {
        private Models.Chainblock chainblock;
        private Transaction transaction;
        [SetUp]
        public void Start()
        {
            chainblock = new Models.Chainblock();
            transaction = new Transaction(1, TransactionStatus.Successfull, "Tashi", "Surbakov", 5);
        }
        [TearDown]
        public void End()
        {
        }



        [Test] 
        public void TestingAdd()
        {
            Assert.DoesNotThrow(() => chainblock.Add(transaction));
            Assert.That(chainblock.Contains(transaction));
        }
        [Test]
        public void TestAddDuplicate()
        {
            chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => chainblock.Add(transaction));
        }
        [Test]
        public void ContainsTester()
        {
            Assert.That(!chainblock.Contains(transaction));
            chainblock.Add(transaction);
            Assert.That(chainblock.Contains(transaction));
        }
        [Test]
        public void ContainsByIdTester()
        {
            Assert.That(!chainblock.Contains(transaction.Id));
            chainblock.Add(transaction);
            Assert.That(chainblock.Contains(transaction.Id));
        }
        [Test]
        public void GetByIdTester()
        {
            Assert.AreEqual(chainblock.GetById(1), null);
            chainblock.Add(transaction);
            Assert.AreEqual(chainblock.GetById(1), transaction);
            Assert.AreEqual(chainblock.GetById(5), null);
        }
        [Test]
        public void TransactionStatusChangerTest()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Unauthorized);
            Assert.That(chainblock.GetById(1).Status == TransactionStatus.Unauthorized);
        }
        [Test]
        public void TransactionStatusMissingId()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(10, TransactionStatus.Aborted));
        }
        [Test]
        public void RemoveTester()
        {
            chainblock.Add(transaction);
            var randomtx = new Transaction(22, TransactionStatus.Failed, "Yeet", "Meem", 22);
            chainblock.Add(randomtx);
            Assert.That(chainblock.Contains(transaction));
            Assert.DoesNotThrow(() => chainblock.RemoveTransactionById(transaction.Id));
            Assert.That(!chainblock.Contains(transaction));
            Assert.That(chainblock.Contains(randomtx));
        }
        [Test]
        public void RemoveNonExistentTransaction()
        {
            Assert.Throws<ArgumentException>(() => chainblock.RemoveTransactionById(69));
        }
        [Test]
        public void DescendingByAmoutThenById()
        {
            Transaction tr1 = new Transaction(63, TransactionStatus.Successfull, "Me", "Unique", 6);
            Transaction tr2 = new Transaction(66, TransactionStatus.Successfull, "Me", "Unique", 6);
            Transaction tr3 = new Transaction(70, TransactionStatus.Successfull, "Me", "Unique", 3);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr1);
            List<ITransaction> expectedlist = new List<ITransaction>();
            expectedlist.Add(tr1);
            expectedlist.Add(tr2);
            expectedlist.Add(tr3);
            CollectionAssert.AreEqual(expectedlist, chainblock.GetAllOrderedByAmountDescendingThenById());
        }
        [Test]
        public void ReceiverAndSenderByTransactionStatus()
        {
            Transaction tr1 = new Transaction(63, TransactionStatus.Successfull, "1", "A", 6);
            Transaction tr2 = new Transaction(66, TransactionStatus.Failed, "2", "B", 6);
            Transaction tr3 = new Transaction(70, TransactionStatus.Successfull, "3", "C", 3);
            Transaction tr4 = new Transaction(74, TransactionStatus.Aborted, "4", "D", 3);
            List<string> senderSuccess = new List<string>(new string[] { "1", "3" });
            List<string> receivedFailed = new List<string>(new string[] { "B" });
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);
            CollectionAssert.AreEqual(senderSuccess, chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull));
            CollectionAssert.AreEqual(receivedFailed, chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }
        
        [Test]
        public void GetRangeTester()
        {
            Transaction tr1 = new Transaction(63, TransactionStatus.Successfull, "1", "A", 2);
            Transaction tr2 = new Transaction(66, TransactionStatus.Failed, "2", "B", 3);
            Transaction tr3 = new Transaction(70, TransactionStatus.Successfull, "3", "C", 4);
            Transaction tr4 = new Transaction(74, TransactionStatus.Aborted, "4", "D", 5);
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);
            List<ITransaction> range = new List<ITransaction>(new Transaction[] { tr2, tr3, tr4 });
            CollectionAssert.AreEquivalent(range, chainblock.GetAllInAmountRange(3, 5));
            CollectionAssert.IsEmpty(chainblock.GetAllInAmountRange(7, 8));
        }
        [Test]
        public void GetByTranasctionStatusTest()
        {
            Transaction tr1 = new Transaction(63, TransactionStatus.Successfull, "1", "A", 6);
            Transaction tr2 = new Transaction(66, TransactionStatus.Failed, "2", "B", 6);
            Transaction tr3 = new Transaction(70, TransactionStatus.Successfull, "3", "C", 3);
            Transaction tr4 = new Transaction(74, TransactionStatus.Aborted, "4", "D", 3);
            List<ITransaction> txwithstate = new List<ITransaction>(new Transaction[] { tr1, tr3 });
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);
            CollectionAssert.AreEquivalent(txwithstate, chainblock.GetByTransactionStatus(TransactionStatus.Successfull));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }
        public void GetBySenderReceiverAndLimitsTest()
        {
            Transaction tr1 = new Transaction(63, TransactionStatus.Successfull, "1", "A", 2);
            Transaction tr2 = new Transaction(66, TransactionStatus.Failed, "1", "B", 3);
            Transaction tr3 = new Transaction(70, TransactionStatus.Successfull, "1", "C", 4);
            Transaction tr4 = new Transaction(74, TransactionStatus.Aborted, "4", "C", 6);
            chainblock.Add(tr1);
            chainblock.Add(tr2);
            chainblock.Add(tr3);
            chainblock.Add(tr4);
        }
    }
}
