using IR.FirstBlazorWasm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Teams
    {
        public List<Team> AllTeams { get; set; }
        public bool IsInEdit { get; set; }

        public void ShowDialog()
        {
            IsInEdit = true;
        }
        protected override void OnInitialized()
        {
            IsInEdit = false;
            AllTeams = new List<Team>()
            {
                new Team()
                { 
                    Name = "project1",
                    Members = new List<Member>()
                    {
                        new Member(){ FirstName = "persoon", LastName = "een", Email = "email1"},
                        new Member(){ FirstName = "persoon", LastName = "twee", Email = "email1"},
                        new Member(){ FirstName = "persoon", LastName = "drie", Email = "email1"},
                        new Member(){ FirstName = "persoon", LastName = "vier", Email = "email1"},
                        new Member(){ FirstName = "persoon", LastName = "vijf", Email = "email1"},
                        new Member(){ FirstName = "persoon", LastName = "zes", Email = "email1"},
                    },
                    Projects = new List<Project>()
                    {
                        new Project(){ Name = "project1", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project2", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project3", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project4", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project5", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project6", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                        new Project(){ Name = "project7", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                    }
                },
            };
        }

        public void OnDialogCanceled()
        {
            IsInEdit = false;
        }

        public void Edit()
        {

        }

        public void Delete(Team team)
        {
            AllTeams.Remove(team);
        }
    }
}
