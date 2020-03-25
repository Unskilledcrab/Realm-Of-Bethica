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
    public class ArmorRestrictionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmorRestrictionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArmorRestriction
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArmorRestrictionModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: ArmorRestriction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestrictionModel = await _context.ArmorRestrictionModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorRestrictionModel == null)
            {
                return NotFound();
            }

            return View(armorRestrictionModel);
        }

        // GET: ArmorRestriction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArmorRestriction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,FeatValuePenalty,CastingPenalty,EvasionPenalty,MovementPenalty")] ArmorRestrictionModel armorRestrictionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armorRestrictionModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(armorRestrictionModel);
        }

        // GET: ArmorRestriction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestrictionModel = await _context.ArmorRestrictionModel.FindAsync(id);
            if (armorRestrictionModel == null)
            {
                return NotFound();
            }
            return View(armorRestrictionModel);
        }

        // POST: ArmorRestriction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,FeatValuePenalty,CastingPenalty,EvasionPenalty,MovementPenalty")] ArmorRestrictionModel armorRestrictionModel)
        {
            if (id != armorRestrictionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armorRestrictionModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorRestrictionModelExists(armorRestrictionModel.Id))
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
            return View(armorRestrictionModel);
        }

        // GET: ArmorRestriction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestrictionModel = await _context.ArmorRestrictionModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorRestrictionModel == null)
            {
                return NotFound();
            }

            return View(armorRestrictionModel);
        }

        // POST: ArmorRestriction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armorRestrictionModel = await _context.ArmorRestrictionModel.FindAsync(id);
            _context.ArmorRestrictionModel.Remove(armorRestrictionModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ArmorRestrictionModelExists(int id)
        {
            return _context.ArmorRestrictionModel.Any(e => e.Id == id);
        }
    }
}
