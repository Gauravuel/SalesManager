using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Services.AccountServices
{
    public class Account : IAccount
    {
        private readonly HttpClient httpClient;

        public Account(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Login(LoginModel login)
        {
            var response = await httpClient.PostAsJsonAsync("account/login", login);
            return response;
        }
        public async Task<HttpResponseMessage> Regiter(Register register)
        {
            var response = await httpClient.PostAsJsonAsync("account/register", register);
            return response;
        }

        public async Task<HttpResponseMessage> ForgetPassword(ForgetPasswordEmail passwordEmail)
        {
            var response = await httpClient.PostAsJsonAsync("account/forgetpassword", passwordEmail);
            return response;
        }

        public async Task<HttpResponseMessage> PasswordReset(ForgetPasswordCred forgetPassword)
        {
            var response = await httpClient.PutAsJsonAsync("account/enternewpassword", forgetPassword);
            return response;
        }

        public async Task<HttpResponseMessage> ChangePassword(ChangePasswordModel changePassword)
        {
            var response = await httpClient.PostAsJsonAsync("account/changepassword", changePassword);
            return response;
        }
        public async Task<HttpResponseMessage> Logout()
        {
            var response = await httpClient.GetAsync("account/logout");
            return response;
        }

    }
}
