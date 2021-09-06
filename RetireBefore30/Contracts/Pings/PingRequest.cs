using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Contracts.Strategies
{
    public class PingRequest
    {
        public int State { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
    }
}
