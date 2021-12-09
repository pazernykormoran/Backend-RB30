using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RetireBefore30.Contracts.Pings
{
    public class PingsGetRequest
    {
        public long from { get; set; } = -1;
        public long to { get; set; } = -1;
        [Required]
        public int? instanceId { get; set; }
    }
}
