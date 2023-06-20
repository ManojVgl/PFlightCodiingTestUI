using System;
namespace GreetMeTool.BLL
{
    public interface IServices<out T>
    {
        T Service { get; }
    }
}
