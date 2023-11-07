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

namespace MyManager.Server.Repository.Purchase
{
    public class Purchaserepo : IPurchaserepo
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Purchaserepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PurchaseResponse> addPurchase(PurchaseView purchases)
        {
            PurchaseResponse purchaseResponse = new();
            try
            {
                var purchase_data = mapper.Map<List<SoldModel>>(purchases.purchaseproduct);
                var customerpurchase_data = mapper.Map<CustomerPurchaseModel>(purchases);
               
                var purchase_id = Guid.NewGuid().ToString();
                string purchasedate = DateTime.UtcNow.ToShortDateString();
                foreach (var purchase in purchase_data)
                {
                    var guid_id = Guid.NewGuid().ToString();
                    purchase.Id = guid_id;
                    purchase.Purchase_Id = purchase_id;
                    purchase.Purchase_Date = purchasedate;
                    await context.Sold.AddAsync(purchase);
                }
                              
                await context.SaveChangesAsync();
                var id = context.Sold.Where(x => x.Purchase_Id == purchase_id).FirstOrDefault().Purchase_Id;
                if (!string.IsNullOrEmpty(id))
                {
                    var custpurchase_id = Guid.NewGuid().ToString();
                    customerpurchase_data.Id = custpurchase_id;
                    customerpurchase_data.Purchase_Id = purchase_id;
                    customerpurchase_data.Purchase_Date = purchasedate;
                    customerpurchase_data.PaidAmount = purchases.Paid_Amount;
                    await context.CustomerPurchases.AddAsync(customerpurchase_data);
                    await context.SaveChangesAsync();

                    if(purchases.Sum_Total != purchases.Paid_Amount)
                    {
                        purchases.Purchase_Date = purchasedate;
                        purchases.Purchase_Id = purchase_id;
                       await addCustomerCredit(purchases);
                    }

                    purchaseResponse.Status = true;
                    purchaseResponse.Type = "alert-success";
                    purchaseResponse.Message.Add("Purchase successfully added.");
                    purchaseResponse.Purchase_Id = purchase_id;

                    

                    return purchaseResponse;
                }
                else
                {
                    purchaseResponse.Status = false;
                    purchaseResponse.Type = "alert-danger";
                    purchaseResponse.Message.Add("Purchase can't be added.");
                    return purchaseResponse;
                }

            }
            catch (Exception e)
            {

                purchaseResponse.Status = false;
                purchaseResponse.Type = "alert-danger";
                purchaseResponse.Message.Add(e.Message);
                return purchaseResponse;
            }

        }

        public async Task<GetPurchase> getPurchase()
        {
            GetPurchase getPurchase = new();
            try
            {
                var purchase = await context.CustomerPurchases.ToListAsync();
                if (purchase?.Any() == true)
                {
                    var map = mapper.Map<List<PurchaseView>>(purchase);
                    getPurchase.Purchases = map;

                    getPurchase.Status = true;
                    return getPurchase;
                }
                getPurchase.Status = false;
                getPurchase.Message.Add("No Purchase available.");
                return getPurchase;
            }
            catch (Exception e)
            {
                getPurchase.Status = false;
                getPurchase.Message.Add(e.Message);
                return getPurchase;
            }
        }
        public async Task<GetPurchase> getPurchaseById(CustomerId customerId)
        {
            GetPurchase getPurchase = new();
            try
            {

                var result = await context.CustomerPurchases.Where(p => p.Customer_Id == customerId.Id).ToListAsync();
                if (!result.Any())
                {
                    getPurchase.Status = false;
                    getPurchase.Message.Add($"No purchase found with id {customerId.Id}");
                    return getPurchase;
                }
                var map = mapper.Map<List<PurchaseView>>(result);
                getPurchase.Status = true;
                getPurchase.Purchases = map;
                return getPurchase;
            }
            catch (Exception e)
            {
                getPurchase.Status = false;
                getPurchase.Message.Add(e.Message);
                return getPurchase;
            }
        }
        public async Task<GetPurchase> getPurchaseProduct(PurchaseId purchaseId)
        {
            GetPurchase getPurchase = new();
            try
            {
                var purchase =  context.CustomerPurchases.Where(p => p.Purchase_Id == purchaseId.Id).FirstOrDefault();
                if(purchase != null)
                {
                    var purchaseproducts = await context.Sold.Where(s => s.Purchase_Id == purchase.Purchase_Id).ToListAsync();     
                    if (purchaseproducts?.Any() == true)
                    {
                        var map = mapper.Map<List<PurchaseView>>(purchaseproducts);
                        getPurchase.PurchaseProduct.Purchase_Date = purchase.Purchase_Date;
                        getPurchase.PurchaseProduct.Sum_Total = purchase.Sum_Total;
                        getPurchase.PurchaseProduct.purchaseproduct = map;          
                        getPurchase.PurchaseProduct.Paid_Amount = purchase.PaidAmount;                                    
                        getPurchase.Status = true;
                        return getPurchase;
                    }
                }
                
                getPurchase.Status = false;
                getPurchase.Message.Add("No Purchase available.");
                return getPurchase;
            }
            catch (Exception e)
            {
                getPurchase.Status = false;
                getPurchase.Message.Add(e.Message);
                return getPurchase;
            }
        }

