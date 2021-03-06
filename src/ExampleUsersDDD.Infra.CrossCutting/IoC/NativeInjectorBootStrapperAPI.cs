﻿
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using ExampleUsersDDD.Common.Interfaces;
using ExampleUsersDDD.Common.Implementations;

using ExampleUsersDDD.Domain.Interfaces.Services;
using ExampleUsersDDD.Domain.Services;

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
            // Common
            services.AddSingleton(typeof(ILoggerManager<>), typeof(LoggerManager<>));

            // Domain
            services.AddScoped(typeof(IServiceSession<>), typeof(ServiceSession<>));
            services.AddScoped<IServiceUser, ServiceUser>();

            // Infra - Data
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IRepositoryUser, RepositoryUser>();

            // Infra - Data - Unit Of Work
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();

            // Application - AutoMapper
            services.AddAutoMapper(typeof(EntityToDtoMappingUser), typeof(DtoToEntityMappingUser));
            services.AddAutoMapper(typeof(EntityToDtoMappingUserRegistration), typeof(DtoToEntityMappingUserRegistration));
            services.AddAutoMapper(typeof(EntityToDtoMappingUserUpdate), typeof(DtoToEntityMappingUserUpdate));

            // Application - AppService
            services.AddScoped<IAppServiceUser, AppServiceUser>();
            
        }
    }
}
