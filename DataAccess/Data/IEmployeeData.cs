using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IEmployeeData
    {
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeModel>> GetEmployees();
    }
}