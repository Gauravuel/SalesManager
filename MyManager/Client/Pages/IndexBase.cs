using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyManager.Client.Services.ChargerService;
using MyManager.Client.Services.HeadPhoneService;
using MyManager.Client.Services.PhoneCaseService;
using MyManager.Client.Services.PurchaseService;
using MyManager.Client.Services.SmartphoneService;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages
{
    public class IndexBase: ComponentBase
    {
        [Inject]
        public ISmartphone smartphone { get; set; }
        public GetSmartphones getSmartphones { get; set; } = new();

        [Inject]
        public IHeadphone headphone { get; set; }
        public GetHeadphone getHeadphone { get; set; } = new();

        [Inject]
        public ICharger charger { get; set; }
        public GetCharger getCharger { get; set; } = new();

        [Inject]
        public IPhoneCase phoneCase { get; set; }
        public GetPhoneCase getPhoneCase { get; set; } = new();
    

        [Inject]
        public IPurchase purchase { get; set; }
        public GetGroupedPurchase getGroupedPurchase { get; set; } = new();
        public GetTopPurchase getTopPurchase { get; set; } = new();

        [Inject]
        public IJSRuntime jsRuntime { get; set; }
        public IJSObjectReference objectReference { get; set; }
       

        public int smartphonecount = 0;
        public int headphonecount = 0;
        public int phonecasecount = 0;
        public int chargercount = 0;
        public int productscount = 0;
        public async Task getSmartphone()
        {
            var result = await smartphone.GetSmartphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();
                if (getSmartphones.Smartphones.Any())
                {
                    smartphonecount = getSmartphones.Smartphones.Count();
                }             
            }      
        }
        public async Task getHeadphones()
        {
            var result = await headphone.GetHeadphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();
                if (getHeadphone.Headphones.Any())
                {
                    headphonecount = getHeadphone.Headphones.Count();
                }
            }
        }

        public async Task getChargers()
        {
            var result = await charger.GetCharger();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();
                if (getCharger.Chargers.Any())
                {
                    chargercount = getCharger.Chargers.Count();
                }
            }
        }
        public async Task getPhonecase()
        {
            var result = await phoneCase.GetCase();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                if (getHeadphone.Headphones.Any())
                {
                    phonecasecount = getPhoneCase.PhoneCases.Count();
                }
            }
        }

        public async Task getGroupedpurchase()
        {
            var result = await purchase.GetGroupedPurchase();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getGroupedPurchase = await result.Content.ReadFromJsonAsync<GetGroupedPurchase>();
                if (getGroupedPurchase.Dates.Any() && getGroupedPurchase.Amount.Any())
                {
                   await getchart(getGroupedPurchase.Amount, getGroupedPurchase.Dates);
                }
            }
        }

        public async Task getTopPurchases()
        {
            var result = await purchase.GetTopPurchase();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getTopPurchase = await result.Content.ReadFromJsonAsync<GetTopPurchase>();

            }
            else
            {
                getTopPurchase = await result.Content.ReadFromJsonAsync<GetTopPurchase>();
            }
        }



        public async Task getchart(List<int> amount, List<string> date)
        {
            objectReference = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/chart.js");
            await objectReference.InvokeVoidAsync("showChart", amount, date);
        }



        protected override async Task OnInitializedAsync()
        {
            await getSmartphone();
            await getHeadphones();
            await getPhonecase();
            await getChargers();
            productscount = smartphonecount + chargercount + headphonecount + phonecasecount;
            await getGroupedpurchase();
            await getTopPurchases();

        }

    }
}
