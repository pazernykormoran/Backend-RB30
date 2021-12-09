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
        public int? id { get; set; }
        [Required]
        public int? direction { get; set; }
        [Required]
        public float? price { get; set; }
        [Required]
        public float? moneyState { get; set; }
        [Required]
        public float? amount { get; set; }
        [Required]
        public long? timestamp { get; set; }
        [Required]
        public int? instanceId { get; set; }
    }
}
