using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Brand
{
    public class ManageBrandBase : ComponentBase
    {
        public GetBrand getBrand { get; set; } = new();
        [Inject]
        public IBrand brand { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        BrandResponse brandResponse = new();


        public string brandid { get; set; }


        public void setBrandId(string id)
        {
            brandid = id;
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

        public async Task brandDeleted(BrandResponse response)
        {

            brandResponse = response;

            if (response.Status == true)
            {
                await getBrands();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }

        protected override async Task OnInitializedAsync()
        {
            await getBrands();
        }

        public void successNotification()
        {
            foreach (var msg in brandResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in brandResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
