using AutoMapper;
using ImageFilters.DB.Models;
using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityUserManager identityUserManager;
        private readonly ITokenService tokenService;

        public AuthService(IIdentityUserManager identityUserManager, ITokenService tokenService)
        {
            this.identityUserManager = identityUserManager;
            this.tokenService = tokenService;
        }

        public async Task<GenericResponseModel<AdminLoginResponseDTO>> AdminLogin(AdminLoginRequestDTO adminLoginRequestDTO)
        {
            var result = new GenericResponseModel<AdminLoginResponseDTO>();

            var user = await identityUserManager.GetUserByEmail(adminLoginRequestDTO.Email);

            if (user is null || !await identityUserManager.CheckPassword(user, adminLoginRequestDTO.Password))
            {
                result.Data = null;
                result.ErrorList.Add(new ErrorListModel { Id=1, Message = "Email or Password is incorrect!" });
                return result;
            }
            var jwtSecurityToken = await tokenService.CreateAccessToken(user);
            result.Data.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            result.Data.TokenExpiration = jwtSecurityToken.ValidTo;
            return result;
        }

        public async Task<GenericResponseModel<StatusMessageResponseDTO>> AdminRegister(AdminRegisterRequestDTO adminRegisterRequestDTO)
        {
            GenericResponseModel<StatusMessageResponseDTO> result = new();

            if ( identityUserManager.GetActiveUserByMail(adminRegisterRequestDTO.Email) != null)
            {
                result.ErrorList.Add(new ErrorListModel { Message = "Email is already registered!" });
                return result;
            }
            var user = new User
            {
                UserName = adminRegisterRequestDTO.UserName,
                Email = adminRegisterRequestDTO.Email,
                FirstName = adminRegisterRequestDTO.FirstName,
                LastName = adminRegisterRequestDTO.LastName
            };

            var createUser = await identityUserManager.CreateUser(user, adminRegisterRequestDTO.Password);

            if (!createUser.Succeeded)
            {
                result.ErrorList.AddRange(createUser.Errors.Select((x, i) => new ErrorListModel { Id = ++i, Message = x.Description }).ToList());
                return result;
            }
            
            await identityUserManager.AddRoleToUser(user, Constants.Admin);

            result.Data.status = true;
            return result;

        }


    }
}
