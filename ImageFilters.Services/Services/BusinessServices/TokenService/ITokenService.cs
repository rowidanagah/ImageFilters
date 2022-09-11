using ImageFilters.DB.Models;
using System.IdentityModel.Tokens.Jwt;

namespace ImageFilters.Services.Services
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateAccessToken(User user);
    }
}