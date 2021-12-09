﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RetireBefore30.Contracts.Pings
{
    public class PingsPutRequest
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public int? state { get; set; }
        [Required]
        public long? timestamp { get; set; }
        // Navigation Properties
        [Required]
        public int? instanceId { get; set; }
    }
}
