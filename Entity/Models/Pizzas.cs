using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Pizzas : GenericModel
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
