using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NxCore.API.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NxCore.API
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
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme) // "Bearer" token authentication
                .AddIdentityServerAuthentication(options => {
                    options.Authority = "https://localhost:5001"; // url to our IDP app
                    options.ApiName = "nxcoreapi";  // most match IDP config apis
                });

            services.AddHttpContextAccessor(); // we need him so it can be injected elswhere e.g.  handlers
          //  services.AddScoped<IAuthorizationHandler, MustOwnImageHandler>();
            //services.AddAuthorization(authOptions =>
            //{
            //    authOptions.AddPolicy(
            //        "MustOwnImage",
            //        policyBuilder =>
            //        {
            //            policyBuilder.RequireAuthenticatedUser(); // must be authenticaded
            //            // logged in user owns an image
            //            policyBuilder.AddRequirements(
            //                new MustOwnImageRequirement()
            //             );
            //        }
            //        );
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NxCore.API", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NxCore.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization(); // access to controllers

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
