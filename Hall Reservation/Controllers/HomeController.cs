using Hall_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hall_Reservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;

        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult IndexUser()
        {

            var home = _context.Homes.Find((decimal)4);
            ViewBag.Image1 = home.Image1;
            ViewBag.Image2 = home.Image2;
            ViewBag.Image3 = home.Image3;
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");


            var contact = _context.ContactUs.Find((decimal)1);
            ViewBag.ContactMsg = contact.Message;
           



            return View();
        }

        public IActionResult Index()
        {

            var home = _context.Homes.Find((decimal)4);
            ViewBag.Image1 = home.Image1;
            ViewBag.Image2 = home.Image2;
            ViewBag.Image3 = home.Image3;
            var contact = _context.ContactUs.Find((decimal)1);
            ViewBag.ContactMsg = contact.Message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}