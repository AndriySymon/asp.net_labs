using CharitySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AccountController : Controller
{
    private readonly CharityDbContext context;

    public AccountController(CharityDbContext ctx)
    {
        context = ctx;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(UserModel model)
    {
        if (ModelState.IsValid)
        {
            if (context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Користувач з таким Email вже існує.");
                return View(model);
            }

            context.Users.Add(model);
            context.SaveChanges();

            return RedirectToAction("Login");
        }
        return View(model);
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Неправильний email або пароль.");
        return View();
    }

    public IActionResult Profile()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login");

        var user = context.Users.Find(userId);
        return View(user);
    }

    public IActionResult Edit() => Profile();

    [HttpPost]
    public IActionResult Edit(UserModel model)
    {
        if (ModelState.IsValid)
        {
            context.Users.Update(model);
            context.SaveChanges();
            return RedirectToAction("Profile");
        }
        return View(model);
    }

    public IActionResult Delete()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId == null) return RedirectToAction("Login");

        var user = context.Users.Find(userId);
        if (user == null) return RedirectToAction("Profile"); 

        return View(user); 
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed()
    {
        var userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                HttpContext.Session.Clear();
            }
        }

        return RedirectToAction("Index", "Home"); 
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
