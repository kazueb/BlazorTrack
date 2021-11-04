using IR.FirstBlazorWasm.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IR.FirstBlazorWasm.Client.Logic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using IR.FirstBlazorWasm.Client.Services;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Members : IAddDialog<Member>, IEditDialog<Member>
    {
        [Inject]
        public IModelService<Member> MemberService { get; set; }

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
        public async Task AddModel(Member context)
        {
            await MemberService.SaveModel(context.Email, context);
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
        public async Task EditModel(Member context)
        {
            await MemberService.SaveModel(context.Email, context);
            IsInEdit = false;
        }
        #endregion

        public async Task Delete(Member member)
        {
            await MemberService.DeleteModel(member.Email);
            AllMembers.Remove(member);
        }

        protected override void OnInitialized()
        {
            EditingModel = new Member();
            IsInAdd = IsInEdit = false;
        }


        protected override async Task OnInitializedAsync()
        {
            var members = await MemberService.GetModels();
            AllMembers = members.ToList();
        }
    }
}
