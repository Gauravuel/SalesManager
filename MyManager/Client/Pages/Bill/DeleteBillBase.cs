using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.BillService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.Bill
{
    public class DeleteBillBase: ComponentBase
    {
        public BillResponse billResponse { get; set; } = new BillResponse();

        [Inject]
        public IBill bill { get; set; }

        [Parameter]
        public string billid { get; set; }
        public BillId BillId { get; set; } = new();

        [Parameter]
        public EventCallback<BillResponse> onDelete { get; set; }



        public async Task deleteBill()
        {
            BillId.Id = billid;
            var result = await bill.deleteBill(BillId);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                billResponse = await result.Content.ReadFromJsonAsync<BillResponse>();
                await onDelete.InvokeAsync(billResponse);

            }
            else
            {
                billResponse = await result.Content.ReadFromJsonAsync<BillResponse>();
                await onDelete.InvokeAsync(billResponse);
            }
        }
    }
}
