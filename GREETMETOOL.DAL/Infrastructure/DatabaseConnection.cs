using System;
using System.Data;
using System.Data.SqlClient;
using GreetMeTool.Domain.AppSettings;

namespace GreetMeTool.DAL.Infrastructure
{
    public sealed class DataBaseConnection : IDataBaseConnection
    {
        /// <summary>
        /// The class is used for database connectivity
        /// </summary>
        /// <param name="appsettings"></param>
        public DataBaseConnection(AppSettings appsettings)
        {
            Connection = new SqlConnection(appsettings.ConnectionInfo.TransactionDatabase);
            Connection.ConnectionString = appsettings.ConnectionInfo.TransactionDatabase;
        }
        public IDbConnection Connection { get; }
    }
}