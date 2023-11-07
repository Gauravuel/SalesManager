using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
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
    public class ManageChargerBase: ComponentBase
    {
        public GetCharger getCharger { get; set; } = new();
        [Inject]
        public ICharger charger { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        ChargerResponse chargerResponse = new();


        public string chargerid { get; set; }

        public string value { get; set; }
        public List<ChargerView> searchedcharger { get; set; } = new();
        public List<ChargerView> chargers{ get; set; } = new();
        public void setChargerId(string id)
        {
            chargerid = id;
        }

        public async Task getChargers()
        {
            var result = await charger.GetCharger();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();

            }
            else
            {
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();
                toastService.ShowWarning(getCharger.Message.FirstOrDefault());
            }
        }
        public async Task chargerDeleted(ChargerResponse response)
        {

            chargerResponse = response;

            if (response.Status == true)
            {
                await getChargers();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getChargers();
        }

        public void priceascending()
        {
            getCharger.Chargers = getCharger.Chargers.OrderBy(p => p.Price).ToList();
            if (searchedcharger.Any())
            {
                searchedcharger = searchedcharger.OrderBy(p => p.Price).ToList();
            }
        }
        public void pricedescending()
        {
            getCharger.Chargers = getCharger.Chargers.OrderByDescending(p => p.Price).ToList();
            if (searchedcharger.Any())
            {
                searchedcharger = searchedcharger.OrderByDescending(p => p.Price).ToList();
            }
        }

        public void onChange(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
        {
            searchedcharger.Clear();
            if (!string.IsNullOrEmpty(value))
            {
                chargers = getCharger.Chargers;

                //searchedcharger = chargers.Where(s => s.Name.ToLower().Contains(value.ToLower())).ToList();

            }
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
