using HackathonDAL;
using HackathonDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Controllers
{
    public class UsersController : Controller
    {
        private readonly ContextMssql _dbmssql;

        public UsersController(ContextMssql dbmssql)
        {
            _dbmssql = dbmssql;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IList<Users>> GetUsers()
        {
            return await _dbmssql.Users.ToListAsync();
        }
    }
}
