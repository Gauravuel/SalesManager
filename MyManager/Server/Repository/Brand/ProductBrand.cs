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

namespace MyManager.Server.Repository.Brand
{
    public class ProductBrand : IProductBrand
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductBrand(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BrandResponse> addBrand(BrandView brand)
        {
            BrandResponse brandResponse = new();
            try
            {
                var brand_data = mapper.Map<BrandModel>(brand);
                var guid_id = Guid.NewGuid().ToString();
                brand_data.Id = guid_id;
                await context.Brand.AddAsync(brand_data);
                await context.SaveChangesAsync();
                var id = context.Brand.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    brandResponse.Status = true;
                    brandResponse.Type = "alert-success";
                    brandResponse.Message.Add("Brand successfully added.");
                    return brandResponse;
                }
                else
                {
                    brandResponse.Status = false;
                    brandResponse.Type = "alert-danger";
                    brandResponse.Message.Add("Brand can't be added.");
                    return brandResponse;
                }

            }
            catch (Exception e)
            {

                brandResponse.Status = false;
                brandResponse.Type = "alert-danger";
                brandResponse.Message.Add(e.Message);
                return brandResponse;
            }

        }

        public async Task<GetBrand> getBrand()
        {
            GetBrand getBrand = new();
            try
            {

                var brands = await context.Brand.ToListAsync();
               
                if (brands?.Any() == true)
                {

                    var map = mapper.Map<List<BrandView>>(brands);
                    foreach(BrandView brand in map)
                    {
                        string catname = context.Category.Where(c => c.Id == brand.Cat_id).FirstOrDefault().Name;
                        brand.Category_Name = catname;
                    }
                    getBrand.Brands = map;              
                    getBrand.Status = true;
                    return getBrand;
                }
                getBrand.Status = false;
                getBrand.Message.Add("No brand available.");
                return getBrand;
            }
            catch (Exception e)
            {
                getBrand.Status = false;
                getBrand.Message.Add(e.Message);
                return getBrand;
            }
        }
        public async Task<GetBrand> getBrandById(BrandId brandId)
        {
            GetBrand getBrand = new();
            try
            {

                var result = await context.Brand.FindAsync(brandId.Id);
                if (result == null)
                {
                    getBrand.Status = false;
                    getBrand.Message.Add($"No brand found with id {brandId.Id}");
                    return getBrand;
                }
                var map = mapper.Map<BrandView>(result);
                getBrand.Status = true;
                getBrand.Singlebrand = map;
                return getBrand;
            }
            catch (Exception e)
            {
                getBrand.Status = false;
                getBrand.Message.Add(e.Message);
                return getBrand;
            }
        }
        public async Task<BrandResponse> updateBrand(BrandView brandView)
        {
            BrandResponse brandResponse = new();
            try
            {
                var result = await context.Brand.FindAsync(brandView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = brandView.Name;
                    result.Description = brandView.Description;
                    result.Cat_id = brandView.Cat_id;
                    context.Brand.Update(result);
                    await context.SaveChangesAsync();
                    brandResponse.Message.Add("Brand successfully updated.");
                    brandResponse.Status = true;
                    brandResponse.Type = "alert-success";
                    return brandResponse;
                }
                brandResponse.Message.Add($"Service with id {brandView.Id} not found.");
                brandResponse.Status = false;
                brandResponse.Type = "alert-danger";
                return brandResponse;

            }
            catch (Exception e)
            {
                brandResponse.Message.Add(e.Message);
                brandResponse.Status = false;
                brandResponse.Type = "alert-danger";
                return brandResponse;
            }
        }

        public async Task<BrandResponse> deleteBrand(String id)
        {
            BrandResponse brandResponse = new();
            try
            {
                var brand = await context.Brand.FindAsync(id);
                if (brand == null)
                {
                    brandResponse.Message.Add($"Brand with id {id} not found.");
                    brandResponse.Status = false;
                    brandResponse.Type = "alert-danger";
                    return brandResponse;
                }
                context.Brand.Remove(brand);
                await context.SaveChangesAsync();
                brandResponse.Message.Add("Service successfully Deleted.");
                brandResponse.Status = true;
                brandResponse.Type = "alert-success";
                return brandResponse;
            }
            catch (Exception e)
            {
                brandResponse.Message.Add(e.Message);
                brandResponse.Status = false;
                brandResponse.Type = "alert-danger";
                return brandResponse;
            }

        }

    }
}
