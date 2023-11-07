using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BrandServices;
using MyManager.Client.Services.PhoneCaseService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.PhoneCase
{
    public class AddPhoneCaseBase: ComponentBase
    {
        public PhoneCaseView phoneCaseView { get; set; } = new();
        public GetPhoneCase getPhoneCase { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public PhoneCaseResponse phoneCaseResponse { get; set; } = new();
        [Inject]
        public IPhoneCase phoneCase { get; set; }
        [Inject]
        public IBrand brand { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string phonecaseid { get; set; }

        public GetBrand getBrand { get; set; } = new();
        public PhoneCaseId phoneCaseId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public async Task handleSubmt()
        {

            if (string.IsNullOrEmpty(phonecaseid))
            {
                await addCase();
            }
            else
            {
                await updateCase();
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


        public async Task addCase()
        {
            var result = await phoneCase.AddCase(phoneCaseView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                phoneCaseResponse = await result.Content.ReadFromJsonAsync<PhoneCaseResponse>();
                phoneCaseView.Brand_Id = "";
                phoneCaseView.CaseMaterial = "";
                phoneCaseView.Compatibility = "";
                phoneCaseView.Name = "";
                phoneCaseView.Price = 0;
                phoneCaseView.Quantity = 0;
                phoneCaseView.Transparent = "";
                phoneCaseView.Type = "";

                successNotification();
            }
            else
            {
                phoneCaseResponse = await result.Content.ReadFromJsonAsync<PhoneCaseResponse>();
                warningNotification();
            }
        }

        public async Task updateCase()
        {
            phoneCaseView.Id = phonecaseid;
            var result = await phoneCase.updateCase(phoneCaseView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/managephonecase");
            }
            else
            {
                phoneCaseResponse = await result.Content.ReadFromJsonAsync<PhoneCaseResponse>();
                warningNotification();
            }
        }
        public async Task getCase()
        {
            if (!string.IsNullOrEmpty(phonecaseid))
            {
                phoneCaseId.Id = phonecaseid;
                var result = await phoneCase.getCaseById(phoneCaseId);
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                phoneCaseView = getPhoneCase.SingleCase;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await getBrands();
            await getCase();
        }

        public void successNotification()
        {
            foreach (var msg in phoneCaseResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in phoneCaseResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
