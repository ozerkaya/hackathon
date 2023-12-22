using Hackathon.DAL.Models;
using Hackathon.UI.Interfaces;
using Hackathon.UI.Models;
using HackathonDAL;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.UI.Helpers
{
    public class GameHelper : IGameHelper
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;

        public GameHelper(ContextMssql dbmssql, ContextDapper dbdapper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
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

        public async Task<bool> GameStatus(GameRequestModel dataModel)
        {
            var game = await _dbmssql.Games.FirstOrDefaultAsync(ok => ok.GameKey == Guid.Parse(dataModel.gameID));

            if (game.Gamer1Key == Guid.Parse(dataModel.gamerID))
            {
                if (game.Gamer2Finish)
                {
                    return true;
                }
            }
            else if (game.Gamer2Key == Guid.Parse(dataModel.gamerID))
            {
                if (game.Gamer1Finish)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
