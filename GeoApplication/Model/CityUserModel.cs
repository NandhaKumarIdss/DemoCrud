using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Model
{
    public class CityUserModel
    {
        public int CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
    public class CityReadModel
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }

    }
}
