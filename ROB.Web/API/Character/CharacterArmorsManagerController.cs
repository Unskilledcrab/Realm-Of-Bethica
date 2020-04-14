using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Attributes;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.API
{
    public class CharacterArmorsManagerController : ApiOwnerControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterArmorsManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArmorModel>>> GetAsync(string characterSheetId)
        {
            try
            {
                var Armors = await _context.ArmorModel
                    .Include(w => w.ArmorRestoration)
                    .Include(w => w.ArmorRestriction)
                    .Where(w => w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .ToListAsync().ConfigureAwait(false);
                if (Armors == null) return NotFound("There are no Armors for this sheet");
                return Ok(Armors);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Armors for character " + characterSheetId);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArmorModel>> Get(string characterSheetId, int id)
        {
            try
            {
                var Armor = await _context.ArmorModel
                    .Include(w => w.ArmorRestoration)
                    .Include(w => w.ArmorRestriction)
                    .Where(w => w.Id == id && w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                if (Armor == null) return NotFound("This Armor is not bound to this sheet");
                return Ok(Armor);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Armor " + id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(string characterSheetId, [FromBody] ApiIdViewModel id)
        {
            try
            {
                var link = new CharacterSheet_Armor_Link { CharacterSheetId = int.Parse(characterSheetId), ArmorId = id.Id };
                _context.Add(link);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not add Armor " + id.Id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string characterSheetId, int id)
        {
            try
            {
                var sheet = await _context.CharacterSheetModel
                    .Include(c => c.Armors)
                    .FirstOrDefaultAsync(c => c.Id == int.Parse(characterSheetId)).ConfigureAwait(false);// Get the sheet we want to update                
                sheet.Armors.Remove(sheet.Armors.Where(w => w.ArmorId == id).FirstOrDefault());// Remove the Armor from the sheet                           
                await _context.SaveChangesAsync().ConfigureAwait(false); // Update the changes to the database
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not remove Armor " + id.ToString() + " for character " + characterSheetId);
            }
        }
    }
}
