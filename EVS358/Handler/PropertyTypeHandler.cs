using EVS358;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EVS358.PropertyHub;

namespace EVS358.Handler
{
   public class PropertyTypeHandler
    {
        public List<PropertyType> GetPropertyTypes()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from pt in context.PropertyTypes select pt).ToList();                   
            }
        }
        public PropertyType GetPropertyType(int Id)
        {
            using (PropertyHubContext context= new PropertyHubContext())
            {
                return (from pt in context.PropertyTypes where pt.Id == Id select pt).FirstOrDefault();
            }
        }
        public PropertyType AddPropertyTypr( PropertyType entity) {
            using (PropertyHubContext context= new PropertyHubContext())
            {
                context.PropertyTypes.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }

        public PropertyType UpdatePropertyTypr(PropertyType entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.PropertyTypes.Update(entity);
                context.SaveChanges();
            }
            return entity;
        }

        public PropertyType DeletePropertyTypr(PropertyType entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.PropertyTypes.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }
    }
}
