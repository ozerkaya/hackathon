using Hackathon.Models;
using Hackathon.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game(string GameKey, string GamerKey)
        {
            QuestionReturnModel model = new QuestionReturnModel
            {
                GameKey = Guid.Parse(GameKey),
                Gamer1Key = Guid.Parse(GamerKey),
                Gamer1Question = 1
            };
            return View(model);
        }

    }
}