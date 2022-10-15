using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> loadData<T, U>(string storedProcudure,
                                                     U parameters,
                                                     string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcudure, parameters,
                                              commandType: CommandType.StoredProcedure);
    }


    public async Task SaveData<T>(string storedProcudure,
                                  T parameters,
                                  string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcudure, parameters,
                                      commandType: CommandType.StoredProcedure);
    }


}
