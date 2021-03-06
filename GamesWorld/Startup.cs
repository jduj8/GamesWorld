﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesWorld.Data;
using GamesWorld.Data.Interfaces;
using GamesWorld.Data.Mocks;
using GamesWorld.Data.Models;
using GamesWorld.Data.Repostiories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GamesWorld
{

    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IGameConsoleRepository, GameConsoleRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp)); //object which is associated with a request
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddMvc();
       
            services.AddSession();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {

            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            //app.UseMvcWithDefaultRoute();

            DbInitializer.Seed(serviceProvider.GetRequiredService<AppDbContext>());
            /*
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            */
            //app.UseStaticFiles();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "filterByConsole",
                    template: "{controller=Product}/{action=List}/{console?}");

                
            });
        }
    }
}
