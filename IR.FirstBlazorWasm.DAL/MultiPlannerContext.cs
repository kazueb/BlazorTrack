using IR.FirstBlazorWasm.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.DAL
{
    public class MultiPlannerContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }

        public MultiPlannerContext(DbContextOptions<MultiPlannerContext> options) : base(options)
        {

        }
    }
}
