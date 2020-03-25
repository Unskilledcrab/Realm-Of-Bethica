using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ROBaspCore.Models;
using ROBaspCore.ViewModels;

namespace ROBaspCore.Controllers
{
    [Authorize(Roles = "Administrator,Developer")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string id)
        {
            ViewBag.userId = id;
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (await userManager.IsInRoleAsync(user, role.Name).ConfigureAwait(false))
                {
                    userRolesViewModel.IsSelected = true;
                } else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            var result = await userManager.RemoveFromRolesAsync(user, roles).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(r => r.RoleName)).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles for user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string id)
        {
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found";
                return View("NotFound");
            }

            var existingUserClaims = await userManager.GetClaimsAsync(user).ConfigureAwait(false);

            var model = new UserClaimsViewModel
            {
                UserId = id
            };

            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            var claims = await userManager.GetClaimsAsync(user).ConfigureAwait(false);
            var result = await userManager.RemoveClaimsAsync(user, claims).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            result = await userManager.AddClaimsAsync(user, 
                model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType))).ConfigureAwait(false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found";
                return View("NotFound");
            }

            var userClaims = await userManager.GetClaimsAsync(user).ConfigureAwait(false);
            var userRoles = await userManager.GetRolesAsync(user).ConfigureAwait(false);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id).ConfigureAwait(false);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await userManager.UpdateAsync(user).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(false);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }

        [HttpGet]
        //[Authorize(Policy = "CreateRolePolicy")]
        public IActionResult CreateRole()
        {
            return View();
        }
        
        [HttpPost]
        //[Authorize(Policy = "CreateRolePolicy")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole).ConfigureAwait(false);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        //[Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id).ConfigureAwait(false);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name).ConfigureAwait(false))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        //[Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id).ConfigureAwait(false);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(role).ConfigureAwait(false);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [HttpPost]
        //[Authorize(Policy = "DeleteRolePolicy")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id).ConfigureAwait(false);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role).ConfigureAwait(false);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListRoles");
            }
        }
    }
}