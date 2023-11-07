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
    public class NewPasswordBase: ComponentBase
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IAccount account { get; set; }

        public ForgetPasswordView forgetPasswordView = new ForgetPasswordView();

        public string uid { get; set; }

        public string passwordresettoken { get; set; }
        public ForgetPasswordCred forgetPasswordCred { get; set; } = new();
        [Inject]
        public IToastService toastService { get; set; }
        public async Task handleSubmit()
        {
            forgetPasswordCred.Id = uid;
            forgetPasswordCred.Token = passwordresettoken;
            var result = await account.PasswordReset(forgetPasswordCred);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                forgetPasswordView = await result.Content.ReadFromJsonAsync<ForgetPasswordView>();
                successNotification();
                navigationManager.NavigateTo("/login");
            }
            else
            {
                forgetPasswordView = await result.Content.ReadFromJsonAsync<ForgetPasswordView>();
                warningNotification();
            }
        }


        //Getting query parameters from the url
        protected override void OnInitialized()
        {
            var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri); //you can use IURIHelper for older versions

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("token", out var token))
            {
                passwordresettoken = token.First();
            }

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("uid", out var userid))
            {
                uid = userid.First();
            }
        }
        public void warningNotification()
        {
            toastService.ShowWarning(forgetPasswordView.Message);
        }
        public void successNotification()
        {
            toastService.ShowSuccess(forgetPasswordView.Message);
        }
    }
}
