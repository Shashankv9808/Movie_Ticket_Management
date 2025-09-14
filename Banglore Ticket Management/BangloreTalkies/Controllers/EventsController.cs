using Microsoft.AspNetCore.Mvc;

namespace BangloreTalkies.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
