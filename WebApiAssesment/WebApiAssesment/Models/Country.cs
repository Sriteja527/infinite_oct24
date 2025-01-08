using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssesment.Models
{
    public class Country
    {
        internal int id;

        public int Id { get; set; }
        public String CountryName { get; set; }
        public String Capital { get; set; }
    }
}