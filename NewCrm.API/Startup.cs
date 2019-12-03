﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using NewCrm.DataLayer.Entities.User;
using NewCrm.DataLayer.Context;
using NewCrm.Core.Services;
using NewCrm.Core.Services.Interfaces;
using NewCrm.Core.TicketServices.Interfaces;
using NewCrm.Core.TicketServices;
using NewCrm.Core.Generators;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace NewCrm.API
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

            services.AddCors(opt => opt.AddPolicy("Cors", builder => {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            #region DataContext
            services.AddDbContext<NewCrmContext>(option => 
                option.UseSqlServer(Configuration.GetConnectionString("NewCrmConnection")));
            #endregion

            #region Intetfaces

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IStaffService, StaffService>();
            services.AddTransient<IserviceType, ServiceTypeService>();
            services.AddTransient<ITicketService, TicketServices>();
            services.AddTransient<IgetService, GetService>();
            services.AddTransient<ITicketChat, TicketChatService>();
            services.AddTransient<IDeveloperService, DeveloperServices>();
            services.AddTransient<IAccessCode, AccessCode>();
            services.AddTransient<IUnivercityService, UnivercityService>();
            services.AddTransient<IUniReport, UniReport>();
            #endregion

            #region JWT
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Cors");
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
