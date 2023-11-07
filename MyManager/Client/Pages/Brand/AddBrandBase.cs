using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
using MyManager.Client.Services.CategoryServices;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Brand
{
    public class AddBrandBase: ComponentBase
    {
        public BrandView brandView { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public BrandResponse brandResponse { get; set; } = new();
        [Inject]
        public IBrand brand { get; set; }
        [Inject]
        public ICategory category { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string brandid { get; set; }

        public GetCategory getCategory { get; set; } = new();
        public GetBrand getBrand { get; set; } = new();
        public BrandId brandId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public async Task handleSubmt()
        {
          
            if (string.IsNullOrEmpty(brandid))
            {
                await addBrand();
            }
            else
            {
                await updateBrand();
            }
        }

        public async Task addBrand()
        {
            var result = await brand.AddBrand(brandView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                brandResponse = await result.Content.ReadFromJsonAsync<BrandResponse>();
                brandView.Name = "";
                brandView.Description = "";
                brandView.Cat_id = "";
                successNotification();
            }
            else
            {
                brandResponse = await result.Content.ReadFromJsonAsync<BrandResponse>();
                warningNotification();
            }
        }
        public async Task updateBrand()
        {
            brandView.Id = brandid;
            var result = await brand.updateBrand(brandView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/managebrand");
            }
            else
            {
                brandResponse = await result.Content.ReadFromJsonAsync<BrandResponse>();
                warningNotification();
            }
        }

        public async Task getBrands()
        {
            if (!string.IsNullOrEmpty(brandid))
            {
                brandId.Id = brandid;
                var result = await brand.getBrandById(brandId);
                getBrand = await result.Content.ReadFromJsonAsync<GetBrand>();
                brandView = getBrand.Singlebrand;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }
      

        public async Task getCategories()
        {
            var result = await category.GetCategory();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCategory = await result.Content.ReadFromJsonAsync<GetCategory>();

            }
            else
            {
                getCategory = await result.Content.ReadFromJsonAsync<GetCategory>();
              
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await getCategories();
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
