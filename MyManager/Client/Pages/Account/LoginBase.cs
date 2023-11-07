using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using MyManager.Client.Services.AccountServices;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Account
{
    public class LoginBase:ComponentBase
    {

        public LoginModel Login { get; set; } = new LoginModel();
        public LoginResponse loginViewModel { get; set; } = new LoginResponse();
        [Inject]
        public IAccount Account { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        public string redirectUrl { get; set; }
        public string absoluteUrl { get; set; }

        public async Task HandleLogin()
        {
            var result = await Account.Login(Login);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    NavigationManager.NavigateTo(redirectUrl, true);
                }
                else
                {
                    NavigationManager.NavigateTo("/", true);
                }
            }
            else
            {
                loginViewModel = await result.Content.ReadFromJsonAsync<LoginResponse>();
                warningNotification();
                //if (!string.IsNullOrEmpty(redirectUrl))
                //{
                //    NavigationManager.NavigateTo(redirectUrl);
                //}           
            }

        }

        protected override void OnInitialized()
        {
            absoluteUrl = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).AbsoluteUri;
            var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var param))
            {
                redirectUrl = param.First();
            }
        }

        public void warningNotification()
        {
            toastService.ShowWarning(loginViewModel.Message);
        }
    }
}
