using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;

namespace RetireBefore30.Services
{
    public interface IStrategyService
    {
        public Task<bool> createStrategy(Strategy strategy);
        public Task<Strategy> getStrategyById(int strategyId);
        public Task<List<Strategy>> getStrategies();
        public Task<bool> updateStrategy(Strategy strategy);
        public Task<bool> deleteStrategy(int strategyId);


    }
}
