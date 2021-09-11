using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Transactions
{
    public class TransactionPostRequest
    {
        [Required]
        public int? Direction { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public float? MoneyState { get; set; }
        [Required]
        public float? Amount { get; set; }

        public long? Timestamp { get; set; } 

        // Navigation Properties
        [Required]
        public int? StrategyInstanceId { get; set; }
    }
}
