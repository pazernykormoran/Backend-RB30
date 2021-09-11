using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.StrategyInstances
{
    public class StrategyInstancesPutRequest
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public int? type { get; set; }
        [Required]
        public string? instrument { get; set; }
        [Required]
        public long? createTimestamp { get; set; }

        // Navigation Properties
        [Required]
        public int? strategyId { get; set; }
    }
}
