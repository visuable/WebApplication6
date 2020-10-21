using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.ViewModels;

namespace WebApplication6
{
    public interface IDbCountryService
    {
        Task AddCountry(CountryArgModel model);
        Task DeleteCountry(int id);
        Task UpdateCountry(CountryArgModel model);
        Task<CountryArgModel> GetCountry(int id);
    }
}
