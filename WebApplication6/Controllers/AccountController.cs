using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Controllers
{
    public class AccountController : ControllerBase
    {
        private AppContext context;
        public AccountController(AppContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public void Auth()
        {
        }
    }
}
