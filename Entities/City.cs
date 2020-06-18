using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }


    }
}
