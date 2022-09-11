using AutoMapper;
using ImageFilters.DB.Models;
using ImageFilters.Services.DTOModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters.Services.Utilities
{
    public class MyMapper : Profile
    {
        public MyMapper(IConfiguration config)
        {
            CreateMap<ImageFilter, ImageFilterResponseDTO>()
           .ForMember(dest => dest.ImageFilterUrl, opt => opt.MapFrom(src => config["BaseUrl"]+ src.ImageFilterUrl))
                .ReverseMap();

        }
    }
}
