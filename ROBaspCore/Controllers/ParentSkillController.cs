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
    public class ParentSkillController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentSkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParentSkill
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParentSkillModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: ParentSkill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentSkillModel = await _context.ParentSkillModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (parentSkillModel == null)
            {
                return NotFound();
            }

            return View(parentSkillModel);
        }

        // GET: ParentSkill/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ParentSkillModel parentSkillModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentSkillModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(parentSkillModel);
        }

        // GET: ParentSkill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentSkillModel = await _context.ParentSkillModel.FindAsync(id);
            if (parentSkillModel == null)
            {
                return NotFound();
            }
            return View(parentSkillModel);
        }

        // POST: ParentSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ParentSkillModel parentSkillModel)
        {
            if (id != parentSkillModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentSkillModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentSkillModelExists(parentSkillModel.Id))
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
            return View(parentSkillModel);
        }

        // GET: ParentSkill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parentSkillModel = await _context.ParentSkillModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (parentSkillModel == null)
            {
                return NotFound();
            }

            return View(parentSkillModel);
        }

        // POST: ParentSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parentSkillModel = await _context.ParentSkillModel.FindAsync(id);
            _context.ParentSkillModel.Remove(parentSkillModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ParentSkillModelExists(int id)
        {
            return _context.ParentSkillModel.Any(e => e.Id == id);
        }
    }
}
