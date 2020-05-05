using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class ChildSkillController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChildSkillController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChildSkill
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChildSkillModel.Include(c => c.ParentSkill);
            return View(await applicationDbContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: ChildSkill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childSkillModel = await _context.ChildSkillModel
                .Include(c => c.ParentSkill)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (childSkillModel == null)
            {
                return NotFound();
            }

            return View(childSkillModel);
        }

        // GET: ChildSkill/Create
        public IActionResult Create()
        {
            ViewData["ParentSkillId"] = new SelectList(_context.Set<ParentSkillModel>(), "Id", "Name");
            return View();
        }

        // POST: ChildSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ParentSkillId")] ChildSkillModel childSkillModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(childSkillModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentSkillId"] = new SelectList(_context.Set<ParentSkillModel>(), "Id", "Name", childSkillModel.ParentSkillId);
            return View(childSkillModel);
        }

        // GET: ChildSkill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childSkillModel = await _context.ChildSkillModel.FindAsync(id);
            if (childSkillModel == null)
            {
                return NotFound();
            }
            ViewData["ParentSkillId"] = new SelectList(_context.Set<ParentSkillModel>(), "Id", "Name", childSkillModel.ParentSkillId);
            return View(childSkillModel);
        }

        // POST: ChildSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ParentSkillId")] ChildSkillModel childSkillModel)
        {
            if (id != childSkillModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(childSkillModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildSkillModelExists(childSkillModel.Id))
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
            ViewData["ParentSkillId"] = new SelectList(_context.Set<ParentSkillModel>(), "Id", "Name", childSkillModel.ParentSkillId);
            return View(childSkillModel);
        }

        // GET: ChildSkill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childSkillModel = await _context.ChildSkillModel
                .Include(c => c.ParentSkill)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (childSkillModel == null)
            {
                return NotFound();
            }

            return View(childSkillModel);
        }

        // POST: ChildSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var childSkillModel = await _context.ChildSkillModel.FindAsync(id);
            _context.ChildSkillModel.Remove(childSkillModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ChildSkillModelExists(int id)
        {
            return _context.ChildSkillModel.Any(e => e.Id == id);
        }
    }
}
