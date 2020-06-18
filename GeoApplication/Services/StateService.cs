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
    public class StateService: IStateService
    {
        private readonly GeoDBContext  _geoDBContext;
        private readonly IMapper _mapper;

        public StateService(GeoDBContext geoDBContext,IMapper mapper)
        {
            _geoDBContext = geoDBContext;
            _mapper = mapper;
        }

        
        public void Delete(int StateId)
        {
            var state = _geoDBContext.State.Find(StateId);
            _geoDBContext.Remove(state);
            _geoDBContext.SaveChanges();
            

        }
        
        public List<StateUserModel> GetAll()
        {
            var states = _geoDBContext.State.AsNoTracking();
            return _mapper.Map<List<StateUserModel>>(states);
        }
        
        public StateUserModel GetById(int StateId)
        {
             return _mapper.Map<StateUserModel>(_geoDBContext.State.FirstOrDefault(n => n.StateId == StateId));
        }

        public void Insert(StateUserModel stateUserModel)
        {
            var statess = _mapper.Map<State>(stateUserModel);
            _geoDBContext.Entry<State>(statess).State = EntityState.Added;
            _geoDBContext.SaveChanges();
        }

        public void Save()
        {
            _geoDBContext.SaveChanges();
        }

        public void Update(StateUserModel stateUserModel)
        {
            var update = _mapper.Map<State>(stateUserModel);
            _geoDBContext.State.Update(update);
            _geoDBContext.SaveChanges();
        }
    }
}
