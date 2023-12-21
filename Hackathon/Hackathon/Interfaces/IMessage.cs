using Microsoft.AspNetCore.Mvc;

namespace Hackathon.UI.Interfaces
{
    public interface IMessage
    {
        string SuccessMessage { get; set; }
        string ErrorMessage { get; set; }
    }
}
