using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers
{
	public class LabController : Controller
	{
		public IActionResult Info()
		{
			ViewData["LabNumber"] = "Лабораторна робота №1";
			ViewData["Topic"] = "Вступ до ASP.NET Core";
			ViewData["Objective"] = "Ознайомлення з основами MVC у .NET";
			ViewData["StudentName"] = "Андрій Симон";

			return View();
		}
	}
}