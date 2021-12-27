using Microsoft.AspNetCore.Components;
using System;
using System.Threading;

namespace PizzaPlace.Client.Pages
{
    public class Timer: ComponentBase
    {
        [Parameter]
        public double TimeInSeconds { get; set; }
        [Parameter]
        public EventCallback Tick { get; set; } = default!;

        protected override void OnInitialized()
        {
            var timer = new System.Threading.Timer(
                callback: (_) => InvokeAsync(() => Tick.InvokeAsync()),
                state: null,
                dueTime: TimeSpan.FromSeconds(TimeInSeconds),
                period: Timeout.InfiniteTimeSpan);
        }
    }
}
