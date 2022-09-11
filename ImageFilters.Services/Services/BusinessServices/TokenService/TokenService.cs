using ImageFilters.DB.Models;
using ImageFilters.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly IIdentityUserManager identityUserManager;


        public TokenService(IConfiguration configuration, IIdentityUserManager identityUserManager)
        {
            this.configuration = configuration;
            this.identityUserManager = identityUserManager;
        }

        public async Task<JwtSecurityToken> CreateAccessToken(User user)
        {
            string TokenKey = configuration.GetValue<string>("JWT:Key");
            var jwtDurationInDays = configuration.GetValue<double>("JWT:DurationInDays");

            var claims = await GetBasicClaims(user);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            var jwtSecurityToken = new JwtSecurityToken(
               claims: claims,
               expires: Utility.GetCurrentTime().AddDays(jwtDurationInDays),
               signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        #region PrivateMethods
        private async Task<List<Claim>> GetBasicClaims(User user)
        {

            var userClaims = await identityUserManager.GetUserClaims(user);
            var userRoles = await identityUserManager.GetUserRoles(user);
            var roleClaims = new List<Claim>();

            foreach (var role in userRoles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("nameid", user.Id)
            }.Union(userClaims)
            .Union(roleClaims);

            return claims.ToList();
        }
        #endregion

    }
}
