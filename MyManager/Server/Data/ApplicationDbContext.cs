using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyManager.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyManager.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<SmartPhonesModel> Smartphones { get; set; }
        public DbSet<PhoneCaseModel> PhoneCase { get; set; }
        public DbSet<ChargersModel> Charger { get; set; }
        public DbSet<HeadphoneModel> Headphone { get; set; }
        public DbSet<DealerModel> Dealer { get; set; }
        public DbSet<BillModel> Bill { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<SoldModel> Sold { get; set; }
        public DbSet<BillProductModel> BillProducts { get; set; }
        public DbSet<CustomerPurchaseModel> CustomerPurchases { get; set; }
        public DbSet<CustomerCreditModel> CustomerCredits { get; set; }
    }
}