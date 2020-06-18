using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
      
        public virtual ICollection<City> Cities { get; set; }
    }
}

