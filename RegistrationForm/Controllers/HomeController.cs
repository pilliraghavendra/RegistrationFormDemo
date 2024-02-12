using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.Models;
using System.Diagnostics;
using System.Reflection.Emit;
using RegistrationForm.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _context = applicationContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.LoginForms.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                return RedirectToAction("HomeIndex", "Home");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }
        [HttpGet]
         public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Register(Registration registration) 
        {
        if (ModelState.IsValid) 
            {
            if(registration.Password == registration.ConfirmPassword) 
                {
                    _context.LoginForms.Add(registration);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
            else
                {
                    ViewBag.ConfirmPassword = "Both Password must be same";
                }
            }
        return View("Register");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeIndex()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
