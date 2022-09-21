using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hall_Reservation.Models;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Hall_Reservation.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IConfiguration _config;

        public BookingsController(ModelContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: Bookings

        public async Task<IActionResult> IndexUser()
        {
            var modelContext = _context.Bookings.Include(b => b.Hall).Include(b => b.User);
            return View(await modelContext.ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Bookings.Include(b => b.Hall).Include(b => b.User);
            return View(await modelContext.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            var modelContext = _context.Bookings.Include(b => b.Hall).Include(b => b.User);
            return View(await modelContext.ToListAsync());
        }

        public async Task<IActionResult> Between(DateTime start,DateTime end)
        {
            var modelContext = _context.Bookings.Where(x=>x.StartDate >= start && x.EndDate <=end).
                Include(b => b.Hall).Include(b => b.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Hall)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }
        public async Task<IActionResult> CreateUser(decimal? id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "LoginAndRegestration");
            }
           

            var booking = new Booking();
            booking.HallId = id;
            booking.UserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.UserId = HttpContext.Session.GetInt32("UserId");

            ViewData["HallId"] = booking.HallId;


            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,StartDate,EndDate,HallId,UserId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.Creation_Date = DateTime.Now;
                _context.Add(booking);
                await _context.SaveChangesAsync();
                Content("<script language='javascript' type='text/javascript'>alert('Thanks for your reservation! You will reseve an Email when we Confirm your Reservation');</script>");
                return RedirectToAction("IndexUser", "Halls");
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", booking.HallId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", booking.HallId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            return View(booking);
        }
        public async Task<IActionResult> Accept(decimal? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            var user = await _context.Users.FindAsync(booking.UserId);
            sendEmail(user.Email,user.UserId);
            new Checked()
            {
                Status = 1,
                CheckedDate = DateTime.Now,
                BookingId = booking.BookingId,
                HallId = booking.HallId,
                UserId = booking.UserId,


            };


            if (booking == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", booking.HallId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            return RedirectToAction("Index", "Bookings"); ;
        }
        private void sendEmail(string userEmail,decimal id)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailConfiguration:From").Value));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = "Employee Password ";
            email.Body = new TextPart(TextFormat.Html) { Text = "you reservation Have been Confirmed !! \n please head to this link to complete your payment \n https://localhost:44342/Visas/Create/"+id};
            var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailConfiguration:SmtpServer").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailConfiguration:Username").Value, _config.GetSection("EmailConfiguration:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<IActionResult> Decline(decimal? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            new Checked()
            {
                Status = 0,
                CheckedDate = DateTime.Now,
                BookingId = booking.BookingId,
                HallId = booking.HallId,
                UserId = booking.UserId,


            };
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", booking.HallId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            return View(booking);
        }


        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("BookingId,StartDate,EndDate,HallId,UserId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", booking.HallId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Hall)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'ModelContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(decimal id)
        {
          return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
