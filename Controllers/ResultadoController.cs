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
    public class ResultadoController : Controller
    {
        private readonly AppDbContext _context;

        public ResultadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Resultado
        public async Task<IActionResult> Index()
        {
            var bingoDbContext = _context.Resultados.Include(r => r.IdCartonGanadorNavigation).Include(r => r.IdJuegoNavigation);
            return View(await bingoDbContext.ToListAsync());
        }

        // GET: Resultado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.IdCartonGanadorNavigation)
                .Include(r => r.IdJuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdResultado == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // GET: Resultado/Create
        public IActionResult Create()
        {
            ViewData["IdCartonGanador"] = new SelectList(_context.Cartons, "IdCarton", "IdCarton");
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego");
            return View();
        }

        // POST: Resultado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdResultado,IdJuego,BolaExtraida,FechaHoraExtraccion,IdCartonGanador,FechaCreacion,FechaModificacion")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCartonGanador"] = new SelectList(_context.Cartons, "IdCarton", "IdCarton", resultado.IdCartonGanador);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", resultado.IdJuego);
            return View(resultado);
        }

        // GET: Resultado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
            {
                return NotFound();
            }
            ViewData["IdCartonGanador"] = new SelectList(_context.Cartons, "IdCarton", "IdCarton", resultado.IdCartonGanador);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", resultado.IdJuego);
            return View(resultado);
        }

        // POST: Resultado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdResultado,IdJuego,BolaExtraida,FechaHoraExtraccion,IdCartonGanador,FechaCreacion,FechaModificacion")] Resultado resultado)
        {
            if (id != resultado.IdResultado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultadoExists(resultado.IdResultado))
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
            ViewData["IdCartonGanador"] = new SelectList(_context.Cartons, "IdCarton", "IdCarton", resultado.IdCartonGanador);
            ViewData["IdJuego"] = new SelectList(_context.Juegos, "IdJuego", "IdJuego", resultado.IdJuego);
            return View(resultado);
        }

        // GET: Resultado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _context.Resultados
                .Include(r => r.IdCartonGanadorNavigation)
                .Include(r => r.IdJuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdResultado == id);
            if (resultado == null)
            {
                return NotFound();
            }

            return View(resultado);
        }

        // POST: Resultado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado != null)
            {
                _context.Resultados.Remove(resultado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultadoExists(int id)
        {
            return _context.Resultados.Any(e => e.IdResultado == id);
        }
    }
}
