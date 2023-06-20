using Dapper;
using System;
using GreetMeTool.Domain.AppSettings;
using System.Data;
using GreetMeTool.Domain.Model;
using GreetMeTool.DAL.Infrastructure;
using GreetMeTool.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using GREETMETOOL.DAL.Constants;

namespace GreetMeTool.DAL.Repository
{
    /// <summary>
    /// class Admin repository
    /// </summary>
	public class AdminRepository : IAdminRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IDataBaseConnection _db;


        public AdminRepository(AppSettings appSettings, IDataBaseConnection db)
        {
            _appSettings = appSettings;
            _db = db;
        }
        public Task<bool> CreateGreetings(Greeting greeting)
        {
            var spName = ConstantSPnames.POSTGREETING;
            return Task.Factory.StartNew(() => _db.Connection.Query<bool>(spName, new
            {
                
                Title = greeting.Title,
                CountryCode = greeting.CountryCode,
                MessageText=greeting.MessageText,
                MessageType= greeting.MessageType,
                StartDate = greeting.StartDate,
                EndDate = greeting.EndDate,
            },


            commandType: CommandType.StoredProcedure).SingleOrDefault());
        }

        public Task<bool> DeleteGreetings(Int64 ID)
        {
            var spName = ConstantSPnames.DELETEGREETING;
            return Task.Factory.StartNew(() => _db.Connection.Query<bool>(spName, new
            {
               Id=ID
            },
            commandType: CommandType.StoredProcedure).SingleOrDefault());
        }

        

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<bool> EditGreetings(Greeting greeting)
        {
            var spName = ConstantSPnames.UPDATEGREETING;
            return Task.Factory.StartNew(() => _db.Connection.Query<bool>(spName, new
            {
                ID= greeting.Id,
                Title = greeting.Title,
                CountryCode = greeting.CountryCode,
                MessageText = greeting.MessageText,
                MessageType = greeting.MessageType,
                StartDate = greeting.StartDate,
                EndDate = greeting.EndDate,
            },


            commandType: CommandType.StoredProcedure).SingleOrDefault());
        }

        public Task<List<Greeting>> GetGreetings(string countryCode,DateTimeOffset startDate)
        {
            var spName = ConstantSPnames.GETGREETING;
            return Task.Factory.StartNew(() => _db.Connection.Query<Greeting>(spName, new {COUNTRYCODE= countryCode ,STARTDATE= startDate }, commandType: CommandType.StoredProcedure).ToList());
        }
    }
}

