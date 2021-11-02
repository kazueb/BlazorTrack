using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Models
{
    public class Team
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public List<Project> Projects { get; set; }
    }
}
