using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
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
    public class AddHeadphoneBase:ComponentBase
    {
        public HeadphoneView headphoneView { get; set; } = new();
        public GetHeadphone getHeadphone { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public HeadphoneResponse headphoneResponse { get; set; } = new();
        [Inject]
        public IHeadphone headphone { get; set; }
        [Inject]
        public IBrand brand { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string headphoneid { get; set; }

        public GetBrand getBrand { get; set; } = new();
        public HeadphoneId headphoneId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public async Task handleSubmt()
        {

            if (string.IsNullOrEmpty(headphoneid))
            {
                await addHeadphone();
            }
            else
            {
                await updateHeadphone();
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


        public async Task addHeadphone()
        {
            var result = await headphone.AddHeadphone(headphoneView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                headphoneResponse = await result.Content.ReadFromJsonAsync<HeadphoneResponse>();
                headphoneView.Name = "";
                headphoneView.Type = "";
                headphoneView.Brand_Id = "";
                headphoneView.Quantity = 0;
                headphoneView.Price = 0;
                successNotification();
            }
            else
            {
                headphoneResponse = await result.Content.ReadFromJsonAsync<HeadphoneResponse>();
                warningNotification();
            }
        }
        public async Task updateHeadphone()
        {
            headphoneView.Id = headphoneid;
            var result = await headphone.updateHeadphone(headphoneView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/manageheadphone");
            }
            else
            {
                headphoneResponse = await result.Content.ReadFromJsonAsync<HeadphoneResponse>();
                warningNotification();
            }
        }
        public async Task getHeadphones()
        {
            if (!string.IsNullOrEmpty(headphoneid))
            {
                headphoneId.Id = headphoneid;
                var result = await headphone.getHeadphoneById(headphoneId);
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();
                headphoneView = getHeadphone.SingleHeadphone;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await getBrands();
            await getHeadphones();
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
