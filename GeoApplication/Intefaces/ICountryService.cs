using Entities;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Intefaces
{
    public interface ICountryServices
    {
        List<CountryModel> GetAll();
        Country GetById(int Id);
        void Insert(CountryModel country);
        void Update(CountryModel country);
        Country Delete(int Id);
        void Save();
    }
}
