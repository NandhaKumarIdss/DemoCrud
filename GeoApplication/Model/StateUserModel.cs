using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Model
{
    public class StateUserModel
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
       
    }

    public class StateReadModel
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}
