using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.CategoryServices;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Category
{
    public class DeleteCategoryBase: ComponentBase

    {
        public CategoryResponse categoryResponse { get; set; } = new CategoryResponse();

        [Inject]
        public ICategory category { get; set; }

        [Parameter]
        public string categoryid { get; set; }
        public CategoryId categoryId { get; set; } = new();

        [Parameter]
        public EventCallback<CategoryResponse> onDelete { get; set; }


        public async Task deletecategory()
        { 
            categoryId.Id = categoryid;
            var result = await category.deleteCategory(categoryId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categoryResponse = await result.Content.ReadFromJsonAsync<CategoryResponse>();
                await onDelete.InvokeAsync(categoryResponse);

            }
            else
            {
                categoryResponse = await result.Content.ReadFromJsonAsync<CategoryResponse>();
                await onDelete.InvokeAsync(categoryResponse);
            }
        }
    }
}
