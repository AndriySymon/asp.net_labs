using Microsoft.AspNetCore.Mvc;
using CharitySystem.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CharitySystem.Controllers
{
    public class UserController : Controller
    {
        private readonly CharityDbContext _context;

        public UserController(CharityDbContext context)
        {
            _context = context;
        }


        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Цей email вже зареєстрований");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }


        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                ModelState.AddModelError("", "Невірний логін або пароль");
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            return RedirectToAction("Profile");
        }


        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.Find(userId.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }


        public IActionResult Edit()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.Find(userId.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserModel updatedUser)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null || updatedUser.Id != userId)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                _context.Users.Update(updatedUser);
                _context.SaveChanges();
                return RedirectToAction("Profile");
            }

            return View(updatedUser);
        }


        public IActionResult Delete()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.Find(userId.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login");

            var user = _context.Users.Find(userId.Value);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            HttpContext.Session.Clear();

            return RedirectToAction("Register");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
