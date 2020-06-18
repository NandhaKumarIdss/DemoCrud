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
    public class CityService : ICityService
    {
        public readonly GeoDBContext _context;
        public readonly IMapper _mapper;

        public CityService(GeoDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public City Delete(int CityId)
        {
            var city = _context.City.Find(CityId);
            _context.City.Remove(city);
            _context.SaveChanges();
            return city;

        }

        public List<CityUserModel> GetAll()
        {
            var cities = _context.City.AsNoTracking();
            return _mapper.Map<List<CityUserModel>>(cities);
        }

        public City GetById(int CityId)
        {
            return _context.City.Where(m => m.CityId == CityId).FirstOrDefault();
        }

        public void Insert(CityUserModel cityUserModel)
        {
            var citiess = _mapper.Map<City>(cityUserModel);
            _context.Entry<City>(citiess).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(CityUserModel cityUserModel)
        {
            var city = _mapper.Map<City>(cityUserModel);
            _context.City.Update(city);
            _context.SaveChanges();
        }
    }
}
