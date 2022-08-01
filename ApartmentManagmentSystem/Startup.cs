using Bussiness.Abstracts;
using Bussiness.Concrete;
using Bussiness.Configuration.Mapper;
using Core.Repository;
using Core.Service;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Bussiness.Configuration.Interceptors;
using Core.Utilities.Security.Encryption;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApartmentManagmentSystem", Version = "v1" });
            });
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

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IOperationClaimService, OperationClaimService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<TransactionInterceptor>();


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
