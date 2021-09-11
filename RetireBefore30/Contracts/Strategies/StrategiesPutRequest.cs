using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Strategies
{
    public class StrategiesPutRequest
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public long? createTimestamp { get; set; }
    }
}
