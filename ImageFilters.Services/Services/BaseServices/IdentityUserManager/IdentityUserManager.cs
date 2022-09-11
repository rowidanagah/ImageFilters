using ImageFilters.DB.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services
{
    public class IdentityUserManager : IIdentityUserManager
    {
        private readonly UserManager<User> userManager;
        public IdentityUserManager(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> AddRoleToUser(User newUser, string roleName)
        {
            var res = await userManager.AddToRoleAsync(newUser, roleName.ToLower());
            return res.Succeeded;
        }
        public async Task<IdentityResult?> CreateUser(User newUser,string password)
        {
            return await userManager.CreateAsync(newUser,password);
        }
        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await userManager.FindByEmailAsync(userEmail);
        }
        public async Task<bool> CheckPassword(User user,string password)
        {
            return await userManager.CheckPasswordAsync(user,password);
        }
        public async Task<IList<string>> GetUserRoles(User user)
        {
            return await userManager.GetRolesAsync(user);
        }
        public async Task<IList<Claim>> GetUserClaims(User user)
        {
            return await userManager.GetClaimsAsync(user);
        }
        public User? GetActiveUserByMail(string userEmail)
        {
            return userManager.Users.FirstOrDefault(s => s.Email.ToLower() == userEmail.ToLower() && !s.IsDeleted);
        }

    }
}
