using IR.FirstBlazorWasm.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IR.FirstBlazorWasm.Client.Logic;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Members : IAddDialog<Member>, IEditDialog<Member>
    {
        public List<Member> AllMembers { get; set; }

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
        public void AddModel(Member context)
        {
            IsInAdd = false;
            AllMembers.Add(context);
        }
        #endregion

        #region EditDialog
        public Member EditingModel { get; set; }
        public bool IsInEdit { get; set; }
        public void ShowEditDialog(Member context)
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

        public void Delete(Member member)
        {
            AllMembers.Remove(member);
        }

        protected override void OnInitialized()
        {
            EditingModel = new Member();
            IsInAdd = IsInEdit = false;
            AllMembers = new List<Member>()
            {
                new Member(){ FirstName = "persoon", LastName = "een", Email = "email1"},
                new Member(){ FirstName = "persoon", LastName = "twee", Email = "email1"},
                new Member(){ FirstName = "persoon", LastName = "drie", Email = "email1"},
                new Member(){ FirstName = "persoon", LastName = "vier", Email = "email1"},
                new Member(){ FirstName = "persoon", LastName = "vijf", Email = "email1"},
                new Member(){ FirstName = "persoon", LastName = "zes", Email = "email1"},
            };
        }
    }
}
