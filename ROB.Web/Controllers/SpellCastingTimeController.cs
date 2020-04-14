using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class SpellCastingTimeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellCastingTimeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellCastingTime
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellCastingTimeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellCastingTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellCastingTimeModel = await _context.SpellCastingTimeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellCastingTimeModel == null)
            {
                return NotFound();
            }

            return View(spellCastingTimeModel);
        }

        // GET: SpellCastingTime/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellCastingTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellCastingTimeModel spellCastingTimeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellCastingTimeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellCastingTimeModel);
        }

        // GET: SpellCastingTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellCastingTimeModel = await _context.SpellCastingTimeModel.FindAsync(id);
            if (spellCastingTimeModel == null)
            {
                return NotFound();
            }
            return View(spellCastingTimeModel);
        }

        // POST: SpellCastingTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellCastingTimeModel spellCastingTimeModel)
        {
            if (id != spellCastingTimeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellCastingTimeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellCastingTimeModelExists(spellCastingTimeModel.Id))
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
            return View(spellCastingTimeModel);
        }

        // GET: SpellCastingTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellCastingTimeModel = await _context.SpellCastingTimeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellCastingTimeModel == null)
            {
                return NotFound();
            }

            return View(spellCastingTimeModel);
        }

        // POST: SpellCastingTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellCastingTimeModel = await _context.SpellCastingTimeModel.FindAsync(id);
            _context.SpellCastingTimeModel.Remove(spellCastingTimeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellCastingTimeModelExists(int id)
        {
            return _context.SpellCastingTimeModel.Any(e => e.Id == id);
        }
    }
}
