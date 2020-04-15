using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class ArmorController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArmorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Armor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ArmorModel.Include(a => a.ArmorRestoration).Include(a => a.ArmorRestriction);
            return View(await applicationDbContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: Armor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorModel = await _context.ArmorModel
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorModel == null)
            {
                return NotFound();
            }

            return View(armorModel);
        }

        // GET: Armor/Create
        public IActionResult Create()
        {
            ViewData["ArmorRestorationId"] = new SelectList(_context.ArmorRestorationModel, "Id", "ArmorStyle");
            ViewData["ArmorRestrictionId"] = new SelectList(_context.ArmorRestrictionModel, "Id", "Name");
            return View();
        }

        // POST: Armor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PenetrationDefenseRating,DefenseRating,ArmorRestrictionId,ArmorRestorationId,Weight,Cost")] ArmorModel armorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armorModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmorRestorationId"] = new SelectList(_context.ArmorRestorationModel, "Id", "ArmorStyle", armorModel.ArmorRestorationId);
            ViewData["ArmorRestrictionId"] = new SelectList(_context.ArmorRestrictionModel, "Id", "Name", armorModel.ArmorRestrictionId);
            return View(armorModel);
        }

        // GET: Armor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorModel = await _context.ArmorModel.FindAsync(id);
            if (armorModel == null)
            {
                return NotFound();
            }
            ViewData["ArmorRestorationId"] = new SelectList(_context.ArmorRestorationModel, "Id", "ArmorStyle", armorModel.ArmorRestorationId);
            ViewData["ArmorRestrictionId"] = new SelectList(_context.ArmorRestrictionModel, "Id", "Name", armorModel.ArmorRestrictionId);
            return View(armorModel);
        }

        // POST: Armor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PenetrationDefenseRating,DefenseRating,ArmorRestrictionId,ArmorRestorationId,Weight,Cost")] ArmorModel armorModel)
        {
            if (id != armorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armorModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmorModelExists(armorModel.Id))
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
            ViewData["ArmorRestorationId"] = new SelectList(_context.ArmorRestorationModel, "Id", "ArmorStyle", armorModel.ArmorRestorationId);
            ViewData["ArmorRestrictionId"] = new SelectList(_context.ArmorRestrictionModel, "Id", "Name", armorModel.ArmorRestrictionId);
            return View(armorModel);
        }

        // GET: Armor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armorModel = await _context.ArmorModel
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (armorModel == null)
            {
                return NotFound();
            }

            return View(armorModel);
        }

        // POST: Armor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armorModel = await _context.ArmorModel.FindAsync(id);
            _context.ArmorModel.Remove(armorModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ArmorModelExists(int id)
        {
            return _context.ArmorModel.Any(e => e.Id == id);
        }
    }
}
