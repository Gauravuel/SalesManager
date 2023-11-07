using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyManager.Server.Data;
using MyManager.Server.Models;
using MyManager.Server.Repository.Account;
using MyManager.Server.Repository.Bill;
using MyManager.Server.Repository.BillProduct;
using MyManager.Server.Repository.Brand;
using MyManager.Server.Repository.Category;
using MyManager.Server.Repository.Customer;
using MyManager.Server.Repository.Dealer;
using MyManager.Server.Repository.Inventory;
using MyManager.Server.Repository.Purchase;
using MyManager.Server.Services;
using System.Linq;

namespace MyManager.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

         
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //swagger configuaration

            services.AddSwaggerGen(options =>
            {
            options.SwaggerDoc("V1", new OpenApiInfo{
                Title = "Swagger Api",
                Description = "This is the APi interface for My Manager",
                Version = "V1"
                 });
            });

            //SMTP configuration
            services.Configure<SMTPConfigModel>(Configuration.GetSection("Mail"));

            //setting up auto mapper
            services.AddAutoMapper(typeof(Startup));

            //Dependency injection

            services.AddScoped<IUserAccount, UserAccount>();
            services.AddScoped<IProductCategory, ProductCategory>();
            services.AddScoped<IProductBrand, ProductBrand>();
            services.AddScoped<ISmartphonesinventory, Smartphonesinventory>();
            services.AddScoped<IPhoneCaseInventory, PhoneCaseInventory>();
            services.AddScoped<IChargerInventory, ChargerInventory>();
            services.AddScoped<IHeadphoneInventory, HeadphoneInventory>();
            services.AddScoped<IDealerrepo, Dealerrepo>();
            services.AddScoped<ICustomerrepo, Customerrepo>();
            services.AddScoped<IBillrepo, Billrepo>();
            services.AddScoped<IPurchaserepo,Purchaserepo>();
            services.AddScoped<IBillProductrepo, BillProductrepo>();
            services.AddTransient<UserSeeder>();
            services.AddScoped<IEmailService, EmailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserSeeder userSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            //swagger setup
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Swagger Api");
                options.RoutePrefix = "swagger";
            });

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            userSeeder.SeedUser();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
