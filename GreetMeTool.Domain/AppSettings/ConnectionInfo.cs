using System;
namespace GreetMeTool.Domain.AppSettings
{
    /// <summary>
    /// The class is used for holding database details
    /// </summary>
    public class ConnectionInfo
    {
        public string? TransactionDatabase { get; set; }
        public string? DefaultConnection { get; set; }


    }
}

