using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;

namespace RetireBefore30.Services
{
    public interface IConfigService
    {
        public Task<bool> createConfig(Config config);
        public Task<Config> getConfigById(int configId);
        public Task<List<Config>> getConfigs();
        public Task<bool> updateConfig(Config config);
        public Task<bool> deleteConfig(int configId);


    }
}
