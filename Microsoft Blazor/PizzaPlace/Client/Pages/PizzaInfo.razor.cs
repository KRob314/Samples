using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;

namespace PizzaPlace.Client.Pages
{
    public partial class PizzaInfo
    {
        [Inject]
        public State state { get; set; } = default!;

        public Pizza CurrentPizza => state.Pizza!;

        private string SpicinessImage(Spiciness spiciness) => $"images/{spiciness.ToString().ToLower()}.png";
    }
}
