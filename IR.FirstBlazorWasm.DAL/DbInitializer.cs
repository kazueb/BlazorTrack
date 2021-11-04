using IR.FirstBlazorWasm.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(MultiPlannerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Members.Any())
            {
                return;
            }

            var members = new List<Member>()
            {
                new Member()
                {
                    Email = "email@email.com",
                    FirstName = "Nicolas",
                    LastName = "Cage",
                    Capacity = 10
                },
                new Member()
                {
                    Email = "email@email.com",
                    FirstName = "Jos",
                    LastName = "vrm",
                    Capacity = 12
                },
            };

            context.AddRange(members);

            context.SaveChanges();
        }
    }
}
