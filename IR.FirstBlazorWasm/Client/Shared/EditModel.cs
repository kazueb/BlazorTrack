using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Shared
{
    public class EditModel<TModel> : ComponentBase where TModel : class, new()
    {
        [Parameter]
        public TModel Model { get; set; }

        [Parameter]
        public bool IsDialogOpen { get; set; }

        [Parameter]
        public EventCallback OnCancel { get; set; }

        [Parameter]
        public EventCallback<TModel> OnSubmit { get; set; }
        protected override void OnInitialized()
        {
            Model = new TModel();
        }
        public void SubmitModel()
        {
            OnSubmit.InvokeAsync(Model);
            Model = new TModel();
            IsDialogOpen = false;
        }
        public void CancelDialog()
        {
            IsDialogOpen = false;
            OnCancel.InvokeAsync();
        }
    }
}
