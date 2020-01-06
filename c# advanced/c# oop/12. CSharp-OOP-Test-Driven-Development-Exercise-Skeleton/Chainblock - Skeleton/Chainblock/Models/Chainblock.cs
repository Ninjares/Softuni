using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;
        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }
        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.Contains(tx)) throw new ArgumentException("Transaction already exists");
            else transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!Contains(id)) throw new ArgumentException("No such transaction");
            else
            {
                GetById(id).Status = newStatus;
            }
        }

        public bool Contains(ITransaction tx)
        {
            return Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            return transactions.Any(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return transactions.Where(x => x.Amount >= lo && x.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return (IEnumerable<ITransaction>) transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToArray();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any(x => x.Status == status)) throw new InvalidOperationException();
            return transactions.Where(x => x.Status == status).Select(x => x.To);
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any(x => x.Status == status)) throw new InvalidOperationException();
            return transactions.Where(x => x.Status == status).Select(x => x.From);
        }

        public ITransaction GetById(int id)
        {
            return transactions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            return GetBySenderOrderedByAmountDescending(sender).Where(x => x.Amount>=amount);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!transactions.Any(x => x.From == sender)) throw new ArgumentException();
            else return transactions.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!transactions.Any(x => x.Status == status)) throw new InvalidOperationException();
            return transactions.Where(x => x.Status == status);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            if (!Contains(id)) throw new ArgumentException("No such transaction");
            else transactions.RemoveAll(x => x.Id == id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
