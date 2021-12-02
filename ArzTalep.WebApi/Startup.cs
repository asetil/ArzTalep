using System;
using System.Net;
using System.Threading.Tasks;
using ArzTalep.BL.Data;
using AD = ArzTalep.BL.Dependency;
using Aware.Dependency;
using Aware.Util;
using Aware.Util.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ArzTalep.WebApi
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
            var dependencySetting = new DependencySetting()
            {
                OrmType = Configuration.GetEnum<ORMType>("OrmType"),
                ConnectionString = Configuration.GetConnectionString("ArzTalepCS"),
                DbType = Configuration.GetEnum<DatabaseType>("DbType"),
                CacheMode = Configuration.GetEnum<CacheMode>("CacheMode"),
                UseIntercepter = Configuration.GetValue<bool>("UseIntercepter")
            };
            var libraryInstaller = new AD.LibraryInstaller();
            libraryInstaller.Install(ref services, dependencySetting);

            if (dependencySetting.OrmType == ORMType.EntityFramework)
            {
                services.AddDbContext<ArzTalep.BL.Data.ArzTalepDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ArzTalepCS")));
            }

            services.AddScoped<IServiceProvider, ServiceProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            var jwtSecretKey = Configuration.GetValue<string>("Jwt:SecretKey");
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //Same Secret key will be used while creating the token
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
                    ValidateIssuer = true,
                    //Usually, this is your application base URL
                    ValidIssuer = "https://localhost:44348/",
                    ValidateAudience = true,
                    ////Here, we are creating and using JWT within the same application.
                    ////In this case, base URL is fine.
                    ////If the JWT is created using a web service, then this would be the consumer URL.
                    ValidAudience = "https://localhost:44348/",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
