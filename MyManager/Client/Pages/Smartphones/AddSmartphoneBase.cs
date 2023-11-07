using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
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
    public class AddSmartphoneBase: ComponentBase
    {
        public SmartphoneView smartphoneView { get; set; } = new();
        public GetSmartphones getSmartphones { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public SmartPhoneResponse smartPhoneResponse { get; set; } = new();
        [Inject]
        public ISmartphone smartphone { get; set; }
        [Inject]
        public IBrand brand { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string smartphoneid { get; set; }
     
        public GetBrand getBrand { get; set; } = new();
        public SmartphoneId smartphoneId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public async Task handleSubmt()
        {

            if (string.IsNullOrEmpty(smartphoneid))
            {  
                await addSmartphone();
            }
            else
            {
                await updateSmartphone();
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


        public async Task addSmartphone()
        {
            var result = await smartphone.AddSmartphone(smartphoneView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                smartPhoneResponse = await result.Content.ReadFromJsonAsync<SmartPhoneResponse>();
                smartphoneView.Brand_Id = "";
                smartphoneView.Color = "";
                smartphoneView.Cpu = "";
                smartphoneView.Display = "";
                smartphoneView.Name = "";
                smartphoneView.Price = 0;
                smartphoneView.Quantity = 0;
                smartphoneView.Ram = 0;
                smartphoneView.Storage = 0;
               
                successNotification();
            }
            else
            {
                smartPhoneResponse = await result.Content.ReadFromJsonAsync<SmartPhoneResponse>();
                warningNotification();
            }
        }
        public async Task updateSmartphone()
        {
            smartphoneView.Id = smartphoneid;
            var result = await smartphone.updateSmartphone(smartphoneView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/managesmartphone");
            }
            else
            {
                smartPhoneResponse = await result.Content.ReadFromJsonAsync<SmartPhoneResponse>();
                warningNotification();
            }
        }
        public async Task getSmartphone()
        {
            if (!string.IsNullOrEmpty(smartphoneid))
            {
                smartphoneId.Id = smartphoneid;
                var result = await smartphone.getSmartphoneById(smartphoneId);
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();
                smartphoneView = getSmartphones.Singleproduct;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await getBrands();
            await getSmartphone();
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
 