using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EVS358;
using System.Linq;


namespace EVS358.Handler
{
   public class ProvinceHandler
    {
        public List<Province> GetProvinces()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Provinces.Include(c=>c.Country) select c).ToList();
            }


        }
        public Province GetProvinceById(int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from c in context.Provinces.Include(c=>c.Country) where c.Id == Id select c).FirstOrDefault();
            }

        }

        public void AddProvince(Province entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Country).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public void UpdateProvince(Province entity, int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Province found = context.Find<Province>(Id);
                found.Name = entity.Name;
                found.Country = entity.Country;
                context.Entry(entity.Country).State = EntityState.Unchanged;
                //context.Provinces.Update(entity);
                context.SaveChanges();

            }

        }
        public void DeleteProvince(Province entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {

                context.Remove(entity);
                context.SaveChanges();

            }

        }
    }
}
