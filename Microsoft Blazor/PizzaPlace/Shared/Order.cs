using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; } = default!;
        public ICollection<Pizza> Pizzas { get; set; } = default!;

    }
}
