using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class Strategy
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        // Navigation Properties
        public List<StrategyInstance> StrategyInstances { get; set; }
    }
}
