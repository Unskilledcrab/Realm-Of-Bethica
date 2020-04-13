using System;
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

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class TechniqueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TechniqueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TechniqueModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TechniqueModel.Include(t => t.TechniqueGroupType);
            return View(await applicationDbContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: TechniqueModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueModel = await _context.TechniqueModel
                .Include(t => t.TechniqueGroupType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (techniqueModel == null)
            {
                return NotFound();
            }

            return View(techniqueModel);
        }

        // GET: TechniqueModels/Create
        public IActionResult Create()
        {
            var technique = new TechniqueModel();
            technique.TechniquePrerequisites = new List<TechniquePrerequisiteLink>();
            PopulateTechniquePrerequisiteData(technique);
            PopulateTalentPrerequisiteData(technique);
            PopulateTechniqueGroupDropDownList();
            return View();
        }

        private void PopulateTechniqueGroupDropDownList(object selectedTechnique = null)
        {
            var TechniqueGroupQuery = from tg in _context.TechniqueGroupTypeModel
                                      select tg;
            ViewBag.TechniqueGroup = new SelectList(TechniqueGroupQuery.AsNoTracking(), "Id", "TechniqueGroupType", selectedTechnique);
        }

        private void PopulateTechniquePrerequisiteData(TechniqueModel technique)
        {
            var allTechniques = _context.TechniqueModel;
            var assignedPrerequisites = new HashSet<int?>(technique.TechniquePrerequisites.Select(t => t.PrerequisiteId));
            var viewModel = new List<TechniquePrerequisiteData>();
            foreach (var prerequisite in allTechniques)
            {
                viewModel.Add(new TechniquePrerequisiteData
                {
                    TechniqueId = prerequisite.Id,
                    TechniqueName = prerequisite.TechniqueName,
                    IsPrerequisite = assignedPrerequisites.Contains(prerequisite.Id),
                    TechniqueGroupId = prerequisite.TechniqueGroupTypeId
                });
            }
            ViewData["PrerequisiteTechniques"] = viewModel;
        }

        private void PopulateTalentPrerequisiteData(TechniqueModel technique)
        {
            var allTalents = _context.TalentModel;
            var assignedPrerequisites = new HashSet<int?>(technique.TalentPrerequisites.Select(t => t.TalentId));
            var viewModel = new List<AssignedTechniqueTalentPrereq>();
            foreach (var prerequisite in allTalents)
            {
                viewModel.Add(new AssignedTechniqueTalentPrereq
                {
                    TalentId = prerequisite.Id,
                    TalentName = prerequisite.Name,
                    IsPrerequisite = assignedPrerequisites.Contains(prerequisite.Id)
                });
            }
            ViewData["PrerequisiteTalents"] = viewModel;
        }

        // POST: TechniqueModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TechniqueGroupTypeId,TechniqueName,Description,DurationLengthType,Duration,Notes")] TechniqueModel techniqueModel, string[] prerequisiteTechniques, string[] prerequisiteTalents)
        {
            // add all of the selected techniques that are pre reqs
            if (prerequisiteTechniques != null)
            {
                techniqueModel.TechniquePrerequisites = new List<TechniquePrerequisiteLink>();
                foreach (var prerequisite in prerequisiteTechniques)
                {
                    var prerequisiteToAdd = new TechniquePrerequisiteLink
                    {
                        TechniqueModelId = techniqueModel.Id,
                        PrerequisiteId = int.Parse(prerequisite)
                    };
                    techniqueModel.TechniquePrerequisites.Add(prerequisiteToAdd);
                }
            }
            // add all of the selected talents to pre reqs
            if (prerequisiteTalents != null)
            {
                techniqueModel.TalentPrerequisites = new List<TechniqueTalentPrerequisiteLink>();
                foreach (var prerequisite in prerequisiteTalents)
                {
                    var prerequisiteToAdd = new TechniqueTalentPrerequisiteLink
                    {
                        TechniqueId = techniqueModel.Id,
                        TalentId = int.Parse(prerequisite)
                    };
                    techniqueModel.TalentPrerequisites.Add(prerequisiteToAdd);
                }
            }
            // check if that shit is good
            if (ModelState.IsValid)
            {
                _context.Add(techniqueModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            // that shit wasn't good... GO BACK
            PopulateTechniquePrerequisiteData(techniqueModel);
            PopulateTalentPrerequisiteData(techniqueModel);
            PopulateTechniqueGroupDropDownList();
            return View(techniqueModel);
        }

        // GET: TechniqueModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueModel = await _context.TechniqueModel
                .Include(t => t.TechniquePrerequisites)
                .Include(t => t.TalentPrerequisites)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);

            if (techniqueModel == null)
            {
                return NotFound();
            }
            PopulateTechniquePrerequisiteData(techniqueModel);
            PopulateTalentPrerequisiteData(techniqueModel);
            PopulateTechniqueGroupDropDownList();
            return View(techniqueModel);
        }

        // POST: TechniqueModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TechniqueGroupTypeId,TechniqueName,Description,DurationLengthType,Duration,Notes")] TechniqueModel techniqueModel, string[] prerequisiteTechniques, string[] prerequisiteTalents)
        {
            if (id != techniqueModel.Id)
            {
                return NotFound();
            }


            // HAVE TO INCLUDE CONNECTIONS TO ALL OTHER TABLES 
            var techniqueToUpdate = await _context.TechniqueModel
                .Include(t => t.TechniqueGroupType) // many to single
                .Include(t => t.TechniquePrerequisites) // many to many
                    .ThenInclude(t => t.Prerequisite)
                .Include(t => t.TalentPrerequisites)
                    .ThenInclude(t => t.TalentPrerequisite)
                .FirstOrDefaultAsync(t => t.Id == id).ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync(techniqueToUpdate, "").ConfigureAwait(false))
                {
                    UpdateTechniquePrerequisites(prerequisiteTechniques, techniqueToUpdate);
                    UpdateTalentPrerequisites(prerequisiteTalents, techniqueToUpdate);

                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TechniqueModelExists(techniqueToUpdate.Id))
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

            PopulateTechniquePrerequisiteData(techniqueToUpdate);
            PopulateTalentPrerequisiteData(techniqueToUpdate);
            PopulateTechniqueGroupDropDownList();
            return View(techniqueToUpdate);
        }

        private void UpdateTechniquePrerequisites(string[] selectedPrerequisites, TechniqueModel technique)
        {
            if (selectedPrerequisites == null)
            {
                technique.TechniquePrerequisites = new List<TechniquePrerequisiteLink>();
                return;
            }

            var selectedPrerequisitesHS = new HashSet<string>(selectedPrerequisites);
            var techniquePrerequisites = new HashSet<int?>(technique.TechniquePrerequisites.Select(t => t.PrerequisiteId));

            foreach (var prereq in _context.TechniqueModel)
            {
                if (selectedPrerequisitesHS.Contains(prereq.Id.ToString()))
                {
                    if (!techniquePrerequisites.Contains(prereq.Id))
                    {
                        technique.TechniquePrerequisites.Add(new TechniquePrerequisiteLink
                        {
                            TechniqueModelId = technique.Id,
                            PrerequisiteId = prereq.Id
                        });
                    }
                }
                else
                {
                    if (techniquePrerequisites.Contains(prereq.Id))
                    {
                        TechniquePrerequisiteLink prereqToRemove = technique.TechniquePrerequisites.FirstOrDefault(t => t.PrerequisiteId == prereq.Id);
                        _context.Remove(prereqToRemove);
                    }
                }
            }
        }

        private void UpdateTalentPrerequisites(string[] selectedPrerequisites, TechniqueModel technique)
        {
            if (selectedPrerequisites == null)
            {
                technique.TalentPrerequisites = new List<TechniqueTalentPrerequisiteLink>();
                return;
            }

            var selectedPrerequisitesHS = new HashSet<string>(selectedPrerequisites);
            var techniquePrerequisites = new HashSet<int?>(technique.TalentPrerequisites.Select(t => t.TechniqueId));

            foreach (var prereq in _context.TalentModel)
            {
                if (selectedPrerequisitesHS.Contains(prereq.Id.ToString()))
                {
                    if (!techniquePrerequisites.Contains(prereq.Id))
                    {
                        technique.TalentPrerequisites.Add(new TechniqueTalentPrerequisiteLink
                        {
                            TechniqueId = technique.Id,
                            TalentId = prereq.Id
                        });
                    }
                }
                else
                {
                    if (techniquePrerequisites.Contains(prereq.Id))
                    {
                        TechniqueTalentPrerequisiteLink prereqToRemove = technique.TalentPrerequisites.FirstOrDefault(t => t.TalentId == prereq.Id);
                        _context.Remove(prereqToRemove);
                    }
                }
            }
        }

        // GET: TechniqueModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var techniqueModel = await _context.TechniqueModel
                .Include(t => t.TechniqueGroupType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (techniqueModel == null)
            {
                return NotFound();
            }

            return View(techniqueModel);
        }

        // POST: TechniqueModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var techniqueModel = await _context.TechniqueModel.FindAsync(id);
            _context.TechniqueModel.Remove(techniqueModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool TechniqueModelExists(int id)
        {
            return _context.TechniqueModel.Any(e => e.Id == id);
        }
    }
}
