using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CountryController : ControllerBase
    {
        private AppContext context;
        public CountryController(AppContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Country> Countries()
        {
            var countries = context.Countries.AsEnumerable();
            return countries;
        }
        [HttpPost]
        public void Countries([FromBody]Country country)
        {
            context.Countries.Add(country);
            context.SaveChanges();
            RedirectToAction("Countries");
        }
        [HttpPost]
        public void Update([FromBody] Country country)
        {
            context.Countries.Update(country);
            context.SaveChanges();
            RedirectToAction("Countries");
        }
    }
}
