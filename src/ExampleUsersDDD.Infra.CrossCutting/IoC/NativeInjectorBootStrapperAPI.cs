
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

// using ExampleUsersDDD.Domain.Interfaces.Services;
// using ExampleUsersDDD.Domain.Services;

using ExampleUsersDDD.Domain.Interfaces.Repositories;
using ExampleUsersDDD.Infra.Data.Repositories;

using ExampleUsersDDD.Application.Interfaces;
using ExampleUsersDDD.Application.Services;
using ExampleUsersDDD.Application.Mappers;

namespace ExampleUsersDDD.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapperAPI
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain
            // services.AddScoped<IServiceProduct, ServiceProduct>();

            // Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();

            // Infra - Data - Unit Of Work
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            // Application - AutoMapper
            services.AddAutoMapper(typeof(EntityToDtoMappingProduct), typeof(DtoToEntityMappingProduct));

            // Application - AppService
            services.AddScoped<IAppServiceProduct, AppServiceProduct>();
            
        }
    }
}
