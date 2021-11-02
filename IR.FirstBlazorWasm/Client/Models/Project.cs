using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Models
{
    public class Project
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public int MaxHours { get; set; }
    }
}
