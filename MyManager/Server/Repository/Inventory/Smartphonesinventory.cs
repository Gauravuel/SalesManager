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

namespace MyManager.Server.Repository.Inventory
{
    public class Smartphonesinventory : ISmartphonesinventory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Smartphonesinventory(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SmartPhoneResponse> addPhone(SmartphoneView product)
        {
            SmartPhoneResponse inventoryResponse = new();
            try
            {
                var product_data = mapper.Map<SmartPhonesModel>(product);
                var guid_id = Guid.NewGuid().ToString();
                product_data.Id = guid_id;
                await context.Smartphones.AddAsync(product_data);
                await context.SaveChangesAsync();
                
                var id = context.Smartphones.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    BillProductModel billProduct = new();
                    var guid_id2 = Guid.NewGuid().ToString();
                    billProduct.Id = guid_id2;
                    billProduct.Productid = guid_id;
                    billProduct.Billid = product_data.Bill_Id;
                    billProduct.Quantity = product_data.Quantity;
                    await context.BillProducts.AddAsync(billProduct);
                    await context.SaveChangesAsync();

                    inventoryResponse.Status = true;
                    inventoryResponse.Type = "alert-success";
                    inventoryResponse.Message.Add("Product successfully added.");
                    return inventoryResponse;
                }
                else
                {
                    inventoryResponse.Status = false;
                    inventoryResponse.Type = "alert-danger";
                    inventoryResponse.Message.Add("Product can't be added.");
                    return inventoryResponse;
                }

        }
            catch (Exception e)
            {

                inventoryResponse.Status = false;
                inventoryResponse.Type = "alert-danger";
                inventoryResponse.Message.Add(e.Message);
                return inventoryResponse;
            }

        }

        public async Task<GetSmartphones> getPhone()
        {
            GetSmartphones getInventory = new();
            try
            {

                var inventory = await context.Smartphones.ToListAsync();
                if (inventory?.Any() == true)
                {
                    var map = mapper.Map<List<SmartphoneView>>(inventory);
                    getInventory.Smartphones = map;

                    getInventory.Status = true;
                    return getInventory;
                }
                getInventory.Status = false;
                getInventory.Message.Add("No Product available.");
                return getInventory;
            }
            catch (Exception e)
            {
                getInventory.Status = false;
                getInventory.Message.Add(e.Message);
                return getInventory;
            }
        }
        public async Task<GetSmartphones> getPhoneById(SmartphoneId productId)
        {
            GetSmartphones getInventory = new();
            try
            {

                var result = await context.Smartphones.FindAsync(productId.Id);
                if (result == null)
                {
                    getInventory.Status = false;
                    getInventory.Message.Add($"No Product found with id {productId.Id}");
                    return getInventory;
                }
                var map = mapper.Map<SmartphoneView>(result);
                getInventory.Status = true;
                getInventory.Singleproduct = map;
                return getInventory;
            }
            catch (Exception e)
            {
                getInventory.Status = false;
                getInventory.Message.Add(e.Message);
                return getInventory;
            }
        }
        public async Task<SmartPhoneResponse> updatePhone(SmartphoneView productView)
        {
            SmartPhoneResponse inventoryResponse = new();
            try
            {
                var result = await context.Smartphones.FindAsync(productView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = productView.Name;
                    result.Color = productView.Color;
                    result.Price = productView.Price;
                    result.Ram = productView.Ram;
                    result.Storage = productView.Storage;
                    result.Cpu = productView.Cpu;
                    result.Display = productView.Display;
                    result.Quantity = productView.Quantity;
                    result.Price = productView.Price;
                    context.Smartphones.Update(result);
                    await context.SaveChangesAsync();
                    inventoryResponse.Message.Add("Product successfully updated.");
                    inventoryResponse.Status = true;
                    inventoryResponse.Type = "alert-success";
                    return inventoryResponse;
                }
                inventoryResponse.Message.Add($"Product with id {productView.Id} not found.");
                inventoryResponse.Status = false;
                inventoryResponse.Type = "alert-danger";
                return inventoryResponse;

            }
            catch (Exception e)
            {
                inventoryResponse.Message.Add(e.Message);
                inventoryResponse.Status = false;
                inventoryResponse.Type = "alert-danger";
                return inventoryResponse;
            }
        }

        public async Task<SmartPhoneResponse> deletePhone(String id)
        {
            SmartPhoneResponse inventoryResponse = new();
            try
            {
                var product = await context.Smartphones.FindAsync(id);
                if (product == null)
                {
                    inventoryResponse.Message.Add($"Product with id {id} not found.");
                    inventoryResponse.Status = false;
                    inventoryResponse.Type = "alert-danger";
                    return inventoryResponse;
                }
                context.Smartphones.Remove(product);
                await context.SaveChangesAsync();
                inventoryResponse.Message.Add("Product successfully Deleted.");
                inventoryResponse.Status = true;
                inventoryResponse.Type = "alert-success";
                return inventoryResponse;
            }
            catch (Exception e)
            {
                inventoryResponse.Message.Add(e.Message);
                inventoryResponse.Status = false;
                inventoryResponse.Type = "alert-danger";
                return inventoryResponse;
            }

        }
    }
}
