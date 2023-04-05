using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SistemaContas.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home/Index
        [Authorize] 
        public IActionResult Index()
        {
            return View();
        }
    }
}
