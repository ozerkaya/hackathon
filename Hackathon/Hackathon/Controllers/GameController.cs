using Hackathon.DAL.Models;
using Hackathon.UI.Interfaces;
using HackathonDAL;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.UI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameHelper _gameHelper;
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;

        public GameController(ContextMssql dbmssql,
            ContextDapper dbdapper,
            IGameHelper gameHelper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _gameHelper = gameHelper;
        }

        public async Task<Games> CreateGame()
        {
            return await _gameHelper.CreateGame();
        }

    }
}
