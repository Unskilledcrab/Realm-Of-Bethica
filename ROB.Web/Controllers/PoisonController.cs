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
    public class PoisonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoisonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Poison
        public async Task<IActionResult> Index()
        {
            var poisons = _context.PoisonModel
                .Include(p => p.Class)
                .Include(p => p.Type)
                .AsNoTracking();
            return View(await poisons.ToListAsync().ConfigureAwait(false));
        }

        // GET: Poison/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonModel = await _context.PoisonModel
                .Include(p => p.Class)
                .Include(p => p.Type)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonModel == null)
            {
                return NotFound();
            }

            return View(poisonModel);
        }

        private void PopulatePoisonTypeDropDownList(object selectedPosionType = null)
        {
            var PoisonTypeQuery = from lg in _context.PoisonTypeModel select lg;
            ViewBag.PoisonType = new SelectList(PoisonTypeQuery.AsNoTracking(), "Id", "Name", selectedPosionType);
        }

        private void PopulatePoisonClassDropDownList(object selectedPosionClass = null)
        {
            var PoisonClassQuery = from lg in _context.PoisonClassModel select lg;
            ViewBag.PoisonClass = new SelectList(PoisonClassQuery.AsNoTracking(), "Id", "Name", selectedPosionClass);
        }

        // GET: Poison/Create
        public IActionResult Create()
        {
            PopulatePoisonClassDropDownList();
            PopulatePoisonTypeDropDownList();
            return View();
        }

        // POST: Poison/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassId,TypeId,Name,Description,Effect,Duration,ConstitutionDamage,Cost")] PoisonModel poisonModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poisonModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            PopulatePoisonClassDropDownList(poisonModel.ClassId);
            PopulatePoisonTypeDropDownList(poisonModel.TypeId);
            return View(poisonModel);
        }

        // GET: Poison/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonModel = await _context.PoisonModel.FindAsync(id);
            if (poisonModel == null)
            {
                return NotFound();
            }
            PopulatePoisonClassDropDownList(poisonModel.ClassId);
            PopulatePoisonTypeDropDownList(poisonModel.TypeId);
            return View(poisonModel);
        }

        // POST: Poison/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Class,Type,Name,Description,Effect,Duration,ConstitutionDamage,Cost")] PoisonModel poisonModel)
        {
            if (id != poisonModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poisonModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoisonModelExists(poisonModel.Id))
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
            PopulatePoisonClassDropDownList(poisonModel.ClassId);
            PopulatePoisonTypeDropDownList(poisonModel.TypeId);
            return View(poisonModel);
        }

        // GET: Poison/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poisonModel = await _context.PoisonModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (poisonModel == null)
            {
                return NotFound();
            }

            return View(poisonModel);
        }

        // POST: Poison/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poisonModel = await _context.PoisonModel.FindAsync(id);
            _context.PoisonModel.Remove(poisonModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool PoisonModelExists(int id)
        {
            return _context.PoisonModel.Any(e => e.Id == id);
        }
    }
}
