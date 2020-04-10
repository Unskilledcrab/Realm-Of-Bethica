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
using ROB.Web.Services;

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class DamageTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DamageTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DamageType
        public async Task<IActionResult> Index()
        {
            return View(await _context.DamageTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: DamageType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageTypeModel = await _context.DamageTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (damageTypeModel == null)
            {
                return NotFound();
            }

            return View(damageTypeModel);
        }

        // GET: DamageType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DamageType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] DamageTypeModel damageTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(damageTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(damageTypeModel);
        }

        // GET: DamageType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageTypeModel = await _context.DamageTypeModel.FindAsync(id);
            if (damageTypeModel == null)
            {
                return NotFound();
            }
            return View(damageTypeModel);
        }

        // POST: DamageType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] DamageTypeModel damageTypeModel)
        {
            if (id != damageTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(damageTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DamageTypeModelExists(damageTypeModel.Id))
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
            return View(damageTypeModel);
        }

        // GET: DamageType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var damageTypeModel = await _context.DamageTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (damageTypeModel == null)
            {
                return NotFound();
            }

            return View(damageTypeModel);
        }

        // POST: DamageType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var damageTypeModel = await _context.DamageTypeModel.FindAsync(id);
            _context.DamageTypeModel.Remove(damageTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool DamageTypeModelExists(int id)
        {
            return _context.DamageTypeModel.Any(e => e.Id == id);
        }
    }
}
