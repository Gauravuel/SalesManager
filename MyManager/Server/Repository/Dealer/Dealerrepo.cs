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

namespace MyManager.Server.Repository.Dealer
{
    public class Dealerrepo : IDealerrepo
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Dealerrepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DealerResponse> addDealer(DealerView dealer)
        {
            DealerResponse dealerResponse = new();
            try
            {
                var dealer_data = mapper.Map<DealerModel>(dealer);
                var guid_id = Guid.NewGuid().ToString();
                dealer_data.Id = guid_id;
                await context.Dealer.AddAsync(dealer_data);
                await context.SaveChangesAsync();
                var id = context.Dealer.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    dealerResponse.Status = true;
                    dealerResponse.Type = "alert-success";
                    dealerResponse.Message.Add("Dealer successfully added.");
                    return dealerResponse;
                }
                else
                {
                    dealerResponse.Status = false;
                    dealerResponse.Type = "alert-danger";
                    dealerResponse.Message.Add("Dealer can't be added.");
                    return dealerResponse;
                }

            }
            catch (Exception e)
            {

                dealerResponse.Status = false;
                dealerResponse.Type = "alert-danger";
                dealerResponse.Message.Add(e.Message);
                return dealerResponse;
            }

        }

        public async Task<GetDealer> getDealer()
        {
            GetDealer getDealer = new();
            try
            {

                var dealer = await context.Dealer.ToListAsync();
                if (dealer?.Any() == true)
                {
                    var map = mapper.Map<List<DealerView>>(dealer);
                    getDealer.Dealer = map;

                    getDealer.Status = true;
                    return getDealer;
                }
                getDealer.Status = false;
                getDealer.Message.Add("No charger available.");
                return getDealer;
            }
            catch (Exception e)
            {
                getDealer.Status = false;
                getDealer.Message.Add(e.Message);
                return getDealer;
            }
        }
        public async Task<GetDealer> getDealerById(DealerId dealerId)
        {
            GetDealer getDealer = new();
            try
            {

                var result = await context.Dealer.FindAsync(dealerId.Id);
                if (result == null)
                {
                    getDealer.Status = false;
                    getDealer.Message.Add($"No dealer found with id {dealerId.Id}");
                    return getDealer;
                }
                var map = mapper.Map<DealerView>(result);
                getDealer.Status = true;
                getDealer.Singledealer = map;
                return getDealer;
            }
            catch (Exception e)
            {
                getDealer.Status = false;
                getDealer.Message.Add(e.Message);
                return getDealer;
            }
        }
        public async Task<DealerResponse> updateDealer(DealerView dealerView)
        {
            DealerResponse dealerResponse = new();
            try
            {
                var result = await context.Dealer.FindAsync(dealerView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = dealerView.Name;
                    result.Adress = dealerView.Adress;
                    result.Phone = dealerView.Phone;


                    context.Dealer.Update(result);
                    await context.SaveChangesAsync();
                    dealerResponse.Message.Add("Dealer successfully updated.");
                    dealerResponse.Status = true;
                    dealerResponse.Type = "alert-success";
                    return dealerResponse;
                }
                dealerResponse.Message.Add($"Charger with id {dealerView.Id} not found.");
                dealerResponse.Status = false;
                dealerResponse.Type = "alert-danger";
                return dealerResponse;

            }
            catch (Exception e)
            {
                dealerResponse.Message.Add(e.Message);
                dealerResponse.Status = false;
                dealerResponse.Type = "alert-danger";
                return dealerResponse;
            }
        }

        public async Task<DealerResponse> deleteDealer(String id)
        {
            DealerResponse dealerResponse = new();
            try
            {
                var product = await context.Dealer.FindAsync(id);
                if (product == null)
                {
                    dealerResponse.Message.Add($"Dealer with id {id} not found.");
                    dealerResponse.Status = false;
                    dealerResponse.Type = "alert-danger";
                    return dealerResponse;
                }
                context.Dealer.Remove(product);
                await context.SaveChangesAsync();
                dealerResponse.Message.Add("Dealer successfully Deleted.");
                dealerResponse.Status = true;
                dealerResponse.Type = "alert-success";
                return dealerResponse;
            }
            catch (Exception e)
            {
                dealerResponse.Message.Add(e.Message);
                dealerResponse.Status = false;
                dealerResponse.Type = "alert-danger";
                return dealerResponse;
            }

        }
    }
}
