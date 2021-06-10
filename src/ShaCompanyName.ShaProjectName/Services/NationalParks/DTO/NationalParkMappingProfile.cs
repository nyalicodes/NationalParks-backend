using AutoMapper;
using ShaCompanyName.ShaProjectName.Domain;
using ShaCompanyName.ShaProjectName.Services.NationalParks.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShaCompanyName.ShaProjectName.Services.NationalParks
{
    public class NationalParkMappingProfile : Profile
    {
        public NationalParkMappingProfile()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}
