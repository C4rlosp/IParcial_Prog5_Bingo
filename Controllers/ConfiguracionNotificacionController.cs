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
    public class ConfiguracionNotificacionController : Controller
    {
        private readonly AppDbContext _context;

        public ConfiguracionNotificacionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ConfiguracionNotificacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfiguracionNotificacions.ToListAsync());
        }

        // GET: ConfiguracionNotificacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionNotificacion = await _context.ConfiguracionNotificacions
                .FirstOrDefaultAsync(m => m.IdConfiguracionNotificacion == id);
            if (configuracionNotificacion == null)
            {
                return NotFound();
            }

            return View(configuracionNotificacion);
        }

        // GET: ConfiguracionNotificacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionNotificacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracionNotificacion,TipoNotificacion,EventoNotificacion,PlantillaMensaje,Destinatarios,FechaCreacion,FechaModificacion")] ConfiguracionNotificacion configuracionNotificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracionNotificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configuracionNotificacion);
        }

        // GET: ConfiguracionNotificacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionNotificacion = await _context.ConfiguracionNotificacions.FindAsync(id);
            if (configuracionNotificacion == null)
            {
                return NotFound();
            }
            return View(configuracionNotificacion);
        }

        // POST: ConfiguracionNotificacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracionNotificacion,TipoNotificacion,EventoNotificacion,PlantillaMensaje,Destinatarios,FechaCreacion,FechaModificacion")] ConfiguracionNotificacion configuracionNotificacion)
        {
            if (id != configuracionNotificacion.IdConfiguracionNotificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracionNotificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracionNotificacionExists(configuracionNotificacion.IdConfiguracionNotificacion))
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
            return View(configuracionNotificacion);
        }

        // GET: ConfiguracionNotificacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configuracionNotificacion = await _context.ConfiguracionNotificacions
                .FirstOrDefaultAsync(m => m.IdConfiguracionNotificacion == id);
            if (configuracionNotificacion == null)
            {
                return NotFound();
            }

            return View(configuracionNotificacion);
        }

        // POST: ConfiguracionNotificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configuracionNotificacion = await _context.ConfiguracionNotificacions.FindAsync(id);
            if (configuracionNotificacion != null)
            {
                _context.ConfiguracionNotificacions.Remove(configuracionNotificacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracionNotificacionExists(int id)
        {
            return _context.ConfiguracionNotificacions.Any(e => e.IdConfiguracionNotificacion == id);
        }
    }
}
