using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Category
{
    public interface IProductCategory
    {
        Task<CategoryResponse> addCategory(CategoryView category);
       Task<GetCategory> getCategory();
        Task<CategoryResponse> updateCategory(CategoryView categoryView);
        Task<GetCategory> getCategoryById(CategoryId categoryId);
        Task<CategoryResponse> deleteCategory(String id);
    }
}