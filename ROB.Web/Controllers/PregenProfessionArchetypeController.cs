using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class PregenProfessionArchetypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PregenProfessionArchetypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void PopulateAssignedTechniqueData(PregenProfessionArchetypeModel pregen)
        {
            var allTechniques = _context.TechniqueModel;
            var assignedTechniques = new HashSet<int?>(pregen.Techniques.Select(t => t.TechniqueId));
            var viewModel = new List<PregenAssignedTechniquesData>();
            foreach (var technique in allTechniques)
            {
                viewModel.Add(new PregenAssignedTechniquesData
                {
                    TechniqueId = technique.Id,
                    TechniqueName = technique.TechniqueName,
                    IsAssigned = assignedTechniques.Contains(technique.Id)
                });
            }
            ViewData["AssignedTechniques"] = viewModel;
        }

        private void PopulateAssignedTalentData(PregenProfessionArchetypeModel pregen)
        {
            var allTalents = _context.TalentModel;
            var assignedTalents = new HashSet<int?>(pregen.Talents.Select(t => t.TalentId));
            var viewModel = new List<PregenAssignedTalentsData>();
            foreach (var talent in allTalents)
            {
                viewModel.Add(new PregenAssignedTalentsData
                {
                    TalentId = talent.Id,
                    TalentName = talent.Name,
                    IsAssigned = assignedTalents.Contains(talent.Id)
                });
            }
            ViewData["AssignedTalents"] = viewModel;
        }

        private void PopulateAssignedChildSkillData(PregenProfessionArchetypeModel pregen)
        {
            var allChildSkills = _context.ChildSkillModel;
            var assignedChildSkills = new HashSet<int?>(pregen.ChildSkills.Select(t => t.ChildSkillId));
            var viewModel = new List<PregenAssignedChildSkillsData>();
            foreach (var childSkill in allChildSkills)
            {
                viewModel.Add(new PregenAssignedChildSkillsData
                {
                    ChildSkillId = childSkill.Id,
                    ChildSkillName = childSkill.Name,
                    IsAssigned = assignedChildSkills.Contains(childSkill.Id)
                });
            }
            ViewData["AssignedChildSkills"] = viewModel;
        }

        private void PopulateAssignedParentSkillData(PregenProfessionArchetypeModel pregen)
        {
            var allParentSkills = _context.ParentSkillModel;
            var assignedParentSkills = new HashSet<int?>(pregen.TrainedParentSkills.Select(t => t.ParentSkillId));
            var viewModel = new List<PregenAssignedTrainedSkillsData>();
            foreach (var parentSkill in allParentSkills)
            {
                viewModel.Add(new PregenAssignedTrainedSkillsData
                {
                    ParentSkillId = parentSkill.Id,
                    ParentSkillName = parentSkill.Name,
                    IsAssigned = assignedParentSkills.Contains(parentSkill.Id)
                });
            }
            ViewData["AssignedParentSkills"] = viewModel;
        }

        // GET: PregenProfessionArchetype
        public async Task<IActionResult> Index()
        {
            return View(await _context.PregenProfessionArchetypeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: PregenProfessionArchetype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregenProfessionArchetypeModel = await _context.PregenProfessionArchetypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (pregenProfessionArchetypeModel == null)
            {
                return NotFound();
            }

            return View(pregenProfessionArchetypeModel);
        }

        // GET: PregenProfessionArchetype/Create
        public IActionResult Create()
        {
            var pregen = new PregenProfessionArchetypeModel();
            PopulateAssignedChildSkillData(pregen);
            PopulateAssignedParentSkillData(pregen);
            PopulateAssignedTalentData(pregen);
            PopulateAssignedTechniqueData(pregen);
            return View();
        }

        // POST: PregenProfessionArchetype/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,file")] PregenProfessionArchetypeModel pregenProfessionArchetypeModel, string[] assignedTalents, string[] assignedTechniques, string[] assignedParentSkills, string[] assignedChildSkills, IFormFile file)
        {
            if (assignedChildSkills != null)
            {
                pregenProfessionArchetypeModel.ChildSkills = new List<PregenProfessionArchetype_ChildSkill_LinkModel>();
                foreach (var assigned in assignedChildSkills)
                {
                    var assignedToAdd = new PregenProfessionArchetype_ChildSkill_LinkModel
                    {
                        ChildSkillId = int.Parse(assigned),
                        PregenProfessionArchetypeId = pregenProfessionArchetypeModel.Id
                    };
                    pregenProfessionArchetypeModel.ChildSkills.Add(assignedToAdd);
                }
            }

            if (assignedTalents != null)
            {
                pregenProfessionArchetypeModel.Talents = new List<PregenProfessionArchetype_Talent_LinkModel>();
                foreach (var assigned in assignedTalents)
                {
                    var assignedToAdd = new PregenProfessionArchetype_Talent_LinkModel
                    {
                        TalentId = int.Parse(assigned),
                        PregenProfessionArchetypeId = pregenProfessionArchetypeModel.Id
                    };
                    pregenProfessionArchetypeModel.Talents.Add(assignedToAdd);
                }
            }

            if (assignedTechniques != null)
            {
                pregenProfessionArchetypeModel.Techniques = new List<PregenProfessionArchetype_Technique_LinkModel>();
                foreach (var assigned in assignedTechniques)
                {
                    var assignedToAdd = new PregenProfessionArchetype_Technique_LinkModel
                    {
                        TechniqueId = int.Parse(assigned),
                        PregenProfessionArchetypeId = pregenProfessionArchetypeModel.Id
                    };
                    pregenProfessionArchetypeModel.Techniques.Add(assignedToAdd);
                }
            }

            if (assignedParentSkills != null)
            {
                pregenProfessionArchetypeModel.TrainedParentSkills = new List<PregenProfessionArchetype_ParentSkill_LinkModel>();
                foreach (var assigned in assignedParentSkills)
                {
                    var assignedToAdd = new PregenProfessionArchetype_ParentSkill_LinkModel
                    {
                        ParentSkillId = int.Parse(assigned),
                        PregenProfessionArchetypeId = pregenProfessionArchetypeModel.Id
                    };
                    pregenProfessionArchetypeModel.TrainedParentSkills.Add(assignedToAdd);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Add(pregenProfessionArchetypeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                var result = await Resources.SetSitePicture(Resources.PregenImagesPath, pregenProfessionArchetypeModel.Id.ToString(), ".gif", file).ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }

            PopulateAssignedChildSkillData(pregenProfessionArchetypeModel);
            PopulateAssignedParentSkillData(pregenProfessionArchetypeModel);
            PopulateAssignedTalentData(pregenProfessionArchetypeModel);
            PopulateAssignedTechniqueData(pregenProfessionArchetypeModel);
            return View(pregenProfessionArchetypeModel);
        }

        // GET: PregenProfessionArchetype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregenProfessionArchetypeModel = await _context.PregenProfessionArchetypeModel
                .Include(p => p.Talents)
                .Include(p => p.Techniques)
                .Include(p => p.TrainedParentSkills)
                .Include(p => p.ChildSkills)
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (pregenProfessionArchetypeModel == null)
            {
                return NotFound();
            }

            PopulateAssignedChildSkillData(pregenProfessionArchetypeModel);
            PopulateAssignedParentSkillData(pregenProfessionArchetypeModel);
            PopulateAssignedTalentData(pregenProfessionArchetypeModel);
            PopulateAssignedTechniqueData(pregenProfessionArchetypeModel);
            return View(pregenProfessionArchetypeModel);
        }

        // POST: PregenProfessionArchetype/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,file")] PregenProfessionArchetypeModel pregenProfessionArchetypeModel, string[] assignedTalents, string[] assignedTechniques, string[] assignedParentSkills, string[] assignedChildSkills, IFormFile file)
        {
            if (id != pregenProfessionArchetypeModel.Id)
            {
                return NotFound();
            }

            var pregenToUpdate = await _context.PregenProfessionArchetypeModel
                .Include(p => p.Talents)
                    .ThenInclude(p => p.Talent)
                .Include(p => p.Techniques)
                    .ThenInclude(p => p.Technique)
                .Include(p => p.TrainedParentSkills)
                    .ThenInclude(p => p.ParentSkill)
                .Include(p => p.ChildSkills)
                    .ThenInclude(p => p.ChildSkill)
                .FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);

            if (ModelState.IsValid)
            {
                var result = await Resources.SetSitePicture(Resources.PregenImagesPath, pregenProfessionArchetypeModel.Id.ToString(), ".gif", file).ConfigureAwait(false);

                if (await TryUpdateModelAsync(pregenToUpdate, "").ConfigureAwait(false))
                {
                    UpdateAssignedChildSkill(assignedChildSkills, pregenToUpdate);
                    UpdateAssignedParentSkill(assignedParentSkills, pregenToUpdate);
                    UpdateAssignedTalent(assignedTalents, pregenToUpdate);
                    UpdateAssignedTechnique(assignedTechniques, pregenToUpdate);
                    try
                    {
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PregenProfessionArchetypeModelExists(pregenToUpdate.Id))
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

            PopulateAssignedChildSkillData(pregenToUpdate);
            PopulateAssignedParentSkillData(pregenToUpdate);
            PopulateAssignedTalentData(pregenToUpdate);
            PopulateAssignedTechniqueData(pregenToUpdate);
            return View(pregenToUpdate);
        }

        private void UpdateAssignedTechnique(string[] selectedTechniques, PregenProfessionArchetypeModel pregen)
        {
            if (selectedTechniques == null)
            {
                pregen.Techniques = new List<PregenProfessionArchetype_Technique_LinkModel>();
                return;
            }

            var selectedTechniquesHS = new HashSet<string>(selectedTechniques);
            var assignedTechniques = new HashSet<int?>(pregen.Techniques.Select(t => t.TechniqueId));

            foreach (var technique in _context.TechniqueModel)
            {
                if (selectedTechniquesHS.Contains(technique.Id.ToString()))
                {
                    if (!assignedTechniques.Contains(technique.Id))
                    {
                        pregen.Techniques.Add(new PregenProfessionArchetype_Technique_LinkModel
                        {
                            TechniqueId = technique.Id,
                            PregenProfessionArchetypeId = pregen.Id
                        });
                    }
                }
                else
                {
                    if (assignedTechniques.Contains(technique.Id))
                    {
                        PregenProfessionArchetype_Technique_LinkModel linkToRemove = pregen.Techniques.FirstOrDefault(t => t.TechniqueId == technique.Id);
                        _context.Remove(linkToRemove);
                    }
                }
            }
        }

        private void UpdateAssignedTalent(string[] selectedTalents, PregenProfessionArchetypeModel pregen)
        {
            if (selectedTalents == null)
            {
                pregen.Talents = new List<PregenProfessionArchetype_Talent_LinkModel>();
                return;
            }

            var selectedTalentsHS = new HashSet<string>(selectedTalents);
            var assignedTalents = new HashSet<int?>(pregen.Talents.Select(t => t.TalentId));

            foreach (var talent in _context.TalentModel)
            {
                if (selectedTalentsHS.Contains(talent.Id.ToString()))
                {
                    if (!assignedTalents.Contains(talent.Id))
                    {
                        pregen.Talents.Add(new PregenProfessionArchetype_Talent_LinkModel
                        {
                            TalentId = talent.Id,
                            PregenProfessionArchetypeId = pregen.Id
                        });
                    }
                }
                else
                {
                    if (assignedTalents.Contains(talent.Id))
                    {
                        PregenProfessionArchetype_Talent_LinkModel linkToRemove = pregen.Talents.FirstOrDefault(t => t.TalentId == talent.Id);
                        _context.Remove(linkToRemove);
                    }
                }
            }
        }

        private void UpdateAssignedChildSkill(string[] selectedChildSkills, PregenProfessionArchetypeModel pregen)
        {
            if (selectedChildSkills == null)
            {
                pregen.ChildSkills = new List<PregenProfessionArchetype_ChildSkill_LinkModel>();
                return;
            }

            var selectedChildSkillsHS = new HashSet<string>(selectedChildSkills);
            var assignedChildSkills = new HashSet<int?>(pregen.ChildSkills.Select(t => t.ChildSkillId));

            foreach (var childSkill in _context.ChildSkillModel)
            {
                if (selectedChildSkillsHS.Contains(childSkill.Id.ToString()))
                {
                    if (!assignedChildSkills.Contains(childSkill.Id))
                    {
                        pregen.ChildSkills.Add(new PregenProfessionArchetype_ChildSkill_LinkModel
                        {
                            ChildSkillId = childSkill.Id,
                            PregenProfessionArchetypeId = pregen.Id
                        });
                    }
                }
                else
                {
                    if (assignedChildSkills.Contains(childSkill.Id))
                    {
                        PregenProfessionArchetype_ChildSkill_LinkModel linkToRemove = pregen.ChildSkills.FirstOrDefault(t => t.ChildSkillId == childSkill.Id);
                        _context.Remove(linkToRemove);
                    }
                }
            }
        }

        private void UpdateAssignedParentSkill(string[] selectedParentSkills, PregenProfessionArchetypeModel pregen)
        {
            if (selectedParentSkills == null)
            {
                pregen.TrainedParentSkills = new List<PregenProfessionArchetype_ParentSkill_LinkModel>();
                return;
            }

            var selectedParentSkillsHS = new HashSet<string>(selectedParentSkills);
            var assignedParentSkills = new HashSet<int?>(pregen.TrainedParentSkills.Select(t => t.ParentSkillId));

            foreach (var parentSkill in _context.ParentSkillModel)
            {
                if (selectedParentSkillsHS.Contains(parentSkill.Id.ToString()))
                {
                    if (!assignedParentSkills.Contains(parentSkill.Id))
                    {
                        pregen.TrainedParentSkills.Add(new PregenProfessionArchetype_ParentSkill_LinkModel
                        {
                            ParentSkillId = parentSkill.Id,
                            PregenProfessionArchetypeId = pregen.Id
                        });
                    }
                }
                else
                {
                    if (assignedParentSkills.Contains(parentSkill.Id))
                    {
                        PregenProfessionArchetype_ParentSkill_LinkModel linkToRemove = pregen.TrainedParentSkills.FirstOrDefault(t => t.ParentSkillId == parentSkill.Id);
                        _context.Remove(linkToRemove);
                    }
                }
            }
        }

        // GET: PregenProfessionArchetype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregenProfessionArchetypeModel = await _context.PregenProfessionArchetypeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (pregenProfessionArchetypeModel == null)
            {
                return NotFound();
            }

            return View(pregenProfessionArchetypeModel);
        }

        // POST: PregenProfessionArchetype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregenProfessionArchetypeModel = await _context.PregenProfessionArchetypeModel.FindAsync(id);
            _context.PregenProfessionArchetypeModel.Remove(pregenProfessionArchetypeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            Resources.DeleteSitePicture(Resources.PregenImagesPath, pregenProfessionArchetypeModel.Id.ToString(), ".gif");
            return RedirectToAction(nameof(Index));
        }

        private bool PregenProfessionArchetypeModelExists(int id)
        {
            return _context.PregenProfessionArchetypeModel.Any(e => e.Id == id);
        }
    }
}
