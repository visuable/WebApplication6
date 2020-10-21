using Microsoft.AspNetCore.Mvc;

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
