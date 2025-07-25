using AutoMapper;
using Entity.Dtos;
using Entity.Models;
using System;
using System.Reflection;
using System.Security;


namespace Utilities.Implementations
{
    public class AutoMapperProfiles : Profile
    {


        public AutoMapperProfiles() : base()
        {

            // Ejemplo de mapeo
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Orders, OrdersDto>().ReverseMap();
            CreateMap<Pizzas, PizzasDto>().ReverseMap();
            CreateMap<OrderPizza, OrderPizzaDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();

        }
    }
}