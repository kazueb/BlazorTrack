using Microsoft.AspNetCore.Components;

namespace IR.FirstBlazorWasm.Client.Pages
{
    public partial class Index
    {
        [Parameter]
        public string Name { get; set; } = "world";

        protected override void OnInitialized()
        {
            Name ??= "world";
        }
    }
}
