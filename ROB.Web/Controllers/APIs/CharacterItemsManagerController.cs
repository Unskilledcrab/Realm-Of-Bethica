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

namespace ROB.Web.Controllers
{
    /// <summary>
    /// For the character sheets all of them will use these type of APIs
    /// 
    /// They will not have the ability to update anything they are only
    /// getting the bound data and adding or removing the data
    /// </summary>
    [ServiceFilter(typeof(AuthorizeSheetOwnerAttribute))]
    [Route("api/{characterSheetId}/[controller]")]
    [ApiController]
    public class CharacterItemsManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CharacterItemsManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemModel>>> GetAsync(string characterSheetId)
        {            
            try
            {
                var Items = await _context.ItemModel
                    .Include(w => w.Category)
                    .Where(w => w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .ToListAsync().ConfigureAwait(false);
                if (Items == null) return NotFound("There are no Items for this sheet");
                return Ok(Items);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Items for character " + characterSheetId);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> Get(string characterSheetId, int id)
        {
            try
            {
                var Item = await _context.ItemModel
                    .Include(w => w.Category)
                    .Where(w => w.Id == id && w.CharacterSheets.Any(c => c.CharacterSheetId == int.Parse(characterSheetId)))
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                if (Item == null) return NotFound("This Item is not bound to this sheet");
                return Ok(Item);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve Item " + id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(string characterSheetId,[FromBody] ApiIdViewModel id)
        {
            try
            {
                var link = new CharacterSheet_Item_Link { CharacterSheetId = int.Parse(characterSheetId), ItemId = id.Id };
                _context.Add(link);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not add Item " + id.Id.ToString() + " for character " + characterSheetId);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string characterSheetId, int id)
        {
            try
            {                
                var sheet = await _context.CharacterSheetModel
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.Id == int.Parse(characterSheetId)).ConfigureAwait(false);// Get the sheet we want to update                
                sheet.Items.Remove(sheet.Items.Where(w => w.ItemId == id).FirstOrDefault());// Remove the Item from the sheet                           
                await _context.SaveChangesAsync().ConfigureAwait(false); // Update the changes to the database
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not remove Item " + id.ToString() + " for character " + characterSheetId);
            }
        }
    }
}
