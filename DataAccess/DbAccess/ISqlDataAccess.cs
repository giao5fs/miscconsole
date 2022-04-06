using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sp, U parameters, string connectionId = "DBCS");
        Task SaveData<T>(string sp, T parameters, string connectionId = "DBCS");
    }
}