using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class SpellDurationController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpellDurationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellDuration
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellDurationModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellDuration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellDurationModel = await _context.SpellDurationModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellDurationModel == null)
            {
                return NotFound();
            }

            return View(spellDurationModel);
        }

        // GET: SpellDuration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellDuration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellDurationModel spellDurationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellDurationModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellDurationModel);
        }

        // GET: SpellDuration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellDurationModel = await _context.SpellDurationModel.FindAsync(id);
            if (spellDurationModel == null)
            {
                return NotFound();
            }
            return View(spellDurationModel);
        }

        // POST: SpellDuration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellDurationModel spellDurationModel)
        {
            if (id != spellDurationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellDurationModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellDurationModelExists(spellDurationModel.Id))
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
            return View(spellDurationModel);
        }

        // GET: SpellDuration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellDurationModel = await _context.SpellDurationModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellDurationModel == null)
            {
                return NotFound();
            }

            return View(spellDurationModel);
        }

        // POST: SpellDuration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellDurationModel = await _context.SpellDurationModel.FindAsync(id);
            _context.SpellDurationModel.Remove(spellDurationModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellDurationModelExists(int id)
        {
            return _context.SpellDurationModel.Any(e => e.Id == id);
        }
    }
}
