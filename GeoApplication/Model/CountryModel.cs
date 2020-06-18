using System;
using System.Collections.Generic;
using System.Text;

namespace GeoApplication.Model
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }

    public class CountryReadModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
