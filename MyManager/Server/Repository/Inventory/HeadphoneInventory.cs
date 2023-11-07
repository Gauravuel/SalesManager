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
    public class HeadphoneInventory : IHeadphoneInventory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HeadphoneInventory(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<HeadphoneResponse> addHeadphone(HeadphoneView headphoneView)
        {
            HeadphoneResponse headphoneResponse = new();
            try
            {
                var headdphone_data = mapper.Map<HeadphoneModel>(headphoneView);
                var guid_id = Guid.NewGuid().ToString();
                headdphone_data.Id = guid_id;
                await context.Headphone.AddAsync(headdphone_data);
                await context.SaveChangesAsync();
                var id = context.Headphone.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    BillProductModel billProduct = new();
                    var guid_id2 = Guid.NewGuid().ToString();
                    billProduct.Id = guid_id2;
                    billProduct.Productid = guid_id;
                    billProduct.Billid = headdphone_data.Bill_Id;
                    billProduct.Quantity = headdphone_data.Quantity;
                    await context.BillProducts.AddAsync(billProduct);
                    await context.SaveChangesAsync();

                    headphoneResponse.Status = true;
                    headphoneResponse.Type = "alert-success";
                    headphoneResponse.Message.Add("Headphone successfully added.");
                    return headphoneResponse;
                }
                else
                {
                    headphoneResponse.Status = false;
                    headphoneResponse.Type = "alert-danger";
                    headphoneResponse.Message.Add("Headphone can't be added.");
                    return headphoneResponse;
                }

            }
            catch (Exception e)
            {

                headphoneResponse.Status = false;
                headphoneResponse.Type = "alert-danger";
                headphoneResponse.Message.Add(e.Message);
                return headphoneResponse;
            }

        }

        public async Task<GetHeadphone> getHeadphone()
        {
            GetHeadphone getHeadphone = new();
            try
            {

                var headphone = await context.Headphone.ToListAsync();
                if (headphone?.Any() == true)
                {
                    var map = mapper.Map<List<HeadphoneView>>(headphone);
                    getHeadphone.Headphones = map;

                    getHeadphone.Status = true;
                    return getHeadphone;
                }
                getHeadphone.Status = false;
                getHeadphone.Message.Add("No headphone available.");
                return getHeadphone;
            }
            catch (Exception e)
            {
                getHeadphone.Status = false;
                getHeadphone.Message.Add(e.Message);
                return getHeadphone;
            }
        }
        public async Task<GetHeadphone> getHeadphoneById(HeadphoneId headphoneId)
        {
            GetHeadphone getHeadphone = new();
            try
            {

                var result = await context.Headphone.FindAsync(headphoneId.Id);
                if (result == null)
                {
                    getHeadphone.Status = false;
                    getHeadphone.Message.Add($"No Headphone found with id {headphoneId.Id}");
                    return getHeadphone;
                }
                var map = mapper.Map<HeadphoneView>(result);
                getHeadphone.Status = true;
                getHeadphone.SingleHeadphone = map;
                return getHeadphone;
            }
            catch (Exception e)
            {
                getHeadphone.Status = false;
                getHeadphone.Message.Add(e.Message);
                return getHeadphone;
            }
        }
        public async Task<HeadphoneResponse> updateHeadphone(HeadphoneView headphoneView)
        {
            HeadphoneResponse headphoneResponse = new();
            try
            {
                var result = await context.Headphone.FindAsync(headphoneView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = headphoneView.Name;
                    result.Quantity = headphoneView.Quantity;
                    result.Price = headphoneView.Price;
                    result.Type = headphoneView.Type;


                    context.Headphone.Update(result);
                    await context.SaveChangesAsync();
                    headphoneResponse.Message.Add("Headphone successfully updated.");
                    headphoneResponse.Status = true;
                    headphoneResponse.Type = "alert-success";
                    return headphoneResponse;
                }
                headphoneResponse.Message.Add($"Headphone with id {headphoneView.Id} not found.");
                headphoneResponse.Status = false;
                headphoneResponse.Type = "alert-danger";
                return headphoneResponse;

            }
            catch (Exception e)
            {
                headphoneResponse.Message.Add(e.Message);
                headphoneResponse.Status = false;
                headphoneResponse.Type = "alert-danger";
                return headphoneResponse;
            }
        }

        public async Task<HeadphoneResponse> deleteHeadphone(String id)
        {
            HeadphoneResponse headphoneResponse = new();
            try
            {
                var product = await context.Headphone.FindAsync(id);
                if (product == null)
                {
                    headphoneResponse.Message.Add($"Headphone with id {id} not found.");
                    headphoneResponse.Status = false;
                    headphoneResponse.Type = "alert-danger";
                    return headphoneResponse;
                }
                context.Headphone.Remove(product);
                await context.SaveChangesAsync();
                headphoneResponse.Message.Add("Headphone successfully Deleted.");
                headphoneResponse.Status = true;
                headphoneResponse.Type = "alert-success";
                return headphoneResponse;
            }
            catch (Exception e)
            {
                headphoneResponse.Message.Add(e.Message);
                headphoneResponse.Status = false;
                headphoneResponse.Type = "alert-danger";
                return headphoneResponse;
            }

        }
    }
}
