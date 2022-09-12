using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Utilities;

namespace ImageFilters.Services.Services
{
    public interface IImageFilterBusinessService
    {
        Task<GenericResponseModel<StatusMessageResponseDTO>> AddImageFilter(AddImageFilterDTO uploadFileDTO);
        Task<GenericResponseModel<StatusMessageResponseDTO>> EditImageFilter(UpdateImageFilterDTO uploadFileDTO);
        Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetPublishedImageFilters();
        Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetAllImageFilters();

        Task<GenericResponseModel<StatusMessageResponseDTO>> DeactivateImageFilter(int id);
       // Task<GenericResponseModel<StatusMessageResponseDTO>> DeleteImageFilter(int id );

    }
}