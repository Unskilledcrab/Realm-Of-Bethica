using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROB.Blazor.Shared.Interfaces.CombatTracker;
using ROB.Web.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ROB.Web.API.Campaign
{
    public class CampaignController : ApiOwnerController
    {
        private readonly ApplicationDbContext _context;

        public CampaignController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IGamePackage>> GetAsync(string campaignId)
        {
            try
            {
                if (int.TryParse(campaignId, out int id))
                {
                    Thread.Sleep(1000);
                    MockGamePackageFactory factory = new MockGamePackageFactory();
                    var package = await factory.GetGamePackage(id);
                    return Ok(package);
                }
                else
                {
                    return NotFound($"CampaignId({campaignId}) is not of a valid form.");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Could not retrieve CampaignId({campaignId}).");
            }
        }
    }
}
