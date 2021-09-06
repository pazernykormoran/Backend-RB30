using Microsoft.EntityFrameworkCore;
using RetireBefore30.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;


namespace RetireBefore30.Services
{
    public class StrategyService : IStrategyService
    {
        private readonly ApplicationDbContext _dbContext;

        public StrategyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> createStrategy(Strategy strategy)
        {
           await _dbContext.Strategies.AddAsync(strategy);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> deleteStrategy(int strategyId)
        {
            var strategy = await getStrategyById(strategyId);
            if (strategy != null)
            {
                _dbContext.Strategies.Remove(strategy);
            }
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Strategy> getStrategyById(int strategyId)
        {
            return await _dbContext.Strategies.SingleOrDefaultAsync(x => x.Id == strategyId);
        }

        public async Task<List<Strategy>> getStrategies()
        {
            return await _dbContext.Strategies.ToListAsync();
        }

        public async Task<bool> updateStrategy(Strategy strategy)
        {
            var exists = await _dbContext.Strategies.AnyAsync(x => x.Id == strategy.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.Entry(strategy).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
