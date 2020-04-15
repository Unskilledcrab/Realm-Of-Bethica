using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.Controllers.OfficialContent
{
    public class TalentController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TalentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Talent
        public async Task<IActionResult> Index()
        {
            var talents = _context.TalentModel.Include(t => t.TalentGroup);
            return View(await talents.ToListAsync().ConfigureAwait(false));
        }

        // GET: Talent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentModel = await _context.TalentModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (talentModel == null)
            {
                return NotFound();
            }

            return View(talentModel);
        }

        // GET: Talent/Create
        public IActionResult Create()
        {
            var talent = new TalentModel();
            PopulateTalentGroupDropDownList(talent);
            PopulateTalentPrerequisiteData(talent);
            return View();
        }

        private void PopulateTalentGroupDropDownList(object selectedTalent = null)
        {
            var TalentGroupQuery = from tg in _context.TalentGroupTypeModel
                                   select tg;
            ViewBag.TalentGroup = new SelectList(TalentGroupQuery.AsNoTracking(), "Id", "GroupName", selectedTalent);
        }

        private void PopulateTalentPrerequisiteData(TalentModel talent)
        {
            var allTalents = _context.TalentModel;
            var assignedPrerequisites = new HashSet<int?>(talent.TalentPrerequisites.Select(t => t.PrerequisiteId));
            var viewModel = new List<TalentPrerequisiteData>();
            foreach (var prerequisite in allTalents)
            {
                viewModel.Add(new TalentPrerequisiteData
                {
                    TalentId = prerequisite.Id,
                    TalentName = prerequisite.Name,
                    IsPrerequisite = assignedPrerequisites.Contains(prerequisite.Id),
                    TalentGroupId = prerequisite.TalentGroupId
                });
            }
            ViewData["PrerequisiteTalents"] = viewModel;
        }

        // POST: Talent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TalentGroupId,Name,Description,Benefit,Notes")] TalentModel talentModel, string[] prerequisiteTalents)
        {
            if (prerequisiteTalents != null)
            {
                talentModel.TalentPrerequisites = new List<TalentPrerequisiteLink>();
                foreach (var prerequisite in prerequisiteTalents)
                {
                    var prerequisiteToAdd = new TalentPrerequisiteLink
                    {
                        TalentId = talentModel.Id,
                        PrerequisiteId = int.Parse(prerequisite)
                    };
                    talentModel.TalentPrerequisites.Add(prerequisiteToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(talentModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }

            PopulateTalentGroupDropDownList(talentModel);
            PopulateTalentPrerequisiteData(talentModel);
            return View(talentModel);
        }

        // GET: Talent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentModel = await _context.TalentModel
                .Include(t => t.TalentPrerequisites)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);

            if (talentModel == null)
            {
                return NotFound();
            }

            PopulateTalentGroupDropDownList(talentModel);
            PopulateTalentPrerequisiteData(talentModel);
            return View(talentModel);
        }

        // POST: Talent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TalentGroupId,Name,Description,Benefit,Notes")] TalentModel talentModel, string[] prerequisiteTalents)
        {
            if (id != talentModel.Id)
            {
                return NotFound();
            }

            var talentToUpdate = await _context.TalentModel
                .Include(t => t.TalentGroup)
                .Include(t => t.TalentPrerequisites)
                    .ThenInclude(t => t.Prerequisite)
                .FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync(talentToUpdate, "").ConfigureAwait(false))
                {
                    UpdateTalentPrerequisites(prerequisiteTalents, talentToUpdate);
                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TalentModelExists(talentToUpdate.Id))
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
            }

            PopulateTalentGroupDropDownList(talentToUpdate);
            PopulateTalentPrerequisiteData(talentToUpdate);
            return View(talentModel);
        }

        private void UpdateTalentPrerequisites(string[] selectedPrerequisites, TalentModel talent)
        {
            if (selectedPrerequisites == null)
            {
                talent.TalentPrerequisites = new List<TalentPrerequisiteLink>();
                return;
            }

            var selectedPrerequisitesHS = new HashSet<string>(selectedPrerequisites);
            var talentPrerequisites = new HashSet<int?>(talent.TalentPrerequisites.Select(t => t.PrerequisiteId));

            foreach (var prereq in _context.TalentModel)
            {
                if (selectedPrerequisitesHS.Contains(prereq.Id.ToString()))
                {
                    if (!talentPrerequisites.Contains(prereq.Id))
                    {
                        talent.TalentPrerequisites.Add(new TalentPrerequisiteLink
                        {
                            TalentId = talent.Id,
                            PrerequisiteId = prereq.Id
                        });
                    }
                }
                else
                {
                    if (talentPrerequisites.Contains(prereq.Id))
                    {
                        TalentPrerequisiteLink prereqToRemove = talent.TalentPrerequisites.FirstOrDefault(t => t.PrerequisiteId == prereq.Id);
                        _context.Remove(prereqToRemove);
                    }
                }
            }
        }

        // GET: Talent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talentModel = await _context.TalentModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (talentModel == null)
            {
                return NotFound();
            }

            return View(talentModel);
        }

        // POST: Talent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talentModel = await _context.TalentModel.FindAsync(id);
            _context.TalentModel.Remove(talentModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool TalentModelExists(int id)
        {
            return _context.TalentModel.Any(e => e.Id == id);
        }
    }
}
