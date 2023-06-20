using System;
namespace GreetMeTool.DAL
{
    public interface IDatabase<out T> : IDisposable
    {
        T Repository { get; }
    }
}
