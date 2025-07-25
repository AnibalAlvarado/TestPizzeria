using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    abstract public class BaseDto
    {
        public int? id { get; set; }
        public bool? Active { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
    }
}
