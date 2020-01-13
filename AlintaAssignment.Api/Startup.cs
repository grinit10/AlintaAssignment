using AlintaAssignment.Api.Extensions;
using AlintaAssignment.Data;
using AlintaAssignment.DomainLogic;
using AlintaAssignment.Repositories.Store;
using AlintaAssignment.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AlintaAssignment.Api
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
            services.AddDbContext<CustomerDbContext>(options => options.UseInMemoryDatabase(databaseName: "CustomersDb"));
            services.AddScoped(typeof(ICustomerDbContext), typeof(CustomerDbContext));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork)); services.AddControllers();
            services.AddScoped(typeof(ICustomerManager), typeof(CustomerManager)); services.AddControllers();
            services.AddTransient<CustomLoggingExceptionFilter>();
        }

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
