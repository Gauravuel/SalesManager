using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.BillProduct
{
    public interface IBillProductrepo
    {
        Task<GetBillProduct> GetProducts(BillId billId);
    }
}