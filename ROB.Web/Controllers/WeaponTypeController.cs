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
    public class WeaponTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeaponType
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeaponTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: WeaponType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponTypeModel = await _context.WeaponTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponTypeModel == null)
            {
                return NotFound();
            }

            return View(weaponTypeModel);
        }

        // GET: WeaponType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeaponType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] WeaponTypeModel weaponTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(weaponTypeModel);
        }

        // GET: WeaponType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponTypeModel = await _context.WeaponTypeModel.FindAsync(id);
            if (weaponTypeModel == null)
            {
                return NotFound();
            }
            return View(weaponTypeModel);
        }

        // POST: WeaponType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] WeaponTypeModel weaponTypeModel)
        {
            if (id != weaponTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponTypeModelExists(weaponTypeModel.Id))
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
            return View(weaponTypeModel);
        }

        // GET: WeaponType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponTypeModel = await _context.WeaponTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponTypeModel == null)
            {
                return NotFound();
            }

            return View(weaponTypeModel);
        }

        // POST: WeaponType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponTypeModel = await _context.WeaponTypeModel.FindAsync(id);
            _context.WeaponTypeModel.Remove(weaponTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponTypeModelExists(int id)
        {
            return _context.WeaponTypeModel.Any(e => e.Id == id);
        }
    }
}
