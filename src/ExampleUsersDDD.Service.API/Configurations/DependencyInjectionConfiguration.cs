
using System;
using Microsoft.Extensions.DependencyInjection;

using ExampleUsersDDD.Infra.CrossCutting.IoC;

namespace ExampleUsersDDD.Service.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            // Where all the magic happens...
            NativeInjectorBootStrapperAPI.RegisterServices(services);
        }

    }
}
