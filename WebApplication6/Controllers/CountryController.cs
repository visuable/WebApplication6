using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication6.Models;
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CountryController : ControllerBase
    {
        private IDbCountryService _service;
        public CountryController(IDbCountryService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task Add(CountryArgModel model)
        {
            await _service.AddCountry(model);
        }
        [HttpPost]
        public async Task Delete(int id)
        {
            await _service.DeleteCountry(id);
        }
        [HttpPost]
        public async Task Update(CountryArgModel model)
        {
            await _service.UpdateCountry(model);
        }
        [HttpGet]
        public async Task Get(int id)
        {
            await _service.GetCountry(id);
        }
    }
}
