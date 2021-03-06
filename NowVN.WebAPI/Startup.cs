﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NowVN.Framework.Models;
using NowVN.Framework.Helpers;
using NowVN.Framework.ProductLogic;
using NowVN.Framework.CustomerLogic;
using NowVN.Framework.ViewModels;
using NowVN.Framework.ViewModels.EntityViewModel;
using NowVN.Logic.OrderLogic;
using NowVN.Logic.CartLogic;
using NowVN.Logic.OrderDetailLogic;

namespace NowVN.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<NowVNSimulatorContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("NowVNConnectionString"));
            });
            
            this.setupAuthentication(services);
            this.setupAutoMapper();
            this.setupDependencyInjection(services);
            this.setupAuthorization(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        private void setupAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, UserRegisterdViewModel>();
                cfg.CreateMap<UserRegisterdViewModel, Customer>();

                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();

                cfg.CreateMap<OrderViewModel, Order>();
                cfg.CreateMap<Order, OrderViewModel>();

                cfg.CreateMap<OrderDetailsViewModel, OrderDetails>();
                cfg.CreateMap<OrderDetails, OrderDetailsViewModel>();
            });

        }

        private void setupDependencyInjection(IServiceCollection services)
        {
            //services.AddSingleton<AppSettings>(appSettings);
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddScoped<DbContext, NowVNSimulatorContext>();
            services.AddScoped<ExtensionSettings>();
            services.AddScoped<JwtSecurityTokenProvider>();

            //resolve logic instance
            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<ICustomerLogic, CustomerLogic>();
            services.AddScoped<IOrderLogic, OrderLogic>();
            services.AddScoped<ICartLogic, CartLogic>();
            services.AddScoped<IOrderDetailLogic, OrderDetailLogic>();


        }

        private void setupAuthentication(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        private void setupAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Customer", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });
        }
    }
}
