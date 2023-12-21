using Hackathon.API.Interfaces;
using Hackathon.DAL.Models;
using HackathonDAL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.API.Controllers
{
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;
        private readonly IQuestionHelper _questionHelper;

        public QuestionsController(ContextMssql dbmssql,
            ContextDapper dbdapper,
            IMediator mediator,
            IQuestionHelper questionHelper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
            _questionHelper = questionHelper;
        }

        [HttpGet("questions/new")]
        public async Task<Questions> GetQuestions(Guid gameID, Guid gamerID)
        {
            return await _questionHelper.GetQuestions(gameID, gamerID);
        }

        [HttpPost("questions/answer")]
        public async Task<Questions> SetAnswer(Guid gameID, Guid gamerID, int questionNumber, string answer)
        {
            return await _questionHelper.SetAnswer(gameID, gamerID, questionNumber, answer);
        }

    }
}
