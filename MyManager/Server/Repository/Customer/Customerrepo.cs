using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyManager.Server.Data;
using MyManager.Server.Models;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Repository.Customer
{
   
    public class Customerrepo : ICustomerrepo
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public Customerrepo(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CustomerResponse> addCustomer(CustomerView customerView)
        {
            CustomerResponse customerResponse = new();
            try
            {
                var customer_data = mapper.Map<CustomerModel>(customerView);
                var guid_id = Guid.NewGuid().ToString();
                customer_data.Id = guid_id;
                await context.Customer.AddAsync(customer_data);
                await context.SaveChangesAsync();
                var id = context.Customer.Where(x => x.Id == guid_id).FirstOrDefault().Id;
                if (!string.IsNullOrEmpty(id))
                {
                    customerResponse.Status = true;
                    customerResponse.Type = "alert-success";
                    customerResponse.Message.Add("Customer successfully added.");
                    return customerResponse;
                }
                else
                {
                    customerResponse.Status = false;
                    customerResponse.Type = "alert-danger";
                    customerResponse.Message.Add("Customer can't be added.");
                    return customerResponse;
                }

            }
            catch (Exception e)
            {

                customerResponse.Status = false;
                customerResponse.Type = "alert-danger";
                customerResponse.Message.Add(e.Message);
                return customerResponse;
            }

        }

        public async Task<GetCustomer> getCustomer()
        {
            GetCustomer getCustomer = new();
            try
            {

                var customer = await context.Customer.ToListAsync();
                if (customer?.Any() == true)
                {
                    var map = mapper.Map<List<CustomerView>>(customer);
                    getCustomer.Customers = map;

                    getCustomer.Status = true;
                    return getCustomer;
                }
                getCustomer.Status = false;
                getCustomer.Message.Add("No customer available.");
                return getCustomer;
            }
            catch (Exception e)
            {
                getCustomer.Status = false;
                getCustomer.Message.Add(e.Message);
                return getCustomer;
            }
        }
        public async Task<GetCustomer> getCustomerById(CustomerId customerId)
        {
            GetCustomer getCustomer = new();
            try
            {

                var result = await context.Customer.FindAsync(customerId.Id);
                if (result == null)
                {
                    getCustomer.Status = false;
                    getCustomer.Message.Add($"No customer found with id {customerId.Id}");
                    return getCustomer;
                }
                var map = mapper.Map<CustomerView>(result);
                getCustomer.Status = true;
                getCustomer.Singlecustomer = map;
                return getCustomer;
            }
            catch (Exception e)
            {
                getCustomer.Status = false;
                getCustomer.Message.Add(e.Message);
                return getCustomer;
            }
        }
        public async Task<CustomerResponse> updateCustomer(CustomerView customerView)
        {
            CustomerResponse customerResponse = new();
            try
            {
                var result = await context.Customer.FindAsync(customerView.Id);
                if (result != null)
                {
                    //var serialized = JsonConvert.SerializeObject(services);
                    //var deserialized = JsonConvert.DeserializeObject(serialized);
                    result.Name = customerView.Name;
                    result.Address = customerView.Address;
                    result.Phone = customerView.Phone;


                    context.Customer.Update(result);
                    await context.SaveChangesAsync();
                    customerResponse.Message.Add("Customer successfully updated.");
                    customerResponse.Status = true;
                    customerResponse.Type = "alert-success";
                    return customerResponse;
                }
                customerResponse.Message.Add($"Customer with id {customerView.Id} not found.");
                customerResponse.Status = false;
                customerResponse.Type = "alert-danger";
                return customerResponse;

            }
            catch (Exception e)
            {
                customerResponse.Message.Add(e.Message);
                customerResponse.Status = false;
                customerResponse.Type = "alert-danger";
                return customerResponse;
            }
        }

        public async Task<CustomerResponse> deleteCustomer(String id)
        {
            CustomerResponse customerResponse = new();
            try
            {
                var product = await context.Customer.FindAsync(id);
                if (product == null)
                {
                    customerResponse.Message.Add($"Customer with id {id} not found.");
                    customerResponse.Status = false;
                    customerResponse.Type = "alert-danger";
                    return customerResponse;
                }
                context.Customer.Remove(product);
                await context.SaveChangesAsync();
                customerResponse.Message.Add("Customer successfully Deleted.");
                customerResponse.Status = true;
                customerResponse.Type = "alert-success";
                return customerResponse;
            }
            catch (Exception e)
            {
                customerResponse.Message.Add(e.Message);
                customerResponse.Status = false;
                customerResponse.Type = "alert-danger";
                return customerResponse;
            }

        }
    }
}
