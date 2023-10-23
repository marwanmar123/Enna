using enaa.Data;
using Microsoft.AspNetCore.Mvc;

namespace enaa.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
