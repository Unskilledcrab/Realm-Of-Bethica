﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ROB.Web.Attributes
{
    public class AuthorizeSheetOwnerAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthorizeSheetOwnerAttribute(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var characterSheetId = filterContext.RouteData.Values["characterSheetId"].ToString();
            int sheetId;
            try
            {
                sheetId = int.Parse(characterSheetId);
            }
            catch (Exception ex)
            {
                // maybe should log path?? might happen alot though
                filterContext.Result = new BadRequestObjectResult("Not a valid request");
                return;
            }
            var sheet = await _context.CharacterSheetModel
                .Where(c => c.Id == sheetId && c.CreatorId == userId)
                .Select(c => c.Id)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            
            if (sheet == null) // if sheet is null then this is not the sheet owner
            {
                var viewer = await _context.CharacterSheetModel
                    .Where(c => c.Id == sheetId)
                    .Include(c => c.PermissionViewers.Where(p => p.ApplicationUserId == userId))
                    .Select(c => c.Id)
                    .FirstOrDefaultAsync().ConfigureAwait(false);
                if (viewer == null) //if viewer is null then this person is not in the viewing permissions list
                {
                    filterContext.Result = new BadRequestObjectResult("You can not view this sheet");
                    return;
                }
            }

            // If everything passes allow controller / method access
            await next().ConfigureAwait(false);
        }
    }
}
