using Business.Implementations;
using Business.Interfaces;
using Business.Interfaces.Business.Interfaces;
using Data.Implementations;
using Data.Interfaces;
using Entity.Dtos;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Utilities.Exceptions;


namespace Web.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            
            // sin necesidad de crear Business o Data concreta
            services.AddScoped<IRepositoryBusiness<Role, RoleDto>, RepositoryBusiness<Role, RoleDto>>();
            services.AddScoped<IRepositoryData<Role>, RepositoryData<Role>>();

            services.AddScoped<IRepositoryBusiness<Pizzas, PizzasDto>, RepositoryBusiness<Pizzas, PizzasDto>>();
            services.AddScoped<IRepositoryData<Pizzas>, RepositoryData<Pizzas>>();

            services.AddScoped<IRepositoryBusiness<User, UserDto>, RepositoryBusiness<User, UserDto>>();
            services.AddScoped<IRepositoryData<User>, RepositoryData<User>>();

            services.AddScoped<IRepositoryBusiness<OrderPizza, OrderPizzaDto>, RepositoryBusiness<OrderPizza, OrderPizzaDto>>();
            services.AddScoped<IRepositoryData<OrderPizza>, RepositoryData<OrderPizza>>();

            services.AddScoped<IRepositoryBusiness<Client, ClientDto>, RepositoryBusiness<Client, ClientDto>>();
            services.AddScoped<IRepositoryData<Client>, RepositoryData<Client>>();

            services.AddScoped<IRepositoryBusiness<Orders, OrdersDto>, RepositoryBusiness<Orders, OrdersDto>>();
            services.AddScoped<IRepositoryData<Orders>, RepositoryData<Orders>>();

            // Genéricos base
            services.AddScoped(typeof(IRepositoryBusiness<,>), typeof(RepositoryBusiness<,>));
            services.AddScoped(typeof(IRepositoryData<>), typeof(RepositoryData<>));

           
            return services;
        }
    }
}