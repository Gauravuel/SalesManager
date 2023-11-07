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
    public class PhoneCaseInventory : IPhoneCaseInventory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PhoneCaseInventory(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PhoneCaseResponse> addPhoneCase(PhoneCaseView phoneCase)
        {
            PhoneCaseResponse phoneCaseResponse = new();
            try
            {
                var case_data = mapper.Map<PhoneCaseModel>(phoneCase);
                var guid_id = Guid.NewGuid().ToString();
                case_data.Id = guid_id;
                await context.PhoneCase.AddAsync(case_data);
                await context.SaveChangesAsync();
                var id = context.PhoneCase.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    BillProductModel billProduct = new();
                    var guid_id2 = Guid.NewGuid().ToString();
                    billProduct.Id = guid_id2;
                    billProduct.Productid = guid_id;
                    billProduct.Billid = case_data.Bill_Id;
                    billProduct.Quantity = case_data.Quantity;
                    await context.BillProducts.AddAsync(billProduct);
                    await context.SaveChangesAsync();

                    phoneCaseResponse.Status = true;
                    phoneCaseResponse.Type = "alert-success";
                    phoneCaseResponse.Message.Add("PhoneCase successfully added.");
                    return phoneCaseResponse;
                }
                else
                {
                    phoneCaseResponse.Status = false;
                    phoneCaseResponse.Type = "alert-danger";
                    phoneCaseResponse.Message.Add("PhoneCase can't be added.");
                    return phoneCaseResponse;
                }

            }
            catch (Exception e)
            {

                phoneCaseResponse.Status = false;
                phoneCaseResponse.Type = "alert-danger";
                phoneCaseResponse.Message.Add(e.Message);
                return phoneCaseResponse;
            }

        }

        public async Task<GetPhoneCase> getPhoneCase()
        {
            GetPhoneCase getPhoneCase = new();
            try
            {

                var phonecase = await context.PhoneCase.ToListAsync();
                if (phonecase?.Any() == true)
                {
                    var map = mapper.Map<List<PhoneCaseView>>(phonecase);
                    getPhoneCase.PhoneCases = map;

                    getPhoneCase.Status = true;
                    return getPhoneCase;
                }
                getPhoneCase.Status = false;
                getPhoneCase.Message.Add("No PhoneCase available.");
                return getPhoneCase;
            }
            catch (Exception e)
            {
                getPhoneCase.Status = false;
                getPhoneCase.Message.Add(e.Message);
                return getPhoneCase;
            }
        }

        public async Task<GetSmartphones> getPhoneCaseById(PhoneCaseId phoneCaseId)
        {
            GetSmartphones getInventory = new();
            try
            {

                var result = await context.PhoneCase.FindAsync(phoneCaseId.Id);
                if (result == null)
                {
                    getInventory.Status = false;
                    getInventory.Message.Add($"No PhoneCase found with id {phoneCaseId.Id}");
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
        public async Task<SmartPhoneResponse> updatePhoneCase(PhoneCaseView phoneCaseView)
        {
            SmartPhoneResponse inventoryResponse = new();
            try
            {
                var result = await context.PhoneCase.FindAsync(phoneCaseView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = phoneCaseView.Name;
                    result.Compatibility = phoneCaseView.Compatibility;
                    result.CaseMaterial = phoneCaseView.CaseMaterial;
                    result.Type = phoneCaseView.Type;
                    result.Transparent = phoneCaseView.Transparent;
                    result.Quantity = phoneCaseView.Quantity;
                    result.Price = phoneCaseView.Price;
                    context.PhoneCase.Update(result);
                    await context.SaveChangesAsync();
                    inventoryResponse.Message.Add("PhoneCase successfully updated.");
                    inventoryResponse.Status = true;
                    inventoryResponse.Type = "alert-success";
                    return inventoryResponse;
                }
                inventoryResponse.Message.Add($"PhoneCase with id {phoneCaseView.Id} not found.");
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

        public async Task<SmartPhoneResponse> deletePhoneCase(String id)
        {
            SmartPhoneResponse inventoryResponse = new();
            try
            {
                var product = await context.PhoneCase.FindAsync(id);
                if (product == null)
                {
                    inventoryResponse.Message.Add($"PhoneCase with id {id} not found.");
                    inventoryResponse.Status = false;
                    inventoryResponse.Type = "alert-danger";
                    return inventoryResponse;
                }
                context.PhoneCase.Remove(product);
                await context.SaveChangesAsync();
                inventoryResponse.Message.Add("PhoneCase successfully Deleted.");
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
