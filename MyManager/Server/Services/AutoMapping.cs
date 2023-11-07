using AutoMapper;
using MyManager.Server.Models;
using MyManager.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CategoryView, CategoryModel>(); // maps categoryView to categoryModel
            CreateMap<CategoryModel,CategoryView> (); // maps  categoryModel to categoryView

            CreateMap<BrandView, BrandModel>(); // maps BrandView to BrandModel
            CreateMap<BrandModel, BrandView>(); // maps  BrandModel to BrandView

            CreateMap<SmartPhonesModel, SmartphoneView>(); // maps  SmartPhones to SmartphoneView
            CreateMap<SmartphoneView, SmartPhonesModel>(); // maps  SmartphoneView to SmartPhones

            CreateMap<PhoneCaseModel, PhoneCaseView>(); // maps  PhoneCase to PhoneCaseView
            CreateMap<PhoneCaseView, PhoneCaseModel>(); // maps  PhoneCaseView to PhoneCase

            CreateMap<ChargersModel, ChargerView>(); // maps  Chargers to ChargerView
            CreateMap<ChargerView, ChargersModel>(); // maps  ChargerView to Chargers


            CreateMap<HeadphoneModel, HeadphoneView>(); // maps  Headphone to HeadphoneView
            CreateMap<HeadphoneView, HeadphoneModel>(); // maps  HeadphoneView to Headphone

            CreateMap<DealerModel, DealerView>(); // maps  DealerModel to DealerView
            CreateMap<DealerView, DealerModel>(); // maps  DealerView to DealerModel

            CreateMap<BillModel, BillView>(); // maps  BillModel to BillView
            CreateMap<BillView, BillModel>(); // maps  BillView to BillModel

            CreateMap<CustomerModel, CustomerView>(); // maps  CustomerModel to CustomerView
            CreateMap<CustomerView, CustomerModel>(); // maps  CustomerView to CustomerModel

            CreateMap<SoldModel, PurchaseView>(); // maps  PurchaseModel to PurchaseView
            CreateMap<PurchaseView, SoldModel>(); // maps  PurchaseView to PurchaseModel

            CreateMap<CustomerPurchaseModel, PurchaseView>(); // maps  CustomerPurchaseModel to PurchaseView
            CreateMap<PurchaseView, CustomerPurchaseModel>(); // maps  PurchaseView to CustomerPurchaseModel

            CreateMap<CustomerCreditModel, PurchaseView>(); // maps  CustomerCreditModel to PurchaseView
            CreateMap<PurchaseView, CustomerCreditModel>(); // maps  PurchaseView to CustomerCreditModel

            CreateMap<CustomerCreditView, CustomerCreditModel>(); // maps  CustomerCreditView to CustomerCreditModel
            CreateMap<CustomerCreditModel, CustomerCreditView>(); // maps  CustomerCreditModel to CustomerCreditView

        }
    }
}
