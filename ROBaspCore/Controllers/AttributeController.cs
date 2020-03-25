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
    public class AttributeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttributeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attribute
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttributeModel.ToListAsync().ConfigureAwait(false));
        }

        // GET: Attribute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeModel = await _context.AttributeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (attributeModel == null)
            {
                return NotFound();
            }

            return View(attributeModel);
        }

        // GET: Attribute/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttributeType,Description")] AttributeModel attributeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attributeModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(attributeModel);
        }

        // GET: Attribute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeModel = await _context.AttributeModel.FindAsync(id);
            if (attributeModel == null)
            {
                return NotFound();
            }
            return View(attributeModel);
        }

        // POST: Attribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AttributeType,Description")] AttributeModel attributeModel)
        {
            if (id != attributeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributeModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeModelExists(attributeModel.Id))
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
            return View(attributeModel);
        }

        // GET: Attribute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeModel = await _context.AttributeModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (attributeModel == null)
            {
                return NotFound();
            }

            return View(attributeModel);
        }

        // POST: Attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attributeModel = await _context.AttributeModel.FindAsync(id);
            _context.AttributeModel.Remove(attributeModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeModelExists(int id)
        {
            return _context.AttributeModel.Any(e => e.Id == id);
        }
    }
}
