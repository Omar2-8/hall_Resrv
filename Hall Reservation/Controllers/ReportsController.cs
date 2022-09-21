using Hall_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hall_Reservation.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ModelContext _context;

        public ReportsController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Reports()
        {
            ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");
            //ViewBag.LoginId = HttpContext.Session.GetInt32("LoginId");
            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.AdminImage = HttpContext.Session.GetString("AdminImage");

            ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
            ViewBag.ReportDate = DateTime.Now;

            var modelContext = _context.Checkeds.Where(c => c.Status == 1).Include(p => p.Booking).Include(h => h.Hall).Include(u => u.User).ToList();


            return View(modelContext);

        }
        [HttpPost]
        public async Task<IActionResult> Reports(DateTime? checkedDate)  /*, DateTime? endDate*/
        {
            ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");
            //ViewBag.LoginId = HttpContext.Session.GetInt32("LoginId");
            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.AdminImage = HttpContext.Session.GetString("AdminImage");


            var modelContext = _context.Checkeds.Where(c => c.Status == 1).Include(p => p.Booking).Include(h => h.Hall).Include(u => u.User);

            if (checkedDate == null)
            {
                ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
                ViewBag.ReportDate = DateTime.Now;
                return View(modelContext);
            }
            else /*if (checkedDate != null)*/
            {
                ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
                ViewBag.ReportDate = DateTime.Now;

                var result = await modelContext.Where(c => c.CheckedDate.Value.Month == checkedDate.Value.Month).ToListAsync();
                return View(result);
            }
        }


        [HttpGet]
        public IActionResult ReportsAnnual()
        {
            ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");
            //ViewBag.LoginId = HttpContext.Session.GetInt32("LoginId");
            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.AdminImage = HttpContext.Session.GetString("AdminImage");

            ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
            ViewBag.ReportDate = DateTime.Now;

            var modelContext = _context.Checkeds.Where(c => c.Status == 1).Include(p => p.Booking).Include(h => h.Hall).Include(u => u.User).ToList();


            return View(modelContext);

        }
        [HttpPost]
        public async Task<IActionResult> ReportsAnnual(DateTime? checkedDate)  /*, DateTime? endDate*/
        {
            ViewBag.AdminId = HttpContext.Session.GetInt32("AdminId");
            //ViewBag.LoginId = HttpContext.Session.GetInt32("LoginId");
            ViewBag.AdminName = HttpContext.Session.GetString("AdminName");
            ViewBag.AdminImage = HttpContext.Session.GetString("AdminImage");


            var modelContext = _context.Checkeds.Where(c => c.Status == 1).Include(p => p.Booking).Include(h => h.Hall).Include(u => u.User);

            if (checkedDate == null)
            {
                ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
                ViewBag.ReportDate = DateTime.Now;
                return View(modelContext);
            }
            else /*if (checkedDate != null)*/
            {
                ViewBag.NumberOfUsersWhoHaveBooked = _context.Checkeds.Where(r => r.Status == 1).Select(x => x.UserId).Distinct().Count();
                ViewBag.ReportDate = DateTime.Now;

                var result = await modelContext.Where(c => c.CheckedDate.Value.Year == checkedDate.Value.Year).ToListAsync();
                return View(result);
            }
        }
    }
}
