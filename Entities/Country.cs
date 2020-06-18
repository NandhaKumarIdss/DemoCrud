using System;
using System.Collections.Generic;

namespace Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        
        public ICollection<State> States { get; set; }
        
       
    }
}
