using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCastController : Controller
    {
        public IActionResult CastList()
        {
            return View();
        }
    }
}
