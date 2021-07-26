using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Test { get; set; }
    }
}
