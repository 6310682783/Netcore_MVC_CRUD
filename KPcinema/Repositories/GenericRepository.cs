﻿using Dapper;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Data;

namespace KPcinema.Repositories
{
    public abstract class GenericRepository<T> 
    {

        //prop
       
        private readonly IConfiguration configuration;
        protected string connectionString = "";

        public GenericRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetSection("ConnectionStrings:MovieDB").Value;
        }

        public async Task<IEnumerable<T>> GetAll() 
        {
            var classname = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {classname}";
            using (var db = new SqlConnection(connectionString)) 
            {
                var result = await db.QueryAsync<T>(sqlCommand);
                return result.ToList();
            }
        }
        public async Task<T> GetById(int id)
        {
            var classname = typeof(T).Name;
            var sqlCommand = $"SELECT * FROM {classname} WHERE [Id] = @id";
            using (var db = new SqlConnection(connectionString))
            {
                var result = await db.QueryAsync<T>(sqlCommand,new { id = id});
                return result.FirstOrDefault() ;
            }
        }

        public abstract Task<int> Add(T model);

        public abstract Task<int> Update(T model);

        public abstract Task<int> Delete(int id);
    }


}
