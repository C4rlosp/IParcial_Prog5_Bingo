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
    public class ParametrosGeneralesController : Controller
    {
        private readonly AppDbContext _context;

        public ParametrosGeneralesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ParametrosGenerales
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParametrosGenerales.ToListAsync());
        }

        // GET: ParametrosGenerales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametrosGenerale = await _context.ParametrosGenerales
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (parametrosGenerale == null)
            {
                return NotFound();
            }

            return View(parametrosGenerale);
        }

        // GET: ParametrosGenerales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParametrosGenerales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametro,Nombre,Valor,Descripcion,FechaCreacion,FechaModificacion")] ParametrosGenerale parametrosGenerale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametrosGenerale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parametrosGenerale);
        }

        // GET: ParametrosGenerales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametrosGenerale = await _context.ParametrosGenerales.FindAsync(id);
            if (parametrosGenerale == null)
            {
                return NotFound();
            }
            return View(parametrosGenerale);
        }

        // POST: ParametrosGenerales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametro,Nombre,Valor,Descripcion,FechaCreacion,FechaModificacion")] ParametrosGenerale parametrosGenerale)
        {
            if (id != parametrosGenerale.IdParametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametrosGenerale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametrosGeneraleExists(parametrosGenerale.IdParametro))
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
            return View(parametrosGenerale);
        }

        // GET: ParametrosGenerales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametrosGenerale = await _context.ParametrosGenerales
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (parametrosGenerale == null)
            {
                return NotFound();
            }

            return View(parametrosGenerale);
        }

        // POST: ParametrosGenerales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parametrosGenerale = await _context.ParametrosGenerales.FindAsync(id);
            if (parametrosGenerale != null)
            {
                _context.ParametrosGenerales.Remove(parametrosGenerale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametrosGeneraleExists(int id)
        {
            return _context.ParametrosGenerales.Any(e => e.IdParametro == id);
        }
    }
}
