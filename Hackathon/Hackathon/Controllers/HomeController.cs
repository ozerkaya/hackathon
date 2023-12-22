using Hackathon.Models;
using Hackathon.UI.Interfaces;
using Hackathon.UI.Models;
using HackathonDAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IQuestionHelper _questionHelper;

        public HomeController(ContextMssql dbmssql,
            ContextDapper dbdapper,
            IQuestionHelper questionHelper)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _questionHelper = questionHelper;
        }

        public IActionResult Index(string winnerOrLoser)
        {
            CreateModel model = new CreateModel();
            if(!string.IsNullOrWhiteSpace(winnerOrLoser))
            {
                model.winnerOrLoser = winnerOrLoser;
            }
            return View(model);
        }

        public IActionResult Game(string GameKey, string GamerKey)
        {
            if (GamerKey == null)
            {
                GamerKey = _dbmssql.Games.FirstOrDefault(ok => ok.GameKey == Guid.Parse(GameKey)).Gamer2Key.ToString();
            }
            QuestionReturnModel model = new QuestionReturnModel
            {
                GameKey = Guid.Parse(GameKey),
                Gamer1Key = Guid.Parse(GamerKey),
                Gamer1Question = 1
            };
            return View(model);
        }

        public IActionResult Game2(string GameKey)
        {
            QuestionReturnModel model = new QuestionReturnModel
            {
                GameKey = Guid.Parse(GameKey),
                Gamer1Key = Guid.Parse(_dbmssql.Games.FirstOrDefault(ok => ok.GameKey == Guid.Parse(GameKey)).Gamer2Key.ToString()),
                Gamer1Question = 1
            };
            return View(model);
        }

    }
}