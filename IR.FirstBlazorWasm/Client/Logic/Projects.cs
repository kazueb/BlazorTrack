using IR.FirstBlazorWasm.Client.Logic;
using IR.FirstBlazorWasm.Client.Models;
using IR.FirstBlazorWasm.Client.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Projects : IAddDialog<Project>, IEditDialog<Project>
    {
        [Inject]
        public IModelService<Project> ProjectService { get; set; }
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
        public async Task AddModel(Project context)
        {
            await ProjectService.SaveModel(context.Name, context);
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
        public async Task EditModel(Project context)
        {
            await ProjectService.SaveModel(context.Name, context);
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
        }

        protected override async Task OnInitializedAsync()
        {
            var projects = await ProjectService.GetModels();
            AllProjects = projects.ToList();
        }
    }
}
