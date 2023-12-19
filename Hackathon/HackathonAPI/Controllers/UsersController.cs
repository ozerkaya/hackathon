using Dapper;
using HackathonDAL;
using HackathonDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HackathonAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;

        public UsersController(ContextMssql dbmssql, ContextDapper dbdapper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
        }

        [HttpGet("users/getusers")]
        public async Task<IList<Users>> GetUsers()
        {
            return await _dbmssql.Users.ToListAsync();
        }

        [HttpGet("users/getusers/dapper")]
        public async Task<IList<Users>> GetUsersDapper(string username)
        {
            using (var connection = _dbdapper.CreateConnection())
            {
                var query = "SELECT TOP(1) * FROM Users where Username=@Username";
                var parameters = new DynamicParameters();
                parameters.Add("Username", username, DbType.String);

                var users = await connection.QueryAsync<Users>(query, parameters);
                return users.ToList();
            }
        }
    }
}