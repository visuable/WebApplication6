using AutoMapper;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using WebApplication6.Models;
using WebApplication6.Services;
using WebApplication6.Users;
using WebApplication6.ViewModels;

namespace WebApplication6
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
            services.AddAuthentication("Bearer").AddIdentityServerAuthentication("Bearer", opt =>
            {
                opt.ApiName = "CountryApi";
                opt.Authority = "https://localhost:44388";
            });
            services.AddIdentityServer()
    .AddInMemoryClients(Clients.Get())
    .AddInMemoryIdentityResources(Users.Resources.GetIdentityResources())
    .AddInMemoryApiResources(Users.Resources.GetApiResources())
    .AddInMemoryApiScopes(Users.Resources.GetApiScopes())
    .AddDeveloperSigningCredential();
            services.AddControllers();
            services.AddAutoMapper(typeof(CountryToViewCountryModelProfile), typeof(ViewCountryToCountryModelProfile), typeof(ViewCityToCityModelProfile), typeof(CityToCityViewModelProfile));
            services.AddTransient<IDbCountryService, DbManagerCountryService>();
            services.AddDbContext<AppContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public class CountryToViewCountryModelProfile : Profile
    {
        public CountryToViewCountryModelProfile()
        {
            CreateMap<Country, CountryArgModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name)).ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code)).ForMember(d => d.Cities, opt => opt.MapFrom(s => s.Cities));
        }
    }
    public class ViewCountryToCountryModelProfile : Profile
    {
        public ViewCountryToCountryModelProfile()
        {
            CreateMap<CountryArgModel, Country>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name)).ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code)).ForMember(d => d.Cities, opt => opt.MapFrom(s => s.Cities));
        }
    }
    public class CityToCityViewModelProfile : Profile
    {
        public CityToCityViewModelProfile()
        {
            CreateMap<City, CityArgModel>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name)).ForMember(d => d.Population, opt => opt.MapFrom(s => s.Population));
        }
    }
    public class ViewCityToCityModelProfile : Profile
    {
        public ViewCityToCityModelProfile()
        {
            CreateMap<CityArgModel, City>().ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name)).ForMember(d => d.Population, opt => opt.MapFrom(s => s.Population));
        }
    }
}
