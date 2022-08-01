using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class FlatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
