using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Configs
{
    public class CandlesGetRequest
    {
        //string symbol, TimeSpan timespan, DateTime? startTime = null, DateTime? endTime = null, int? limit = null
        [Required]
        public string? symbol { get; set; }
        [Required]
        public string? period { get; set; }
        public long startTime { get; set; } = -1;
        public long endTime { get; set; } = -1;
        public int? limit { get; set; } = 100;
    }
}
