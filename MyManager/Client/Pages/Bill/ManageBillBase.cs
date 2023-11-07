using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BillService;
using MyManager.Client.Services.BrandServices;
using MyManager.Client.Services.DealerService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Bill
{
    public class ManageBillBase : ComponentBase
    {
        public GetBill getBill { get; set; } = new();
        [Inject]
        public IBill bill { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        BillResponse billResponse = new();


        public string billid { get; set; }


        public void setBillId(string id)
        {
            billid = id;
        }


        public async Task getBills()
        {
            var result = await bill.GetBill();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getBill = await result.Content.ReadFromJsonAsync<GetBill>();

            }
            else
            {
                getBill = await result.Content.ReadFromJsonAsync<GetBill>();
                toastService.ShowWarning(getBill.Message.FirstOrDefault());
            }
        }


        public async Task billDeleted(BillResponse response)
        {

            billResponse = response;

            if (response.Status == true)
            {
                await getBills();
                successNotification();
            }
            else
            {
                warningNotification();
            }

        }
        protected override async Task OnInitializedAsync()
        {
            await getBills();
        }

        public void successNotification()
        {
            foreach (var msg in billResponse.Message)
            {
                toastService.ShowSuccess(msg);
            }
        }

        public void warningNotification()
        {
            foreach (var msg in billResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