        public async Task<PurchaseResponse> addCustomerCredit(PurchaseView purchases)
        {
            PurchaseResponse purchaseResponse = new();
            try
            {
                var credit_data = mapper.Map<CustomerCreditModel>(purchases);                       
                var guid_id = Guid.NewGuid().ToString();
                credit_data.Id = guid_id;
                credit_data.Credited_amount = credit_data.Sum_Total - credit_data.Paid_Amount;
                await context.CustomerCredits.AddAsync(credit_data);            
                await context.SaveChangesAsync();

                var id = context.CustomerCredits.Where(c => c.Id == credit_data.Id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {                    
                    purchaseResponse.Status = true;
                    purchaseResponse.Type = "alert-success";
                    purchaseResponse.Message.Add("Credit of" + (credit_data.Sum_Total-credit_data.Paid_Amount).ToString()+"added to customer");
                    return purchaseResponse;
                }
                else
                {
                    purchaseResponse.Status = false;
                    purchaseResponse.Type = "alert-danger";
                    purchaseResponse.Message.Add("Purchase can't be added.");
                    return purchaseResponse;
                }

            }
            catch (Exception e)
            {

                purchaseResponse.Status = false;
                purchaseResponse.Type = "alert-danger";
                purchaseResponse.Message.Add(e.Message);
                return purchaseResponse;
            }

        }

        public async Task<GetCustomerCredit> getCustomerCredit()
        {
            GetCustomerCredit getCustomerCredit = new();
            try
            {
                var credit = await context.CustomerCredits.ToListAsync();
                if (credit?.Any() == true)
                {
                    var map = mapper.Map<List<CustomerCreditView>>(credit);
                    foreach( var credits in map)
                    {
                        credits.Customer_Name =  context.Customer.Where(c => c.Id == credits.Customer_Id).FirstOrDefault().Name;
                        
                    }
                    getCustomerCredit.CustomerCredit = map;

                    getCustomerCredit.Status = true;
                    return getCustomerCredit;
                }
                getCustomerCredit.Status = false;
                getCustomerCredit.Message.Add("No credits available.");
                return getCustomerCredit;
            }
            catch (Exception e)
            {
                getCustomerCredit.Status = false;
                getCustomerCredit.Message.Add(e.Message);
                return getCustomerCredit;
            }
        }
        public async Task<CustomerCreditResponse> removecredit(String id)
        {
            CustomerCreditResponse customerCreditResponse = new();
            try
            {
                var credit = await context.CustomerCredits.FindAsync(id);
                if (credit == null)
                {
                    customerCreditResponse.Message.Add($"Credit with id {id} not found.");
                    customerCreditResponse.Status = false;
                    customerCreditResponse.Type = "alert-danger";
                    return customerCreditResponse;
                }
                context.CustomerCredits.Remove(credit);
                await context.SaveChangesAsync();
                customerCreditResponse.Message.Add("Credit successfully Cleared.");
                customerCreditResponse.Status = true;
                customerCreditResponse.Type = "alert-success";
                return customerCreditResponse;
            }
            catch (Exception e)
            {
                customerCreditResponse.Message.Add(e.Message);
                customerCreditResponse.Status = false;
                customerCreditResponse.Type = "alert-danger";
                return customerCreditResponse;
            }

        }

        public async Task<GetGroupedPurchase> getGroupByPurchase()
        {
            GetGroupedPurchase getGroupedPurchase = new();
           
        
            try
            {
                var purchase = await context.CustomerPurchases.ToListAsync();
                if (purchase?.Any() == true)
                {
                    var purchased = purchase.GroupBy(t => t.Purchase_Date)
                           .Select(t => new
                           {
                               Date = t.Key,
                               Amount = t.Sum(ta => ta.Sum_Total),
                           }).ToList();

               
                    foreach(var item in purchased)
                    {
                        getGroupedPurchase.Dates.Add(item.Date);
                        getGroupedPurchase.Amount.Add(item.Amount);
                    }

                    getGroupedPurchase.Status = true;
                    return getGroupedPurchase;
                }
                getGroupedPurchase.Status = false;
                getGroupedPurchase.Message.Add("No data available.");
                return getGroupedPurchase;
            }
            catch (Exception e)
            {
                getGroupedPurchase.Status = false;
                getGroupedPurchase.Message.Add(e.Message);
                return getGroupedPurchase;
            }
        }
        public async Task<GetTopPurchase> getTopPurchase()
        {
            GetTopPurchase getTopPurchase = new();
            TopPurchaseModel topPurchaseModel = new();

            try
            {
                var purchase = await context.CustomerPurchases.ToListAsync();
                if (purchase?.Any() == true)
                {
                    var purchased = purchase.GroupBy(t => t.Customer_Id)
                           .Select(t => new
                           {
                               Customer_Id = t.Key,
                               Amount = t.Sum(ta => ta.Sum_Total),
                           }).ToList();


                    foreach (var item in purchased)
                    {
                        var customer =  context.Customer.Where(c => c.Id == item.Customer_Id).FirstOrDefault().Name;
                        topPurchaseModel.Customer_Name = customer;
                        topPurchaseModel.Amount = item.Amount;
                        getTopPurchase.Purchases.Add(topPurchaseModel);
                        //getTopPurchase.Cust_Name.Add(customer);
                        //getTopPurchase.Amount.Add(item.Amount);
                    }

                    getTopPurchase.Status = true;
                    return getTopPurchase;
                }
                getTopPurchase.Status = false;
                getTopPurchase.Message.Add("No data available.");
                return getTopPurchase;
            }
            catch (Exception e)
            {
                getTopPurchase.Status = false;
                getTopPurchase.Message.Add(e.Message);
                return getTopPurchase;
            }
        }

        //public async Task<PurchaseResponse> updatePurchase(PurchaseView purchaseView)
        //{
        //    PurchaseResponse purchaseResponse = new();
        //    try
        //    {
        //        var result = await context.Purchase.FindAsync(purchaseView.Id);
        //        if (result != null)
        //        {
        //            //var serialized = JsonConvert.SerializeObject(services);
        //            //var deserialized = JsonConvert.DeserializeObject(serialized);
        //            result.Quantity = purchaseView.Quantity;
        //            result.Price = purchaseView.Price;
        //            result.Discount = purchaseView.Discount;
        //            result.Sum_Total = purchaseView.Sum_Total;
        //            result.Paid_Amount = purchaseView.Paid_Amount;
        //            result.Puschase_Date = purchaseView.Puschase_Date;


        //            context.Purchase.Update(result);
        //            await context.SaveChangesAsync();
        //            purchaseResponse.Message.Add("Purchase successfully updated.");
        //            purchaseResponse.Status = true;
        //            purchaseResponse.Type = "alert-success";
        //            return purchaseResponse;
        //        }
        //        purchaseResponse.Message.Add($"Purchase with id {purchaseView.Id} not found.");
        //        purchaseResponse.Status = false;
        //        purchaseResponse.Type = "alert-danger";
        //        return purchaseResponse;

        //    }
        //    catch (Exception e)
        //    {
        //        purchaseResponse.Message.Add(e.Message);
        //        purchaseResponse.Status = false;
        //        purchaseResponse.Type = "alert-danger";
        //        return purchaseResponse;
        //    }
        //}

        //public async Task<PurchaseResponse> deletePurchase(String id)
        //{
        //    PurchaseResponse purchaseResponse = new();
        //    try
        //    {
        //        var bill = await context.Purchase.FindAsync(id);
        //        if (bill == null)
        //        {
        //            purchaseResponse.Message.Add($"Purchase with id {id} not found.");
        //            purchaseResponse.Status = false;
        //            purchaseResponse.Type = "alert-danger";
        //            return purchaseResponse;
        //        }
        //        context.Purchase.Remove(bill);
        //        await context.SaveChangesAsync();
        //        purchaseResponse.Message.Add("Purchase successfully Deleted.");
        //        purchaseResponse.Status = true;
        //        purchaseResponse.Type = "alert-success";
        //        return purchaseResponse;
        //    }
        //    catch (Exception e)
        //    {
        //        purchaseResponse.Message.Add(e.Message);
        //        purchaseResponse.Status = false;
        //        purchaseResponse.Type = "alert-danger";
        //        return purchaseResponse;
        //    }

        //}
    }
}
