using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;
using ROB.Web.ViewModels;

namespace ROB.Web.Controllers
{
    public class ItemPackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemPackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemPackModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemPackModel.ToListAsync());
        }

        // GET: ItemPackModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPackModel = await _context.ItemPackModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPackModel == null)
            {
                return NotFound();
            }

            return View(itemPackModel);
        }

        // GET: ItemPackModels/Create
        public IActionResult Create()
        {
            var itemPack = new ItemPackModel();
            PopulateItemsData(itemPack);
            return View();
        }

        private void PopulateItemsData(ItemPackModel itemPack)
        {
            var allItems = _context.ItemModel;
            var assignedPrerequisites = new HashSet<int>(itemPack.Items.Select(t => t.ItemId));
            var viewModel = new List<AssignedItemPackItems>();
            foreach (var prerequisite in allItems)
            {
                viewModel.Add(new AssignedItemPackItems
                {
                    ItemId = prerequisite.Id,
                    ItemName = prerequisite.Name,
                    IsAssigned = assignedPrerequisites.Contains(prerequisite.Id)
                });
            }
            ViewData["Items"] = viewModel;
        }

        // POST: ItemPackModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ItemPackModel itemPackModel, string[] items)
        {
            if (items != null)
            {
                itemPackModel.Items = new List<ItemPack_Item_Link>();
                foreach (var item in items)
                {
                    var itemToAdd = new ItemPack_Item_Link
                    {
                        ItemPackId = itemPackModel.Id,
                        ItemId = int.Parse(item)
                    };
                    itemPackModel.Items.Add(itemToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(itemPackModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateItemsData(itemPackModel);
            return View(itemPackModel);
        }

        // GET: ItemPackModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPackModel = await _context.ItemPackModel
                .Include(i=>i.Items)
                .FirstOrDefaultAsync(i=>i.Id == id);
            if (itemPackModel == null)
            {
                return NotFound();
            }
            PopulateItemsData(itemPackModel);
            return View(itemPackModel);
        }

        // POST: ItemPackModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ItemPackModel itemPackModel, string[] items)
        {
            if (id != itemPackModel.Id)
            {
                return NotFound();
            }

            var itemPackModelToUpdate = await _context.ItemPackModel
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (ModelState.IsValid)
            {
                if (await TryUpdateModelAsync(itemPackModelToUpdate, "").ConfigureAwait(false))
                {
                    UpdateItems(items, itemPackModelToUpdate);
                    try
                    {
                        _context.Update(itemPackModelToUpdate);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemPackModelExists(itemPackModelToUpdate.Id))
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
            }
            PopulateItemsData(itemPackModel);
            return View(itemPackModel);
        }

        private void UpdateItems(string[] selectedItems, ItemPackModel itemPack)
        {
            if (selectedItems == null)
            {
                itemPack.Items = new List<ItemPack_Item_Link>();
                return;
            }

            var selectedItemsHS = new HashSet<string>(selectedItems);
            var itemPackItems = new HashSet<int>(itemPack.Items.Select(t => t.ItemPackId));

            foreach (var prereq in _context.ItemModel)
            {
                if (selectedItemsHS.Contains(prereq.Id.ToString()))
                {
                    if (!itemPackItems.Contains(prereq.Id))
                    {
                        itemPack.Items.Add(new ItemPack_Item_Link
                        {
                            ItemPackId = itemPack.Id,
                            ItemId = prereq.Id
                        });
                    }
                }
                else
                {
                    if (itemPackItems.Contains(prereq.Id))
                    {
                        ItemPack_Item_Link itemToRemove = itemPack.Items.FirstOrDefault(t => t.ItemId == prereq.Id);
                        _context.Remove(itemToRemove);
                    }
                }
            }
        }

        // GET: ItemPackModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPackModel = await _context.ItemPackModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemPackModel == null)
            {
                return NotFound();
            }

            return View(itemPackModel);
        }

        // POST: ItemPackModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPackModel = await _context.ItemPackModel.FindAsync(id);
            _context.ItemPackModel.Remove(itemPackModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPackModelExists(int id)
        {
            return _context.ItemPackModel.Any(e => e.Id == id);
        }
    }
}
