using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using MyManager.Client.Services.ChargerService;
using MyManager.Client.Services.HeadPhoneService;
using MyManager.Client.Services.PhoneCaseService;
using MyManager.Client.Services.PurchaseService;
using MyManager.Client.Services.SmartphoneService;
using MyManager.Shared.Models;
using MyManager.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManager.Client.Pages.CustomerCart
{
    public class AddPurchaseBase: ComponentBase
    {
        public PurchaseView PurchaseView { get; set; } = new();
        public GetSmartphones getSmartphones { get; set; } = new();
        public GetCharger getCharger { get; set; } = new();
        public GetHeadphone getHeadphone { get; set; } = new();
        public GetPhoneCase getPhoneCase { get; set; } = new();
        public PurchaseResponse purchaseResponse { get; set; } = new();
        [Parameter]
        public string custid { get; set; }

        [Inject]
        public IToastService toastService { get; set; }

        [Inject]
        public ISmartphone smartphone { get; set; }
        [Inject]
        public ICharger charger { get; set; }
        [Inject]
        public IPhoneCase phoneCase { get; set; }
        [Inject]
        public IHeadphone headphone { get; set; }
        [Inject]
        public IPurchase purchase { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        //public List<PurchaseView> listofpurchase { get; set; } = new();
        public void addtopurchaselist()
        {
            PurchaseView purchase = new();

            purchase.Customer_Id = custid;
            purchase.Product_Id = PurchaseView.Product_Id;
            purchase.Price = PurchaseView.Price;
            purchase.Product_name = PurchaseView.Product_name;
            purchase.Quantity = PurchaseView.Quantity;
            purchase.TotalPrice = PurchaseView.TotalPrice; 
            PurchaseView.purchaseproduct.Add(purchase);

            PurchaseView.Sum_Total = PurchaseView.purchaseproduct.Sum(p => p.TotalPrice);

            PurchaseView.Product_Id = "";
            PurchaseView.Product_name = "";
            PurchaseView.Quantity = 1;
            PurchaseView.Price = 0;
            PurchaseView.TotalPrice = 0;       
        }

        public async Task sendforcheckout()
        {
            if (PurchaseView.purchaseproduct.Any())
            {
                PurchaseView.Customer_Id = custid;
                var result = await purchase.AddPurchase(PurchaseView);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                   

                    purchaseResponse = await result.Content.ReadFromJsonAsync<PurchaseResponse>();
                    NavigationManager.NavigateTo($"/receipt/{purchaseResponse.Purchase_Id}");
                    //successNotification();
                }
                else
                {
                    //dealerResponse = await result.Content.ReadFromJsonAsync<DealerResponse>();
                    warningNotification();
                }
            }
        }

        public void deletefromlist(string id)
        {
            var product = PurchaseView.purchaseproduct.Where(p => p.Product_Id == id).FirstOrDefault();
            PurchaseView.purchaseproduct.Remove(product);
            PurchaseView.Sum_Total = PurchaseView.purchaseproduct.Sum(p => p.Price);
        }
        //public void getProductbyId (string id)
        //{
        //    var product = listofpurchase.Where(p => p.Id == id).FirstOrDefault();
        //    PurchaseView = product;
        //}

        public async Task getSmartphone()
        {
            var result = await smartphone.GetSmartphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();

            }
            else
            {
                getSmartphones = await result.Content.ReadFromJsonAsync<GetSmartphones>();
                //toastService.ShowWarning(getSmartphones.Message.FirstOrDefault());
            }
        }
        public async Task getCase()
        {
            var result = await phoneCase.GetCase();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                //getPhoneCase.PhoneCases.OrderBy(p => p.Price);
            }
            else
            {
                getPhoneCase = await result.Content.ReadFromJsonAsync<GetPhoneCase>();
                //toastService.ShowWarning(getPhoneCase.Message.FirstOrDefault());
            }
        }
        public async Task getHeadphones()
        {
            var result = await headphone.GetHeadphone();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();

            }
            else
            {
                getHeadphone = await result.Content.ReadFromJsonAsync<GetHeadphone>();
                //toastService.ShowWarning(getHeadphone.Message.FirstOrDefault());
            }
        }
        public async Task getChargers()
        {
            var result = await charger.GetCharger();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();

            }
            else
            {
                getCharger = await result.Content.ReadFromJsonAsync<GetCharger>();
                //toastService.ShowWarning(getCharger.Message.FirstOrDefault());
            }
        }

        public void productChoosen(ChangeEventArgs e)
        {
            PurchaseView.Product_Id = e.Value.ToString();

            var phone = getSmartphones.Smartphones.Where(p => p.Id == PurchaseView.Product_Id).FirstOrDefault();
            var charger = getCharger.Chargers.Where(c => c.Id == PurchaseView.Product_Id).FirstOrDefault();
            var phonecase = getPhoneCase.PhoneCases.Where(pc => pc.Id == PurchaseView.Product_Id).FirstOrDefault();
            var headphone = getHeadphone.Headphones.Where(h => h.Id == PurchaseView.Product_Id).FirstOrDefault();
            if (phone != null)
            {
                PurchaseView.Price = getSmartphones.Smartphones.Where(p => p.Id == PurchaseView.Product_Id).FirstOrDefault().Price;
                PurchaseView.Product_name = getSmartphones.Smartphones.Where(p => p.Id == PurchaseView.Product_Id).FirstOrDefault().Name;
                generateTotal();
            }
            else if (charger != null)
            {
                PurchaseView.Price = getCharger.Chargers.Where(c => c.Id == PurchaseView.Product_Id).FirstOrDefault().Price;
                //PurchaseView.Product_name = getCharger.Chargers.Where(c => c.Id == PurchaseView.Product_Id).FirstOrDefault().name;
                generateTotal();
            }
            else if (phonecase != null)
            {
                PurchaseView.Price = getPhoneCase.PhoneCases.Where(pc => pc.Id == PurchaseView.Product_Id).FirstOrDefault().Price;
                PurchaseView.Product_name = getPhoneCase.PhoneCases.Where(pc => pc.Id == PurchaseView.Product_Id).FirstOrDefault().Name;
                generateTotal();
            }
            if (headphone != null)
            {
                PurchaseView.Price = getHeadphone.Headphones.Where(h => h.Id == PurchaseView.Product_Id).FirstOrDefault().Price;
                PurchaseView.Product_name = getHeadphone.Headphones.Where(h => h.Id == PurchaseView.Product_Id).FirstOrDefault().Name;
                generateTotal();
            }
        }
        
        public void generateTotal()
        {
            PurchaseView.TotalPrice = PurchaseView.Quantity * PurchaseView.Price;
        }
        public void quantityChanged(ChangeEventArgs args)
        {
            string quant = args.Value.ToString();
            PurchaseView.TotalPrice = Int32.Parse(quant) * PurchaseView.Price;
        }
        public void priceChanged(ChangeEventArgs args)
        {
            string prc = args.Value.ToString();
            PurchaseView.TotalPrice = Int32.Parse(prc) * PurchaseView.Quantity;
        }


        protected override async Task OnInitializedAsync()
        {
            await getSmartphone();
            await getChargers();
            await getHeadphones();
            await getCase();
        }
        public void warningNotification()
        {
            foreach (var msg in purchaseResponse.Message)
            {
                toastService.ShowWarning(msg);
            }
        }
    }
}
