using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class StrategyInstance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int Type { get; set; }
        public string Instrument { get; set; }

        // Navigation Properties
        public int StrategyId { get; set; }
        public Strategy Strategy { get; set; }
        public List<Config> Configs { get; set; }
        public List<Ping> Pings { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
