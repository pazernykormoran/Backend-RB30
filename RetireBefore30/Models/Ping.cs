using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class Ping
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public int State { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
        public StrategyInstance StrategyInstance { get; set; }
    }
}
