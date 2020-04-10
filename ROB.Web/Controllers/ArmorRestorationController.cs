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
    public class ArmorRestorationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArmorRestorationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArmorRestoration
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArmorRestorationModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: ArmorRestoration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestorationModel = await _context.ArmorRestorationModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorRestorationModel == null)
            {
                return NotFound();
            }

            return View(armorRestorationModel);
        }

        // GET: ArmorRestoration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArmorRestoration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArmorStyle,Description,DamageRatingRestoration,Cost,RepairTimeHours")] ArmorRestorationModel armorRestorationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armorRestorationModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(armorRestorationModel);
        }

        // GET: ArmorRestoration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestorationModel = await _context.ArmorRestorationModel.FindAsync(id);
            if (armorRestorationModel == null)
            {
                return NotFound();
            }
            return View(armorRestorationModel);
        }

        // POST: ArmorRestoration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArmorStyle,Description,DamageRatingRestoration,Cost,RepairTimeHours")] ArmorRestorationModel armorRestorationModel)
        {
            if (id != armorRestorationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armorRestorationModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorRestorationModelExists(armorRestorationModel.Id))
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
            return View(armorRestorationModel);
        }

        // GET: ArmorRestoration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorRestorationModel = await _context.ArmorRestorationModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorRestorationModel == null)
            {
                return NotFound();
            }

            return View(armorRestorationModel);
        }

        // POST: ArmorRestoration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armorRestorationModel = await _context.ArmorRestorationModel.FindAsync(id);
            _context.ArmorRestorationModel.Remove(armorRestorationModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ArmorRestorationModelExists(int id)
        {
            return _context.ArmorRestorationModel.Any(e => e.Id == id);
        }
    }
}
