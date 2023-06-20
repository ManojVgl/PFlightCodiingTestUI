using System;
using GreetMeTool.Domain.AppSettings;
using GreetMeTool.DAL;
using Microsoft.Extensions.DependencyInjection;


namespace GreetMeTool.BLL
{
    /// <summary>
    /// The class is used for dependency injection for services
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Services<T> : IServices<T>
    {
        private readonly AppSettings _appsettings;
        public Services(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }

        public T Service
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                   .AddSingleton(typeof(IDatabase<>), typeof(Database<>))
                    .AddSingleton(_appsettings)
                    .AddSingleton(typeof(T))
                    .BuildServiceProvider();
                return (T)Convert.ChangeType(serviceProvider
                    .GetService<T>(), typeof(T));
            }

        }
    }
}
