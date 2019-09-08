using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlPanel.Data;
using ControlPanel.Models;

namespace ControlPanel.Controllers
{
    public class MemoTestsController : Controller
    {
        private readonly MemoTestContext _context;

        public MemoTestsController(MemoTestContext context)
        {
            _context = context;
        }

        // GET: MemoTests
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemoTest.ToListAsync());
        }

        // GET: MemoTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoTest = await _context.MemoTest
                .SingleOrDefaultAsync(m => m.MemoTestID == id);
            if (memoTest == null)
            {
                return NotFound();
            }

            return View(memoTest);
        }

        // GET: MemoTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemoTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemoTestID,Nombre,Categoria,Descripcion,Estado")] MemoTest memoTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memoTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memoTest);
        }

        // GET: MemoTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoTest = await _context.MemoTest.SingleOrDefaultAsync(m => m.MemoTestID == id);
            if (memoTest == null)
            {
                return NotFound();
            }
            return View(memoTest);
        }

        // POST: MemoTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemoTestID,Nombre,Categoria,Descripcion,Estado")] MemoTest memoTest)
        {
            if (id != memoTest.MemoTestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memoTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoTestExists(memoTest.MemoTestID))
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
            return View(memoTest);
        }

        // GET: MemoTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoTest = await _context.MemoTest
                .SingleOrDefaultAsync(m => m.MemoTestID == id);
            if (memoTest == null)
            {
                return NotFound();
            }

            return View(memoTest);
        }

        // POST: MemoTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memoTest = await _context.MemoTest.SingleOrDefaultAsync(m => m.MemoTestID == id);
            _context.MemoTest.Remove(memoTest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoTestExists(int id)
        {
            return _context.MemoTest.Any(e => e.MemoTestID == id);
        }
    }
}
