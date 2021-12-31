using Microsoft.AspNetCore.Components;

namespace Components.Library
{
    public partial class ListView2<TItem>
    {
        public RenderFragment<RenderFragment>? ListTemplate{ get; set; }

        [Parameter]
        public RenderFragment<TItem> ItemTemplate{ get; set; } = default!;

        [Parameter]
        public IReadOnlyList<TItem> Items{ get; set; } = default!;
    }
}
