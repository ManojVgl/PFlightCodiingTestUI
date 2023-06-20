using System;
using GreetMeTool.Domain.Model;

namespace GreetMeTool.DAL.Interfaces
{
	public interface IAdminRepository : IDisposable
    {
        /// <summary>
        /// The method signatures to create the greetings
        /// </summary>
        /// <param name="greeting">Object</param>
        /// <returns>True/False</returns>
        Task<bool> CreateGreetings(Greeting greeting);
        Task<bool> DeleteGreetings(Int64 Id);
        Task<bool> EditGreetings(Greeting greeting);
        Task<List<Greeting>> GetGreetings(string countryCode, DateTimeOffset startDate);

    }
}

