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
        public int? direction { get; set; }
        [Required]
        public float? price { get; set; }
        [Required]
        public float? moneyState { get; set; }
        [Required]
        public float? amount { get; set; }

        public long? timestamp { get; set; } 

        // Navigation Properties
        [Required]
        public int? instanceId { get; set; }
    }
}
