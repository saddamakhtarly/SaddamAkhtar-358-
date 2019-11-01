using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EVS358;
using System.Linq;

namespace EVS358.Handler
{
 public   class CountryHandler
    {
        public List<Country> GetCountries()
        {
            using (PropertyHubContext context= new PropertyHubContext())
            {
                return (from c in context.Countries select c).ToList();
            }
           

        }
        public Country GetCountryById(int Id)
        {
            using (PropertyHubContext context= new PropertyHubContext())
            {
                return (from c in context.Countries where c.Id == Id select c).FirstOrDefault();
            }

        }

        public void AddCountry(Country entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Countries.Add(entity);
                context.SaveChanges();
            }

        }

        public void UpdateCountry(Country entity,int Id)
        {
            using(PropertyHubContext context = new PropertyHubContext())
            {
                context.Countries.Update(entity);
                context.SaveChanges();

            }

        }
        public void DeleteCountry(Country entity, int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Remove(entity);
                context.SaveChanges();

            }

        }


    }
}
