using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FortCode.Helpers;

namespace FortCode
{
    public class Startup
    {     
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options => {
                 options.TokenValidationParameters =
                      new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,

                          ValidIssuer = "FortCode",
                          ValidAudience = "FortCode",
                          IssuerSigningKey =JwtSecurityKey.Create("fortCode ")
                      };
             });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Member",
            //        policy => policy.RequireClaim("MembershipId"));
            //});
            //services.AddAuthentication();
            services.AddAuthorization();

            services
                .AddMvc();

            //services
            //    .AddControllers();
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseAuthorization();
             //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endPoints => { endPoints.MapControllers(); });
                //.UseFileServer()
                //.UseRouting()
                

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}



        }
    }
}
