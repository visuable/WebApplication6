using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Services
{
    public class DbManagerCountryService : IDbCountryService
    {
        private AppContext context;
        private IMapper _mapper;
        public DbManagerCountryService(AppContext context, IMapper mapper)
        {
            _mapper = mapper;
            this.context = context;

        }
        public async Task Add(CountryArgModel model)
        {
            await context.Countries.AddAsync(_mapper.Map<CountryArgModel, Country>(model));
            await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var country = await context.Countries.FindAsync(id);
            var check = context.Countries.Remove(country);
            await context.SaveChangesAsync();
            if(check != null)
            {
                return true;
            }
            return false;
        }

        public async Task<CountryArgModel> Get(int id)
        {
            var country = await context.Countries.Include(x => x.Cities).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Country, CountryArgModel>(country);
        }

        public async Task Update(CountryArgModel model)
        {
            context.Countries.Update(_mapper.Map<CountryArgModel, Country>(model));
            await context.SaveChangesAsync();
        }
    }
}
