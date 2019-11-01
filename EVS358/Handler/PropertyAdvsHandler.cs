using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EVS358.PropertyHub;

namespace EVS358.Handler
{
    public class PropertyAdvsHandler
    {


        #region Property Advs

        public List<PropertyAdv> GetPropertyAdvs()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from pa in context.PropertyAdvs
                                                .Include(pa => pa.AdvStatus)
                                                .Include(pa => pa.AdvType)
                                                .Include(pa => pa.Area.Unit)
                                                .Include(pa => pa.Neighborhood.Parent)
                                                .Include(pa => pa.Neighborhood.City)
                                                .Include(pa => pa.Images)
                                                .Include(pa => pa.PostedBy)
                                                .Include(pa => pa.PropertyType)
                        select pa).ToList();
            }
        }

        public PropertyAdv GetPropertyAdv(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from pa in context.PropertyAdvs
                                                .Include(pa => pa.AdvStatus)
                                                .Include(pa => pa.AdvType)
                                                .Include(pa => pa.Area.Unit)
                                                .Include(pa => pa.Neighborhood.Parent)
                                                .Include(pa => pa.Neighborhood.City)
                                                .Include(pa => pa.Images)
                                                .Include(pa => pa.PostedBy)
                                                .Include(pa => pa.PropertyType)
                        where pa.Id == id
                        select pa).FirstOrDefault();
            }
        }

        public PropertyAdv AddPropertyAdv(PropertyAdv entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.AdvStatus).State = EntityState.Unchanged;
                context.Entry(entity.AdvType).State = EntityState.Unchanged;
                context.Entry(entity.Neighborhood).State = EntityState.Unchanged;
                context.Entry(entity.PostedBy).State = EntityState.Unchanged;
                context.Entry(entity.PropertyType).State = EntityState.Unchanged;
                context.Entry(entity.Area.Unit).State = EntityState.Unchanged;
                
                foreach (var f in entity.Features)
                {
                    context.Entry(f.Feature).State = EntityState.Unchanged;
                }
                context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }


        public PropertyAdv UpdatePropertyAdv(PropertyAdv entity,int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {

                PropertyAdv found = (from adv in context.PropertyAdvs where adv.Id == Id select adv).First();
                if (!(string.IsNullOrWhiteSpace(entity.Name)))
                {
                    found.Id = entity.Id;
                    found.Name = entity.Name;
                    found.Price = entity.Price;
                    //found.CityId = entity.Neighborhood.City.Id;
                    //found.AreaUnitId = entity.Area.Unit.Id;
                    //found.AdvType = entity.AdvType.Id;
                    //found.PropertyTypeId = entity.PropertyType.Id;
                    //found.BlockId = entity.Neighborhood.Id;
                    //found.SchemeId = entity.Neighborhood.Parent.Id;
                    //found.StartDate = entity.StartOn;
                    //found.Area = entity.Area;
                    found.Beds = entity.Beds;
                    found.Baths = entity.Baths;
                    
                   
                }

                foreach (var item in entity.Images)
                {
                    found.Images.Add(item);
                }
                

                context.Entry(entity.AdvStatus).State = EntityState.Unchanged;
                context.Entry(entity.AdvType).State = EntityState.Unchanged;
                context.Entry(entity.Neighborhood).State = EntityState.Unchanged;
                context.Entry(entity.PostedBy).State = EntityState.Unchanged;
                context.Entry(entity.PropertyType).State = EntityState.Unchanged;
                context.Entry(entity.Area.Unit).State = EntityState.Unchanged;
               // context.Entry(entity.Images).State = EntityState.Unchanged;
                
                foreach (var f in entity.Features)
                {
                    context.Entry(f.Feature).State = EntityState.Unchanged;
                }
                //context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }


        public PropertyAdv DeletePropertyAdv(PropertyAdv entity, int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {

                //PropertyAdv found = (from adv in context.PropertyAdvs where adv.Id == Id select adv).First();
                //if (!(string.IsNullOrWhiteSpace(entity.Name)))
                //{
                //    found.Id = entity.Id;
                //    found.Name = entity.Name;
                //    found.Price = entity.Price;
                //    //found.CityId = entity.Neighborhood.City.Id;
                //    //found.AreaUnitId = entity.Area.Unit.Id;
                //    //found.AdvType = entity.AdvType.Id;
                //    //found.PropertyTypeId = entity.PropertyType.Id;
                //    //found.BlockId = entity.Neighborhood.Id;
                //    //found.SchemeId = entity.Neighborhood.Parent.Id;
                //    //found.StartDate = entity.StartOn;
                //    //found.Area = entity.Area;
                //    found.Beds = entity.Beds;
                //    found.Baths = entity.Baths;

                //}

                context.Entry(entity.AdvStatus).State = EntityState.Unchanged;
                context.Entry(entity.AdvType).State = EntityState.Unchanged;
                context.Entry(entity.Neighborhood).State = EntityState.Unchanged;
                context.Entry(entity.PostedBy).State = EntityState.Unchanged;
                context.Entry(entity.PropertyType).State = EntityState.Unchanged;
                context.Entry(entity.Area.Unit).State = EntityState.Unchanged;
                foreach (var f in entity.Features)
                {
                    context.Entry(f.Feature).State = EntityState.Unchanged;
                }

                context.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }


        #endregion

        //#region Property Adv Types
        //public List<PropertyType> GetPropertyTypes()
        //{
        //    using (PropertyHubContext context = new PropertyHubContext())
        //    {
        //        return (from t in context.PropertyTypes
        //                select t).ToList();
        //    }
        //}

        //public PropertyType GetPropertyType(int id)
        //{
        //    using (PropertyHubContext context = new PropertyHubContext())
        //    {
        //        return (from pa in context.PropertyTypes
        //                where pa.Id == id
        //                select pa).FirstOrDefault();
        //    }
        //}

        //public PropertyType AddPropertyType(PropertyType type)
        //{
        //    using (PropertyHubContext context = new PropertyHubContext())
        //    {
        //        context.Add(type);
        //        context.SaveChanges();
        //        return type;
        //    }
        //}

        //public PropertyType UpdatePropertyType(int idToSearch, PropertyType type)
        //{
        //    using (PropertyHubContext context = new PropertyHubContext())
        //    {
        //        PropertyType found = (from t in context.PropertyTypes
        //                              where t.Id == idToSearch
        //                              select t).First();
        //        if (!(string.IsNullOrWhiteSpace(type.Name)))
        //        {
        //            found.Name = type.Name;
        //            context.SaveChanges();
        //        }
        //        return found;
        //    }
        //}


        //public PropertyType DeletePropertyType(int idToSearch)
        //{
        //    using (PropertyHubContext context = new PropertyHubContext())
        //    {
        //        PropertyType found = (from t in context.PropertyTypes
        //                              where t.Id == idToSearch
        //                              select t).First();
        //        context.Remove(found);
        //        context.SaveChanges();
        //        return found;
        //    }
        //}






        //#endregion

        #region Area Units
        public List<AreaUnit> GetAreaUnits()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from au in context.AreaUnits
                        select au).ToList();
            }
        }
        #endregion


        #region Adv Types
        public List<AdvType> GetAdvTypes()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from at in context.AdvTypes
                        select at).ToList();
            }
        }


        #endregion

        #region Features
        public List<PropertyFeature> GetFeatures()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from f in context.PropertyFeatures
                        select f).ToList();
            }
        }
        #endregion

        #region Neighborhood
        //top level - All
        public List<Neighborhood> GetNeighborhoods()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from n in context.Neighborhoods
                                           .Include(n => n.City)
                                           .Include(n => n.Parent)
                        where n.Parent == null
                        select n).ToList();
            }
        }
        //Top Level - By city
        public List<Neighborhood> GetNeighborhoods(City city)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from n in context.Neighborhoods
                                           .Include(n => n.City)
                                           .Include(n => n.Parent)
                        where n.Parent == null && n.City.Id == city.Id
                        select n).ToList();
            }
        }

        //Child Level - By parent
        public List<Neighborhood> GetNeighborhoods(Neighborhood parent)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from n in context.Neighborhoods
                                           .Include(n => n.City)
                                           .Include(n => n.Parent)
                        where n.Parent.Id == parent.Id
                        select n).ToList();
            }
        }


        public Neighborhood GetNeighborhood(int id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from n in context.Neighborhoods
                                           .Include(n => n.City)
                                           .Include(n => n.Parent)
                        where n.Id == id
                        select n).FirstOrDefault();
            }
        }
        public Neighborhood AddNeighborhood(Neighborhood entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.City).State = EntityState.Unchanged;
                context.Add(entity);
                context.SaveChanges();
            }
            return entity;
        }

        public Neighborhood UpdateNeighborhood(int idToSearch, Neighborhood entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                Neighborhood found = context.Find<Neighborhood>(idToSearch);
                found.Name = entity.Name;
                found.City = entity.City;
                context.Entry(entity.City).State = EntityState.Unchanged;

                if (entity.Parent != null)
                {
                    found.Parent = entity.Parent;
                    context.Entry(entity.Parent).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
            return entity;
        }

        public Neighborhood DeleteNeighborhood(int idToSearch)
        {
            Neighborhood found = null;
            using (PropertyHubContext context = new PropertyHubContext())
            {
                found = context.Find<Neighborhood>(idToSearch);
                context.Remove(found);
                context.SaveChanges();
            }
            return found;
        }
        #endregion




    }
}
