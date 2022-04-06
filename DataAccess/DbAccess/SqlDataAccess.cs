using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string sp,
                                                  U parameters,
                                                  string connectionId = "DBCS")
        {
            using IDbConnection c = new SqlConnection(config.GetConnectionString(connectionId));
            return await c.QueryAsync<T>(sp, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string sp, T parameters, string connectionId = "DBCS")
        {
            using IDbConnection c = new SqlConnection(config.GetConnectionString(connectionId));
            await c.ExecuteAsync(sp, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
