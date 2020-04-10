using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CharacterDetailsManagerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public CharacterDetailsManagerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CharacterDetailsViewModel>> GetAsync(string characterSheetId)
        {            
            try
            {
                var characterSheet = await _context.CharacterSheetModel
                    .FirstOrDefaultAsync(c => c.Id == Convert.ToInt32(characterSheetId)).ConfigureAwait(false);

                CharacterDetailsViewModel model = mapper.Map<CharacterDetailsViewModel>(characterSheet);
                return Ok(model);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve details for character " + characterSheetId);
            }
        }

        [HttpPut()]
        public async Task<ActionResult<CharacterDetailsViewModel>> Put(string characterSheetId,[FromBody] CharacterDetailsViewModel details)
        {
            try
            {                
                var sheet = await _context.CharacterSheetModel.FindAsync(Convert.ToInt32(characterSheetId));
                if (sheet == null) return NotFound("Could not find character " + characterSheetId);
                
                mapper.Map(details, sheet);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not update details for character " + characterSheetId);
            }
        }
    }
}
