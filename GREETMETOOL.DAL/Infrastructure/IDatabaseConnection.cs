using System;
using System.Data;
using GreetMeTool.Domain.Model;

namespace GreetMeTool.DAL.Infrastructure
{
    /// <summary>
    /// The interface is for for declaring database
    /// Connectivity method
    /// </summary>
    public interface IDataBaseConnection
    {
        IDbConnection Connection { get; }
    }
    
}

