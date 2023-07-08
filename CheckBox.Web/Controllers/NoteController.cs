using Microsoft.AspNetCore.Mvc;

namespace CheckBox.Web.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
