
using IParcial_Prog5_Bingo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    public class CartonsController : Controller
    {
        private readonly AppDbContext _context;

        public CartonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cartons
        public async Task<IActionResult> Index()
        {
            var bingoDbContext = _context.Cartons.Include(c => c.IdJuegoNavigation).Include(c => c.IdJugadorNavigation);
            return View(await bingoDbContext.ToListAsync());
        }

        // GET: Cartons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carton = await _context.Cartons
                .Include(c => c.IdJuegoNavigation)
                .Include(c => c.IdJugadorNavigation)
                .FirstOrDefaultAsync(m => m.IdCarton == id);
            if (carton == null)
            {
                return NotFound();
            }

            return View(carton);
        }

        // GET: Cartons/Create
        public IActionResult Create()
        {
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego");
            ViewData["IdJugador"] = new SelectList(_context.Jugadors, "IdJugador", "IdJugador");
            return View();
        }

        // POST: Cartons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarton,IdJuego,IdJugador,Numeros,Estado,FechaCreacion,FechaModificacion")] Carton carton)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", carton.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadors, "IdJugador", "IdJugador", carton.IdJugador);
            return View(carton);
        }

        // GET: Cartons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carton = await _context.Cartons.FindAsync(id);
            if (carton == null)
            {
                return NotFound();
            }
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", carton.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadors, "IdJugador", "IdJugador", carton.IdJugador);
            return View(carton);
        }

        // POST: Cartons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCarton,IdJuego,IdJugador,Numeros,Estado,FechaCreacion,FechaModificacion")] Carton carton)
        {
            if (id != carton.IdCarton)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartonExists(carton.IdCarton))
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
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", carton.IdJuego);
            ViewData["IdJugador"] = new SelectList(_context.Jugadors, "IdJugador", "IdJugador", carton.IdJugador);
            return View(carton);
        }

        // GET: Cartons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carton = await _context.Cartons
                .Include(c => c.IdJuegoNavigation)
                .Include(c => c.IdJugadorNavigation)
                .FirstOrDefaultAsync(m => m.IdCarton == id);
            if (carton == null)
            {
                return NotFound();
            }

            return View(carton);
        }

        // POST: Cartons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carton = await _context.Cartons.FindAsync(id);
            if (carton != null)
            {
                _context.Cartons.Remove(carton);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartonExists(int id)
        {
            return _context.Cartons.Any(e => e.IdCarton == id);
        }
    }
}
