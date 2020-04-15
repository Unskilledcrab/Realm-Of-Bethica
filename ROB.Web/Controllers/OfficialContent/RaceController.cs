using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace ROB.Web.Controllers.OfficialContent
{
    public class RaceController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;
        public RaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Race
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RaceModel.Include(r => r.FirstModifiedAttribute).Include(r => r.SecondModifiedAttribute);
            return View(await applicationDbContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: Race/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel
                .Include(r => r.FirstModifiedAttribute)
                .Include(r => r.SecondModifiedAttribute)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (raceModel == null)
            {
                return NotFound();
            }

            return View(raceModel);
        }

        // GET: Race/Create
        public IActionResult Create()
        {
            ViewData["FirstModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType");
            ViewData["SecondModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType");
            return View();
        }

        // POST: Race/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DescriptionBrief,Description,HeightInches,WeightLBS,LifeSpanYears,Walk,Tactical,Sprint,Luck,Size,FirstModifiedAttributeId,FirstAttributeModifier,SecondModifiedAttributeId,SecondAttributeModifier,file")] RaceModel raceModel, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                var result = await Resources.SetSitePicture(Resources.RaceImagesPath, raceModel.Id.ToString(), ".gif", file).ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FirstModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.FirstModifiedAttributeId);
            ViewData["SecondModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.SecondModifiedAttributeId);
            return View(raceModel);
        }

        // GET: Race/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel.FindAsync(id);
            if (raceModel == null)
            {
                return NotFound();
            }
            ViewData["FirstModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.FirstModifiedAttributeId);
            ViewData["SecondModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.SecondModifiedAttributeId);
            return View(raceModel);
        }

        // POST: Race/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DescriptionBrief,Description,HeightInches,WeightLBS,LifeSpanYears,Walk,Tactical,Sprint,Luck,Size,FirstModifiedAttributeId,FirstAttributeModifier,SecondModifiedAttributeId,SecondAttributeModifier,file")] RaceModel raceModel, IFormFile file)
        {
            if (id != raceModel.Id)
            {
                return NotFound();
            }

            var oldRace = await _context.RaceModel
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == raceModel.Id).ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                var result = await Resources.SetSitePicture(Resources.RaceImagesPath, raceModel.Id.ToString(), ".gif", file).ConfigureAwait(false);
                
                try
                {
                    _context.Update(raceModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceModelExists(raceModel.Id))
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


            ViewData["FirstModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.FirstModifiedAttributeId);
            ViewData["SecondModifiedAttributeId"] = new SelectList(_context.AttributeModel, "Id", "AttributeType", raceModel.SecondModifiedAttributeId);
            return View(raceModel);
        }

        // GET: Race/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceModel = await _context.RaceModel
                .Include(r => r.FirstModifiedAttribute)
                .Include(r => r.SecondModifiedAttribute)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (raceModel == null)
            {
                return NotFound();
            }

            return View(raceModel);
        }

        // POST: Race/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceModel = await _context.RaceModel.FindAsync(id);
            _context.RaceModel.Remove(raceModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            Resources.DeleteSitePicture(Resources.RaceImagesPath, raceModel.Id.ToString(), ".gif");
            return RedirectToAction(nameof(Index));
        }

        private bool RaceModelExists(int id)
        {
            return _context.RaceModel.Any(e => e.Id == id);
        }
    }
}
