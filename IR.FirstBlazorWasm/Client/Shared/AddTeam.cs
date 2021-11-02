using IR.FirstBlazorWasm.Client.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Shared
{
    public partial class AddTeam
    {
        public Team Team { get; set; }
        [Parameter]
        public bool IsDialogOpen { get; set; }
        [Parameter]
        public EventCallback OnCancel { get; set; }

        public string SelectedMember { get; set; }
        public string SelectedProject { get; set; }

        public void SubmitTeam()
        {
            // persist => call API
            IsDialogOpen = false;
        }

        public void CancelDialog()
        {
            IsDialogOpen = false;
            OnCancel.InvokeAsync();
        }

        protected override void OnInitialized()
        {
            Team = new Team()
            {
                Name = "Beuzak",
                Members = new List<Member>()
                {
                    new Member(){ FirstName = "persoon", LastName = "een"},
                    new Member(){ FirstName = "persoon", LastName = "twee"},
                    new Member(){ FirstName = "persoon", LastName = "drie"}
                },
                Projects = new List<Project>()
                {
                    new Project(){ Name = "myproject" },
                    new Project(){ Name = "second project" },
                    new Project(){ Name = "third project" },
                }
            };
        }

        public List<Member> GetMembers()
        {
            return Team.Members;
        }
        public List<Project> GetProjects()
        {
            return Team.Projects;
        }
    }
}
