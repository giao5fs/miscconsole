using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class EmployeeData : IEmployeeData
    {
        private readonly ISqlDataAccess sqlDataAccess;

        public EmployeeData(ISqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }

        public Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            return sqlDataAccess.LoadData<EmployeeModel, dynamic>("dbo.sp_GetAllEmployee", new { });
        }
        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            Console.WriteLine("GetEmployeeById");
            var result = await sqlDataAccess.LoadData<EmployeeModel, dynamic>("dbo.sp_GetEmployeeById", new { Id = id });
            return result.FirstOrDefault();
        }
    }
}
