using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PriceManager.Infrastructure.Data;
using PriceManager.Infrastructure.Data.Interfaces;
using PriceManager.Infrastructure.Data.Repositories;
using PriceManager.Infrastructure.Models.Models;
using PriceManager.Infrastructure.Services.Interfaces;
using PriceManager.Infrastructure.Services.Services;
using ISecurityService = PriceManager.Infrastructure.Services.Interfaces.ISecurityService;

namespace PriceManager.Api
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
            // Adding logger
            services.AddSingleton<ILoggerFactory, NullLoggerFactory>();

            // Adding configuration
            services.AddSingleton<IConfiguration>(Configuration);

            // Adding the in-memory database context
            services.AddDbContext<ManagerDbContext>(options =>
                options.UseInMemoryDatabase("PriceManager"));

            // Adding repositories
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IMarketRepository, MarketRepository>();
            services.AddScoped<ICompanyPriceRepository, CompanyPriceRepository>();

            // Adding services
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IPriceManagementService, PriceManagementService>();

            services.AddControllers();

            // Adding swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Price Manager API", Version = "v1" });
            });

            // Adding JWT authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });

            // adding authorization
            services.AddAuthorization();

            // adding CORS policy
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ensuring database created on startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ManagerDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Setting up swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Price Manager API V1");
            });

            app.UseHttpsRedirection();

            // Serving angular app files statically for demonstration
            string staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "AngularAppFiles");
            app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(staticFilesPath) });

            app.UseRouting();

            // Enabling CORS policy
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // Mapping angular paths to index
                foreach (string path in new[] { "/", "/dashboard", "/sign-in" })
                    endpoints.MapGet(path, async context =>
                    {
                        await context.Response.SendFileAsync(staticFilesPath + "/index.html");
                    });

            });
        }
    }
}
