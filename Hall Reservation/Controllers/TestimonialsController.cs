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
    public class TestimonialsController : Controller
    {
        private readonly ModelContext _context;

        public TestimonialsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Testimonials
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Testimonials.Include(t => t.Home).Include(t => t.StatusNavigation).Include(t => t.User)
                .Where(x => x.Status == 2); 
            return View(await modelContext.ToListAsync());
        }
        public async Task<IActionResult> IndexUser()
        {
           
            var modelContext = _context.Testimonials.Include(t => t.Home).Include(t => t.StatusNavigation).Include(t => t.User)
                .Where(x=>x.Status==1);
            return View(await modelContext.ToListAsync());
        }

        // GET: Testimonials/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Testimonials == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials
                .Include(t => t.Home)
                .Include(t => t.StatusNavigation)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }
        public async Task<IActionResult> Approve(decimal? id)
        {
            if (id == null || _context.Testimonials == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials.FindAsync(id);

            testimonial.Status = 1;
            _context.SaveChanges();
            if (testimonial == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Testimonials");
        }
        public async Task<IActionResult> Decline(decimal? id)
        {
            if (id == null || _context.Testimonials == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials.FindAsync(id);

            testimonial.Status = 0;
            _context.SaveChanges();

            if (testimonial == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Testimonials");
        }

        // GET: Testimonials/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "LoginAndRegestration");
            }

            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "Id");
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Testimonials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,Opinion")] Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                testimonial.UserId = HttpContext.Session.GetInt32("UserId");
                testimonial.HomeId = _context.Homes.First().Id;
                testimonial.Status = 2;
                _context.Add(testimonial);
                await _context.SaveChangesAsync();
               
            }
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "Id", testimonial.HomeId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", testimonial.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", testimonial.UserId);
            return RedirectToAction("IndexUser", "Home");
        }

        // GET: Testimonials/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Testimonials == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null)
            {
                return NotFound();
            }
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "Id", testimonial.HomeId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", testimonial.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", testimonial.UserId);
            return View(testimonial);
        }

        // POST: Testimonials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Rating,Opinion,UserId,HomeId,Status")] Testimonial testimonial)
        {
            if (id != testimonial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimonial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimonialExists(testimonial.Id))
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
            ViewData["HomeId"] = new SelectList(_context.Homes, "Id", "Id", testimonial.HomeId);
            ViewData["Status"] = new SelectList(_context.Checklists, "CheckedId", "CheckedId", testimonial.Status);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", testimonial.UserId);
            return View(testimonial);
        }

        // GET: Testimonials/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Testimonials == null)
            {
                return NotFound();
            }

            var testimonial = await _context.Testimonials
                .Include(t => t.Home)
                .Include(t => t.StatusNavigation)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testimonial == null)
            {
                return NotFound();
            }

            return View(testimonial);
        }

        // POST: Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Testimonials == null)
            {
                return Problem("Entity set 'ModelContext.Testimonials'  is null.");
            }
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestimonialExists(decimal id)
        {
          return _context.Testimonials.Any(e => e.Id == id);
        }
    }
}
