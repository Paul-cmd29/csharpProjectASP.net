using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CompStore.Models;

namespace CompStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Laptops.ToList());
        }
    }
}