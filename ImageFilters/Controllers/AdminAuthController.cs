using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageFilters.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AdminAuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AdminLoginRequestDTO adminLoginRequestDTO)
        {

            var result = await authService.AdminLogin(adminLoginRequestDTO);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] AdminRegisterRequestDTO adminRegisterRequestDTO)
        {
            var result = await authService.AdminRegister(adminRegisterRequestDTO);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }

    }
}
