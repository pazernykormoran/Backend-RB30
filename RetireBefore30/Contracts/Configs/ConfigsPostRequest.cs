using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RetireBefore30.Contracts.Configs
{
    public class ConfigsPostRequest
    {
        [Required]
        public string? name { get; set; }
        [Required]
        public string? value { get; set; }

        // Navigation Properties
        [Required]
        public int? instanceId { get; set; }
    }
}
