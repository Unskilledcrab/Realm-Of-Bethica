using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROBaspCore.Data;
using ROBaspCore.Models;

namespace ROBaspCore.Controllers
{
    public class SpellController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spell
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SpellModel
                .Include(s => s.ArcaneSphere)
                .Include(s => s.Area)
                .Include(s => s.CastingTime)
                .Include(s => s.Duration)
                .Include(s => s.Range)
                .Include(s => s.Save)
                .Include(s => s.SizeLimit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Spell/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellModel = await _context.SpellModel
                .Include(s => s.ArcaneSphere)
                .Include(s => s.Area)
                .Include(s => s.CastingTime)
                .Include(s => s.Duration)
                .Include(s => s.Range)
                .Include(s => s.Save)
                .Include(s => s.SizeLimit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spellModel == null)
            {
                return NotFound();
            }

            return View(spellModel);
        }

        // GET: Spell/Create
        public IActionResult Create()
        {
            ViewData["ArcaneSphereId"] = new SelectList(_context.ArcaneSphereModel.AsNoTracking(), "Id", "Name");
            ViewData["AreaId"] = new SelectList(_context.SpellAreaModel.AsNoTracking(), "Id", "Name");
            ViewData["CastingTimeId"] = new SelectList(_context.SpellCastingTimeModel.AsNoTracking(), "Id", "Name");
            ViewData["DurationId"] = new SelectList(_context.SpellDurationModel.AsNoTracking(), "Id", "Name");
            ViewData["RangeId"] = new SelectList(_context.SpellRangeModel.AsNoTracking(), "Id", "Name");
            ViewData["SaveId"] = new SelectList(_context.SpellSaveModel.AsNoTracking(), "Id", "Name");
            ViewData["SizeLimitId"] = new SelectList(_context.SpellSizeLimitModel.AsNoTracking(), "Id", "Name");
            return View();
        }

        // POST: Spell/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneSphereId,RangeId,AreaId,SizeLimitId,DurationId,SaveId,CastingTimeId,Damage,Armor,Movement,Description,Notes")] SpellModel spellModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArcaneSphereId"] = new SelectList(_context.ArcaneSphereModel, "Id", "Name", spellModel.ArcaneSphereId);
            ViewData["AreaId"] = new SelectList(_context.SpellAreaModel, "Id", "Name", spellModel.AreaId);
            ViewData["CastingTimeId"] = new SelectList(_context.SpellCastingTimeModel, "Id", "Name", spellModel.CastingTimeId);
            ViewData["DurationId"] = new SelectList(_context.SpellDurationModel, "Id", "Name", spellModel.DurationId);
            ViewData["RangeId"] = new SelectList(_context.SpellRangeModel, "Id", "Name", spellModel.RangeId);
            ViewData["SaveId"] = new SelectList(_context.SpellSaveModel, "Id", "Name", spellModel.SaveId);
            ViewData["SizeLimitId"] = new SelectList(_context.SpellSizeLimitModel, "Id", "Name", spellModel.SizeLimitId);
            return View(spellModel);
        }

        // GET: Spell/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellModel = await _context.SpellModel.FindAsync(id);
            if (spellModel == null)
            {
                return NotFound();
            }
            ViewData["ArcaneSphereId"] = new SelectList(_context.ArcaneSphereModel, "Id", "Name", spellModel.ArcaneSphereId);
            ViewData["AreaId"] = new SelectList(_context.SpellAreaModel, "Id", "Name", spellModel.AreaId);
            ViewData["CastingTimeId"] = new SelectList(_context.SpellCastingTimeModel, "Id", "Name", spellModel.CastingTimeId);
            ViewData["DurationId"] = new SelectList(_context.SpellDurationModel, "Id", "Name", spellModel.DurationId);
            ViewData["RangeId"] = new SelectList(_context.SpellRangeModel, "Id", "Name", spellModel.RangeId);
            ViewData["SaveId"] = new SelectList(_context.SpellSaveModel, "Id", "Name", spellModel.SaveId);
            ViewData["SizeLimitId"] = new SelectList(_context.SpellSizeLimitModel, "Id", "Name", spellModel.SizeLimitId);
            return View(spellModel);
        }

        // POST: Spell/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneSphereId,RangeId,AreaId,SizeLimitId,DurationId,SaveId,CastingTimeId,Damage,Armor,Movement,Description,Notes")] SpellModel spellModel)
        {
            if (id != spellModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellModelExists(spellModel.Id))
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
            ViewData["ArcaneSphereId"] = new SelectList(_context.ArcaneSphereModel, "Id", "Name", spellModel.ArcaneSphereId);
            ViewData["AreaId"] = new SelectList(_context.SpellAreaModel, "Id", "Name", spellModel.AreaId);
            ViewData["CastingTimeId"] = new SelectList(_context.SpellCastingTimeModel, "Id", "Name", spellModel.CastingTimeId);
            ViewData["DurationId"] = new SelectList(_context.SpellDurationModel, "Id", "Name", spellModel.DurationId);
            ViewData["RangeId"] = new SelectList(_context.SpellRangeModel, "Id", "Name", spellModel.RangeId);
            ViewData["SaveId"] = new SelectList(_context.SpellSaveModel, "Id", "Name", spellModel.SaveId);
            ViewData["SizeLimitId"] = new SelectList(_context.SpellSizeLimitModel, "Id", "Name", spellModel.SizeLimitId);
            return View(spellModel);
        }

        // GET: Spell/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellModel = await _context.SpellModel
                .Include(s => s.ArcaneSphere)
                .Include(s => s.Area)
                .Include(s => s.CastingTime)
                .Include(s => s.Duration)
                .Include(s => s.Range)
                .Include(s => s.Save)
                .Include(s => s.SizeLimit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spellModel == null)
            {
                return NotFound();
            }

            return View(spellModel);
        }

        // POST: Spell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellModel = await _context.SpellModel.FindAsync(id);
            _context.SpellModel.Remove(spellModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellModelExists(int id)
        {
            return _context.SpellModel.Any(e => e.Id == id);
        }
    }
}
