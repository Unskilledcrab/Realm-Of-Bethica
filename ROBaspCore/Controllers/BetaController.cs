using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROBaspCore.Data;
using ROBaspCore.Models;
using ROBaspCore.Services;

namespace ROBaspCore.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class BetaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This will be a page that links to all of the beta testing utilities
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CombatCalculator()
        {
            return View();
        }
    }
}
