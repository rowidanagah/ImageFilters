using ImageFilters.Services;
using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageFilters.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageFiltersController : ControllerBase
    {
        private readonly IImageFilterBusinessService imageFilterBusinessService;

        public ImageFiltersController(IImageFilterBusinessService imageFilterBusinessService)
        {
            this.imageFilterBusinessService = imageFilterBusinessService;
        }

        [HttpPost]
        //[Authorize(Roles = $"{Constants.Admin}")]
        public async Task<IActionResult> AddImageFilter([FromQuery] AddImageFilterDTO uploadFileRequestDTO)
        {

            var result = await imageFilterBusinessService.AddImageFilter(uploadFileRequestDTO);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPut]
        //[Authorize(Roles = $"{Constants.Admin}")]
        public async Task<IActionResult> EditImageFilter([FromQuery] UpdateImageFilterDTO uploadFileRequestDTO)
        {

            var result = await imageFilterBusinessService.EditImageFilter(uploadFileRequestDTO);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet]
        //[Authorize(Roles = $"{Constants.Admin}")]
        public async Task<IActionResult> GetAllImageFilters()
        {

            var result = await imageFilterBusinessService.GetAllImageFilters();

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPublishedImageFilters()
        {

            var result = await imageFilterBusinessService.GetPublishedImageFilters();

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> DeactivateImageFilter([FromQuery] int id)
        {

            var result = await imageFilterBusinessService.DeactivateImageFilter(id);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteImageFilter([FromQuery] int id)
        {

            var result = await imageFilterBusinessService.DeleteImageFilter(id);

            if (result.ErrorList.Any())
                return BadRequest(result);

            return Ok(result);
        }

    }
}
