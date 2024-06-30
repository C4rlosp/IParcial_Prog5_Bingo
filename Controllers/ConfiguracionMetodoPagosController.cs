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
    public class ConfiguracionMetodoPagosController : Controller
    {
        private readonly AppDbContext _context;

        public ConfiguracionMetodoPagosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ConfiguracionMetodoPagos
        public async Task<IActionResult> Index()
        {
            var bingoDbContext = _context.ConfiguracionMetodoPagos.Include(c => c.IdMetodoPagoNavigation);
            return View(await bingoDbContext.ToListAsync());
        }

        // GET: ConfiguracionMetodoPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionMetodoPago = await _context.ConfiguracionMetodoPagos
                .Include(c => c.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdConfiguracionMetodoPago == id);
            if (configuracionMetodoPago == null)
            {
                return NotFound();
            }

            return View(configuracionMetodoPago);
        }

        // GET: ConfiguracionMetodoPagos/Create
        public IActionResult Create()
        {
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago");
            return View();
        }

        // POST: ConfiguracionMetodoPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracionMetodoPago,IdMetodoPago,ComisionAplicada,DatosRequeridos,FechaCreacion,FechaModificacion")] ConfiguracionMetodoPago configuracionMetodoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracionMetodoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", configuracionMetodoPago.IdMetodoPago);
            return View(configuracionMetodoPago);
        }

        // GET: ConfiguracionMetodoPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionMetodoPago = await _context.ConfiguracionMetodoPagos.FindAsync(id);
            if (configuracionMetodoPago == null)
            {
                return NotFound();
            }
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", configuracionMetodoPago.IdMetodoPago);
            return View(configuracionMetodoPago);
        }

        // POST: ConfiguracionMetodoPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracionMetodoPago,IdMetodoPago,ComisionAplicada,DatosRequeridos,FechaCreacion,FechaModificacion")] ConfiguracionMetodoPago configuracionMetodoPago)
        {
            if (id != configuracionMetodoPago.IdConfiguracionMetodoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionMetodoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionMetodoPagoExists(configuracionMetodoPago.IdConfiguracionMetodoPago))
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
            ViewData["IdMetodoPago"] = new SelectList(_context.MetodoPagos, "IdMetodoPago", "IdMetodoPago", configuracionMetodoPago.IdMetodoPago);
            return View(configuracionMetodoPago);
        }

        // GET: ConfiguracionMetodoPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionMetodoPago = await _context.ConfiguracionMetodoPagos
                .Include(c => c.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdConfiguracionMetodoPago == id);
            if (configuracionMetodoPago == null)
            {
                return NotFound();
            }

            return View(configuracionMetodoPago);
        }

        // POST: ConfiguracionMetodoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracionMetodoPago = await _context.ConfiguracionMetodoPagos.FindAsync(id);
            if (configuracionMetodoPago != null)
            {
                _context.ConfiguracionMetodoPagos.Remove(configuracionMetodoPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionMetodoPagoExists(int id)
        {
            return _context.ConfiguracionMetodoPagos.Any(e => e.IdConfiguracionMetodoPago == id);
        }
    }
}
