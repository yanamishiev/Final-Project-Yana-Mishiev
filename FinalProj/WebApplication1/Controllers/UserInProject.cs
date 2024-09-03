using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserInProject : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
