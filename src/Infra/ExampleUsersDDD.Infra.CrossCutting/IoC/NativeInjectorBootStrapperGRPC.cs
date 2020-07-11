
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using ExampleUsersDDD.Domain.Interfaces.Services;
using ExampleUsersDDD.Domain.Services;

using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Repositories;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Services;
using ExampleUsersDDD.Application.Mappers;

namespace ExampleUsersDDD.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapperGRPC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // // Domain
            // services.AddSingleton<IServiceProduct, ServiceProduct>();

            // // Infra - Data
            // services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            // services.AddSingleton<IRepositoryProduct, RepositoryProduct>();

            // // Application
            // services.AddSingleton<IAppServiceProduct, AppServiceProduct>();

            // // Application - AutoMapper
            // services.AddAutoMapper(typeof(EntityToDtoMappingProduct), typeof(DtoToEntityMappingProduct));

            // // ...
        }
    }
}
