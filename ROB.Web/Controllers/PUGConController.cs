using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ROB.Web.Controllers
{    
    public class PUGConController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public PUGConController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult CreateGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateGame( PUBConGameModel pubConGameModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                pubConGameModel.CreatorId = userId;
                _context.Add(pubConGameModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(GameDashboard));
            }
            return View(pubConGameModel);
        }

        [Authorize]
        public async Task<IActionResult> EditGame(int id)
        {
            var pubConGame = await _context.PUBConGameModel.FindAsync(id);
            if (pubConGame == null)
            {
                return NotFound();
            }
            return View(pubConGame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditGame(int id, PUBConGameModel pubConGame)
        {
            if (id != pubConGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pubConGame);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(GameDashboard));
            }
            return View(pubConGame);
        }

        public async Task<IActionResult> GameDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var game = await _context.PUBConGameModel
                .Include(p => p.Players)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);

            if (game == null)
                return NotFound();

            return View(game);
        }

        //[HttpPost]
        [Authorize]
        public async Task<IActionResult> JoinGame(int id)
        {

            var game = await _context.PUBConGameModel
                .Include(p => p.Players)
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);

            if (game == null)
                return NotFound();

            if (game.Players.Count() >= game.MaximumPlayers)
                return BadRequest();

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var link = new User_PUBConGame_Link { PUBConGameId = id, UserId = userId };
                _context.Add(link);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(GameDashboard));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        public async Task<IActionResult> LeaveGame(int id)
        {

            var game = await _context.PUBConGameModel
                .Include(p => p.Players)
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);

            if (game == null)
                return NotFound();

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                game.Players.Remove(game.Players.Where(p => p.UserId == userId).FirstOrDefault());
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(GameDashboard));
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        public async Task<IActionResult> DeleteGame(int id)
        {

            var game = await _context.PUBConGameModel
                .FirstOrDefaultAsync(p => p.Id == id)
                .ConfigureAwait(false);

            if (game == null)
                return NotFound();

            try
            {
                _context.Remove(game);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(GameDashboard));
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> GameDashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var games = await _context.PUBConGameModel
                .Where(p => p.IsPublic == true || p.CreatorId == userId)
                .Include(p => p.Players)                
                .AsNoTracking()
                .ToListAsync();
            return View(games);
        }

        public IActionResult TermsOfConduct()
        {
            return View();
        }

        public IActionResult WelcomePage()
        {
            return View();
        }
    }
}
