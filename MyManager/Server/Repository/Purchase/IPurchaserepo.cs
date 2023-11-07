using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Purchase
{
    public interface IPurchaserepo
    {
        Task<PurchaseResponse> addPurchase(PurchaseView purchase);
        //Task<PurchaseResponse> deletePurchase(string id);
        Task<GetPurchase> getPurchase();
        Task<GetPurchase> getPurchaseById(CustomerId customerId);
        Task<GetPurchase> getPurchaseProduct(PurchaseId purchaseId);
        Task<GetCustomerCredit> getCustomerCredit();
        Task<CustomerCreditResponse> removecredit(string id);
        Task<GetGroupedPurchase> getGroupByPurchase();
        Task<GetTopPurchase> getTopPurchase();
        //Task<PurchaseResponse> updatePurchase(PurchaseView purchaseView);
    }
}