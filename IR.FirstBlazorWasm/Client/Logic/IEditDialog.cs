using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Logic
{
    interface IEditDialog<TModel>
    {
        TModel EditingModel { get; set; }
        bool IsInEdit { get; set; }
        void ShowEditDialog(TModel context);
        void OnEditDialogCanceled();
        void EditModel();
    }
}
