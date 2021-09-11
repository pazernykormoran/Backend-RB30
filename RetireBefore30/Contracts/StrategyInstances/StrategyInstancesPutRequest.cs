using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.StrategyInstances
{
    public class StrategyInstancesPostRequest
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public int? type { get; set; }
        [Required]
        public string? instrument { get; set; }
        public long? createTimestamp { get; set; }

        // Navigation Properties
        [Required]
        public int? strategyId { get; set; }
    }
}
