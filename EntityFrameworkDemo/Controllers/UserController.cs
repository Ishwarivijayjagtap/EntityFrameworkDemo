using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserCrud db;

        public UsersController(UserCrud db)
        {
            this.db = db;
        }

        // Display login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Handle login POST request
        [HttpPost]
        public IActionResult Login(User user)
        {
            var validUser = db.ValidateUser(user);

            if (validUser != null)
            {
                // Store user session or token
                HttpContext.Session.SetString("UserId", validUser.Id.ToString());
                return RedirectToAction("Index", "Home"); // Redirect to home or dashboard
            }

            ViewBag.Message = "Invalid email or password.";
            return View(user);
        }

        // Display registration page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Handle registration POST request
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            int result = db.AddUser(user);

            if (result > 0)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "User already exists.";
            return View(user);
        }
    }

}
