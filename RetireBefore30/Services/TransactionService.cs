using Microsoft.EntityFrameworkCore;
using RetireBefore30.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;


namespace RetireBefore30.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> createTransaction(Transaction transactionToBeCreated)
        {
           await _dbContext.Transactions.AddAsync(transactionToBeCreated);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> deleteTransaction(int transactionId)
        {
            var transactionToBeRemoved = await getTransactionById(transactionId);
            if (transactionToBeRemoved != null)
            {
                _dbContext.Transactions.Remove(transactionToBeRemoved);
            }
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Transaction> getTransactionById(int transactionId)
        {
            return await _dbContext.Transactions.SingleOrDefaultAsync(x => x.Id == transactionId);
        }

        public async Task<List<Transaction>> getTransactions()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        public async Task<bool> updateTransaction(Transaction transactionToBeUpdated)
        {
            var exists = await _dbContext.Transactions.AnyAsync(x => x.Id == transactionToBeUpdated.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.Entry(transactionToBeUpdated).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
