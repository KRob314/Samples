using PizzaPlace.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzaPlace.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask PlaceOrder(ShoppingBasket basket)
        {
            await _httpClient.PostAsJsonAsync("/orders", basket);
        }
     }
}
