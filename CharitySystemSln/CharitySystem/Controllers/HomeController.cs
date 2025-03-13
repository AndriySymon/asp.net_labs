using Microsoft.AspNetCore.Mvc;
using CharitySystem.Models;
using CharitySystem.Models.ViewModels;
using System.Linq;

namespace CharitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharityRepository repository;
        private const int PageSize = 5;

        public HomeController(ICharityRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(int page = 1)
        {
            var totalItems = repository.Events.Count();
            var events = repository.Events
                .OrderBy(e => e.Date)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var model = new EventListViewModel
            {
                Events = events,
                PagingInfo = new PagingInfo
                {
                    TotalItems = totalItems,
                    ItemsPerPage = PageSize,
                    CurrentPage = page
                }
            };

            return View(model);
        }
    }
}
