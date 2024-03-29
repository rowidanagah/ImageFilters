﻿using AutoMapper;
using ImageFilters.DB.Models;
using ImageFilters.Services.DTOModels;
using ImageFilters.Services.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Services
{
    public class ImageFilterBusinessService : IImageFilterBusinessService
    {
        private readonly IImageFilterService imageFilterService;
        private readonly IMapper mapper;

        public ImageFilterBusinessService(IImageFilterService imageFilterService, IMapper mapper)
        {
            this.imageFilterService = imageFilterService;
            this.mapper = mapper;
        }

        public async Task<GenericResponseModel<StatusMessageResponseDTO>> AddImageFilter(AddImageFilterDTO uploadFileDTO)
        {
            var result = new GenericResponseModel<StatusMessageResponseDTO>();

            if ((uploadFileDTO?.Image?.Length ?? 0) < 0 ||
                !(uploadFileDTO?.Image?.ContentType ?? string.Empty).Contains("image"))
            {
                result.Data = null;
                result.ErrorList.Add(new ErrorListModel { Id = 1, Message = "Image is required!" });
                return result;
            }

            var imageUrl = Utility.UploadFile(uploadFileDTO.Image, "Uploads");
            await imageFilterService.AddImageFilter(new ImageFilter
            {
                ImageFilterUrl = imageUrl,
                OriginalFileName = Path.GetFileNameWithoutExtension(uploadFileDTO.Image.FileName),
                StatusId = uploadFileDTO.StatusName == true ? 1 : 2 // 1 -> true -> published, otherwise 2
            });
            return new GenericResponseModel<StatusMessageResponseDTO> { Data = new StatusMessageResponseDTO { status = true } };
        }

        public async Task<GenericResponseModel<StatusMessageResponseDTO>> EditImageFilter(UpdateImageFilterDTO uploadFileDTO)
        {
            var result = new GenericResponseModel<StatusMessageResponseDTO>();
            var imageFilter = await imageFilterService.GetImageFilter(x => x.Id == uploadFileDTO.Id);
            if (imageFilter == null)
            {
                result.Data = null;
                result.ErrorList.Add(new ErrorListModel { Id = 1, Message = "Invalid id!" });
                return result;
            }
           
            string fileName, imageUrl;
            if ((uploadFileDTO?.Image?.Length ?? 0) > 0)
            {
                fileName = Path.GetFileNameWithoutExtension(uploadFileDTO.Image.FileName);
                imageUrl = Utility.UploadFile(uploadFileDTO.Image, "Uploads");
            }
            else
            {
                fileName = uploadFileDTO?.OriginalFileName ?? string.Empty;
                imageUrl = Utility.GetAbsolutePathOrSameString(imageFilter?.ImageFilterUrl) ?? string.Empty;
            }
            await imageFilterService.UpdateImageFilter(
                 new ImageFilter { Id = uploadFileDTO.Id, ImageFilterUrl = imageUrl, StatusId = uploadFileDTO.StatusName == true ? 1 : 2, OriginalFileName = fileName }
                );

            return new GenericResponseModel<StatusMessageResponseDTO> { Data = new StatusMessageResponseDTO { status = true } };
        }

        public async Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetPublishedImageFilters()
        {
            var imageFilters = await imageFilterService.GetImageFilters(x=>x.StatusId == Constants.StatusPublished);
            var result = new GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>();
            result.Data.Items = mapper.Map<List<ImageFilterResponseDTO>>(imageFilters);

            return result;
        }

        public async Task<GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>> GetAllImageFilters()
        {
            var imageFilters =await imageFilterService.GetImageFilters(x=>true);
            var result = new GenericResponseModel<ListResponseDTO<ImageFilterResponseDTO>>();
            result.Data.Items = mapper.Map<List<ImageFilterResponseDTO>>(imageFilters);

            return result;
        }

        public async Task<GenericResponseModel<StatusMessageResponseDTO>> DeactivateImageFilter(int id)
        {
            var result = new GenericResponseModel<StatusMessageResponseDTO>();
            var imageFilter = await imageFilterService.GetImageFilter(x => x.Id == id);

            if (imageFilter == null)
            {
                result.Data = null;
                result.ErrorList.Add(new ErrorListModel { Id = 1, Message = "Invalid id!" });
                return result;
            }
            await imageFilterService.UpdateImageFilter(
               new ImageFilter { Id = id, ImageFilterUrl = imageFilter.ImageFilterUrl, StatusId =imageFilter.StatusId==1? Constants.StatusDraft : Constants.StatusPublished, OriginalFileName = imageFilter.OriginalFileName });
            return new GenericResponseModel<StatusMessageResponseDTO> { Data = new StatusMessageResponseDTO { status = true } };
        }

        public async Task<GenericResponseModel<StatusMessageResponseDTO>> DeleteImageFilter(int id)
        {
            var result = new GenericResponseModel<StatusMessageResponseDTO>();
            var imageFilter = await imageFilterService.GetImageFilter(x => x.Id == id);
            if (imageFilter == null) // check valid data
            {
                result.Data = null;
                result.ErrorList.Add(new ErrorListModel { Id = 1, Message = "Invalid id!" });
                return result;

            }
            var msg = Utility.DeleteFile(imageFilter.ImageFilterUrl, imageFilter.OriginalFileName);
            await imageFilterService.DeleteImageFilter(id);
            return new GenericResponseModel<StatusMessageResponseDTO> { Data = new StatusMessageResponseDTO { status = true } };
        }

    }

}
