using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApiAssesment.Models;
namespace WebApiAssesment.Controllers
{
    public class CountryController : ApiController
    {
        public  List<Country> list = new List<Country>();
        public  CountryController()
        {
            list.Add(new Country { Id = 1, CountryName = "Newzeland", Capital = "wellington" });
            list.Add(new Country { Id = 2, CountryName = "Australia", Capital = "Melbourne" });
            list.Add(new Country { Id = 3, CountryName = "India", Capital = "Delhi" });
        }
        [HttpGet]
        public List<Country> GetAllCountries()
        {
            return list;
        }

        [HttpPost]
        public List<Country> CreateCountry([FromBody] Country country)
        {
            list.Add(country);
            return list;
            
        }
        [HttpPut]
        public List<Country> Update(int id, [FromBody] Country up)
        {
            var country = list.FirstOrDefault(c => c.Id == id);
            if (country == null)
            {
             
            }

            country.CountryName = up.CountryName;
            country.Capital = up.Capital;
            return list;
        }
        [HttpDelete]
        public List<Country> DeleteCountry(int id)
        {
            var country = list.Find(c => c.Id  == id);
            if (country == null)
            {
                
            }
            list.Remove(country);
            return list;
        }
    }
}
