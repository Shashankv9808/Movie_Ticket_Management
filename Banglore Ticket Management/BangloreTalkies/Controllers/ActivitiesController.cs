using Microsoft.AspNetCore.Mvc;

namespace BangloreTalkies.Controllers
{
    public class ActivitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
