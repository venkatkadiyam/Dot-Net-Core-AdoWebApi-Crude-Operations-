using FluentValidation;
using WebApplication1.models;
using WebApplication1.validater;
using FluentValidation.AspNetCore;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1
{
    public class startup
    {
        public IConfiguration Configuration { get; set; }
        public startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       // var builder = WebApplication.CreateBuilder();
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddControllers();
            services.AddScoped<Iinterface,EmplistImplementation>();
            services.AddConnections();
            
            services.AddControllers().AddFluentValidation(x =>
            {

                x.AutomaticValidationEnabled
                 = true;
            });
            services.AddTransient<IValidator<Emplistclass>, Crudeoperationsvalidater>();
           

        }
        public void configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
