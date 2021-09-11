using Microsoft.EntityFrameworkCore;
using RetireBefore30.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;


namespace RetireBefore30.Services
{
    public class StrategyInstanceService : IStrategyInstanceService
    {
        private readonly ApplicationDbContext _dbContext;

        public StrategyInstanceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> createStrategyInstance(StrategyInstance strategyInstance)
        {
           await _dbContext.StrategyInstances.AddAsync(strategyInstance);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> deleteStrategyInstance(int strategyInstanceId)
        {
            var strategyInstance = await getStrategyInstanceById(strategyInstanceId);
            if (strategyInstance != null)
            {
                _dbContext.StrategyInstances.Remove(strategyInstance);
            }
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<StrategyInstance> getStrategyInstanceById(int strategyInstanceId)
        {
            return await _dbContext.StrategyInstances.SingleOrDefaultAsync(x => x.Id == strategyInstanceId);
        }

        public async Task<List<StrategyInstance>> getStrategyInstances(int strategyId)
        {
            return await _dbContext.StrategyInstances.Where(x => x.StrategyId == strategyId).ToListAsync();
        }

        public async Task<bool> updateStrategyInstance(StrategyInstance strategyInstance)
        {
            var exists = await _dbContext.StrategyInstances.AnyAsync(x => x.Id == strategyInstance.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.Entry(strategyInstance).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
