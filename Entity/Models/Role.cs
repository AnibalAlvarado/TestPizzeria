using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Role : GenericModel
    {
        public string Description { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
