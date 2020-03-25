using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROBaspCore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ROBaspCore.Models;
using Microsoft.AspNetCore.Routing;
using System.IO;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Identity.UI.Services;
using ROBaspCore.Services;
using ROBaspCore.Attributes;
using AutoMapper;

namespace ROBaspCore
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //if (environment.IsDevelopment())
            //{
            //    services.AddDbContext<Data.ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            Configuration.GetConnectionString("DevelopmentConnection")));
            //}
            //else
            //{
                services.AddDbContext<Data.ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));
            //}

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers().AddNewtonsoftJson();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()                
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role")
                                    .RequireClaim("Edit Role")
                                    .RequireClaim("Create Role"));
                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireClaim("Edit Role")
                                    .RequireClaim("Create Role"));
                options.AddPolicy("CreateRolePolicy",
                    policy => policy.RequireClaim("Create Role"));
            });

            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            });

            services.AddScoped<AuthorizeSheetOwnerAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();  
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
