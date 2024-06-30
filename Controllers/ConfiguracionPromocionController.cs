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
    public class ConfiguracionPromocionController : Controller
    {
        private readonly AppDbContext _context;

        public ConfiguracionPromocionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ConfiguracionPromocion
        public async Task<IActionResult> Index()
        {
            var bingoDbContext = _context.ConfiguracionPromocions.Include(c => c.IdPromocionNavigation);
            return View(await bingoDbContext.ToListAsync());
        }

        // GET: ConfiguracionPromocion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionPromocion = await _context.ConfiguracionPromocions
                .Include(c => c.IdPromocionNavigation)
                .FirstOrDefaultAsync(m => m.IdConfiguracionPromocion == id);
            if (configuracionPromocion == null)
            {
                return NotFound();
            }

            return View(configuracionPromocion);
        }

        // GET: ConfiguracionPromocion/Create
        public IActionResult Create()
        {
            ViewData["IdPromocion"] = new SelectList(_context.Promocions, "IdPromocion", "IdPromocion");
            return View();
        }

        // POST: ConfiguracionPromocion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracionPromocion,IdPromocion,TipoDescuento,ValorDescuento,RequisitosAplicacion,FechaCreacion,FechaModificacion")] ConfiguracionPromocion configuracionPromocion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracionPromocion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPromocion"] = new SelectList(_context.Promocions, "IdPromocion", "IdPromocion", configuracionPromocion.IdPromocion);
            return View(configuracionPromocion);
        }

        // GET: ConfiguracionPromocion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionPromocion = await _context.ConfiguracionPromocions.FindAsync(id);
            if (configuracionPromocion == null)
            {
                return NotFound();
            }
            ViewData["IdPromocion"] = new SelectList(_context.Promocions, "IdPromocion", "IdPromocion", configuracionPromocion.IdPromocion);
            return View(configuracionPromocion);
        }

        // POST: ConfiguracionPromocion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracionPromocion,IdPromocion,TipoDescuento,ValorDescuento,RequisitosAplicacion,FechaCreacion,FechaModificacion")] ConfiguracionPromocion configuracionPromocion)
        {
            if (id != configuracionPromocion.IdConfiguracionPromocion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionPromocion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionPromocionExists(configuracionPromocion.IdConfiguracionPromocion))
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
            ViewData["IdPromocion"] = new SelectList(_context.Promocions, "IdPromocion", "IdPromocion", configuracionPromocion.IdPromocion);
            return View(configuracionPromocion);
        }

        // GET: ConfiguracionPromocion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionPromocion = await _context.ConfiguracionPromocions
                .Include(c => c.IdPromocionNavigation)
                .FirstOrDefaultAsync(m => m.IdConfiguracionPromocion == id);
            if (configuracionPromocion == null)
            {
                return NotFound();
            }

            return View(configuracionPromocion);
        }

        // POST: ConfiguracionPromocion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracionPromocion = await _context.ConfiguracionPromocions.FindAsync(id);
            if (configuracionPromocion != null)
            {
                _context.ConfiguracionPromocions.Remove(configuracionPromocion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionPromocionExists(int id)
        {
            return _context.ConfiguracionPromocions.Any(e => e.IdConfiguracionPromocion == id);
        }
    }
}
