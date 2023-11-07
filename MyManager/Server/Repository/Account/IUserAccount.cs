using Microsoft.AspNetCore.Identity;
using MyManager.Server.Models;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Account
{
    public interface IUserAccount
    {
        Task<ApplicationUser> ForgetPasswordUserCheck(ForgetPasswordEmail cred);
        Task GenerateForgetPasswordTokenAsync(ApplicationUser user);
        Task<LoginResponse> Login(LoginModel login);
        Task<RegisterViewModel> Register(Register userdetails);
        Task<ForgetPasswordView> ResetPassword(ForgetPasswordCred details);
        Task sendEmailConfirmationEmail(ApplicationUser user, string token);
        Task<IdentityResult> ConfirmEmailAsync(string id, string token);
        Task sendForgetPasswordEmail(ApplicationUser user, string token);
        Task<ChangePasswordView> changePassword(ChangePasswordModel details);
        Task Logout();
    }
}