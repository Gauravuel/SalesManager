using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.SmartphoneService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Smartphones
{
    public class ManageSmartphoneBase:ComponentBase
    {
        public GetSmartphones getSmartphones { get; set; } = new();
        [Inject]
        public ISmartphone smartphone { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        SmartPhoneResponse smartPhoneResponse = new();


        public string smartphoneid { get; set; }

        public string value { get; set; }
        public List<SmartphoneView> searchedphones { get; set; } = new List<SmartphoneView>();
        public List<SmartphoneView> phone { get; set; } = new List<SmartphoneView>();
        public void setSmartphoneId(string id)
        {
            smartphoneid = id;
        }
        public async Task getSmartphone()
        {
            var result = await smartphone.GetSmartphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();

            }
            else
            {
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();
                toastService.ShowWarning(getSmartphones.Message.FirstOrDefault());
            }
        }
        public void priceascending()
        {
            getSmartphones.Smartphones =  getSmartphones.Smartphones.OrderBy(p => p.Price).ToList();
            if (searchedphones.Any())
            {
                searchedphones = searchedphones.OrderBy(p => p.Price).ToList();
            }
        }
        public void pricedescending()
        {
            getSmartphones.Smartphones = getSmartphones.Smartphones.OrderByDescending(p => p.Price).ToList();
            if (searchedphones.Any())
            {
                searchedphones = searchedphones.OrderByDescending(p => p.Price).ToList();
            }
        }
        public async Task smartphoneDeleted(SmartPhoneResponse response)
        {

            smartPhoneResponse = response;

            if (response.Status == true)
            {
                await getSmartphone();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getSmartphone();
        }


    
        public void onChange(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
        {
            searchedphones.Clear();
            if (!string.IsNullOrEmpty(value))
            {
                phone = getSmartphones.Smartphones;
                
                 searchedphones = phone.Where(s => s.Name.ToLower().Contains(value.ToLower()) || s.Ram.ToString().Contains(value) || s.Storage.ToString().Contains(value)).ToList();
                
            }
        }
        public void successNotification()
        {
            foreach (var msg in smartPhoneResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in smartPhoneResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
