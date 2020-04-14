using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using ROB.Web.Models;

namespace ROB.Web.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class WeaponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeaponsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Weapon
        public async Task<IActionResult> Index()
        {
            var weapons = _context.WeaponModel
                .Include(w => w.Size)
                .Include(w => w.DamageType)
                .Include(w => w.WeaponType)
                .AsNoTracking();
            return View(await weapons.ToListAsync().ConfigureAwait(false));
        }

        // GET: Weapon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponModel = await _context.WeaponModel
                .Include(w => w.Size)
                .Include(w => w.DamageType)
                .Include(w => w.WeaponType)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponModel == null)
            {
                return NotFound();
            }

            return View(weaponModel);
        }
        private void PopulateWeaponTypeDropDownList(object selectedWeaponType = null)
        {
            var WeaponTypeQuery = from lg in _context.WeaponTypeModel select lg;
            ViewBag.WeaponType = new SelectList(WeaponTypeQuery.AsNoTracking(), "Id", "Name", selectedWeaponType);
        }
        private void PopulateDamageTypeDropDownList(object selectedDamageType = null)
        {
            var DamageTypeQuery = from lg in _context.DamageTypeModel select lg;
            ViewBag.DamageType = new SelectList(DamageTypeQuery.AsNoTracking(), "Id", "Name", selectedDamageType);
        }
        private void PopulateWeaponSizeDropDownList(object selectedWeaponSize = null)
        {
            var WeaponSizeQuery = from lg in _context.WeaponSizeModel select lg;
            ViewBag.WeaponSize = new SelectList(WeaponSizeQuery.AsNoTracking(), "Id", "Name", selectedWeaponSize);
        }
        // GET: Weapon/Create
        public IActionResult Create()
        {
            PopulateDamageTypeDropDownList();
            PopulateWeaponSizeDropDownList();
            PopulateWeaponTypeDropDownList();
            return View();
        }

        // POST: Weapon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SizeId,DamageTypeId,WeaponTypeId,Name,Description,Handed,RateOfAttack,DamageValue,DamageFactor,ReactionModifier,PenetrationValue,Weight,Range,Cost,Evasion")] WeaponModel weaponModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weaponModel);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            PopulateDamageTypeDropDownList(weaponModel.DamageTypeId);
            PopulateWeaponSizeDropDownList(weaponModel.SizeId);
            PopulateWeaponTypeDropDownList(weaponModel.WeaponTypeId);
            return View(weaponModel);
        }

        // GET: Weapon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponModel = await _context.WeaponModel.FindAsync(id);
            if (weaponModel == null)
            {
                return NotFound();
            }
            PopulateDamageTypeDropDownList(weaponModel.DamageTypeId);
            PopulateWeaponSizeDropDownList(weaponModel.SizeId);
            PopulateWeaponTypeDropDownList(weaponModel.WeaponTypeId);
            return View(weaponModel);
        }

        // POST: Weapon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SizeId,DamageTypeId,WeaponTypeId,Name,Description,Handed,RateOfAttack,DamageValue,DamageFactor,ReactionModifier,PenetrationValue,Weight,Range,Cost,Evasion")] WeaponModel weaponModel)
        {
            if (id != weaponModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weaponModel);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeaponModelExists(weaponModel.Id))
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
            PopulateDamageTypeDropDownList(weaponModel.DamageTypeId);
            PopulateWeaponSizeDropDownList(weaponModel.SizeId);
            PopulateWeaponTypeDropDownList(weaponModel.WeaponTypeId);
            return View(weaponModel);
        }

        // GET: Weapon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weaponModel = await _context.WeaponModel
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weaponModel == null)
            {
                return NotFound();
            }

            return View(weaponModel);
        }

        // POST: Weapon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weaponModel = await _context.WeaponModel.FindAsync(id);
            _context.WeaponModel.Remove(weaponModel);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool WeaponModelExists(int id)
        {
            return _context.WeaponModel.Any(e => e.Id == id);
        }
    }
}
