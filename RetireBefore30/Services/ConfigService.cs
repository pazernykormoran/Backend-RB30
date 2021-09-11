using Microsoft.EntityFrameworkCore;
using RetireBefore30.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;


namespace RetireBefore30.Services
{
    public class ConfigService : IConfigService
    {
        private readonly ApplicationDbContext _dbContext;

        public ConfigService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> createConfig(Config config)
        {
           await _dbContext.Configs.AddAsync(config);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> deleteConfig(int configId)
        {
            var config = await getConfigById(configId);
            if (config != null)
            {
                _dbContext.Configs.Remove(config);
            }
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Config> getConfigById(int configId)
        {
            return await _dbContext.Configs.SingleOrDefaultAsync(x => x.Id == configId);
        }

        public async Task<List<Config>> getConfigs(int instanceId)
        {
            return await _dbContext.Configs.Where(x => x.StrategyInstanceId == instanceId).ToListAsync();
        }

        public async Task<bool> updateConfig(Config config)
        {
            var exists = await _dbContext.Configs.AnyAsync(x => x.Id == config.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.Entry(config).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
