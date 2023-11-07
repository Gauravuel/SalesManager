using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyManager.Client.Services.AccountServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Client.Shared.CustomLayout {
    public class CustSideNavBase: ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public SignOutSessionStateManager SignOutManager { get; set; }
        [Inject]
        public IAccount Account { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        public async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            var result = await Account.Logout();
            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Navigation.NavigateTo("/login",forceLoad:true);
            }
            else
            {
                toastService.ShowWarning("Unable to logout");
            }
           
           
        }
    }
}
