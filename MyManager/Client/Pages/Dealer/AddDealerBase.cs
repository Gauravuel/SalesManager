using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.DealerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Dealer
{
    public class AddDealerBase : ComponentBase
    {
        public DealerView dealerView { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public DealerResponse dealerResponse { get; set; } = new();

        public DealerId dealerId { get; set; } = new();
        public GetDealer getDealer { get; set; } = new();
        [Inject]
        public IDealer dealer { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task handleSubmit()
        {
            if (string.IsNullOrEmpty(Id))
            {
                await addDealer();
            }
            else
            {
                await updateCategory();
            }
        }

        public async Task addDealer()
        {
            var result = await dealer.AddDealer(dealerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                dealerView.Name = "";
                dealerView.Adress = "";
                dealerView.Phone = "";
                successNotification();
            }
            else
            {
                dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                warningNotification();
            }
        }

        public async Task updateCategory()
        {
            dealerView.Id = Id;
            var result = await dealer.updateDealer(dealerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo("/managedealer");
            }
            else
            {
                dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                warningNotification();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                dealerId.Id = Id;
                var result = await dealer.getDealerById(dealerId);
                getDealer = await result.Content.ReadFromJsonAsync<GetDealer>();
                dealerView = getDealer.Singledealer;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }

        public void successNotification()
        {
            foreach (var msg in dealerResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in dealerResponse.Message)
            {
                toastService.ShowWarning(msg);


            }
        }
    }
}