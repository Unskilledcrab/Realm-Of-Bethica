using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROBaspCore.Data;
using ROBaspCore.Models;

namespace ROBaspCore.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class PoisonClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoisonClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoisonClass
        public async Task<IActionResult> Index()
        {
            return View(await _context.PoisonClassModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: PoisonClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonClassModel = await _context.PoisonClassModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonClassModel == null)
            {
                return NotFound();
            }

            return View(poisonClassModel);
        }

        // GET: PoisonClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoisonClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PoisonClassModel poisonClassModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poisonClassModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(poisonClassModel);
        }

        // GET: PoisonClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonClassModel = await _context.PoisonClassModel.FindAsync(id);
            if (poisonClassModel == null)
            {
                return NotFound();
            }
            return View(poisonClassModel);
        }

        // POST: PoisonClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PoisonClassModel poisonClassModel)
        {
            if (id != poisonClassModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poisonClassModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoisonClassModelExists(poisonClassModel.Id))
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
            return View(poisonClassModel);
        }

        // GET: PoisonClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonClassModel = await _context.PoisonClassModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonClassModel == null)
            {
                return NotFound();
            }

            return View(poisonClassModel);
        }

        // POST: PoisonClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poisonClassModel = await _context.PoisonClassModel.FindAsync(id);
            _context.PoisonClassModel.Remove(poisonClassModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool PoisonClassModelExists(int id)
        {
            return _context.PoisonClassModel.Any(e => e.Id == id);
        }
    }
}
