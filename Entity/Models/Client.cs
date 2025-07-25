using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Client : GenericModel
    {
        public int roleId {  get; set; }
        public virtual Role Role { get; set; }

    }
}
