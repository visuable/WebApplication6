using System.Threading.Tasks;
using WebApplication6.ViewModels;

namespace WebApplication6
{
    public interface IDbCountryService
    {
        Task Add(CountryArgModel model);
        Task<bool> Delete(int id);
        Task Update(CountryArgModel model);
        Task<CountryArgModel> Get(int id);
    }
}
