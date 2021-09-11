using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Transactions
{
    public class TransactionsGetRequest
    {
        public long from { get; set; } = -1;
        public long to { get; set; } = -1;

        // Navigation Properties
        [Required]
        public int? instanceId { get; set; }
    }
}
