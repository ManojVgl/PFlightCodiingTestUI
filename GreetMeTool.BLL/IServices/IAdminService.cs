using System;
using GreetMeTool.Domain.Model;

namespace GreetMeTool.BLL.IServices
{
	public interface IAdminService
	{
        /// <summary>
        /// The method signatures to create the greetings
        /// </summary>
        /// <param name="greeting">Object</param>
        /// <returns>True/False</returns>
        Task<bool> CreateGreetings(Greeting greeting);
        Task<List<Greeting>> GetGreetings(string countryCode, DateTimeOffset startDate);
        Task<bool> DeleteGreetings(Int64 ID);
        Task<bool> EditGreetings(Greeting greeting);
    }
}

