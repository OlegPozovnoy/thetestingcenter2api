using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Model
{
    public class Test
    {

        public int Id { get; set; }
        public string author { get; set; }

        [Required]
        public string name { get; set; }
        public string description { get; set; }

    }
}
