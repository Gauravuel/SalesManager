using MyManager.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManager.Client.Services.CategoryServices
{
    public interface ICategory
    {
        Task<HttpResponseMessage> AddCategory(CategoryView category);
        Task<HttpResponseMessage> GetCategory();
        Task<HttpResponseMessage> getCategoryById(CategoryId categoryId);
        Task<HttpResponseMessage> updateCategory(CategoryView categoryView);
        Task<HttpResponseMessage> deleteCategory(CategoryId categoryId);
    }
}