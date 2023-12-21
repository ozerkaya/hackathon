using Dapper;
using HackathonAPI.Features.Requests;
using HackathonDAL.Models;
using HackathonDAL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Hackathon.DAL.Models;

namespace Hackathon.API.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;

        public GameController(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
        }

        [HttpPost("game/create")]
        public async Task<Games> CreateGame()
        {
            var gameKey = Guid.NewGuid();
            _dbmssql.Games.Add(new Games
            {
                GameKey = gameKey,
                Gamer1Key = Guid.NewGuid(),
                Gamer2Key = Guid.NewGuid(),

            });
            await _dbmssql.SaveChangesAsync();
            var game = await _dbmssql.Games.FirstOrDefaultAsync(ok => ok.GameKey == gameKey);

            if (game != null)
            {
                return game;
            }
            else
            {
                return new Games();
            }
        }

    }
}
