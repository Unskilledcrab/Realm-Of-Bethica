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
    public class LanguagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Languages
        public async Task<IActionResult> Index(int? id)
        {
            var languages = _context.LanguageModel
                .Include(l => l.GroupType) // this joins in the group type data
                .OrderBy(l => l.GroupType) // this shows to user in order or the group type
                .AsNoTracking();

            return View(await languages.ToListAsync().ConfigureAwait(false)); // the query doesn't get performed until ToListAsync() is called
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.LanguageModel
                .Include(l => l.GroupType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (languageModel == null)
            {
                return NotFound();
            }

            return View(languageModel);
        }

        private void PopulateLanguageGroupDropDownList(object selectedLanguage = null)
        {
            var LanguageGroupQuery = from lg in _context.LanguageGroupTypeModel
                                     orderby lg.LanguageType
                                     select lg;
            ViewBag.LanguageGroup = new SelectList(LanguageGroupQuery.AsNoTracking(), "Id", "LanguageType", selectedLanguage);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            PopulateLanguageGroupDropDownList();
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupTypeId,TypeName,LanguageName,Written")] LanguageModel languageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languageModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            PopulateLanguageGroupDropDownList(languageModel.GroupTypeId);
            return View(languageModel);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.LanguageModel.FindAsync(id);
            if (languageModel == null)
            {
                return NotFound();
            }
            PopulateLanguageGroupDropDownList(languageModel.GroupTypeId);
            return View(languageModel);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupTypeId,TypeName,LanguageName,Written")] LanguageModel languageModel)
        {
            if (id != languageModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageModelExists(languageModel.Id))
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
            return View(languageModel);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languageModel = await _context.LanguageModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (languageModel == null)
            {
                return NotFound();
            }

            return View(languageModel);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languageModel = await _context.LanguageModel.FindAsync(id);
            _context.LanguageModel.Remove(languageModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageModelExists(int id)
        {
            return _context.LanguageModel.Any(e => e.Id == id);
        }
    }
}
