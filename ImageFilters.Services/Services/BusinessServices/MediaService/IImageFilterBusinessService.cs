using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Utilities;

namespace ImageFilters.Services.Services
{
    public interface IImageFilterBusinessService
    {
        Task<GenericResponseModel<StatusMessageResponseDTO>> AddImageFilter(UpdateImageFilterDTO uploadFileDTO);
        Task<GenericResponseModel<StatusMessageResponseDTO>> EditImageFilter(UpdateImageFilterDTO uploadFileDTO);
        Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetPublishedImageFilters();
        Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetAllImageFilters();
    }
}