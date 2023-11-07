using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BillService
{
    public interface IBill
    {
        Task<HttpResponseMessage> AddBill(BillView bill);
        Task<HttpResponseMessage> deleteBill(BillId billId);
        Task<HttpResponseMessage> GetBill();
        Task<HttpResponseMessage> getBillById(BillId billId);
        Task<HttpResponseMessage> updateBill(BillView billView);
    }
}