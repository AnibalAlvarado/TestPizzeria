using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class OrdersDto : GenericDto
    {
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public ClientDto? Client { get; set; }
    }
}
