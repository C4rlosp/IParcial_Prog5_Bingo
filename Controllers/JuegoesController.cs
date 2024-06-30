using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IParcial_Prog5_Bingo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    public class JuegoesController : Controller
    {
       
        private readonly AppDbContext _context;

        public JuegoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Juegoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juegos.ToListAsync());
        }

        // GET: Juegoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.IdJuego == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }
        [Route("api/juegos")]
        [ApiController]
        public class JuegosApiController : ControllerBase
        {
            private readonly AppDbContext _context;

            public JuegosApiController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/juegos/buscar
            [HttpGet("buscar")]
            public ActionResult<IEnumerable<Juego>> BuscarJuegos(DateTime? fechaJuego, string estado)
            {
                IQueryable<Juego> query = _context.Juegos;

                if (fechaJuego.HasValue)
                {
                    query = query.Where(j => j.FechaJuego.Date == fechaJuego.Value.Date);
                }

                if (!string.IsNullOrEmpty(estado))
                {
                    query = query.Where(j => j.Estado.Contains(estado));
                }

                var juegos = query.ToList();

                return juegos;
            }
        }

            // GET: Juegoes/Create
            public IActionResult Create()
        {
            return View();
        }

        // POST: Juegoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJuego,FechaJuego,TipoJuego,PrecioCarton,PremioMayor,PremiosMenores,Estado,FechaCreacion,FechaModificacion")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juegoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

        // POST: Juegoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJuego,FechaJuego,TipoJuego,PrecioCarton,PremioMayor,PremiosMenores,Estado,FechaCreacion,FechaModificacion")] Juego juego)
        {
            if (id != juego.IdJuego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegoExists(juego.IdJuego))
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
            return View(juego);
        }

        // GET: Juegoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.IdJuego == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // POST: Juegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juego = await _context.Juegos.FindAsync(id);
            if (juego != null)
            {
                _context.Juegos.Remove(juego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
            return _context.Juegos.Any(e => e.IdJuego == id);
        }
    }
}
