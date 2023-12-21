using Hackathon.API.Models;
using Hackathon.DAL.Models;

namespace Hackathon.API.Interfaces
{
    public interface IQuestionHelper
    {
        public Task<QuestionReturnModel> GetQuestions(Guid gameID, Guid gamerID);
        public Task<QuestionReturnModel> SetAnswer(Guid gameID, Guid gamerID, int questionNumber, string answer);
        public QuestionReturnModel MergeQuestions(Games games,Questions questions);
    }
}
