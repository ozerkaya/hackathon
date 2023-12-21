using Hackathon.DAL.Models;

namespace Hackathon.UI.Interfaces
{
    public interface IGameHelper
    {
        public Task<Games> CreateGame();
    }
}
