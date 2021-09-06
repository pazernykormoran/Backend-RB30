using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Contracts.Transactions
{
    public class TransactionRequest
    {
        public int Direction { get; set; }
        public float Price { get; set; }
        public float MoneyState { get; set; }
        public float Amount { get; set; }

        // Navigation Properties
        public int StrategyInstanceId { get; set; }
    }
}
