using Blazored.Toast.Services;
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
    public class AddCategoryBase:ComponentBase
    {
        public CategoryView categoryView { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public CategoryResponse categoryResponse { get; set; } = new();

        public CategoryId categoryId { get; set; } = new();
        public GetCategory getCategory { get; set; } = new();
        [Inject]
        public ICategory category { get; set; }
        [Inject]
        public IToastService toastService { get; set; }

        [Parameter]
        public string Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public async Task handleSubmt()
        {
            if (string.IsNullOrEmpty(Id))
            {
                await addCategory();
            }
            else
            {
                await updateCategory();
            }
      
        }

        public async Task addCategory()
        {
            var result = await category.AddCategory(categoryView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categoryResponse = await result.Content.ReadFromJsonAsync<CategoryResponse>();
                categoryView.Name = "";
                categoryView.Description = "";
                successNotification();
            }
            else
            {
                categoryResponse = await result.Content.ReadFromJsonAsync<CategoryResponse>();
                warningNotification();
            }
        }

        public async Task updateCategory()
        {
            categoryView.Id = Id;
            var result = await category.updateCategory(categoryView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                NavigationManager.NavigateTo("/managecategory");
            }
            else
            {
                categoryResponse = await result.Content.ReadFromJsonAsync<CategoryResponse>();
                warningNotification();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                categoryId.Id = Id;
                var result = await category.getCategoryById(categoryId);
                getCategory = await result.Content.ReadFromJsonAsync<GetCategory>();
                categoryView = getCategory.Singlecategory;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }

        public void successNotification()
        {
            foreach (var msg in categoryResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in categoryResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }

    }

   
}
