using Hackathon.API.Interfaces;
using Hackathon.DAL.Models;
using HackathonDAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Helpers
{
    public class GameHelper : IGameHelper
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;

        public GameHelper(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
        }

        public async Task<Games> CreateGame()
        {
            var gameKey = Guid.NewGuid();
            _dbmssql.Games.Add(new Games
            {
                GameKey = gameKey,
                Gamer1Key = Guid.NewGuid(),
                Gamer2Key = Guid.NewGuid(),
                Gamer1Question = 1,
                Gamer2Question = 1

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
