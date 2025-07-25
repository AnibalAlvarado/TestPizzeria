using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Orders : GenericModel
    {
        public string Description { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
