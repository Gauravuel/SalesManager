using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyManager.Server.Data;
using MyManager.Server.Models;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Category
{
    public class ProductCategory : IProductCategory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductCategory(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryResponse> addCategory(CategoryView category)
        {
            CategoryResponse categoryResponse = new();
            try
            {
                var category_data = mapper.Map<CategoryModel>(category);
                var guid_id = Guid.NewGuid().ToString();
                category_data.Id = guid_id;
                await context.Category.AddAsync(category_data);
                await context.SaveChangesAsync();
                var id = context.Category.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    categoryResponse.Status = true;
                    categoryResponse.Type = "alert-success";
                    categoryResponse.Message.Add("Category successfully added.");
                    return categoryResponse;
                }
                else
                {
                    categoryResponse.Status = false;
                    categoryResponse.Type = "alert-danger";
                    categoryResponse.Message.Add("Category can't be added.");
                    return categoryResponse;
                }

            }
            catch (Exception e)
            {

                categoryResponse.Status = false;
                categoryResponse.Type = "alert-danger";
                categoryResponse.Message.Add(e.Message);
                return categoryResponse;
            }

        }

        public async Task<GetCategory> getCategory()
        {
            GetCategory getCategory = new();
            try
            {

                var category = await context.Category.ToListAsync();
                if (category?.Any() == true)
                {
                    var map = mapper.Map<List<CategoryView>>(category);
                    getCategory.Categories = map;

                    getCategory.Status = true;
                    return getCategory;
                }
                getCategory.Status = false;
                getCategory.Message.Add("No Category available.");
                return getCategory;
            }
            catch (Exception e)
            {
                getCategory.Status = false;
                getCategory.Message.Add(e.Message);
                return getCategory;
            }
        }
        public async Task<GetCategory> getCategoryById(CategoryId categoryId)
        {
            GetCategory getCategory = new();
            try
            {

                var result = await context.Category.FindAsync(categoryId.Id);
                if (result == null)
                {
                    getCategory.Status = false;
                    getCategory.Message.Add($"No Category found with id {categoryId.Id}");
                    return getCategory;
                }
                var map = mapper.Map<CategoryView>(result);
                getCategory.Status = true;
                getCategory.Singlecategory = map;
                return getCategory;
            }
            catch (Exception e)
            {
                getCategory.Status = false;
                getCategory.Message.Add(e.Message);
                return getCategory;
            }
        }
        public async Task<CategoryResponse> updateCategory(CategoryView categoryView)
        {
            CategoryResponse categoryResponse = new();
            try
            {
                var result = await context.Category.FindAsync(categoryView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = categoryView.Name;
                    result.Description = categoryView.Description;
                    context.Category.Update(result);
                    await context.SaveChangesAsync();
                    categoryResponse.Message.Add("Category successfully updated.");
                    categoryResponse.Status = true;
                    categoryResponse.Type = "alert-success";
                    return categoryResponse;
                }
                categoryResponse.Message.Add($"Category with id {categoryView.Id} not found.");
                categoryResponse.Status = false;
                categoryResponse.Type = "alert-danger";
                return categoryResponse;

            }
            catch (Exception e)
            {
                categoryResponse.Message.Add(e.Message);
                categoryResponse.Status = false;
                categoryResponse.Type = "alert-danger";
                return categoryResponse;
            }
        }

        public async Task<CategoryResponse> deleteCategory(String id)
        {
            CategoryResponse categoryResponse = new();
            try
            {
                var category = await context.Category.FindAsync(id);
                if (category == null)
                {
                    categoryResponse.Message.Add($"Category with id {id} not found.");
                    categoryResponse.Status = false;
                    categoryResponse.Type = "alert-danger";
                    return categoryResponse;
                }
                context.Category.Remove(category);
                await context.SaveChangesAsync();
                categoryResponse.Message.Add("Category successfully Deleted.");
                categoryResponse.Status = true;
                categoryResponse.Type = "alert-success";
                return categoryResponse;
            }
            catch (Exception e)
            {
                categoryResponse.Message.Add("Cannot delete this category. This category is being used by Brands.");
                categoryResponse.Status = false;
                categoryResponse.Type = "alert-danger";
                return categoryResponse;
            }

        }
    }
}
