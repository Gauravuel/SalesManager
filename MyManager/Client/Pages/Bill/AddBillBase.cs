using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BillService;
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
    public class AddBillBase : ComponentBase
    {
        public BillView billView { get; set; } = new();
        public string DynamicLabel { get; set; } = "Add";
        public BillResponse billResponse { get; set; } = new();
        [Inject]
        public IBill bill { get; set; }
        [Inject]
        public IDealer dealer { get; set; }
        [Inject]
        public IToastService toastService { get; set; }
        [Parameter]
        public string billid { get; set; }

        public GetBill getBill { get; set; } = new();
        public GetDealer getDealer { get; set; } = new();
        public BillId billId { get; set; } = new();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public async Task handleSubmt()
        {
         

            if (string.IsNullOrEmpty(billid))
            {
                await addBill();
            }
            else
            {
                await updateBill();
            }
        }
        public async Task addBill()
        {
            var result = await bill.AddBill(billView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                billResponse = await result.Content.ReadFromJsonAsync<BillResponse>();
                billView.BillNo = 0;
                billView.Dealer_Id = "";
                billView.Checkout_Date = DateTime.UtcNow;
                successNotification();
            }
            else
            {
                billResponse = await result.Content.ReadFromJsonAsync<BillResponse>();
                warningNotification();
            }
        }

        public async Task updateBill()
        {
            billView.Id = billid;
            var result = await bill.updateBill(billView);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                navigationManager.NavigateTo("/managebill");
            }
            else
            {
                billResponse = await result.Content.ReadFromJsonAsync<BillResponse>();
                warningNotification();
            }
        }
        public async Task getBills()
        {
            if (!string.IsNullOrEmpty(billid))
            {
                billId.Id = billid;
                var result = await bill.getBillById(billId);
                getBill = await result.Content.ReadFromJsonAsync<GetBill>();
                billView = getBill.Singlebill;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DynamicLabel = "Edit";
                }
            }
        }
        public async Task getDealers()
        {
            var result = await dealer.GetDealer();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getDealer = await result.Content.ReadFromJsonAsync<GetDealer>();

            }
            else
            {
                getDealer = await result.Content.ReadFromJsonAsync<GetDealer>();

            }
        }

        protected override async Task OnInitializedAsync()
        {
            await getDealers();
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
