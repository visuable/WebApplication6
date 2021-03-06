﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        [Route(nameof(AddCountry))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task AddCountry(CountryArgModel model)
        {
            await _service.Add(model);
        }
        [HttpGet]
        [Route(nameof(DeleteCountry))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<bool> DeleteCountry(int id)
        {
            return await _service.Delete(id);
        }
        [HttpPost]
        [Route(nameof(UpdateCountry))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task UpdateCountry(CountryArgModel model)
        {
            await _service.Update(model);
        }
        [HttpGet]
        [Route(nameof(GetCountry))]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<CountryArgModel> GetCountry(int id)
        {
            return await _service.Get(id);
        }
    }
}
