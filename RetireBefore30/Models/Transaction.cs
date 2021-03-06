using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int Direction { get; set; }
        public double Price { get; set; }
        public double MoneyState { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
        public StrategyInstance StrategyInstance { get; set; }
    }
}
