using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ROB.Web.Data;

namespace ROB.Web.Controllers
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CombatCalculator()
        {
            return View();
        }
    }
}
