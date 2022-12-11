using Application.CQRS.Commands;
using Application.CQRS.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(ConfigurationMapper, Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly(), Assembly.GetCallingAssembly());
            return services;
        }

        private static void ConfigurationMapper(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.CreateMap<Todo, TodoResponse>();
            mapperConfigurationExpression.CreateMap<AddTodoCommand, Todo>();
        }
    }
}