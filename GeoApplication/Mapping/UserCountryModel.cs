using AutoMapper;
using Entities;
using GeoApplication.Intefaces;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Mapping
{
    public class UserCountryModel : Profile
    {
        public UserCountryModel()
        {
            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<Country, CountryReadModel>().ReverseMap();
        }
    }
}
