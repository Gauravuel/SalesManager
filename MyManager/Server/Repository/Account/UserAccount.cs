using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MyManager.Server.Models;
using MyManager.Server.Services;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Account
{
    public class UserAccount : IUserAccount
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration config;
        private readonly IEmailService emailService;

        public UserAccount(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config, IEmailService emailService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.config = config;
            this.emailService = emailService;
        }

        public async Task<LoginResponse> Login(LoginModel login) /*This method is responsible for users login*/
        {
            LoginResponse loginResponse = null;
            try
            {
                loginResponse = new LoginResponse();

                var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

                if (result.Succeeded)
                {
                    loginResponse.Status = true;
                    loginResponse.Message = "success Login";
                    loginResponse.Type = "alert-success";
                    return loginResponse;
                }

                loginResponse.Status = false;
                loginResponse.Message = "Invalid Login attempt.";
                loginResponse.Type = "alert-warning";
                return loginResponse;
            }
            catch (Exception ex)
            {
                loginResponse.Status = false;
                loginResponse.Message = ex.Message;
                loginResponse.Type = "alert-warning";
                return loginResponse;
            }
        }
        public async Task<RegisterViewModel> Register(Register userdetails) /*THis method is responsible to register the user in database*/
        {
            var resp = new RegisterViewModel();
            try
            {

                var duplicate = userManager.FindByEmailAsync(userdetails.Email);

                if (duplicate.Result != null)
                {
                    resp.status = false;
                    resp.Message.Add("Email already in use.");
                    resp.type = "alert-danger";
                    return resp;
                }
                var user = new ApplicationUser()
                {
                    Email = userdetails.Email,
                    UserName = userdetails.Email,
                };
                var result = await userManager.CreateAsync(user, userdetails.Password);

                if (result.Succeeded)
                {
                    var userdata = userManager.FindByEmailAsync(userdetails.Email);
                    resp.status = true;
                    resp.Message.Add("Registration success.Please check your email to confirm your account");
                    resp.type = "alert-success";
                    resp.id = userdata.Result.Id;
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (!string.IsNullOrEmpty(token))
                    {

                        await sendEmailConfirmationEmail(user, token);

                    }
                    return resp;
                }
                else
                {
                    resp.status = false;
                    resp.type = "alert-warning";
                    foreach (var errormessage in result.Errors)
                    {
                        resp.Message.Add(errormessage.Description);
                    };

                }

                return resp;
            }
            catch (Exception e)
            {
                resp.status = false;
                resp.Message.Add(e.Message);
                resp.type = "alert-danger";
                return resp;
            }
        }

        public async Task sendEmailConfirmationEmail(ApplicationUser user, string token)
        {
            string domain = config.GetSection("Application:AppDomain").Value;
            string confirmationLink = config.GetSection("Application:EmailConfirmation").Value;
            EmailCred options = new EmailCred
            {
                Email = user.Email,
                DynamicData = new List<KeyValuePair<string, string>>(){
                    new KeyValuePair<string, string>("{{Username}}", user.Email),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(domain+confirmationLink,user.Id,token))
                }
            };
            await emailService.sendAccountconfirmationLink(options);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(String id, string token)
        {
            return await userManager.ConfirmEmailAsync(await userManager.FindByIdAsync(id), token);
        }


        public async Task<ApplicationUser> ForgetPasswordUserCheck(ForgetPasswordEmail cred)
        {
            var user = await userManager.FindByEmailAsync(cred.Email);
            return user;
        }

        public async Task GenerateForgetPasswordTokenAsync(ApplicationUser user)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await sendForgetPasswordEmail(user, token);
            };
        }

        public async Task sendForgetPasswordEmail(ApplicationUser user, string token)
        {
            string domain = config.GetSection("Application:BlazorDomain").Value;
            string confirmationLink = config.GetSection("Application:ForgetPassword").Value;
            EmailCred options = new EmailCred
            {
                Email = user.Email,
                DynamicData = new List<KeyValuePair<string, string>>(){
                    new KeyValuePair<string, string>("{{Username}}", user.Email),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(domain+confirmationLink,user.Id,token))
                }
            };
            await emailService.sendForgetPasswordEmail(options);
        }
        public async Task<ForgetPasswordView> ResetPassword(ForgetPasswordCred details)
        {
            ForgetPasswordView forgetPasswordView = new ForgetPasswordView();
            var result = await userManager.ResetPasswordAsync(await userManager.FindByIdAsync(details.Id), details.Token, details.Password);
           
            if (result.Succeeded)
            {
                forgetPasswordView.Status = true;
                forgetPasswordView.Type = "alert-success";
                forgetPasswordView.Message = "Password successfully reset.";
                return forgetPasswordView;
            }
            forgetPasswordView.Status = false;
            forgetPasswordView.Type = "alert-danger";
            forgetPasswordView.Message = "Unable to reset password.";
            return forgetPasswordView;
        }
        public async Task<ChangePasswordView> changePassword(ChangePasswordModel details)
        {
            ChangePasswordView changePassword = new ChangePasswordView();
            if (string.IsNullOrEmpty(details.userEmail))
            {
                changePassword.Status = false;
                changePassword.Type = "alert-danger";
                changePassword.Message.Add("User not logged in!!.");
                return changePassword;
            }

            if (!string.IsNullOrEmpty(details.userEmail))
            {
                var user = await userManager.FindByEmailAsync(details.userEmail);
                var result = await userManager.ChangePasswordAsync(user, details.PrevPassword, details.Password);
                if (result.Succeeded)
                {
                    changePassword.Status = true;
                    changePassword.Type = "alert-success";
                    changePassword.Message.Add("Password Successfully Changed.");
                    return changePassword;
                }
            }
            changePassword.Status = false;
            changePassword.Type = "alert-warning";
            changePassword.Message.Add("Unable to change Password");
            return changePassword;
        }

        public async Task Logout()
        { 
          
            await signInManager.SignOutAsync();
           
        }

    }
}
