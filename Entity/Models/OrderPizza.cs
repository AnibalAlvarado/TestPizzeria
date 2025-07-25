using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class OrderPizza : BaseModel
    {
        public int OrderId { get; set; }
        public Orders Order { get; set; }

        public int PizzaId { get; set; }
        public Pizzas Pizza { get; set; }
    }
}
