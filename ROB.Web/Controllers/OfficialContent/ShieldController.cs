using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class ShieldController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShieldController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shield
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShieldModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: Shield/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shieldModel = await _context.ShieldModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (shieldModel == null)
            {
                return NotFound();
            }

            return View(shieldModel);
        }

        // GET: Shield/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shield/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,DefensePoints,PenetrationDefenseRating,EvasionModifier,Weight,Cost")] ShieldModel shieldModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shieldModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(shieldModel);
        }

        // GET: Shield/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shieldModel = await _context.ShieldModel.FindAsync(id);
            if (shieldModel == null)
            {
                return NotFound();
            }
            return View(shieldModel);
        }

        // POST: Shield/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,DefensePoints,PenetrationDefenseRating,EvasionModifier,Weight,Cost")] ShieldModel shieldModel)
        {
            if (id != shieldModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shieldModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShieldModelExists(shieldModel.Id))
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
            return View(shieldModel);
        }

        // GET: Shield/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shieldModel = await _context.ShieldModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (shieldModel == null)
            {
                return NotFound();
            }

            return View(shieldModel);
        }

        // POST: Shield/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shieldModel = await _context.ShieldModel.FindAsync(id);
            _context.ShieldModel.Remove(shieldModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ShieldModelExists(int id)
        {
            return _context.ShieldModel.Any(e => e.Id == id);
        }
    }
}
