using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using GeoApplication.Intefaces;
using GeoApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("GetAll")]
        public List<StateUserModel> GetAll()
        {
            return _stateService.GetAll();
        }

        [HttpDelete("Delete")]
        public void Delete(int StateId)
        {
            _stateService.Delete(StateId);
            
            
        }
        [HttpPost("Insert")]
        public StateUserModel Insert([FromBody] StateUserModel stateUserModel)
        {
            _stateService.Insert(stateUserModel);
            return stateUserModel;
        }
        [HttpPost("Edit")]
        public StateUserModel Edit(StateUserModel stateUserModel)
        {
            _stateService.Update(stateUserModel);
            return stateUserModel;
        }
        [HttpGet("GetById")]
        public StateUserModel GetById(int StateId)
        {
            return _stateService.GetById(StateId);
            
        }

    }
}