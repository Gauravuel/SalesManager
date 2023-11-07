using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Bill
{
    public interface IBillrepo
    {
        Task<BillResponse> addBill(BillView billView);
        Task<BillResponse> deleteBill(string id);
        Task<GetBill> getBill();
        Task<GetBill> getBillById(BillId billId);
        Task<BillResponse> updateBill(BillView billView);
    }
}