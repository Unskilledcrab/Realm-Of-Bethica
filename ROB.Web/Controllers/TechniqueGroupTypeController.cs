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
    public class TechniqueGroupTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechniqueGroupTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TechniqueGroupTypeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TechniqueGroupTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: TechniqueGroupTypeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueGroupTypeModel = await _context.TechniqueGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (techniqueGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(techniqueGroupTypeModel);
        }

        // GET: TechniqueGroupTypeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TechniqueGroupTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TechniqueGroupType,Description")] TechniqueGroupTypeModel techniqueGroupTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(techniqueGroupTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(techniqueGroupTypeModel);
        }

        // GET: TechniqueGroupTypeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueGroupTypeModel = await _context.TechniqueGroupTypeModel.FindAsync(id);
            if (techniqueGroupTypeModel == null)
            {
                return NotFound();
            }
            return View(techniqueGroupTypeModel);
        }

        // POST: TechniqueGroupTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TechniqueGroupType,Description")] TechniqueGroupTypeModel techniqueGroupTypeModel)
        {
            if (id != techniqueGroupTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(techniqueGroupTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechniqueGroupTypeModelExists(techniqueGroupTypeModel.Id))
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
            return View(techniqueGroupTypeModel);
        }

        // GET: TechniqueGroupTypeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueGroupTypeModel = await _context.TechniqueGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (techniqueGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(techniqueGroupTypeModel);
        }

        // POST: TechniqueGroupTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techniqueGroupTypeModel = await _context.TechniqueGroupTypeModel.FindAsync(id);
            _context.TechniqueGroupTypeModel.Remove(techniqueGroupTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool TechniqueGroupTypeModelExists(int id)
        {
            return _context.TechniqueGroupTypeModel.Any(e => e.Id == id);
        }
    }
}
