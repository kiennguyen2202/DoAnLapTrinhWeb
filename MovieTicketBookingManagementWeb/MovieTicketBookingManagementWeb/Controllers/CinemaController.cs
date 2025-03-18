using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTicketBookingManagementWeb.Models;

namespace MovieTicketBookingManagementWeb.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return View(cinemas);
        }
        public async Task<IActionResult> Display(int? id)
        {
            if (id == null) return NotFound();

            var cinema = await _context.Cinemas
                .Include(c => c.Rooms)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cinema == null) return NotFound();

            return View(cinema);
        }
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,Location")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return NotFound();

            return View(cinema);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location")] Cinema cinema)
        {
            if (id != cinema.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Cinemas.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cinema = await _context.Cinemas
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cinema == null) return NotFound();

            return View(cinema);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
}
}
