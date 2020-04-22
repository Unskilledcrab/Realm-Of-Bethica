﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ROB.Web.Controllers
{
    [Authorize]
    public class PUBConController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public PUBConController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( PUBConGameModel pubConGameModel)
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
            var games = await _context.PUBConGameModel
                .Include(p => p.Players)
                .AsNoTracking()
                .ToListAsync();
            return View(games);
        }

        public IActionResult TermsOfConduct()
        {
            return View();
        }
    }
}
