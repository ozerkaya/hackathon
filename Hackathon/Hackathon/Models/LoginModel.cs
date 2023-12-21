using Hackathon.UI.Interfaces;

namespace Hackathon.UI.Models
{
    public class LoginModel : IMessage
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Remember { get; set; }
        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
