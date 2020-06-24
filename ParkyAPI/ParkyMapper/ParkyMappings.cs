using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkyAPI.ParkyMapper
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark,NationalParkDtos>().ReverseMap();
        }
    }
}
