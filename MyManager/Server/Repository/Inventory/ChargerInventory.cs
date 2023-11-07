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
    public class ChargerInventory : IChargerInventory
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ChargerInventory(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ChargerResponse> addCharger(ChargerView chargerview)
        {
            ChargerResponse chargerResponse = new();
            try
            {
                var charger_data = mapper.Map<ChargersModel>(chargerview);
                var guid_id = Guid.NewGuid().ToString();
                charger_data.Id = guid_id;
                await context.Charger.AddAsync(charger_data);
                await context.SaveChangesAsync();
                var id = context.Charger.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    BillProductModel billProduct = new();
                    var guid_id2 = Guid.NewGuid().ToString();
                    billProduct.Id = guid_id2;
                    billProduct.Productid = guid_id;
                    billProduct.Billid = charger_data.Bill_Id;
                    billProduct.Quantity = charger_data.Quantity;
                    await context.BillProducts.AddAsync(billProduct);
                    await context.SaveChangesAsync();

                    chargerResponse.Status = true;
                    chargerResponse.Type = "alert-success";
                    chargerResponse.Message.Add("Charger successfully added.");
                    return chargerResponse;
                }
                else
                {
                    chargerResponse.Status = false;
                    chargerResponse.Type = "alert-danger";
                    chargerResponse.Message.Add("Charger can't be added.");
                    return chargerResponse;
                }

            }
            catch (Exception e)
            {

                chargerResponse.Status = false;
                chargerResponse.Type = "alert-danger";
                chargerResponse.Message.Add(e.Message);
                return chargerResponse;
            }

        }

        public async Task<GetCharger> getCharger()
        {
            GetCharger getCharger = new();
            try
            {

                var charger = await context.Charger.ToListAsync();
                if (charger?.Any() == true)
                {
                    var map = mapper.Map<List<ChargerView>>(charger);
                    getCharger.Chargers = map;

                    getCharger.Status = true;
                    return getCharger;
                }
                getCharger.Status = false;
                getCharger.Message.Add("No charger available.");
                return getCharger;
            }
            catch (Exception e)
            {
                getCharger.Status = false;
                getCharger.Message.Add(e.Message);
                return getCharger;
            }
        }
        public async Task<GetCharger> getChargerById(ChargerId chargerId)
        {
            GetCharger getCharger = new();
            try
            {

                var result = await context.Charger.FindAsync(chargerId.Id);
                if (result == null)
                {
                    getCharger.Status = false;
                    getCharger.Message.Add($"No charger found with id {chargerId.Id}");
                    return getCharger;
                }
                var map = mapper.Map<ChargerView>(result);
                getCharger.Status = true;
                getCharger.SingleCharger = map;
                return getCharger;
            }
            catch (Exception e)
            {
                getCharger.Status = false;
                getCharger.Message.Add(e.Message);
                return getCharger;
            }
        }
        public async Task<ChargerResponse> updateCharger(ChargerView chargerView)
        {
            ChargerResponse chargerResponse = new();
            try
            {
                var result = await context.Charger.FindAsync(chargerView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Watt = chargerView.Watt;
                    result.Port = chargerView.Port;
                    result.Quantity = chargerView.Quantity;
                    result.Price = chargerView.Price;
                    result.Type = chargerView.Type;
                    result.Fast_Charging = chargerView.Fast_Charging;

                    context.Charger.Update(result);
                    await context.SaveChangesAsync();
                    chargerResponse.Message.Add("Charger successfully updated.");
                    chargerResponse.Status = true;
                    chargerResponse.Type = "alert-success";
                    return chargerResponse;
                }
                chargerResponse.Message.Add($"Charger with id {chargerView.Id} not found.");
                chargerResponse.Status = false;
                chargerResponse.Type = "alert-danger";
                return chargerResponse;

            }
            catch (Exception e)
            {
                chargerResponse.Message.Add(e.Message);
                chargerResponse.Status = false;
                chargerResponse.Type = "alert-danger";
                return chargerResponse;
            }
        }

        public async Task<ChargerResponse> deleteCharger(String id)
        {
            ChargerResponse chargerResponse = new();
            try
            {
                var product = await context.Charger.FindAsync(id);
                if (product == null)
                {
                    chargerResponse.Message.Add($"Charger with id {id} not found.");
                    chargerResponse.Status = false;
                    chargerResponse.Type = "alert-danger";
                    return chargerResponse;
                }
                context.Charger.Remove(product);
                await context.SaveChangesAsync();
                chargerResponse.Message.Add("Charger successfully Deleted.");
                chargerResponse.Status = true;
                chargerResponse.Type = "alert-success";
                return chargerResponse;
            }
            catch (Exception e)
            {
                chargerResponse.Message.Add(e.Message);
                chargerResponse.Status = false;
                chargerResponse.Type = "alert-danger";
                return chargerResponse;
            }

        }
    }
}
