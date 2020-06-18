using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using GeoApplication.Intefaces;
using GeoApplication.Model;
using GeoApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet("GetAll")]
        public List<CityUserModel> GetAll()
        {
            return _cityService.GetAll();
        }

        [HttpPost("Delete")]
        public City Delete(int CityId)
        {
            var cities=_cityService.Delete(CityId);
            return cities;
        } 

        [HttpPost("Insert")]
        public CityUserModel Insert(CityUserModel cityUserModel)
        {
            _cityService.Insert(cityUserModel);
            return cityUserModel;
        }

        [HttpPost("Update")]
        public CityUserModel Update(CityUserModel cityUserModel)
        {
            _cityService.Update(cityUserModel);
            return cityUserModel;
        }
        [HttpGet("GetById")]
        public City GetById(int CityId)
        {
            var city = _cityService.GetById(CityId);
            return city;
        }
    }
}