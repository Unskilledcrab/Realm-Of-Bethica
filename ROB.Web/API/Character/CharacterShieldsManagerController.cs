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
    public class CharacterShieldsManagerController : ApiOwnerControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterShieldsManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShieldModel>>> GetAsync(string characterSheetId)
        {
            try
            {
                var Shields = await _context.ShieldModel
                    .Where(w => w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .ToListAsync().ConfigureAwait(false);
                if (Shields == null) return NotFound("There are no Shields for this sheet");
                return Ok(Shields);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Shields for character " + characterSheetId);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShieldModel>> Get(string characterSheetId, int id)
        {
            try
            {
                var Shield = await _context.ShieldModel
                    .Where(w => w.Id == id && w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                if (Shield == null) return NotFound("This Shield is not bound to this sheet");
                return Ok(Shield);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Shield " + id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(string characterSheetId, [FromBody] ApiIdViewModel id)
        {
            try
            {
                var link = new CharacterSheet_Shield_Link { CharacterSheetId = int.Parse(characterSheetId), ShieldId = id.Id };
                _context.Add(link);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not add Shield " + id.Id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string characterSheetId, int id)
        {
            try
            {
                var sheet = await _context.CharacterSheetModel
                    .Include(c => c.Shields)
                    .FirstOrDefaultAsync(c => c.Id == int.Parse(characterSheetId)).ConfigureAwait(false);// Get the sheet we want to update                
                sheet.Shields.Remove(sheet.Shields.Where(w => w.ShieldId == id).FirstOrDefault());// Remove the Shield from the sheet                           
                await _context.SaveChangesAsync().ConfigureAwait(false); // Update the changes to the database
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not remove Shield " + id.ToString() + " for character " + characterSheetId);
            }
        }
    }
}
