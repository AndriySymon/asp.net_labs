using Microsoft.AspNetCore.Mvc;
using CharitySystem.Models;
using System.Linq;

namespace CharitySystem.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly CharityDbContext _context;

        public NavigationMenuViewComponent(CharityDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(string currentCategory)
        {
            var categories = _context.Events
                .Select(e => e.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ViewData["CurrentCategory"] = currentCategory;

            return View(categories);
        }
    }

}
