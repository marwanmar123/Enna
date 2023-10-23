using enaa.Data;
using enaa.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace enaa.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public NavbarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Nav = new NavViewModel()
            {
                Menu = await _context.Menu.ToListAsync(),
                Home = await _context.HomeNav.ToListAsync(),
            };
            return View(Nav);
        }
    }
}
