using Cestech.Application.Interfaces;
using Cestech.Application.Services;
using Cestech.Domain.Interfaces;
using Cestech.Domain.Repositories;
using Cestech.Domain.Services;
using Cestech.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cestech.Infrastructure.Ioc
{
    public class SimpleInjectorContainer
    {
        public static Container Register(DbContextOptions<CestechContext> options)
        {
            var container = new Container();

            container.Register<CestechContext>(() => {
                return new CestechContext(options);
            }, ScopedLifestyle.Singleton);

            // Application
            container.Register<IApplicationServiceUsuario, ApplicationServiceUsuario>();

            // Domain
            container.Register<IServiceUsuario, ServiceUsuario>();

            // Infrastructure
            container.Register<IRepositoryUsuario, RepositoryUsuario>();

            container.Verify();

            return container;
        }
    }
}
