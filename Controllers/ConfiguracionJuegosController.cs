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
    public class ConfiguracionJuegosController : Controller
    {
        private readonly AppDbContext _context;

        public ConfiguracionJuegosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ConfiguracionJuegos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfiguracionJuegos.ToListAsync());
        }

        // GET: ConfiguracionJuegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionJuego = await _context.ConfiguracionJuegos
                .FirstOrDefaultAsync(m => m.IdConfiguracionJuego == id);
            if (configuracionJuego == null)
            {
                return NotFound();
            }

            return View(configuracionJuego);
        }

        // GET: ConfiguracionJuegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionJuegos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracionJuego,IdTipoJuego,CantidadBolas,PatronesGanadores,PremioMayor,PremiosMenores,FechaCreacion,FechaModificacion")] ConfiguracionJuego configuracionJuego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracionJuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuracionJuego);
        }

        // GET: ConfiguracionJuegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionJuego = await _context.ConfiguracionJuegos.FindAsync(id);
            if (configuracionJuego == null)
            {
                return NotFound();
            }
            return View(configuracionJuego);
        }

        // POST: ConfiguracionJuegos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracionJuego,IdTipoJuego,CantidadBolas,PatronesGanadores,PremioMayor,PremiosMenores,FechaCreacion,FechaModificacion")] ConfiguracionJuego configuracionJuego)
        {
            if (id != configuracionJuego.IdConfiguracionJuego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionJuego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionJuegoExists(configuracionJuego.IdConfiguracionJuego))
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
            return View(configuracionJuego);
        }

        // GET: ConfiguracionJuegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionJuego = await _context.ConfiguracionJuegos
                .FirstOrDefaultAsync(m => m.IdConfiguracionJuego == id);
            if (configuracionJuego == null)
            {
                return NotFound();
            }

            return View(configuracionJuego);
        }

        // POST: ConfiguracionJuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracionJuego = await _context.ConfiguracionJuegos.FindAsync(id);
            if (configuracionJuego != null)
            {
                _context.ConfiguracionJuegos.Remove(configuracionJuego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionJuegoExists(int id)
        {
            return _context.ConfiguracionJuegos.Any(e => e.IdConfiguracionJuego == id);
        }
    }
}
