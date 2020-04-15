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
    public class ModifierController : OfficialContentControllerBase
    {
        private readonly ApplicationDbContext _context;

        private void PopulateChildSkillsGroupDropDownList(object selectedModifier = null)
        {
            var ChildSkillGroupQuery = from tg in _context.ChildSkillModel
                                       select tg;
            ViewBag.ChildSkillGroup = new SelectList(ChildSkillGroupQuery.AsNoTracking(), "Id", "Name", selectedModifier);
        }

        private void PopulateParentSkillsGroupDropDownList(object selectedModifier = null)
        {
            var ParentSkillGroupQuery = from tg in _context.ParentSkillModel
                                        select tg;
            ViewBag.ParentSkillGroup = new SelectList(ParentSkillGroupQuery.AsNoTracking(), "Id", "Name", selectedModifier);
        }

        private void PopulateAttributesGroupDropDownList(object selectedModifier = null)
        {
            var AttributeGroupQuery = from tg in _context.AttributeModel
                                      select tg;
            ViewBag.AttributeGroup = new SelectList(AttributeGroupQuery.AsNoTracking(), "Id", "AttributeType", selectedModifier);
        }

        private void PopulateAssignedRaces(ModifierModel modifier)
        {
            var allRaces = _context.RaceModel;
            var assignedRaces = new HashSet<int>(modifier.Races.Select(t => t.RaceId));
            var viewModel = new List<ModifierAssignedRacesData>();
            foreach (var race in allRaces)
            {
                viewModel.Add(new ModifierAssignedRacesData
                {
                    RaceId = race.Id,
                    Name = race.Name,
                    IsAssigned = assignedRaces.Contains(race.Id),
                    Description = race.Description
                });
            }
            ViewData["AssignedRaces"] = viewModel;
        }

        private void PopulateAssignedTechniques(ModifierModel modifier)
        {
            var allTechniques = _context.TechniqueModel;
            var assignedTechniques = new HashSet<int>(modifier.Techniques.Select(t => t.TechniqueId));
            var viewModel = new List<ModifierAssignedTechniquesData>();
            foreach (var technique in allTechniques)
            {
                viewModel.Add(new ModifierAssignedTechniquesData
                {
                    TechniqueId = technique.Id,
                    Name = technique.TechniqueName,
                    IsAssigned = assignedTechniques.Contains(technique.Id),
                    Description = technique.Description
                });
            }
            ViewData["AssignedTechniques"] = viewModel;
        }

        public ModifierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modifier
        public async Task<IActionResult> Index()
        {
            var modifierContext = _context.ModifierModel
                .Include(m => m.ChildSkillToModify)
                .Include(m => m.ParentSkillToModify)
                .Include(m => m.AttributeToModify)
                .Include(m => m.Techniques)
                .Include(m => m.Races);
            return View(await modifierContext.ToListAsync().ConfigureAwait(false));
        }

        // GET: Modifier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifierModel = await _context.ModifierModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (modifierModel == null)
            {
                return NotFound();
            }

            return View(modifierModel);
        }

        // GET: Modifier/Create
        public IActionResult Create()
        {
            var modifer = new ModifierModel();
            PopulateAttributesGroupDropDownList(modifer);
            PopulateChildSkillsGroupDropDownList(modifer);
            PopulateParentSkillsGroupDropDownList(modifer);
            PopulateAssignedRaces(modifer);
            PopulateAssignedTechniques(modifer);
            return View();
        }

        // POST: Modifier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IsStatic,StaticSkillSufix,StaticSkillToModify,ChildSkillToModifyId,ParentSkillToModifyId,AttributeToModifyId,Description,EffectAllParentSkills,EffectAllTrainedParentSkills,MultiplyByLevel,AdditionalModifiers,Modifier")] ModifierModel modifierModel, string[] assignedRaces, string[] assignedTechniques)
        {
            if (assignedRaces != null)
            {
                foreach (var race in assignedRaces)
                {
                    var raceToAdd = new Modifier_Race_Link
                    {
                        ModifierId = modifierModel.Id,
                        RaceId = int.Parse(race)
                    };
                    modifierModel.Races.Add(raceToAdd);
                }
            }

            if (assignedTechniques != null)
            {
                foreach (var Technique in assignedTechniques)
                {
                    var TechniqueToAdd = new Modifier_Technique_Link
                    {
                        ModifierId = modifierModel.Id,
                        TechniqueId = int.Parse(Technique)
                    };
                    modifierModel.Techniques.Add(TechniqueToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(modifierModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            PopulateAttributesGroupDropDownList(modifierModel);
            PopulateChildSkillsGroupDropDownList(modifierModel);
            PopulateParentSkillsGroupDropDownList(modifierModel);
            PopulateAssignedRaces(modifierModel);
            PopulateAssignedTechniques(modifierModel);
            return View(modifierModel);
        }

        // GET: Modifier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifierModel = await _context.ModifierModel
                .Include(m => m.ChildSkillToModify)
                .Include(m => m.ParentSkillToModify)
                .Include(m => m.AttributeToModify)
                .Include(m => m.Techniques)
                    .ThenInclude(m => m.Technique)
                .Include(m => m.Races)
                    .ThenInclude(m => m.Race)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);

            if (modifierModel == null)
            {
                return NotFound();
            }

            PopulateAttributesGroupDropDownList(modifierModel);
            PopulateChildSkillsGroupDropDownList(modifierModel);
            PopulateParentSkillsGroupDropDownList(modifierModel);
            PopulateAssignedRaces(modifierModel);
            PopulateAssignedTechniques(modifierModel);
            return View(modifierModel);
        }

        // POST: Modifier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IsStatic,StaticSkillSufix,StaticSkillToModify,ChildSkillToModifyId,ParentSkillToModifyId,AttributeToModifyId,Description,EffectAllParentSkills,EffectAllTrainedParentSkills,MultiplyByLevel,AdditionalModifiers,Modifier")] ModifierModel modifierModel, string[] assignedRaces, string[] assignedTechniques)
        {
            if (id != modifierModel.Id)
            {
                return NotFound();
            }

            var modifierToUpdate = await _context.ModifierModel
                .Include(m => m.ChildSkillToModify)
                .Include(m => m.ParentSkillToModify)
                .Include(m => m.AttributeToModify)
                .Include(m => m.Techniques)
                    .ThenInclude(m => m.Technique)
                .Include(m => m.Races)
                    .ThenInclude(m => m.Race)
                // CAN NOT PUT NO TRACKING HERE OR UPDATE WON"T WORK!!!
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync(modifierToUpdate, "").ConfigureAwait(false))
                {
                    UpdateAssignedRaces(assignedRaces, modifierToUpdate);
                    UpdateAssignedTechniques(assignedTechniques, modifierToUpdate);
                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ModifierModelExists(modifierModel.Id))
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

            PopulateAttributesGroupDropDownList(modifierToUpdate);
            PopulateChildSkillsGroupDropDownList(modifierToUpdate);
            PopulateParentSkillsGroupDropDownList(modifierToUpdate);
            PopulateAssignedRaces(modifierToUpdate);
            PopulateAssignedTechniques(modifierToUpdate);
            return View(modifierToUpdate);
        }

        private void UpdateAssignedRaces(string[] selectedRaces, ModifierModel modifier)
        {
            if (selectedRaces == null)
            {
                modifier.Races = new List<Modifier_Race_Link>();
                return;
            }

            var selectedHS = new HashSet<string>(selectedRaces);
            var modifierRaces = new HashSet<int>(modifier.Races.Select(t => t.RaceId));

            foreach (var race in _context.RaceModel)
            {
                if (selectedHS.Contains(race.Id.ToString()))
                {
                    if (!modifierRaces.Contains(race.Id))
                    {
                        modifier.Races.Add(new Modifier_Race_Link
                        {
                            RaceId = race.Id,
                            ModifierId = modifier.Id
                        });
                    }
                }
                else
                {
                    if (modifierRaces.Contains(race.Id))
                    {
                        Modifier_Race_Link raceToRemove = modifier.Races.FirstOrDefault(t => t.RaceId == race.Id);
                        _context.Remove(raceToRemove);
                    }
                }
            }
        }

        private void UpdateAssignedTechniques(string[] selectedTechniques, ModifierModel modifier)
        {
            if (selectedTechniques == null)
            {
                modifier.Techniques = new List<Modifier_Technique_Link>();
                return;
            }

            var selectedHS = new HashSet<string>(selectedTechniques);
            var modifierTechniques = new HashSet<int>(modifier.Techniques.Select(t => t.TechniqueId));

            foreach (var Technique in _context.TechniqueModel)
            {
                if (selectedHS.Contains(Technique.Id.ToString()))
                {
                    if (!modifierTechniques.Contains(Technique.Id))
                    {
                        modifier.Techniques.Add(new Modifier_Technique_Link
                        {
                            TechniqueId = Technique.Id,
                            ModifierId = modifier.Id
                        });
                    }
                }
                else
                {
                    if (modifierTechniques.Contains(Technique.Id))
                    {
                        Modifier_Technique_Link TechniqueToRemove = modifier.Techniques.FirstOrDefault(t => t.TechniqueId == Technique.Id);
                        _context.Remove(TechniqueToRemove);
                    }
                }
            }
        }

        // GET: Modifier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifierModel = await _context.ModifierModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (modifierModel == null)
            {
                return NotFound();
            }

            return View(modifierModel);
        }

        // POST: Modifier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modifierModel = await _context.ModifierModel.FindAsync(id);
            _context.ModifierModel.Remove(modifierModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ModifierModelExists(int id)
        {
            return _context.ModifierModel.Any(e => e.Id == id);
        }
    }
}
