using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using activate_assurance.DataAccess;
using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.DataAccess.Data.Repository.Impl;
using activate_assurance.Services;
using activate_assurance.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace backend_activate_assurance
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
            services.AddDbContext<ApplicationDbContext>(options =>

            options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAssuranceRepository, AssuranceRepository>();
            services.AddScoped<ICommerceRepository, CommerceRepository>();
            services.AddScoped<IUsersCommerceRepository, UsersCommerceRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped(typeof(IServicesTemplate<>), typeof(Produ<>));
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IClientServices, ClientServices>();
            //services.AddScoped<IActivateAssuranceRepository, ActivateAssuranceRepository>();
            //services.AddScoped<ICommerceRepository, CommerceRepository>();
            //services.AddScoped<IUsersCommerceRepository, UsersCommerceRepository>();
            //services.AddScoped<IClaimAssuranceRepository, ClaimAssuranceRepository>();



            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
