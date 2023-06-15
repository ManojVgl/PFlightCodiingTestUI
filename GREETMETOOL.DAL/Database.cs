using System;
using GreetMeTool.DAL.Infrastructure;
using GreetMeTool.Domain.AppSettings;
using Microsoft.Extensions.DependencyInjection;
namespace GreetMeTool.DAL
{
    public class Database<T> : IDatabase<T> where T : IDisposable
    {
        private readonly AppSettings _appsettings;
        public Database(AppSettings appsettings)
        {
            _appsettings = appsettings;
        }

        public T Repository
        {
            get
            {
                var serviceProvider = new ServiceCollection()
                    .AddSingleton(typeof(T))
                    //.AddSingleton(typeof(IServiceLogger), typeof(ServiceLogger))
                    .AddSingleton(typeof(IDataBaseConnection), typeof(DataBaseConnection))
                    .AddSingleton(_appsettings)
                    .BuildServiceProvider();
                return serviceProvider.GetService<T>();
            }
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
