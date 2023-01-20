using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Steve.Model;
using Steve.Service;

namespace SteveMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Index(LoginViewModel loginView, IFormCollection form)
        {
            var result = _userService.ValidLogin(loginView);

            if (result.Item1)
            {
                HttpContext.Session.SetInt32(SessionKey.UserId, result.Item2.Id);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("LoginMessage", "Incorrect Username or Password");
            return View(loginView);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Account");
        }
    }
}
