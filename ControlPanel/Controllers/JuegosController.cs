using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Models;
using ControlPanel.Data;

namespace ControlPanel.Controllers
{
    public class JuegosController : Controller
    {
        private readonly ControlPanelContext _context;

        public JuegosController(ControlPanelContext context)
        {
            _context = context;
        }

        // GET: Juegos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Juego.ToListAsync());
        }

        // GET: Juegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juego
                .SingleOrDefaultAsync(m => m.JuegoID == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // GET: Juegos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juegos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JuegoID,Nombre,Categoria,Descripcion,Estado")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juego.SingleOrDefaultAsync(m => m.JuegoID == id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

        // POST: Juegos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JuegoID,Nombre,Categoria,Descripcion,Estado")] Juego juego)
        {
            if (id != juego.JuegoID)
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
                    if (!JuegoExists(juego.JuegoID))
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

        // GET: Juegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juego = await _context.Juego
                .SingleOrDefaultAsync(m => m.JuegoID == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // POST: Juegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juego = await _context.Juego.SingleOrDefaultAsync(m => m.JuegoID == id);
            _context.Juego.Remove(juego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
            return _context.Juego.Any(e => e.JuegoID == id);
        }
    }
}
