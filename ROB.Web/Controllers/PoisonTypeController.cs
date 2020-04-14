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
    public class PoisonTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoisonTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PoisonType
        public async Task<IActionResult> Index()
        {
            return View(await _context.PoisonTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: PoisonType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonTypeModel = await _context.PoisonTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonTypeModel == null)
            {
                return NotFound();
            }

            return View(poisonTypeModel);
        }

        // GET: PoisonType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PoisonType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PoisonTypeModel poisonTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poisonTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(poisonTypeModel);
        }

        // GET: PoisonType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonTypeModel = await _context.PoisonTypeModel.FindAsync(id);
            if (poisonTypeModel == null)
            {
                return NotFound();
            }
            return View(poisonTypeModel);
        }

        // POST: PoisonType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] PoisonTypeModel poisonTypeModel)
        {
            if (id != poisonTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poisonTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoisonTypeModelExists(poisonTypeModel.Id))
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
            return View(poisonTypeModel);
        }

        // GET: PoisonType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonTypeModel = await _context.PoisonTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonTypeModel == null)
            {
                return NotFound();
            }

            return View(poisonTypeModel);
        }

        // POST: PoisonType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poisonTypeModel = await _context.PoisonTypeModel.FindAsync(id);
            _context.PoisonTypeModel.Remove(poisonTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool PoisonTypeModelExists(int id)
        {
            return _context.PoisonTypeModel.Any(e => e.Id == id);
        }
    }
}
