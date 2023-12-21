using Hackathon.API.Interfaces;
using Hackathon.DAL.Models;
using HackathonDAL;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Helpers
{
    public class QuestionHelper : IQuestionHelper
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;

        public QuestionHelper(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
        }

        public async Task<Questions> GetQuestions(Guid gameID, Guid gamerID)
        {
            var game = _dbmssql.Games.FirstOrDefault(ok => ok.GameKey == gameID);

            if (game.Gamer1Key == gamerID)
            {
                var question = await _dbmssql.Questions.FirstOrDefaultAsync(ok => ok.QuestionNumber == game.Gamer1Question);
                return question;
            }
            else if (game.Gamer2Key == gamerID)
            {
                var question = await _dbmssql.Questions.FirstOrDefaultAsync(ok => ok.QuestionNumber == game.Gamer2Question);
                return question;
            }
            else
            {
                return new Questions();
            }
        }

        public async Task<Questions> SetAnswer(Guid gameID, Guid gamerID, int questionNumber, string answer)
        {
            var game = _dbmssql.Games.FirstOrDefault(ok => ok.GameKey == gameID);
            var answerCorrect = _dbmssql.Questions.Any(ok => ok.QuestionNumber == questionNumber && ok.Answer == answer);

            questionNumber++;

            if (game.Gamer1Key == gamerID)
            {
                if (answerCorrect)
                {
                    game.Gamer1Point++;
                }

                game.Gamer1Question++;
                _dbmssql.Games.Attach(game);
                _dbmssql.Entry(game).State = EntityState.Modified;
                _dbmssql.SaveChanges();
            }
            else if (game.Gamer2Key == gamerID)
            {
                if (answerCorrect)
                {
                    game.Gamer2Point++;
                }

                game.Gamer2Question++;
                _dbmssql.Games.Attach(game);
                _dbmssql.Entry(game).State = EntityState.Modified;
                _dbmssql.SaveChanges();
            }

            return await GetQuestions(gameID, gamerID);
        }
    }
}
