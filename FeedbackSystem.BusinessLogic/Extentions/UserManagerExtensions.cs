using FeedbackSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Extentions
{
    public static class UserManagerExtensions
    {
        public static async Task<UserModel> GetCurrentUserAsync(this UserManager<UserModel> userManager, HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    return user;
                }
            }
            return null;
        }
    }
}
