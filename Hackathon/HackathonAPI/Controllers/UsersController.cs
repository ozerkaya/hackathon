using HackathonDAL;
using HackathonDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackathonAPI.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContextMssql _dbmssql;

        public UsersController(ContextMssql dbmssql)
        {
            _dbmssql = dbmssql;
        }

        [HttpGet("users/getusers")]
        public async Task<IList<Users>> GetUsers()
        {
            return await _dbmssql.Users.ToListAsync();
        }
    }
}