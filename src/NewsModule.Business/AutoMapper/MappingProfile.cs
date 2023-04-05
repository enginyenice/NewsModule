using AutoMapper;
using NewsModule.DTOs.NewsDtos;
using NewsModule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModule.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<News, GetNewsDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
        }
    }
}
