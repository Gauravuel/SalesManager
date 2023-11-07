using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
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
    public class ManageCaseBase:ComponentBase
    {
        public GetPhoneCase getPhoneCase { get; set; } = new();
        [Inject]
        public IPhoneCase phoneCase { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        PhoneCaseResponse phoneCaseResponse = new();


        public string phonecaseid { get; set; }

        public string value { get; set; }
        public List<PhoneCaseView> searchedcases { get; set; } = new();
        public List<PhoneCaseView> cases { get; set; } = new();
        public void setCaseId(string id)
        {
            phonecaseid = id;
        }
        public async Task getCase()
        {
            var result = await phoneCase.GetCase();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                //getPhoneCase.PhoneCases.OrderBy(p => p.Price);
            }
            else
            {
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                toastService.ShowWarning(getPhoneCase.Message.FirstOrDefault());
            }
        }

        public async Task caseDeleted(PhoneCaseResponse response)
        {

            phoneCaseResponse = response;

            if (response.Status == true)
            {
                await getCase();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getCase();
        }

        public void priceascending()
        {
            getPhoneCase.PhoneCases = getPhoneCase.PhoneCases.OrderBy(p => p.Price).ToList();
            if (searchedcases.Any())
            {
                searchedcases = searchedcases.OrderBy(p => p.Price).ToList();
            }
        }
        public void pricedescending()
        {
            getPhoneCase.PhoneCases = getPhoneCase.PhoneCases.OrderByDescending(p => p.Price).ToList();
            if (searchedcases.Any())
            {
                searchedcases = searchedcases.OrderByDescending(p => p.Price).ToList();
            }
        }

        public void onChange(Microsoft.AspNetCore.Components.Web.KeyboardEventArgs args)
        {
            searchedcases.Clear();
            if (!string.IsNullOrEmpty(value))
            {
                cases = getPhoneCase.PhoneCases;

                searchedcases = cases.Where(s => s.Name.ToLower().Contains(value.ToLower())|| s.Compatibility.ToLower().Contains(value.ToLower()) || s.CaseMaterial.ToLower().Contains(value.ToLower())).ToList();

            }
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
