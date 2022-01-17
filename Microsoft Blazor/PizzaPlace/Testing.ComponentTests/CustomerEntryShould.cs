using Bunit;
using Xunit;
using PizzaPlace.Client.Pages;
using PizzaPlace.Shared;

namespace Testing.ComponentTests
{
    public class CustomerEntryShould : TestContext
    {
        [Fact]
        public void RenderCorrectly()
        {
            Customer customer = new Customer();
            // var cut = RenderComponent<CustomerEntry>(parameters =>
            //parameters.Add(counter => counter.Title, "")
            //    .Add(counter => counter.ButtonClass, "btn-success").
            //    Add(counter => counter.ButtonTitle, "Save")
            //    .Add(counter => counter.Customer, customer));

            //var cut = RenderComponent<PizzaPlace.Client.Pages.CustomerEntry>();

            //Assert.True(cut.Find("button").TextContent == "Save");

            //cut.Find("button").Click();

            //cut.Find("p")
            //   .MarkupMatches("<p>Current count: 1</p>");
        }
    }
}