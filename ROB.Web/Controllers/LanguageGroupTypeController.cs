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
    public class LanguageGroupTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageGroupTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LanguageGroupTypeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LanguageGroupTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: LanguageGroupTypeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageGroupTypeModel = await _context.LanguageGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (languageGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(languageGroupTypeModel);
        }

        // GET: LanguageGroupTypeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LanguageGroupTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LanguageType,Description")] LanguageGroupTypeModel languageGroupTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languageGroupTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(languageGroupTypeModel);
        }

        // GET: LanguageGroupTypeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageGroupTypeModel = await _context.LanguageGroupTypeModel.FindAsync(id);
            if (languageGroupTypeModel == null)
            {
                return NotFound();
            }
            return View(languageGroupTypeModel);
        }

        // POST: LanguageGroupTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LanguageType,Description")] LanguageGroupTypeModel languageGroupTypeModel)
        {
            if (id != languageGroupTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageGroupTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageGroupTypeModelExists(languageGroupTypeModel.Id))
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
            return View(languageGroupTypeModel);
        }

        // GET: LanguageGroupTypeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageGroupTypeModel = await _context.LanguageGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (languageGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(languageGroupTypeModel);
        }

        // POST: LanguageGroupTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languageGroupTypeModel = await _context.LanguageGroupTypeModel.FindAsync(id);
            _context.LanguageGroupTypeModel.Remove(languageGroupTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageGroupTypeModelExists(int id)
        {
            return _context.LanguageGroupTypeModel.Any(e => e.Id == id);
        }
    }
}
