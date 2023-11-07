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
    public class AddUserBase: ComponentBase
    {

        public Register register { get; set; } = new();
        [Inject]
        public IAccount account { get; set; }

        public RegisterViewModel registerView { get; set; } = new();
        [Inject]
        public IToastService toastService { get; set; }

        public async Task addNewUser()
        {
            
            var result = await account.Regiter(register);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                registerView = await result.Content.ReadFromJsonAsync<RegisterViewModel>();
                successNotification();
                //id = adminregistercustomer.id;
                //NavigationManager.NavigateTo("/customerroles/" + id);

            }
            else
            {
                registerView = await result.Content.ReadFromJsonAsync<RegisterViewModel>();
                warningNotification();
            }
        }

        public void successNotification()
        {
            foreach (var msg in registerView.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in registerView.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
