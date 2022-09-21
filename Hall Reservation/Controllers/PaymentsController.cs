using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hall_Reservation.Models;

namespace Hall_Reservation.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ModelContext _context;

        public PaymentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Payments.Include(p => p.Booking).Include(p => p.HallNameNavigation).Include(p => p.PayAmountNavigation).Include(p => p.PayUser).Include(p => p.StatusNavigation).Include(p => p.Visa);
            return View(await modelContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .Include(p => p.HallNameNavigation)
                .Include(p => p.PayAmountNavigation)
                .Include(p => p.PayUser)
                .Include(p => p.StatusNavigation)
                .Include(p => p.Visa)
                .FirstOrDefaultAsync(m => m.PayId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create(decimal id)
        {
            var visa = _context.Visas.First(x => x.UserId == id);
            var booking = _context.Bookings.First(x => x.UserId == id);
            var check = _context.Checkeds.First(x => x.UserId == id);
            var hall = _context.Halls.First(x => x.HallId == check.HallId);

            var payment = new Payment();
            payment.Status = 1;
            if (visa.VisaAmount - hall.BookingPrice > 0)
            {
                visa.VisaAmount -= hall.BookingPrice;
                payment.PayAmount = hall.BookingPrice;
                payment.PayDesc = "Thanks for Dealing With us";


            }
            else
            {
                payment.PayAmount = 0;
                payment.Status = 0;
                payment.PayDesc = "Insuficant Ballence";


            }
            payment.PayDate = DateTime.Now;
            payment.PayUserId = id;
            payment.VisaId = visa.VisaId;
            payment.BookingId = booking.BookingId;
            _context.Add(payment);
            _context.SaveChanges();
            //await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = payment.PayId });

            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["HallName"] = new SelectList(_context.Halls, "HallId", "HallId");
            ViewData["PayAmount"] = new SelectList(_context.Halls, "HallId", "HallId");
            ViewData["PayUserId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["Status"] = new SelectList(_context.Checkeds, "CheckId", "CheckId");
            ViewData["VisaId"] = new SelectList(_context.Visas, "VisaId", "VisaId");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("PayId,Status,PayAmount,HallName,PayDate,PayDesc,PayUserId,VisaId,BookingId")] Payment payment)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(payment);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", payment.BookingId);
        //    ViewData["HallName"] = new SelectList(_context.Halls, "HallId", "HallId", payment.HallName);
        //    ViewData["PayAmount"] = new SelectList(_context.Halls, "HallId", "HallId", payment.PayAmount);
        //    ViewData["PayUserId"] = new SelectList(_context.Users, "UserId", "UserId", payment.PayUserId);
        //    ViewData["Status"] = new SelectList(_context.Checkeds, "CheckId", "CheckId", payment.Status);
        //    ViewData["VisaId"] = new SelectList(_context.Visas, "VisaId", "VisaId", payment.VisaId);
        //    return View(payment);
        //}
        //public async Task<IActionResult> Create(decimal id)
        //{
        //    var visa = _context.Visas.First(x => x.UserId == id);
        //    var booking = _context.Bookings.First(x => x.UserId == id);
        //    var check = _context.Checkeds.First(x => x.UserId == id);
        //    var hall = _context.Halls.First(x => x.HallId == check.HallId);

        //    var payment = new Payment();
        //    payment.Status = 1;
        //    if (visa.VisaAmount - hall.BookingPrice > 0)
        //    {
        //        visa.VisaAmount -= hall.BookingPrice;
        //        payment.PayAmount = hall.BookingPrice;


        //    }
        //    else
        //    {
        //        payment.PayAmount = 0;
        //        payment.Status = 0;
        //        payment.PayDesc = "Insuficant Ballence";


        //    }
        //    payment.PayUserId = id;
        //    payment.VisaId = visa.VisaId;
        //    payment.BookingId = booking.BookingId;
        //    _context.Add(payment);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Details", new {id = payment.PayId});
        //    //return RedirectToAction();



            
        //    //ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", payment.BookingId);
        //    //ViewData["HallName"] = new SelectList(_context.Halls, "HallId", "HallId", payment.HallName);
        //    //ViewData["PayAmount"] = new SelectList(_context.Halls, "HallId", "HallId", payment.PayAmount);
        //    //ViewData["PayUserId"] = new SelectList(_context.Users, "UserId", "UserId", payment.PayUserId);
        //    //ViewData["Status"] = new SelectList(_context.Checkeds, "CheckId", "CheckId", payment.Status);
        //    //ViewData["VisaId"] = new SelectList(_context.Visas, "VisaId", "VisaId", payment.VisaId);
        //    //return View(payment);
        //}

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", payment.BookingId);
            ViewData["HallName"] = new SelectList(_context.Halls, "HallId", "HallId", payment.HallName);
            ViewData["PayAmount"] = new SelectList(_context.Halls, "HallId", "HallId", payment.PayAmount);
            ViewData["PayUserId"] = new SelectList(_context.Users, "UserId", "UserId", payment.PayUserId);
            ViewData["Status"] = new SelectList(_context.Checkeds, "CheckId", "CheckId", payment.Status);
            ViewData["VisaId"] = new SelectList(_context.Visas, "VisaId", "VisaId", payment.VisaId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("PayId,Status,PayAmount,HallName,PayDate,PayDesc,PayUserId,VisaId,BookingId")] Payment payment)
        {
            if (id != payment.PayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PayId))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", payment.BookingId);
            ViewData["HallName"] = new SelectList(_context.Halls, "HallId", "HallId", payment.HallName);
            ViewData["PayAmount"] = new SelectList(_context.Halls, "HallId", "HallId", payment.PayAmount);
            ViewData["PayUserId"] = new SelectList(_context.Users, "UserId", "UserId", payment.PayUserId);
            ViewData["Status"] = new SelectList(_context.Checkeds, "CheckId", "CheckId", payment.Status);
            ViewData["VisaId"] = new SelectList(_context.Visas, "VisaId", "VisaId", payment.VisaId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Payments == null)
            {
                return NotFound();
            }

            var payment = await _context.Payments
                .Include(p => p.Booking)
                .Include(p => p.HallNameNavigation)
                .Include(p => p.PayAmountNavigation)
                .Include(p => p.PayUser)
                .Include(p => p.StatusNavigation)
                .Include(p => p.Visa)
                .FirstOrDefaultAsync(m => m.PayId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Payments == null)
            {
                return Problem("Entity set 'ModelContext.Payments'  is null.");
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(decimal id)
        {
          return _context.Payments.Any(e => e.PayId == id);
        }
    }
}
