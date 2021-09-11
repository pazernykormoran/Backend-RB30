using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Transactions
{
    public class TransactionPutRequest
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public int? Direction { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public float? MoneyState { get; set; }
        [Required]
        public float? Amount { get; set; }
        [Required]
        public long? Timestamp { get; set; }
        [Required]
        public int? StrategyInstanceId { get; set; }
    }
}
