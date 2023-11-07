using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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
    public class ChangePasswordBase: ComponentBase
    {
        public ChangePasswordModel changePasswordModel { get; set; } = new ChangePasswordModel();
        public ChangePasswordView changePasswordView { get; set; } = new ChangePasswordView();
        [Inject]
        public IAccount account { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState> authenticationState { get; set; }
        public async void handleSubmit()
        {
            var user = authenticationState.Result.User;
            if (user.Identity.IsAuthenticated)
            {
                var username = authenticationState.Result.User.Identity.Name;
                changePasswordModel.userEmail = username;

                var result = await account.ChangePassword(changePasswordModel);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    changePasswordView = await result.Content.ReadFromJsonAsync<ChangePasswordView>();
                    foreach (var msg in changePasswordView.Message)
                    {
                        toastService.ShowSuccess(msg);
                        NavigationManager.NavigateTo("/");
                    }


                }
                else
                {
                    changePasswordView = await result.Content.ReadFromJsonAsync<ChangePasswordView>();
                    foreach (var msg in changePasswordView.Message)
                    {
                        toastService.ShowWarning(msg);
                    }
                }
            }
        }
    }
}
