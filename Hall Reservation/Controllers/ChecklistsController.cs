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
    public class ChecklistsController : Controller
    {
        private readonly ModelContext _context;

        public ChecklistsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Checklists
        public async Task<IActionResult> Index()
        {
              return View(await _context.Checklists.ToListAsync());
        }

        // GET: Checklists/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Checklists == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists
                .FirstOrDefaultAsync(m => m.CheckedId == id);
            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // GET: Checklists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checklists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckedId,Status")] Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checklist);
        }

        // GET: Checklists/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Checklists == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }
            return View(checklist);
        }

        // POST: Checklists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CheckedId,Status")] Checklist checklist)
        {
            if (id != checklist.CheckedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecklistExists(checklist.CheckedId))
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
            return View(checklist);
        }

        // GET: Checklists/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Checklists == null)
            {
                return NotFound();
            }

            var checklist = await _context.Checklists
                .FirstOrDefaultAsync(m => m.CheckedId == id);
            if (checklist == null)
            {
                return NotFound();
            }

            return View(checklist);
        }

        // POST: Checklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Checklists == null)
            {
                return Problem("Entity set 'ModelContext.Checklists'  is null.");
            }
            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist != null)
            {
                _context.Checklists.Remove(checklist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChecklistExists(decimal id)
        {
          return _context.Checklists.Any(e => e.CheckedId == id);
        }
    }
}
