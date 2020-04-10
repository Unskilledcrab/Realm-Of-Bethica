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
    public class SpellSaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellSaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellSave
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellSaveModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellSave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSaveModel = await _context.SpellSaveModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellSaveModel == null)
            {
                return NotFound();
            }

            return View(spellSaveModel);
        }

        // GET: SpellSave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellSave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellSaveModel spellSaveModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellSaveModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellSaveModel);
        }

        // GET: SpellSave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSaveModel = await _context.SpellSaveModel.FindAsync(id);
            if (spellSaveModel == null)
            {
                return NotFound();
            }
            return View(spellSaveModel);
        }

        // POST: SpellSave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellSaveModel spellSaveModel)
        {
            if (id != spellSaveModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellSaveModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellSaveModelExists(spellSaveModel.Id))
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
            return View(spellSaveModel);
        }

        // GET: SpellSave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellSaveModel = await _context.SpellSaveModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellSaveModel == null)
            {
                return NotFound();
            }

            return View(spellSaveModel);
        }

        // POST: SpellSave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellSaveModel = await _context.SpellSaveModel.FindAsync(id);
            _context.SpellSaveModel.Remove(spellSaveModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellSaveModelExists(int id)
        {
            return _context.SpellSaveModel.Any(e => e.Id == id);
        }
    }
}
