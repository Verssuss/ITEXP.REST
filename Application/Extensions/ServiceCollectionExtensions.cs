using Application.CQRS.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            //IMapperConfigurationExpression mapperConfigurationExpression = new MapperConfigurationExpression();
            //mapperConfigurationExpression.CreateMap<TodoResponse, Todo>();

            services.AddAutoMapper((c) => c.CreateMap<Todo, TodoResponse>(), Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly(), Assembly.GetCallingAssembly());
            return services;
        }
    }
}
