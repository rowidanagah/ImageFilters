using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Utilities;

namespace ImageFilters.Services.Services
{
    public interface IAuthService
    {
        Task<GenericResponseModel<AdminLoginResponseDTO>> AdminLogin(AdminLoginRequestDTO adminLoginRequestDTO);
        Task<GenericResponseModel<StatusMessageResponseDTO>> AdminRegister(AdminRegisterRequestDTO adminRegisterRequestDTO);
    }
}