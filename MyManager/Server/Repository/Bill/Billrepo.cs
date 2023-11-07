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

namespace MyManager.Server.Repository.Bill
{
    public class Billrepo : IBillrepo
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Billrepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<BillResponse> addBill(BillView billView)
        {
            BillResponse billResponse = new();
            try
            {
                var bill_data = mapper.Map<BillModel>(billView);
                var guid_id = Guid.NewGuid().ToString();
                bill_data.Id = guid_id;
                await context.Bill.AddAsync(bill_data);
                await context.SaveChangesAsync();
                var id = context.Bill.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    billResponse.Status = true;
                    billResponse.Type = "alert-success";
                    billResponse.Message.Add("Bill successfully added.");
                    return billResponse;
                }
                else
                {
                    billResponse.Status = false;
                    billResponse.Type = "alert-danger";
                    billResponse.Message.Add("Bill can't be added.");
                    return billResponse;
                }

            }
            catch (Exception e)
            {

                billResponse.Status = false;
                billResponse.Type = "alert-danger";
                billResponse.Message.Add(e.Message);
                return billResponse;
            }

        }

        public async Task<GetBill> getBill()
        {
            GetBill getBill = new();
            try
            {

                var bill = await context.Bill.ToListAsync();
                if (bill?.Any() == true)
                {
                    var map = mapper.Map<List<BillView>>(bill);
                    foreach (BillView bills in map)
                    {
                        var dealer = context.Dealer.Where(d => d.Id == bills.Dealer_Id).FirstOrDefault();
                        bills.dealerView = mapper.Map<DealerView>(dealer); 
                    }
                    getBill.Bills = map;

                    getBill.Status = true;
                    return getBill;
                }
                getBill.Status = false;
                getBill.Message.Add("No bill available.");
                return getBill;
            }
            catch (Exception e)
            {
                getBill.Status = false;
                getBill.Message.Add(e.Message);
                return getBill;
            }
        }
        public async Task<GetBill> getBillById(BillId billId)
        {
            GetBill getBill = new();
            try
            {

                var result = await context.Bill.FindAsync(billId.Id);
                if (result == null)
                {
                    getBill.Status = false;
                    getBill.Message.Add($"No Bill found with id {billId.Id}");
                    return getBill;
                }
                var map = mapper.Map<BillView>(result);

                var dealer = context.Dealer.Where(d => d.Id == result.Dealer_Id).FirstOrDefault();
                map.dealerView = mapper.Map<DealerView>(dealer);
                getBill.Status = true;
                getBill.Singlebill = map;
                return getBill;
            }
            catch (Exception e)
            {
                getBill.Status = false;
                getBill.Message.Add(e.Message);
                return getBill;
            }
        }
        public async Task<BillResponse> updateBill(BillView billView)
        {
            BillResponse billResponse = new();
            try
            {
                var result = await context.Bill.FindAsync(billView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Checkout_Date = billView.Checkout_Date;
                    result.BillNo = billView.BillNo;
                    result.Dealer_Id = billView.Dealer_Id;


                    context.Bill.Update(result);
                    await context.SaveChangesAsync();
                    billResponse.Message.Add("Bill successfully updated.");
                    billResponse.Status = true;
                    billResponse.Type = "alert-success";
                    return billResponse;
                }
                billResponse.Message.Add($"Bill with id {billView.Id} not found.");
                billResponse.Status = false;
                billResponse.Type = "alert-danger";
                return billResponse;

            }
            catch (Exception e)
            {
                billResponse.Message.Add(e.Message);
                billResponse.Status = false;
                billResponse.Type = "alert-danger";
                return billResponse;
            }
        }

        public async Task<BillResponse> deleteBill(String id)
        {
            BillResponse billResponse = new();
            try
            {
                var bill = await context.Bill.FindAsync(id);
                if (bill == null)
                {
                    billResponse.Message.Add($"Bill with id {id} not found.");
                    billResponse.Status = false;
                    billResponse.Type = "alert-danger";
                    return billResponse;
                }
                context.Bill.Remove(bill);
                await context.SaveChangesAsync();
                billResponse.Message.Add("Bill successfully Deleted.");
                billResponse.Status = true;
                billResponse.Type = "alert-success";
                return billResponse;
            }
            catch (Exception e)
            {
                billResponse.Message.Add(e.Message);
                billResponse.Status = false;
                billResponse.Type = "alert-danger";
                return billResponse;
            }

        }
    }
}
