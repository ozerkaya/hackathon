using Hackathon.DAL.Models;
using Hackathon.UI.Models;

namespace Hackathon.UI.Interfaces
{
    public interface IGameHelper
    {
        public Task<Games> CreateGame();
        public Task<bool> GameStatus(GameRequestModel dataModel);
    }
}
