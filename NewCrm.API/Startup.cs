using System;
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
            app.UseMvc();
        }
    }
}
