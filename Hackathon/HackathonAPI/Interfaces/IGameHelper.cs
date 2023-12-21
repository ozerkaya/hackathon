using Hackathon.DAL.Models;

namespace Hackathon.API.Interfaces
{
    public interface IGameHelper
    {
        public Task<Games> CreateGame();
    }
}
