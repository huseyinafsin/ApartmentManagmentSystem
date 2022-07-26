using System;
using BackgroundJobs.Abstract;
using BackgroundJobs.Concrete;
using BackgroundJobs.Concrete.HangfireJobs;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Bussiness.Concrete;
using Bussiness.Concrete.Apartment;
using Bussiness.Configuration.Filters.Exception;
using Bussiness.Configuration.Filters.Log;
using Bussiness.Configuration.Mapper;
using Core.Repository;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Bussiness.Configuration.Interceptors;
using Core.Cahce.Redis;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Service.Abstract;
using Core.Service.Concretye;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using StackExchange.Redis;
using DataAccess.Abstract.Apartment;
using DataAccess.Concrete.Apartment;

namespace ApartmentManagmentSystem
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

            services.AddControllers(
                opt =>
                opt.Filters.Add<ExceptionFilter>()
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApartmentManagmentSystem", Version = "v1" });
            });

            //Authentication
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            services.AddDbContext<ApartmentContext>();

            //Automapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            // Redis
            var redisConfigInfo = Configuration.GetSection("RedisEndpointInfo").Get<RedisEndpointInfo>();
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.Endpoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.Username

                };
            });
            //Hangfire

            var hangFireDb = Configuration.GetConnectionString("HangfireConnection");
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangFireDb, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            services.AddHangfireServer();
            //Log
            services.AddSingleton<MongoDbLogger>();
            services.AddMongoDbSettings(Configuration);



            //Service Injection
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOperationClaimService, OperationClaimService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IService<,>), typeof(Service<,>));
            services.AddScoped<TransactionInterceptor>();
            services.AddScoped<IJobs, HangfireJobs>();
            services.AddScoped<ISendMessageService, SendMessageService>();
            services.AddScoped<ITenatRepository, TenantRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApartmentManagmentSystem v1"));
            }

            app.UseHangfireDashboard("/hangfire", new DashboardOptions()
            {

            });
            RecurringJob.AddOrUpdate<IJobs>(x => x.ReccuringJob(), "10 19 7 * *");
            
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
