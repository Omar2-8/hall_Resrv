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
    public class HallsController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public HallsController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: Halls

        public  IEnumerable<Hall>  Search(string searchTerm)
        {

            if (string.IsNullOrEmpty(searchTerm))
            {
               // var modelContext =
                  return  _context.Halls.Include(h => h.Address).Include(h => h.Category);
               // View(await modelContext.ToListAsync());

            }
            else
            {
               // var modelContext
                return _context.Halls.Where(x => x.HallName.Contains(searchTerm)
                || x.CategoryName.Contains(searchTerm) || x.AddressName.Contains(searchTerm)).
                Include(h => h.Address).Include(h => h.Category);
                
                    //View(await modelContext.ToListAsync());

            }

        }
        public async Task<IActionResult> IndexUser(string searchTerm)
            {
            try
            {
                if (string.IsNullOrEmpty(searchTerm))
            {
                var modelContext = _context.Halls.Include(h => h.Address).Include(h => h.Category);
                return View(await modelContext.ToListAsync());

            }
            else
            {
                var modelContext = _context.Halls.Include(h => h.Address).Include(h => h.Category)
                    .Where(x => x.HallName.Contains(searchTerm)
                || x.Category.CatName.Contains(searchTerm) || x.Address.City.Contains(searchTerm));
               
                return View(await modelContext.ToListAsync());

            }

            }
            catch (Exception)
            {

                return RedirectToAction("Login", "LoginAndRegestration");
            }
            
            
        }
        //public async Task<IActionResult> IndexUser()
        //{
        //    var modelContext = _context.Halls.Include(h => h.Address).Include(h => h.Category);
        //    return View(await modelContext.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {
            try
            { 
                var modelContext = _context.Halls.Include(h => h.Address).Include(h => h.Category);
            return View(await modelContext.ToListAsync());

            }
            catch (Exception)
            {

               return  RedirectToAction("Login", "LoginAndRegestration");
            }
           

          
        }

        // GET: Halls/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .Include(h => h.Address)
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.HallId == id);
            if (hall == null)
            {
                return NotFound();
            }

            return View(hall);
        }

        // GET: Halls/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CatId", "CatId");
            ViewData["Address"] = new SelectList(_context.Addresses, "City", "City");
            ViewData["Category"] = new SelectList(_context.Categories, "CatName", "CatName");

            return View();
        }

        // POST: Halls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HallId,HallName,HallCapacity,HallDescription,BookingPrice,Street,BuildingNumber,ImageFile,CategoryName,AddressName")] Hall hall)
        {
            try
            {
                var cat = _context.Categories.First(x => x.CatName == hall.CategoryName).CatId;
                var address = _context.Addresses.First(x => x.City == hall.AddressName).AddressId;
           
                string fileName = Guid.NewGuid().ToString() + "_" + hall.ImageFile.FileName;
                string extension = Path.GetExtension(hall.ImageFile.FileName);
                hall.ImagePath = fileName;
                string path = Path.Combine(_webHostEnviroment.WebRootPath + "/images/" + fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await hall.ImageFile.CopyToAsync(filestream);
                }

                hall.CategoryId = cat;
                hall.AddressId = address;


                _context.Add(hall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hall.AddressId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CatId", "CatId", hall.CategoryId);
            return View(hall);

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET: Halls/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hall.AddressId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CatId", "CatId", hall.CategoryId);
            return View(hall);
        }

        // POST: Halls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("HallId,CategoryId,HallName,HallCapacity,ImagePath,HallDescription,BookingPrice,AddressId,Street,BuildingNumber")] Hall hall)
        {
            if (id != hall.HallId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HallExists(hall.HallId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hall.AddressId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CatId", "CatId", hall.CategoryId);
            return View(hall);
        }

        // GET: Halls/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Halls == null)
            {
                return NotFound();
            }

            var hall = await _context.Halls
                .Include(h => h.Address)
                .Include(h => h.Category)
                .FirstOrDefaultAsync(m => m.HallId == id);
            if (hall == null)
            {
                return NotFound();
            }

            return View(hall);
        }

        // POST: Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Halls == null)
            {
                return Problem("Entity set 'ModelContext.Halls'  is null.");
            }
            var hall = await _context.Halls.FindAsync(id);
            if (hall != null)
            {
                _context.Halls.Remove(hall);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HallExists(decimal id)
        {
          return _context.Halls.Any(e => e.HallId == id);
        }
    }
}
