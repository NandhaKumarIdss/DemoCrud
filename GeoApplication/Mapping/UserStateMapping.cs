using AutoMapper;
using Entities;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Mapping
{
    public class UserStateMapping:Profile
    {
        public UserStateMapping()
        {
            CreateMap<State, StateUserModel>().ReverseMap();
            CreateMap<State, StateReadModel>().ReverseMap();
        }
    }
}
