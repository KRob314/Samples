using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Client.Pages
{
    public partial class AnimalComponent: ComponentBase
    {
        [Parameter]
        public EventCallback ValidSubmit { get; set; }
    }
}
