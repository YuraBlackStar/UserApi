using Core.Interfaces.Services;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Infrastructure.Data.LocalCache.Repositories;
using Microsoft.Extensions.Configuration;
using CrossCutting.Params;
using Core.Interfaces.Repositories;

namespace Infrastructure.IoC
{
    public static class IoCBuilder
    {
        /// <summary>
        /// Inyecta todas las dependencias en el IoC proporcionado como parámetro
        /// </summary>
        /// <param name="services">IoC que se utiliza en la aplicación</param>
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentException($"El parámetro {nameof(services)} no puede ser nulo");
            }

            services.AddTransient(typeof(Core.Interfaces.IAppParameters), typeof(AppParameters));

            BuildServices(services, configuration);
            BuildRepositories(services, configuration);
        }

        private static void BuildServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IUserService), typeof(UserService));
            //services.Add(new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Transient));
        }

        private static void BuildRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var ormProvider = configuration.GetSection("Parameters:TipoServicio");

            if (ormProvider.Value == "local")
            {
                services.AddTransient(typeof(IUserRepository), typeof(UserRepositoryCache));
            }
            else
            {
                throw new ArgumentException($"El parámetro Parameters.TipoServicio tiene el valor {ormProvider} ");
            }
        }
    }
}
