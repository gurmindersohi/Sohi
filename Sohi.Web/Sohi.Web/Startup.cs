using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sohi.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Sohi.Web.Models.Leads;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Sohi.Web.Security;
using Sohi.Web.Models.Emails;
using Sohi.Web.Models.SocialMedia;
using Sohi.Web.Models.Account;
using Azure.Storage.Blobs;
using Sohi.Web.Models.Azure;

namespace Sohi.Web
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("SohiDbConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMvc(option => option.EnableEndpointRouting = false).AddXmlSerializerFormatters();


            //services.AddSingleton()

            //services.AddSingleton(x: IServiceProvider => new BlobServiceClient(Configuration.GetValue<string>(KeyExtensions: "AzureBlobStorageConnectionString")));

            services.AddSingleton(IServiceProvider => new BlobServiceClient(_config.GetSection("AzureStorage").GetSection("ConnectionString").Value));

            services.AddScoped<IBlobRepository, BlobRepository>();

            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();


            services.AddScoped<ILeadsRepository, LeadsRepository>();

            //services.AddScoped<ILeadsRepository, MockLeadsRepository>();
            services.AddScoped<IEmailsRepository, EmailsRepository>();
            //services.AddScoped<IUserRepository, SQLUserRepository>();

            services.AddSingleton<DataProtectionPurposeStrings>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


            app.UseStaticFiles();
            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Dashboard}/{action=Index}/{id?}");
            });


        }
    }
}
