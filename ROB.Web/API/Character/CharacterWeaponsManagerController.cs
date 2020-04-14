using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.API;
using ROB.Web.Attributes;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.API
{
    public class CharacterWeaponsManagerController : ApiOwnerControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterWeaponsManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeaponModel>>> GetAsync(string characterSheetId)
        {
            try
            {
                var weapons = await _context.WeaponModel
                    .Include(w => w.WeaponType)
                    .Include(w => w.Size)
                    .Include(w => w.DamageType)
                    .Where(w => w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .ToListAsync().ConfigureAwait(false);
                if (weapons == null) return NotFound("There are no weapons for this sheet");
                return Ok(weapons);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve weapons for character " + characterSheetId);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponModel>> Get(string characterSheetId, int id)
        {
            try
            {
                var weapon = await _context.WeaponModel
                    .Include(w => w.WeaponType)
                    .Include(w => w.Size)
                    .Include(w => w.DamageType)
                    .Where(w => w.Id == id && w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                if (weapon == null) return NotFound("This weapon is not bound to this sheet");
                return Ok(weapon);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve weapon " + id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(string characterSheetId, [FromBody] ApiIdViewModel id)
        {
            try
            {
                var link = new CharacterSheet_Weapon_Link { CharacterSheetId = int.Parse(characterSheetId), WeaponId = id.Id };
                _context.Add(link);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not add weapon " + id.Id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string characterSheetId, int id)
        {
            try
            {
                var sheet = await _context.CharacterSheetModel
                    .Include(c => c.Weapons)
                    .FirstOrDefaultAsync(c => c.Id == int.Parse(characterSheetId)).ConfigureAwait(false);// Get the sheet we want to update                
                sheet.Weapons.Remove(sheet.Weapons.Where(w => w.WeaponId == id).FirstOrDefault());// Remove the weapon from the sheet                           
                await _context.SaveChangesAsync().ConfigureAwait(false); // Update the changes to the database
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not remove weapon " + id.ToString() + " for character " + characterSheetId);
            }
        }
    }
}
