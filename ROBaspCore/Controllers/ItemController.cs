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

namespace ROBaspCore.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var model = _context.ItemModel
                .Include(i => i.Category)
                .AsNoTracking();
            return View(await model.ToListAsync().ConfigureAwait(false));
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .Include(i => i.Category)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        private void PopulateItemCategoryDropDownList(object selectedCategory = null)
        {
            var CategoryQuery = from lg in _context.ItemCategoryModel
                                orderby lg.Name
                                select lg;
            ViewBag.Category = new SelectList(CategoryQuery.AsNoTracking(), "Id", "Name", selectedCategory);
        }

        // GET: Item/Create
        public IActionResult Create()
        {
            PopulateItemCategoryDropDownList();
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Description,Weight,Cost,ResellValue")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            PopulateItemCategoryDropDownList(itemModel.CategoryId);
            return View(itemModel);
        }

        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            PopulateItemCategoryDropDownList(itemModel.CategoryId);
            return View(itemModel);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Name,Description,Weight,Cost,ResellValue")] ItemModel itemModel)
        {
            if (id != itemModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.Id))
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
            return View(itemModel);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemModel = await _context.ItemModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemModel = await _context.ItemModel.FindAsync(id);
            _context.ItemModel.Remove(itemModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool ItemModelExists(int id)
        {
            return _context.ItemModel.Any(e => e.Id == id);
        }
    }
}
