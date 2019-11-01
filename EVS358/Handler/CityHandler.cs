using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EVS358;
using EVS358.Handler;


namespace EVS358.Handler
{
  public  class CityHandler
    {
        public List<City> GetCitys()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities.Include(c => c.Province) select c).ToList();
            }


        }
        public City GetCityById(int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Cities.Include(c => c.Province) where c.Id == Id select c).FirstOrDefault();
            }

        }

        public void AddCity(City entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Province).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public void UpdateCity(City entity, int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                City found = context.Find<City>(Id);
                found.Name = entity.Name;
                found.Province = entity.Province;
                context.Entry(entity.Province).State = EntityState.Unchanged;
                //context.Citys.Update(entity);
                context.SaveChanges();

            }

        }
        public void DeleteCity(City entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {

                context.Remove(entity);
                context.SaveChanges();

            }

        }


    }
}
