using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
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
    public class ForgetPasswordBase: ComponentBase
    {
        public ForgetPasswordEmail ForgetPasswordEmail { get; set; } = new();
        public ForgetPasswordView forgetPasswordView { get; set; } = new();
        [Inject]
        public IToastService toastService { get; set; }

        [Inject]
        public IAccount account { get; set; }
        public async Task handleSubmit()
        {
            var result = await account.ForgetPassword(ForgetPasswordEmail);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                forgetPasswordView = await result.Content.ReadFromJsonAsync<ForgetPasswordView>();
                successNotification();
                ForgetPasswordEmail.Email = "";

            }
            else
            {
                forgetPasswordView = await result.Content.ReadFromJsonAsync<ForgetPasswordView>();
                warningNotification();
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
