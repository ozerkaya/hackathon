using Dapper;
using HackathonAPI.Features.Requests;
using HackathonDAL.Models;
using HackathonDAL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Hackathon.DAL.Models;
using Hackathon.API.Helpers;
using Hackathon.API.Interfaces;

namespace Hackathon.API.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameHelper _gameHelper;
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;

        public GameController(ContextMssql dbmssql,
            ContextDapper dbdapper,
            IMediator mediator,
            IGameHelper gameHelper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
            _gameHelper = gameHelper;
        }

        [HttpPost("game/create")]
        public async Task<Games> CreateGame()
        {
            return await _gameHelper.CreateGame();
        }

    }
}
