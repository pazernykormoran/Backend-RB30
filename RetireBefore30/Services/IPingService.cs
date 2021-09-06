using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetireBefore30.Models;

namespace RetireBefore30.Services
{
    public interface IPingService
    {
        public Task<bool> createPing(Ping ping);
        public Task<Ping> getPingById(int pingId);
        public Task<List<Ping>> getPings();
        public Task<bool> updatePing(Ping ping);
        public Task<bool> deletePing(int pingId);


    }
}
