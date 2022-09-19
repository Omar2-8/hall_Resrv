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
    public class CheckedsController : Controller
    {
        private readonly ModelContext _context;

        public CheckedsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Checkeds
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Checkeds.Include(x => x.Booking).Include(x => x.Hall).Include(x => x.StatusNavigation).Include(x => x.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Checkeds/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Checkeds == null)
            {
                return NotFound();
            }

            var xchecked = await _context.Checkeds
                .Include(x => x.Booking)
                .Include(x => x.Hall)
                .Include(x => x.StatusNavigation)
                .Include(x => x.User)
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (xchecked == null)
            {
                return NotFound();
            }

            return View(xchecked);
        }

        // GET: Checkeds/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId");
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId");
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Checkeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckId,UserId,HallId,BookingId,CheckedDate,Status")] Checked xchecked)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xchecked);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", xchecked.BookingId);
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", xchecked.HallId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", xchecked.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", xchecked.UserId);
            return View(xchecked);
        }

        // GET: Checkeds/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Checkeds == null)
            {
                return NotFound();
            }

            var xchecked = await _context.Checkeds.FindAsync(id);
            if (xchecked == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", xchecked.BookingId);
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", xchecked.HallId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", xchecked.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", xchecked.UserId);
            return View(xchecked);
        }

        // POST: Checkeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CheckId,UserId,HallId,BookingId,CheckedDate,Status")] Checked xchecked)
        {
            if (id != xchecked.CheckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xchecked);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckedExists(xchecked.CheckId))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", xchecked.BookingId);
            ViewData["HallId"] = new SelectList(_context.Halls, "HallId", "HallId", xchecked.HallId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", xchecked.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", xchecked.UserId);
            return View(xchecked);
        }

        // GET: Checkeds/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Checkeds == null)
            {
                return NotFound();
            }

            var xchecked = await _context.Checkeds
                .Include(x => x.Booking)
                .Include(x => x.Hall)
                .Include(x => x.StatusNavigation)
                .Include(x => x.User)
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (xchecked == null)
            {
                return NotFound();
            }

            return View(xchecked);
        }

        // POST: Checkeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Checkeds == null)
            {
                return Problem("Entity set 'ModelContext.Checkeds'  is null.");
            }
            var xchecked = await _context.Checkeds.FindAsync(id);
            if (xchecked != null)
            {
                _context.Checkeds.Remove(xchecked);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckedExists(decimal id)
        {
          return _context.Checkeds.Any(e => e.CheckId == id);
        }
    }
}
