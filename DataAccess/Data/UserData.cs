using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    // Retorna todos os usuários
    public Task<IEnumerable<UserModel>> GetUsers() =>
          _db.loadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    // Retorna apenas um usuário de acordo com o id
    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.loadData<UserModel, dynamic>(
            "dbo.spUser_Get",
            new { Id = id });

        return results.FirstOrDefault();
    }

    // Insere um usuário no banco de dados
    public Task InsertUser(UserModel user) =>
        _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    // Atualiza um usuário de acordo com o id
    public Task UpdateUser(UserModel user) =>
        _db.SaveData("dbo.spUser_Update", user);

    // Deleta um usuário de acordo com o id
    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.spUser_Delete", new { Id = id });



}
