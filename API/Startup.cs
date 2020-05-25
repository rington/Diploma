using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.UserContext;
using BLL.DIResolver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace API
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
            services.AddDIForBLL();
            services.AddSingleton((_) => new AutoMapper.MapperConfiguration(cfg => {
                cfg.AddProfile<API.Helpers.AutoMapperProfile>();
                cfg.AddProfile<AutoMapperProfile>();
            }).CreateMapper());
            services.AddDbContext<Context>((options) =>
            {
               options.UseSqlServer(@"Server=WIN-RZAIETS;Database=UserHotelDB2;Trusted_Connection=True;");
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<Context>();

            services.ConfigureApplicationCookie((options) =>
            {
                //options.Cookie.Path = "/";
                options.Cookie.SameSite = SameSiteMode.None;
                //options.Cookie.Domain = "localhost";
                options.Cookie.HttpOnly = true;
            });
            
            services.AddMvc();
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
            app.UseCors(builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:8080"));
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
