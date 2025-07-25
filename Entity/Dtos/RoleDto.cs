using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class RoleDto : GenericDto
    {
        public string? Description { get; set; }
        public string? clients { get; set; }
    }
}
