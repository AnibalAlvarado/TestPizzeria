
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Contexts
{
    internal class DataInitial
    {
        public static void Data(ModelBuilder modelBuilder)
        {
            // Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Administrador", Description = "Rol de administrador" },
                new Role { Id = 2, Name = "Usuario", Description = "Rol de usuario estándar" }
            );
            //
        }
    }
}