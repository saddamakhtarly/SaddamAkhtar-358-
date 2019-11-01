using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EVS358
{
    public class LocationsHandler
    {
        public List<City> GetCities()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities.Include(c => c.Province.Country) select c).ToList();
            }
        }

        public List<City> GetCities(Country country)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                             .Include(c => c.Province.Country)
                        where country.Id == c.Province.Country.Id
                        select c).ToList();
            }
        }

        public List<City> GetCities(Province province)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities
                             .Include(c => c.Province.Country)
                        where province.Id == c.Province.Id
                        select c).ToList();
            }
        }
    }
}
