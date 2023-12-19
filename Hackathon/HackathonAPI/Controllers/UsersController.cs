using Dapper;
using HackathonAPI.Features.Requests;
using HackathonDAL;
using HackathonDAL.Models;
using MediatR;
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
        private readonly IMediator _mediator;

        public UsersController(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
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

        [HttpGet("users/getusers/mediatr")]
        public async Task<IActionResult> GetUsersMediatr(string username)
        {
            var result = await _mediator.Send(new UsersRequest { Data = username });
            return Ok(result);
        }
    }
}