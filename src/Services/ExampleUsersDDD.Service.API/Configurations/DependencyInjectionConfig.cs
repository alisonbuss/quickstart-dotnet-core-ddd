
using System;
using Microsoft.Extensions.DependencyInjection;

using ExampleUsersDDD.Infra.CrossCutting.IoC;

namespace ExampleUsersDDD.Service.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapperAPI.RegisterServices(services);
        }
    }
}