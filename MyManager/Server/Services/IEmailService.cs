using MyManager.Server.Models;
using System.Threading.Tasks;

namespace MyManager.Server.Services
{
    public interface IEmailService
    {
        Task sendAccountconfirmationLink(EmailCred cred);
        Task sendChangeEmail(EmailCred cred);
        Task sendForgetPasswordEmail(EmailCred cred);
    }
}