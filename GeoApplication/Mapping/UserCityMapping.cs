using AutoMapper;
using Entities;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Mapping
{
    public class UserCityMapping:Profile
    {
        public UserCityMapping()
        {
            CreateMap<City, CityUserModel>().ReverseMap();
            CreateMap<City, CityReadModel>().ReverseMap();
        }
    }
}
