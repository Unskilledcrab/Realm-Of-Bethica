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

namespace ROB.Web.Controllers
{
    [ServiceFilter(typeof(AuthorizeSheetOwnerAttribute))]
    [Route("api/{characterSheetId}/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorldController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/World
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorldModel>>> GetWorldModel()
        {
            return await _context.WorldModel.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/World/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorldModel>> GetWorldModel(int id)
        {
            var worldModel = await _context.WorldModel.FindAsync(id);

            if (worldModel == null)
            {
                return NotFound();
            }

            return worldModel;
        }

        // PUT: api/World/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorldModel(int id, WorldModel worldModel)
        {
            if (id != worldModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(worldModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorldModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/World
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WorldModel>> PostWorldModel(WorldModel worldModel)
        {
            _context.WorldModel.Add(worldModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetWorldModel", new { id = worldModel.Id }, worldModel);
        }

        // DELETE: api/World/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorldModel>> DeleteWorldModel(int id)
        {
            var worldModel = await _context.WorldModel.FindAsync(id);
            if (worldModel == null)
            {
                return NotFound();
            }

            _context.WorldModel.Remove(worldModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return worldModel;
        }

        private bool WorldModelExists(int id)
        {
            return _context.WorldModel.Any(e => e.Id == id);
        }
    }
}
