using Microsoft.AspNetCore.Mvc;
using CharitySystem.Models;
using CharitySystem.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using CharitySystem.Extensions;

namespace CharitySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharityRepository repository;
        private readonly CharityDbContext dbContext;
        private const int PageSize = 5;

        public HomeController(ICharityRepository repo, CharityDbContext context)
        {
            repository = repo;
            dbContext = context;
        }

        public IActionResult Index(string? category, int page = 1)
        {
            var filteredEvents = string.IsNullOrEmpty(category)
                ? repository.Events
                : repository.Events.Where(e => e.Category == category);

            var totalItems = filteredEvents.Count();

            var events = filteredEvents
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
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public IActionResult Register(int eventId)
        {
            var eventDetails = repository.Events.FirstOrDefault(e => e.Id == eventId);
            if (eventDetails == null)
            {
                return NotFound();
            }

            var registrationModel = new EventRegistrationModel
            {
                EventId = eventDetails.Id,
                EventTitle = eventDetails.Title
            };

            return View(registrationModel);
        }

        [HttpPost]
        public IActionResult Register(EventRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObject("EventRegistration", model);
                return RedirectToAction("ConfirmRegistration");
            }

            return View(model);
        }

        public IActionResult ConfirmRegistration()
        {
            var registrationData = HttpContext.Session.GetObject<EventRegistrationModel>("EventRegistration");

            if (registrationData == null)
            {
                return RedirectToAction("Index");
            }

            return View(registrationData);
        }

        [HttpPost]
        public IActionResult ConfirmRegistration(EventRegistrationModel model)
        {
            var registrationData = HttpContext.Session.GetObject<EventRegistrationModel>("EventRegistration");

            if (registrationData == null)
            {
                return RedirectToAction("Index");
            }

            registrationData.FirstName = model.FirstName;
            registrationData.LastName = model.LastName;
            registrationData.Email = model.Email;

            try
            {
                var newRegistration = new EventRegistrationModel
                {
                    EventId = registrationData.EventId,
                    FirstName = registrationData.FirstName,
                    LastName = registrationData.LastName,
                    Email = registrationData.Email
                };

                dbContext.EventRegistrations.Add(newRegistration);
                dbContext.SaveChanges();

                Console.WriteLine("Реєстрація успішно збережена в БД");

                HttpContext.Session.Remove("EventRegistration");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні: {ex.Message}");
                return RedirectToAction("Index");
            }
        }

    }
}

