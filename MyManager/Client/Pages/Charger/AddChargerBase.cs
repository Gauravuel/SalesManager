using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
using MyManager.Client.Services.ChargerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Charger
{
    public class AddChargerBase: ComponentBase
    {
        public ChargerView chargerView { get; set; } = new();
        public GetCharger getCharger { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public ChargerResponse chargerResponse { get; set; } = new();
        [Inject]
        public ICharger charger { get; set; }
        [Inject]
        public IBrand brand { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string chargerid { get; set; }

        public GetBrand getBrand { get; set; } = new();
        public ChargerId chargerId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public async Task handleSubmt()
        {

            if (string.IsNullOrEmpty(chargerid))
            {
                await addCharger();
            }
            else
            {
                await updateCharger();
            }
        }
        public async Task getBrands()
        {
            var result = await brand.GetBrand();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getBrand = await result.Content.ReadFromJsonAsync<GetBrand>();

            }
            else
            {
                getBrand = await result.Content.ReadFromJsonAsync<GetBrand>();
                toastService.ShowWarning(getBrand.Message.FirstOrDefault());
            }
        }


        public async Task addCharger()
        {
            var result = await charger.AddCharger(chargerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                chargerResponse = await result.Content.ReadFromJsonAsync<ChargerResponse>();
                chargerView.Chargername = "";
                chargerView.Fast_Charging = "";
                chargerView.Port = 0;
                chargerView.Price = 0;
                chargerView.Quantity = 0;
                chargerView.Brand_Id = "";
                successNotification();
            }
            else
            {
                chargerResponse = await result.Content.ReadFromJsonAsync<ChargerResponse>();
                warningNotification();
            }
        }


        public async Task updateCharger()
        {
            chargerView.Id = chargerid;
            var result = await charger.updateCharger(chargerView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/managecharger");
            }
            else
            {
                chargerResponse = await result.Content.ReadFromJsonAsync<ChargerResponse>();
                warningNotification();
            }
        }
        public async Task getChargers()
        {
            if (!string.IsNullOrEmpty(chargerid))
            {
                chargerId.Id = chargerid;
                var result = await charger.getChargerById(chargerId);
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();
                chargerView = getCharger.SingleCharger;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await getBrands();
            await getChargers();
        }

        public void successNotification()
        {
            foreach (var msg in chargerResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in chargerResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
