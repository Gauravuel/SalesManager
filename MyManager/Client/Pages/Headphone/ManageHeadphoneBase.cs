using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.HeadPhoneService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Headphone
{
    public class ManageHeadphoneBase:ComponentBase
    {
        public GetHeadphone getHeadphone { get; set; } = new();
        [Inject]
        public IHeadphone headphone { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        HeadphoneResponse headphoneResponse = new();


        public string headphoneid { get; set; }

        public string value { get; set; }
        public List<HeadphoneView> searchedheadphone { get; set; } = new();
        public List<HeadphoneView> headphones { get; set; } = new();
        public void setHeadphoneId(string id)
        {
            headphoneid = id;
        }
        public async Task getHeadphones()
        {
            var result = await headphone.GetHeadphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();

            }
            else
            {
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();
                toastService.ShowWarning(getHeadphone.Message.FirstOrDefault());
            }
        }
        public async Task headphoneDeleted(HeadphoneResponse response)
        {

            headphoneResponse = response;

            if (response.Status == true)
            {
                await getHeadphones();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getHeadphones();
        }

        public void priceascending()
        {
            getHeadphone.Headphones = getHeadphone.Headphones.OrderBy(p => p.Price).ToList();
            if (searchedheadphone.Any())
            {
                searchedheadphone = searchedheadphone.OrderBy(p => p.Price).ToList();
            }
        }
        public void pricedescending()
        {
            getHeadphone.Headphones = getHeadphone.Headphones.OrderByDescending(p => p.Price).ToList();
            if (searchedheadphone.Any())
            {
                searchedheadphone = searchedheadphone.OrderByDescending(p => p.Price).ToList();
            }
        }

        public void onChange(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
        {
            searchedheadphone.Clear();
            if (!string.IsNullOrEmpty(value))
            {
                headphones = getHeadphone.Headphones;

                searchedheadphone = headphones.Where(s => s.Name.ToLower().Contains(value.ToLower())).ToList();

            }
        }

        public void successNotification()
        {
            foreach (var msg in headphoneResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in headphoneResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
