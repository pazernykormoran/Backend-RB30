using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;

namespace RetireBefore30.Services
{
    public interface ITransactionService
    {
        public Task<bool> createTransaction(Transaction transactionToBeCreated);
        public Task<Transaction> getTransactionById(int transactionId);
        public Task<List<Transaction>> getTransactions();
        public Task<bool> updateTransaction(Transaction transactionToBeUpdated);
        public Task<bool> deleteTransaction(int transactionId);


    }
}
