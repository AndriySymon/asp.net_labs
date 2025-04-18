using Microsoft.AspNetCore.Mvc;
using CharitySystem.Models;
using System.Linq;

namespace CharitySystem.Controllers
{
	public class EventController : Controller
	{
		private readonly CharityDbContext _context;

		public EventController(CharityDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
            var events = _context.Events.ToList();
            return View("AllEvents", events);
        }

		public IActionResult Create() => View();

		[HttpPost]
		public IActionResult Create(Event e)
		{
			if (ModelState.IsValid)
			{
				_context.Events.Add(e);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(e);
		}

		public IActionResult Details(long? id)
		{
			var e = _context.Events.Find(id);
			return View(e);
		}

		public IActionResult Edit(long? id)
		{
			var e = _context.Events.Find(id);
			return View(e);
		}

		[HttpPost]
		public IActionResult Edit(Event e)
		{
			if (ModelState.IsValid)
			{
				_context.Events.Update(e);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(e);
		}

		public IActionResult Delete(long? id)
		{
			var e = _context.Events.Find(id);
			return View(e);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(long? id)
		{
			var e = _context.Events.Find(id);
			_context.Events.Remove(e);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
