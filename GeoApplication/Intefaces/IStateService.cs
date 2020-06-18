using Entities;
using GeoApplication.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Intefaces
{
    public interface IStateService
    {
        List<StateUserModel> GetAll();
        StateUserModel GetById(int StateId);
        void Insert(StateUserModel stateUserModel);
        void Update(StateUserModel stateUserModel);
        void Delete(int StateId);
        void Save();
    }
}
