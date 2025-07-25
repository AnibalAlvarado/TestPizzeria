﻿using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos
{
    public class ClientDto : GenericDto
    {
        public int? roleId { get; set; }
        public RoleDto? Role { get; set; }
    }
}
