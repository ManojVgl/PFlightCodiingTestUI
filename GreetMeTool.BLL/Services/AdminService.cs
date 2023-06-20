using System;
using System.Collections;
using System.Numerics;
using GreetMeTool.BLL.IServices;
using GreetMeTool.Domain.Model;
using GreetMeTool.DAL;
using GreetMeTool.DAL.Repository;

namespace GreetMeTool.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IDatabase<AdminRepository> _adminRepo;
        public AdminService(IDatabase<AdminRepository> adminRepo)
        {
            _adminRepo = adminRepo;
        }

        
        public async Task<bool> CreateGreetings(Greeting greeting)
        {
            try
            {
                return await _adminRepo.Repository.CreateGreetings(greeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteGreetings(long ID)
        {
            try
            {
                return await _adminRepo.Repository.DeleteGreetings(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditGreetings(Greeting greeting)
        {
            try
            {
                return await _adminRepo.Repository.EditGreetings(greeting);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Greeting>> GetGreetings(string countryCode, DateTimeOffset startDate)
        {
            try
            {
                return await _adminRepo.Repository.GetGreetings(countryCode, startDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
