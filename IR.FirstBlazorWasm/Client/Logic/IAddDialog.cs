using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IR.FirstBlazorWasm.Client.Logic
{
    interface IAddDialog<TModel>
    {
        bool IsInAdd { get; set; }
        void ShowAddDialog();
        void OnAddDialogCanceled();
        void AddModel(TModel context);
    }
}
