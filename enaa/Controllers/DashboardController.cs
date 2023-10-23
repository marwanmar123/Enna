using enaa.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace enaa.Controllers
{
    [Authorize(Roles = "Admin")]
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
