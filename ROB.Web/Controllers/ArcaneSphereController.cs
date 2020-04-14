using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers
{
    public class ArcaneSphereController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArcaneSphereController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ArcaneSphere
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArcaneSphereModel.ToListAsync());
        }

        // GET: ArcaneSphere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcaneSphereModel = await _context.ArcaneSphereModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arcaneSphereModel == null)
            {
                return NotFound();
            }

            return View(arcaneSphereModel);
        }

        // GET: ArcaneSphere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArcaneSphere/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ArcaneSphereModel arcaneSphereModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arcaneSphereModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arcaneSphereModel);
        }

        // GET: ArcaneSphere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcaneSphereModel = await _context.ArcaneSphereModel.FindAsync(id);
            if (arcaneSphereModel == null)
            {
                return NotFound();
            }
            return View(arcaneSphereModel);
        }

        // POST: ArcaneSphere/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ArcaneSphereModel arcaneSphereModel)
        {
            if (id != arcaneSphereModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arcaneSphereModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArcaneSphereModelExists(arcaneSphereModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(arcaneSphereModel);
        }

        // GET: ArcaneSphere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arcaneSphereModel = await _context.ArcaneSphereModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arcaneSphereModel == null)
            {
                return NotFound();
            }

            return View(arcaneSphereModel);
        }

        // POST: ArcaneSphere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arcaneSphereModel = await _context.ArcaneSphereModel.FindAsync(id);
            _context.ArcaneSphereModel.Remove(arcaneSphereModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArcaneSphereModelExists(int id)
        {
            return _context.ArcaneSphereModel.Any(e => e.Id == id);
        }
    }
}
