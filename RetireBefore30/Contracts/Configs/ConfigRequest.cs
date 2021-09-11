using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Contracts.Configs
{
    public class ConfigRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
    }
}
