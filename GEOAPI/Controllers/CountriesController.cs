using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using FluentValidation;
using GeoApplication.Intefaces;
using GeoApplication.Model;
using GeoApplication.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryServices _services;
       


        public CountriesController(ICountryServices services)
        {
            _services = services;
        }

        
        [HttpGet("GetAll")]
        public List<CountryModel> GetAll()
        {
            return _services.GetAll();
        }

        [HttpDelete("Delete")]
        public Country Delete(int id)
        {
            var country=_services.Delete(id);
            return country;
        }
        [HttpPost("Insert")]
        public CountryModel Insert(CountryModel countryModel)
        {
            _services.Insert(countryModel);
            return countryModel;
        }
        [HttpPost("Update")]
        public CountryModel Update(CountryModel countryModel)
        {
            _services.Update(countryModel);
            return countryModel;
        }

        [HttpGet("GetById")]
        public Country GetById(int id)
        {
            Country x= _services.GetById(id);
            return x;
        }
    }
}