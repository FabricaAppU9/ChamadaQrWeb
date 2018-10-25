﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaQR.Data;
using ChamadaQR.Models.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChamadaQR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //Corresponde a Classe starup do chamadaWS
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IESContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("IESConnection")));

            //services.AddDbContext<IESContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("IESConnection")));

            services.AddIdentity<UsuarioDaAplicacao, IdentityRole>()
                    .AddEntityFrameworkStores<IESContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Infra/Acessar";
                options.AccessDeniedPath = "/Infra/AcessoNegado";
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
