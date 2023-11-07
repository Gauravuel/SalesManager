using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.CategoryServices;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Category
{
    public class ManageCategoryBase:ComponentBase
    {
        public GetCategory getCategory { get; set; } = new();
        [Inject]
        public ICategory category { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        CategoryResponse categoryResponse = new();


        public string categoryid { get; set; }


        public void setCategoryId(string id)
        {
            categoryid = id;
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
                toastService.ShowWarning(getCategory.Message.FirstOrDefault());
            }
        }

        public async Task categoryDeleted(CategoryResponse view)
        {

            categoryResponse = view;

            if (view.Status == true)
            {
                await getCategories();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }

        protected override async Task OnInitializedAsync()
        {
            await getCategories();
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
