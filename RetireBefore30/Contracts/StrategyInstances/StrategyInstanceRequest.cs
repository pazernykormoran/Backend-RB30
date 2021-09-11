using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Contracts.StrategyInstances
{
    public class StrategyInstanceRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public string Instrument { get; set; }

        // Navigation Properties
        public int StrategyId { get; set; }
    }
}
