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

        public async Task<QuestionReturnModel> GetQuestions([FromBody] GameRequestModel dataModel)
        {
            return await _questionHelper.GetQuestions(Guid.Parse(dataModel.gameID), Guid.Parse(dataModel.gamerID));
        }
        public async Task<QuestionReturnModel> SetAnswer([FromBody] SetAnswerModel dataModel)
        {
            return await _questionHelper.SetAnswer(Guid.Parse(dataModel.gameID), Guid.Parse(dataModel.gamerID), dataModel.questionNumber, dataModel.answer);
        }

    }
}
