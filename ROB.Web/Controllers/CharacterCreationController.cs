using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ROB.Web.Controllers
{
    [Authorize]
    public class CharacterCreationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public CharacterCreationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> CharacterSheetManager()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var characterSheets = await _context.CharacterSheetModel
                .Include(c => c.Race)
                .Where(c => c.CreatorId == userId)
                .AsNoTracking()
                .ToListAsync();

            return View(characterSheets);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var characterSheet = await _context.CharacterSheetModel.FindAsync(id);
            _context.CharacterSheetModel.Remove(characterSheet);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(CharacterSheetManager));
        }

        public async Task<IActionResult> NewCharacter()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> NewCharacter(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return View();
            }

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var newCharacterSheet = new CharacterSheetModel();
                newCharacterSheet.Name = Name;
                newCharacterSheet.CreatorId = userId;

                _context.Add(newCharacterSheet);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return RedirectToAction(nameof(RaceSelection), new { id = newCharacterSheet.Id });
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> RaceSelection(int? id)
        {
            if (id == null) return NotFound();

            var characterSheet = await _context.CharacterSheetModel
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            var query = _context.RaceModel
                .Include(r => r.FirstModifiedAttribute)
                .Include(r => r.SecondModifiedAttribute);

            await query.Include(r => r.Modifiers).ThenInclude(r => r.Modifier).ThenInclude(r => r.ParentSkillToModify).LoadAsync().ConfigureAwait(false);
            await query.Include(r => r.Modifiers).ThenInclude(r => r.Modifier).ThenInclude(r => r.ChildSkillToModify).LoadAsync().ConfigureAwait(false);
            await query.Include(r => r.Modifiers).ThenInclude(r => r.Modifier).ThenInclude(r => r.AttributeToModify).LoadAsync().ConfigureAwait(false);

            var races = await query.ToListAsync().ConfigureAwait(false);

            var raceSelection = new RaceSelection();
            raceSelection.CharacterSheetId = (int)id;
            raceSelection.Races = races;

            return View(raceSelection);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RaceSelection(int id, int RaceId)
        {
            if (id == null) return NotFound();

            var characterSheet = await _context.CharacterSheetModel
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            characterSheet.RaceId = RaceId;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(PregenSelection), new { id = characterSheet.Id });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<IActionResult> PregenSelection(int? id)
        {
            if (id == null) return NotFound();

            var characterSheet = await _context.CharacterSheetModel
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            var query = _context.PregenProfessionArchetypeModel;

            await query.Include(r => r.TrainedParentSkills).ThenInclude(r => r.ParentSkill).LoadAsync().ConfigureAwait(false);
            await query.Include(r => r.ChildSkills).ThenInclude(r => r.ChildSkill).LoadAsync().ConfigureAwait(false);
            await query.Include(r => r.Talents).ThenInclude(r => r.Talent).LoadAsync().ConfigureAwait(false);
            await query.Include(r => r.Techniques).ThenInclude(r => r.Technique).LoadAsync().ConfigureAwait(false);

            var pregens = await query.ToListAsync().ConfigureAwait(false);

            var pregenSelection = new PregenSelection();
            pregenSelection.CharacterSheetId = (int)id;
            pregenSelection.Pregens = pregens;

            return View(pregenSelection);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> PregenSelection(int id, int PregenId)
        {
            if (id == null) return NotFound();

            // Need to bring in both contexts
            var characterSheet = await _context.CharacterSheetModel
                .Include(r => r.ParentSkills)
                .Include(r => r.ChildSkills)
                .Include(r => r.Talents)
                .Include(r => r.Techniques)
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            var selectedPregen = await _context.PregenProfessionArchetypeModel
                .Include(r => r.TrainedParentSkills)
                .Include(r => r.ChildSkills)
                .Include(r => r.Talents)
                .Include(r => r.Techniques)
                .FirstOrDefaultAsync(r => r.Id == PregenId).ConfigureAwait(false);

            // then you delete anything in the context that doesn't match
            foreach (var technique in characterSheet.Techniques)
            {
                // see if there is anything in the selected pregens techniques that is in the current techniques
                if (!selectedPregen.Techniques.Where(t => t.TechniqueId == technique.TechniqueId).Any())
                {
                    // if there isn't, then remove it from the database context... you have to do this for EF Core. 
                    // removing it from the class db set will not provoke removing it when you save changes
                    _context.Remove(technique);
                }
            }

            // add everything that is new
            var techniquesToAdd = new List<CharacterSheet_Technique_Link>();
            foreach (var technique in selectedPregen.Techniques)
            {
                techniquesToAdd.Add(new CharacterSheet_Technique_Link
                {
                    CharacterSheetId = id,
                    TechniqueId = technique.TechniqueId
                });
            }

            // and finally update the model
            characterSheet.Techniques.Clear();
            characterSheet.Techniques = techniquesToAdd;

            // then it's on to the next. rinse and repeat
            foreach (var talent in characterSheet.Talents)
            {
                if (!selectedPregen.Talents.Where(t => t.TalentId == talent.TalentId).Any())
                {
                    _context.Remove(talent);
                }
            }

            var talentsToAdd = new List<CharacterSheet_Talent_Link>();
            foreach (var talent in selectedPregen.Talents)
            {
                talentsToAdd.Add(new CharacterSheet_Talent_Link
                {
                    CharacterSheetId = id,
                    TalentId = talent.TalentId
                });
            }
            characterSheet.Talents.Clear();
            characterSheet.Talents = talentsToAdd;

            foreach (var childSkill in characterSheet.ChildSkills)
            {
                if (!selectedPregen.ChildSkills.Where(t => t.ChildSkillId == childSkill.ChildSkillId).Any())
                {
                    _context.Remove(childSkill);
                }
            }

            var childSkillsToAdd = new List<CharacterSheet_ChildSkill_Link>();
            foreach (var childSkill in selectedPregen.ChildSkills)
            {
                childSkillsToAdd.Add(new CharacterSheet_ChildSkill_Link
                {
                    CharacterSheetId = id,
                    ChildSkillId = childSkill.ChildSkillId
                });
            }
            characterSheet.ChildSkills.Clear();
            characterSheet.ChildSkills = childSkillsToAdd;

            foreach (var parentSkill in characterSheet.ParentSkills)
            {
                if (!selectedPregen.TrainedParentSkills.Where(t => t.ParentSkillId == parentSkill.ParentSkillId).Any())
                {
                    _context.Remove(parentSkill);
                }
            }

            var parentSkillsToAdd = new List<CharacterSheet_ParentSkill_Link>();
            foreach (var parentSkill in selectedPregen.TrainedParentSkills)
            {
                parentSkillsToAdd.Add(new CharacterSheet_ParentSkill_Link
                {
                    CharacterSheetId = id,
                    ParentSkillId = parentSkill.ParentSkillId
                });
            }
            characterSheet.ParentSkills.Clear();
            characterSheet.ParentSkills = parentSkillsToAdd;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(AttributeSelection), new { id = characterSheet.Id });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<IActionResult> AttributeSelection(int id)
        {
            return View(id);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AttributeSelection(int id, int strong, int robust, int agile, int precision, int knowledgeable, int headstrong, int charismatic, int attractive)
        {
            var characterSheet = await _context.CharacterSheetModel
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            characterSheet.Strong = strong;
            characterSheet.Robust = robust;
            characterSheet.Agile = agile;
            characterSheet.Precision = precision;
            characterSheet.Knowledgeable = knowledgeable;
            characterSheet.Headstrong = headstrong;
            characterSheet.Charismatic = charismatic;
            characterSheet.Attractive = attractive;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(CharacterSheet), new { id = characterSheet.Id });
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<IActionResult> CharacterSheet(int? id)
        {
            if (id == null) return NotFound();
            
            if (!await Utilities.PrivacyCharacterSheet.IsSheetOwner(_context,userManager.GetUserId(HttpContext.User),id.GetValueOrDefault()).ConfigureAwait(false))
            {
                ViewBag.ErrorMessage = $"This character sheet does not belong to you and is set to private. Ask the owner to share this sheet with you to view";
                return View("NotFound");
            }

            var characterSheet = await _context.CharacterSheetModel
                .Include(c => c.ChildSkills)
                    .ThenInclude(c => c.ChildSkill)
                .Include(c => c.ParentSkills)
                    .ThenInclude(c => c.ParentSkill)
                .Include(c => c.Talents)
                    .ThenInclude(c => c.Talent)
                .Include(c => c.Techniques)
                    .ThenInclude(c => c.Technique)
                .Include(c => c.Race)
                .FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);

            if (characterSheet == null) return NotFound();

            return View(characterSheet);
        }
    }
}
