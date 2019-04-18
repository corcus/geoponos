using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoponos.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Geoponos.Infrastructure.EntityFramework.Entities;
using Geoponos.Core.Interfaces.Repositories;
using Geoponos.Infrastructure.EntityFramework.Repositories;
using Geoponos.Core.Interfaces.UseCases;
using Geoponos.Core.UseCases;
using Geoponos.Api.Presenters;
using Geoponos.Core.Interfaces.Services;
using Geoponos.Infrastructure.Services;

namespace Geoponos.Api
{
    public class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default"), sql => sql.MigrationsAssembly("Geoponos.Infrastructure")));
            
            //identity
            services
                .AddIdentityCore<EFUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(5));

            //always before automapper
            services.AddMvc();

            services.AddAutoMapper();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<RegisterUserPresenter>();
            services.AddScoped<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();  
        }
    }
}
