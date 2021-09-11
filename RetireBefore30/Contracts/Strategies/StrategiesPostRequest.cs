using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Strategies
{
    public class StrategiesPostRequest
    {
        [Required]
        public string? name { get; set; }
        public long? createTimestamp { get; set; }
    }
}
