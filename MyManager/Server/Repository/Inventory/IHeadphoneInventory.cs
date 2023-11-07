using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Inventory
{
    public interface IHeadphoneInventory
    {
        Task<HeadphoneResponse> addHeadphone(HeadphoneView headphoneView);
        Task<HeadphoneResponse> deleteHeadphone(string id);
        Task<GetHeadphone> getHeadphone();
        Task<GetHeadphone> getHeadphoneById(HeadphoneId headphoneId);
        Task<HeadphoneResponse> updateHeadphone(HeadphoneView headphoneView);
    }
}