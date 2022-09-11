using ImageFilters.DB.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ImageFilters.Services.Services
{
    public interface IIdentityUserManager
    {
        Task<bool> AddRoleToUser(User newUser, string roleName);
        Task<IdentityResult?> CreateUser(User newUser, string password);
        Task<User> GetUserByEmail(string userEmail);
        Task<bool> CheckPassword(User user, string password);
        Task<IList<string>> GetUserRoles(User user);
        Task<IList<Claim>> GetUserClaims(User user);
        User? GetActiveUserByMail(string userEmail);
    }
}