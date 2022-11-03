using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;

namespace DBFirstProyecto.Controllers
{
    public class FutbolistasController : Controller
    {
        private readonly DBFirstContext _context;

        public FutbolistasController(DBFirstContext context)
        {
            _context = context;
        }

        // GET: Futbolistas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Futbolistas.ToListAsync());
        }

        // GET: Futbolistas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Futbolistas == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // GET: Futbolistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Futbolistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellidos")] Futbolista futbolista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futbolista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(futbolista);
        }

        // GET: Futbolistas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Futbolistas == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolistas.FindAsync(id);
            if (futbolista == null)
            {
                return NotFound();
            }
            return View(futbolista);
        }

        // POST: Futbolistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nombre,Apellidos")] Futbolista futbolista)
        {
            if (id != futbolista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futbolista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutbolistaExists(futbolista.Id))
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
            return View(futbolista);
        }

        // GET: Futbolistas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Futbolistas == null)
            {
                return NotFound();
            }

            var futbolista = await _context.Futbolistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futbolista == null)
            {
                return NotFound();
            }

            return View(futbolista);
        }

        // POST: Futbolistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Futbolistas == null)
            {
                return Problem("Entity set 'DBFirstContext.Futbolistas'  is null.");
            }
            var futbolista = await _context.Futbolistas.FindAsync(id);
            if (futbolista != null)
            {
                _context.Futbolistas.Remove(futbolista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FutbolistaExists(long id)
        {
          return _context.Futbolistas.Any(e => e.Id == id);
        }
    }
}
