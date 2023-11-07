using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Brand
{
    public class DeleteBrandBase : ComponentBase
    {
        public BrandResponse brandResponse { get; set; } = new BrandResponse();

        [Inject]
        public IBrand brand { get; set; }

        [Parameter]
        public string brandid { get; set; }
        public BrandId BrandId { get; set; } = new();

        [Parameter]
        public EventCallback<BrandResponse> onDelete { get; set; }


        public async Task deleteBrand()
        {
            BrandId.Id = brandid;
            var result = await brand.deleteBrand(BrandId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                brandResponse = await result.Content.ReadFromJsonAsync<BrandResponse>();
                await onDelete.InvokeAsync(brandResponse);

            }
            else
            {
                brandResponse = await result.Content.ReadFromJsonAsync<BrandResponse>();
                await onDelete.InvokeAsync(brandResponse);
            }
        }
    }
}
