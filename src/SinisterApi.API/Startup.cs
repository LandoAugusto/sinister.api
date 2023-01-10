﻿using SinisterApi.API.Extensions;
using Infrastruture.CrossCutting.IoC.Extensions;

namespace SinisterApi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApi(Configuration);
            services.AddIoC(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sinister.Api v1"));
                app.UseCors(MyAllowSpecificOrigins);
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
