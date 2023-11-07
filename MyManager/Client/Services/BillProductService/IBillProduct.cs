using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.BillProductService
{
    public interface IBillProduct
    {
        Task<HttpResponseMessage> GetBillProduct(BillId billId);
    }
}