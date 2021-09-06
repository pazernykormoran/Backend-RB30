using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class Config
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
        public StrategyInstance StrategyInstance { get; set; }
    }
}
