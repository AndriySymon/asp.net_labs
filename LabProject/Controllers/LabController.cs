using Microsoft.AspNetCore.Mvc;

namespace LabProject.Controllers
{
	public class LabController : Controller
	{
		public IActionResult Info()
		{
			ViewData["LabNumber"] = "����������� ������ �1";
			ViewData["Topic"] = "����� �� ASP.NET Core";
			ViewData["Objective"] = "������������ � �������� MVC � .NET";
			ViewData["StudentName"] = "����� �����";

			return View();
		}
	}
}