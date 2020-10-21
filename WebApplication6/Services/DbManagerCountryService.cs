using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Services
{
    public class DbManagerCountryService : IDbCountryService
    {
        private AppContext context;
        public DbManagerCountryService(AppContext context)
        {
            this.context = context;
        }
        public async Task AddCountry(CountryArgModel model)
        {
            await context.Countries.AddAsync(ConvertFrom(model));
            await context.SaveChangesAsync();
        }

        public async Task DeleteCountry(int id)
        {
            var country = await context.Countries.FindAsync(id);
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
        }

        public async Task<CountryArgModel> GetCountry(int id)
        {
            var country = await context.Countries.FindAsync(id);
            return ConvertFrom(country);
        }

        public async Task UpdateCountry(CountryArgModel model)
        {
            context.Countries.Update(ConvertFrom(model));
            await context.SaveChangesAsync();
        }
        private CountryArgModel ConvertFrom(Country country)
        {
            return new CountryArgModel()
            {
                Name = country.Name,
                Code = country.Code,
                Cities = country.Cities.Select(x => new CityArgModel()
                {
                    Name = x.Name,
                    Population = x.Population
                }).ToList()
            };
        }

        private Country ConvertFrom(CountryArgModel model)
        {
            return new Country()
            {
                Name = model.Name,
                Code = model.Code,
                Cities = model.Cities.Select(x => new City()
                {
                    Name = x.Name,
                    Population = x.Population
                }).ToList()
            };
        }
    }
}
