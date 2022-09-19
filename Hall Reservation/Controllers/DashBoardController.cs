using Hall_Reservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hall_Reservation.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly ModelContext _context;

        public DashBoardController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            var count = _context.Users.Count();
            var halls = _context.Halls.Count();
            var reserved = _context.Checkeds.Count();
            return View();
        }

       
        //public ActionResult usersCount()
        //{
            
        //    ViewBag.TotalCountUsers = count;
        //    ViewData["Users"]=count;
        //    return View(count);
        //}

        //public ActionResult hallsCount()
        //{
        //   
        //    ViewBag.CountHalls=halls;
        //    ViewData["halls"]=halls;
        //    return View(halls);
        //}

     
        //public ActionResult reservedHallsCount()
        //{
        //    
        //    ViewBag.ReservedHalls=reserved;
        //    ViewData["reservedHalls"] = reserved;
        //    return View(reserved);
        //}








    }
}
