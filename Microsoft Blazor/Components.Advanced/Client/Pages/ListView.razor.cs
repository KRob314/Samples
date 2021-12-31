using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Client.Pages
{
    public partial class ListView<TItem>
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }= default!;
        [Parameter]
        public IReadOnlyList<TItem> Items { get; set; } = default!;
    }
}
