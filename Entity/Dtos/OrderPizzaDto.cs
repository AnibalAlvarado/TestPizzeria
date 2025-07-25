using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class OrderPizzaDto : BaseDto
    {
        public int? OrderId { get; set; }
        public OrdersDto? Orders { get; set; }

        public int? PizzaId { get; set; }
        public PizzasDto? Pizza { get; set; }
    }
}
