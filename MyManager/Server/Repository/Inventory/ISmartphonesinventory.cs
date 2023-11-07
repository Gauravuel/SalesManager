using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Inventory
{
    public interface ISmartphonesinventory
    {
        Task<SmartPhoneResponse> addPhone(SmartphoneView product);
        Task<SmartPhoneResponse> deletePhone(string id);
        Task<GetSmartphones> getPhone();
        Task<GetSmartphones> getPhoneById(SmartphoneId productId);
        Task<SmartPhoneResponse> updatePhone(SmartphoneView productView);
    }
}