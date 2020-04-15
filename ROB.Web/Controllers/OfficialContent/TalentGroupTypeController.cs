using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class TalentGroupTypeController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TalentGroupTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TalentGroupType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TalentGroupTypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: TalentGroupType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentGroupTypeModel = await _context.TalentGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (talentGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(talentGroupTypeModel);
        }

        // GET: TalentGroupType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TalentGroupType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName,Description")] TalentGroupTypeModel talentGroupTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talentGroupTypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(talentGroupTypeModel);
        }

        // GET: TalentGroupType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentGroupTypeModel = await _context.TalentGroupTypeModel.FindAsync(id);
            if (talentGroupTypeModel == null)
            {
                return NotFound();
            }
            return View(talentGroupTypeModel);
        }

        // POST: TalentGroupType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName,Description")] TalentGroupTypeModel talentGroupTypeModel)
        {
            if (id != talentGroupTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talentGroupTypeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentGroupTypeModelExists(talentGroupTypeModel.Id))
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
            return View(talentGroupTypeModel);
        }

        // GET: TalentGroupType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentGroupTypeModel = await _context.TalentGroupTypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (talentGroupTypeModel == null)
            {
                return NotFound();
            }

            return View(talentGroupTypeModel);
        }

        // POST: TalentGroupType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talentGroupTypeModel = await _context.TalentGroupTypeModel.FindAsync(id);
            _context.TalentGroupTypeModel.Remove(talentGroupTypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool TalentGroupTypeModelExists(int id)
        {
            return _context.TalentGroupTypeModel.Any(e => e.Id == id);
        }
    }
}
