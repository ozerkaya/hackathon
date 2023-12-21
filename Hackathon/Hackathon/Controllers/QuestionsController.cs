using Hackathon.UI.Interfaces;
using Hackathon.UI.Models;
using HackathonDAL;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.UI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IQuestionHelper _questionHelper;

        public QuestionsController(ContextMssql dbmssql,
            ContextDapper dbdapper,
            IQuestionHelper questionHelper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _questionHelper = questionHelper;
        }

        [HttpGet("questions/new")]
        public async Task<QuestionReturnModel> GetQuestions(Guid gameID, Guid gamerID)
        {
            return await _questionHelper.GetQuestions(gameID, gamerID);
        }

        [HttpPost("questions/answer")]
        public async Task<QuestionReturnModel> SetAnswer(Guid gameID, Guid gamerID, int questionNumber, string answer)
        {
            return await _questionHelper.SetAnswer(gameID, gamerID, questionNumber, answer);
        }

    }
}
