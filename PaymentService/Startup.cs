using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Bussiness.Abstracts.Payment;
using Bussiness.Concrete.Payment;
using Bussiness.Configuration.Mapper;
using Core.Extensions;
using Core.Repository;
using Core.Service.Abstract;
using Core.Service.Concretye;
using DataAccess.Concrete;

namespace PaymmentService
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymmentService", Version = "v1" });
            });
            services.AddMongoDbSettings(Configuration);
            services.AddScoped(typeof(IRepository<>), typeof(MongoDbRepository<>));
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICreditCardService, CreditCardService>();
            services.AddScoped<IAccountService, AccountService>();

            //Automapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MappingProfile());
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymmentService v1"));
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
