using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.AccountServices
{
    public interface IAccount
    {
        Task<HttpResponseMessage> ForgetPassword(ForgetPasswordEmail passwordEmail);
        Task<HttpResponseMessage> Login(LoginModel login);
        Task<HttpResponseMessage> Regiter(Register register);
        Task<HttpResponseMessage> PasswordReset(ForgetPasswordCred forgetPassword);
        Task<HttpResponseMessage> ChangePassword(ChangePasswordModel changePassword);
        Task<HttpResponseMessage> Logout();
    }
}