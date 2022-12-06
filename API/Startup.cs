using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API
{
    internal class Startup
    {
        public IConfiguration _config { get;}
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(_config.GetConnectionString("cn"));
            });

            // Only for development 
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyHeader().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"});
            });
            services.AddMediatR(typeof(List.Handler).Assembly);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseCors("CorsPolicy");
                app.UseAuthorization();
                app.UseEndpoints(endpoints => 
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}