

using AutoMapper;
using Entities;
using GeoApplication.Intefaces;
using GeoApplication.Model;
using GeoData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeoApplication.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly GeoDBContext _geoDB;
        private readonly IMapper _mapper;

        public CountryServices(GeoDBContext geoDB,IMapper mapper)
        {
            _geoDB = geoDB;
            _mapper = mapper; 
        }

        public Country Delete(int id)
        {
            var country = _geoDB.Country.Find(id);
            _geoDB.Country.Remove(country);
            _geoDB.SaveChanges();
            return country;

        }

        public List<CountryModel> GetAll()
        {
            var countries = _geoDB.Country.AsNoTracking();
            return _mapper.Map<List<CountryModel>>(countries);


        }

        public Country GetById(int Id)
        {
            return _geoDB.Country.Where(o => o.CountryId == Id).FirstOrDefault();
            
        }

        public void Insert(CountryModel countryModel)
        {
            var country = _mapper.Map<Country>(countryModel);
            _geoDB.Country.Add(country).State = EntityState.Added;
            _geoDB.SaveChanges();

        }

        public void Save()
        {
            _geoDB.SaveChanges();
        }

        public void Update(CountryModel countryModel)
        {
            var country = _mapper.Map<Country>(countryModel);
            _geoDB.Country.Update(country);
            _geoDB.SaveChanges();

        }

        
    }
}
