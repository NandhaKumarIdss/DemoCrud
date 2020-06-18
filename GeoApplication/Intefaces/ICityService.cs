using Entities;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Intefaces
{
    public interface ICityService
    {
        List<CityUserModel> GetAll();
        City GetById(int CityId);
        void Insert(CityUserModel cityUserModel);
        void Update(CityUserModel cityUserModel);
        City Delete(int CityId);
        void Save();
    }
}
