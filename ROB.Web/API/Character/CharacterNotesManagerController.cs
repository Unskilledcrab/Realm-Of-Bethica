using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CharacterNotesManagerController : ApiOwnerControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public CharacterNotesManagerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CharacterNotesViewModel>> GetAsync(string characterSheetId)
        {
            try
            {
                var characterSheet = await _context.CharacterSheetModel
                    .FirstOrDefaultAsync(c => c.Id == Convert.ToInt32(characterSheetId)).ConfigureAwait(false);

                CharacterNotesViewModel model = mapper.Map<CharacterNotesViewModel>(characterSheet);
                return Ok(model);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve notes for character " + characterSheetId);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(string characterSheetId, [FromBody] CharacterNotesViewModel notes)
        {
            try
            {
                var sheet = await _context.CharacterSheetModel.FindAsync(Convert.ToInt32(characterSheetId));
                if (sheet == null) return NotFound("Could not find character " + characterSheetId);

                mapper.Map(notes, sheet);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok(notes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not add notes for character " + characterSheetId);
            }
        }
    }
}
