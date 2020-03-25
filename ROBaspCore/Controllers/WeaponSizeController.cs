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
    public class WeaponSizeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponSizeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeaponSize
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeaponSizeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: WeaponSize/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponSizeModel = await _context.WeaponSizeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponSizeModel == null)
            {
                return NotFound();
            }

            return View(weaponSizeModel);
        }

        // GET: WeaponSize/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeaponSize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,DamageModifier,WeightModifier")] WeaponSizeModel weaponSizeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponSizeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(weaponSizeModel);
        }

        // GET: WeaponSize/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponSizeModel = await _context.WeaponSizeModel.FindAsync(id);
            if (weaponSizeModel == null)
            {
                return NotFound();
            }
            return View(weaponSizeModel);
        }

        // POST: WeaponSize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,DamageModifier,WeightModifier")] WeaponSizeModel weaponSizeModel)
        {
            if (id != weaponSizeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponSizeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponSizeModelExists(weaponSizeModel.Id))
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
            return View(weaponSizeModel);
        }

        // GET: WeaponSize/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponSizeModel = await _context.WeaponSizeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponSizeModel == null)
            {
                return NotFound();
            }

            return View(weaponSizeModel);
        }

        // POST: WeaponSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponSizeModel = await _context.WeaponSizeModel.FindAsync(id);
            _context.WeaponSizeModel.Remove(weaponSizeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponSizeModelExists(int id)
        {
            return _context.WeaponSizeModel.Any(e => e.Id == id);
        }
    }
}
