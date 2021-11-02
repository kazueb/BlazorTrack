using IR.FirstBlazorWasm.Client.Logic;
using IR.FirstBlazorWasm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Projects : IAddDialog<Project>, IEditDialog<Project>
    {
        public List<Project> AllProjects { get; set; }

        #region AddDialog
        public bool IsInAdd { get; set; }
        public void ShowAddDialog()
        {
            IsInAdd = true;
        }
        public void OnAddDialogCanceled()
        {
            IsInAdd = false;
        }
        public void AddModel(Project context)
        {
            IsInAdd = false;
            AllProjects.Add(context);
        }
        #endregion

        #region EditDialog
        public Project EditingModel { get; set; }
        public bool IsInEdit { get; set; }
        public void ShowEditDialog(Project context)
        {
            IsInEdit = true;
            EditingModel = context;
        }
        public void OnEditDialogCanceled()
        {
            IsInEdit = false;
        }
        public void EditModel()
        {
            IsInEdit = false;
        }
        #endregion

        public void Delete(Project project)
        {
            AllProjects.Remove(project);
        }

        protected override void OnInitialized()
        {
            EditingModel = new Project();
            IsInAdd = IsInEdit = false;
            AllProjects = new List<Project>()
            {
                new Project(){ Name = "project1", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project2", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project3", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project4", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project5", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project6", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
                new Project(){ Name = "project7", StartDate = DateTime.Now, EndDate = DateTime.Now, Customer = "customer", MaxHours = 10},
            };
        }
    }
}
