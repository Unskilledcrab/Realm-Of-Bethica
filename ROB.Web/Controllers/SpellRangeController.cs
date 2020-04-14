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
    public class SpellRangeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpellRangeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellRange
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellRangeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellRange/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellRangeModel = await _context.SpellRangeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellRangeModel == null)
            {
                return NotFound();
            }

            return View(spellRangeModel);
        }

        // GET: SpellRange/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellRange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellRangeModel spellRangeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellRangeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellRangeModel);
        }

        // GET: SpellRange/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellRangeModel = await _context.SpellRangeModel.FindAsync(id);
            if (spellRangeModel == null)
            {
                return NotFound();
            }
            return View(spellRangeModel);
        }

        // POST: SpellRange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellRangeModel spellRangeModel)
        {
            if (id != spellRangeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellRangeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellRangeModelExists(spellRangeModel.Id))
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
            return View(spellRangeModel);
        }

        // GET: SpellRange/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellRangeModel = await _context.SpellRangeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellRangeModel == null)
            {
                return NotFound();
            }

            return View(spellRangeModel);
        }

        // POST: SpellRange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellRangeModel = await _context.SpellRangeModel.FindAsync(id);
            _context.SpellRangeModel.Remove(spellRangeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellRangeModelExists(int id)
        {
            return _context.SpellRangeModel.Any(e => e.Id == id);
        }
    }
}
