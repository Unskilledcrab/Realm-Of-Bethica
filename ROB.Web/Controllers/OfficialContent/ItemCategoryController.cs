using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers.OfficialContent
{
    public class ItemCategoryController : OfficialContentControllerBase 
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemCategoryModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: ItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategoryModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }

            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ItemCategoryModel itemCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCategoryModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategoryModel.FindAsync(id);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }
            return View(itemCategoryModel);
        }

        // POST: ItemCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ItemCategoryModel itemCategoryModel)
        {
            if (id != itemCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCategoryModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryModelExists(itemCategoryModel.Id))
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
            return View(itemCategoryModel);
        }

        // GET: ItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategoryModel = await _context.ItemCategoryModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (itemCategoryModel == null)
            {
                return NotFound();
            }

            return View(itemCategoryModel);
        }

        // POST: ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCategoryModel = await _context.ItemCategoryModel.FindAsync(id);
            _context.ItemCategoryModel.Remove(itemCategoryModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryModelExists(int id)
        {
            return _context.ItemCategoryModel.Any(e => e.Id == id);
        }
    }
}
