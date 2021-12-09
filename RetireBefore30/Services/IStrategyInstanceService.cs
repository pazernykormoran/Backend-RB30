using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;

namespace RetireBefore30.Services
{
    public interface IStrategyInstanceService
    {
        public Task<bool> createStrategyInstance(StrategyInstance strategyInstance);
        public Task<StrategyInstance> getStrategyInstanceById(int strategyInstanceId);
        public Task<List<StrategyInstance>> getStrategyInstances(int strategyId);
        public Task<bool> updateStrategyInstance(StrategyInstance strategyInstance);
        public Task<bool> deleteStrategyInstance(int strategyInstanceId);


    }
}
