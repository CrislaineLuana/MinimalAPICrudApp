
namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> loadData<T, U>(string storedProcudure, U parameters, string connectionId = "Default");
    Task SaveData<T>(string storedProcudure, T parameters, string connectionId = "Default");
}