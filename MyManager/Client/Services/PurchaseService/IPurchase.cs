using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.PurchaseService
{
    public interface IPurchase
    {
        Task<HttpResponseMessage> AddPurchase(PurchaseView purchaseView);
        Task<HttpResponseMessage> GetPurchaseById(CustomerId customerId);
        Task<HttpResponseMessage> GetPurchaseProduct(PurchaseId purchaseId);
        Task<HttpResponseMessage> GetCustomerCredit();
        Task<HttpResponseMessage> DeleteCredit(CreditId creditId);
        Task<HttpResponseMessage> GetGroupedPurchase();
        Task<HttpResponseMessage> GetTopPurchase();
    }
}