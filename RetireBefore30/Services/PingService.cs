using Microsoft.EntityFrameworkCore;
using RetireBefore30.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;


namespace RetireBefore30.Services
{
    public class PingService : IPingService
    {
        private readonly ApplicationDbContext _dbContext;

        public PingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> createPing(Ping ping)
        {
           await _dbContext.Pings.AddAsync(ping);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> deletePing(int pingId)
        {
            var ping = await getPingById(pingId);
            if (ping != null)
            {
                _dbContext.Pings.Remove(ping);
            }
            var deleted = await _dbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Ping> getPingById(int pingId)
        {
            return await _dbContext.Pings.SingleOrDefaultAsync(x => x.Id == pingId);
        }

        public async Task<List<Ping>> getPings()
        {
            return await _dbContext.Pings.ToListAsync();
        }

        public async Task<bool> updatePing(Ping ping)
        {
            var exists = await _dbContext.Pings.AnyAsync(x => x.Id == ping.Id);
            if (!exists)
            {
                return false;
            }

            _dbContext.Entry(ping).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
