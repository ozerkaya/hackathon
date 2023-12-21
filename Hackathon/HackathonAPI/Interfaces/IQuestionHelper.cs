using Hackathon.DAL.Models;

namespace Hackathon.API.Interfaces
{
    public interface IQuestionHelper
    {
        public Task<Questions> GetQuestions(Guid gameID, Guid gamerID);
        public Task<Questions> SetAnswer(Guid gameID, Guid gamerID, int questionNumber, string answer);
    }
}
