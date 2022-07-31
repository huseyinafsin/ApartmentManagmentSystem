using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
