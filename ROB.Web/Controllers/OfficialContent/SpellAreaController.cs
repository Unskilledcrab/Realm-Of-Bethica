using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class SpellAreaController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SpellAreaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpellArea
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpellAreaModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: SpellArea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellAreaModel = await _context.SpellAreaModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellAreaModel == null)
            {
                return NotFound();
            }

            return View(spellAreaModel);
        }

        // GET: SpellArea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpellArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArcaneValue,Description")] SpellAreaModel spellAreaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spellAreaModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(spellAreaModel);
        }

        // GET: SpellArea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellAreaModel = await _context.SpellAreaModel.FindAsync(id);
            if (spellAreaModel == null)
            {
                return NotFound();
            }
            return View(spellAreaModel);
        }

        // POST: SpellArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArcaneValue,Description")] SpellAreaModel spellAreaModel)
        {
            if (id != spellAreaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spellAreaModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellAreaModelExists(spellAreaModel.Id))
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
            return View(spellAreaModel);
        }

        // GET: SpellArea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spellAreaModel = await _context.SpellAreaModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (spellAreaModel == null)
            {
                return NotFound();
            }

            return View(spellAreaModel);
        }

        // POST: SpellArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spellAreaModel = await _context.SpellAreaModel.FindAsync(id);
            _context.SpellAreaModel.Remove(spellAreaModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool SpellAreaModelExists(int id)
        {
            return _context.SpellAreaModel.Any(e => e.Id == id);
        }
    }
}
