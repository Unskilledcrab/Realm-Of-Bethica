using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class SpellSizeLimitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellSizeLimitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellSizeLimit
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellSizeLimitModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellSizeLimit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSizeLimitModel = await _context.SpellSizeLimitModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellSizeLimitModel == null)
            {
                return NotFound();
            }

            return View(spellSizeLimitModel);
        }

        // GET: SpellSizeLimit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellSizeLimit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellSizeLimitModel spellSizeLimitModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellSizeLimitModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellSizeLimitModel);
        }

        // GET: SpellSizeLimit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSizeLimitModel = await _context.SpellSizeLimitModel.FindAsync(id);
            if (spellSizeLimitModel == null)
            {
                return NotFound();
            }
            return View(spellSizeLimitModel);
        }

        // POST: SpellSizeLimit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellSizeLimitModel spellSizeLimitModel)
        {
            if (id != spellSizeLimitModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellSizeLimitModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellSizeLimitModelExists(spellSizeLimitModel.Id))
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
            return View(spellSizeLimitModel);
        }

        // GET: SpellSizeLimit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSizeLimitModel = await _context.SpellSizeLimitModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellSizeLimitModel == null)
            {
                return NotFound();
            }

            return View(spellSizeLimitModel);
        }

        // POST: SpellSizeLimit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellSizeLimitModel = await _context.SpellSizeLimitModel.FindAsync(id);
            _context.SpellSizeLimitModel.Remove(spellSizeLimitModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellSizeLimitModelExists(int id)
        {
            return _context.SpellSizeLimitModel.Any(e => e.Id == id);
        }
    }
}
