using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
//using Store.Business.BlogBusiness;
//using Store.Business.Interfaces;
//using Store.Repository.BlogRepository;
//using Store.Repository.Interfaces;
using Store.Data;
using System.Configuration;
using Store.Business.Interface;
using Store.Business.StoreBusiness;
using Store.Repository.Interfaces;
using Store.Repository.CinemaRepository;

namespace Store.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigurationServicies(IServiceCollection services)
        { 
            services.AddControllers();

            services.AddDbContext<CinemaDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Store API", Version = "v1.0" });
            });
        }
    }
}
