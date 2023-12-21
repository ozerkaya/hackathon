using System.ComponentModel.DataAnnotations;

namespace Hackathon.API.Models
{
    public class QuestionReturnModel
    {
        public int ID { get; set; }
        public int QuestionNumber { get; set; }
        public string? QuestionTR { get; set; }
        public string? QuestionEN { get; set; }
        public string? ChoiseA { get; set; }
        public string? ChoiseB { get; set; }
        public string? ChoiseC { get; set; }
        public string? ChoiseD { get; set; }
        public Guid GameKey { get; set; }
        public Guid Gamer1Key { get; set; }
        public Guid Gamer2Key { get; set; }
        public int Gamer1Point { get; set; }
        public int Gamer2Point { get; set; }
        public int Gamer1Question { get; set; }
        public int Gamer2Question { get; set; }
        public bool Gamer1Finish { get; set; }
        public bool Gamer2Finish { get; set; }
    }
}
