
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public static class ModelsHelper
    {

        public static List<SelectListItem> ToSelectListItemList(this IEnumerable<IListable> entitiesList)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var entity in entitiesList)
            {
                items.Add(new SelectListItem { Text=entity.Name, Value=Convert.ToString(entity.Id) });
            }
            items.TrimExcess();
            return items;
        }

        public static SchemeModel ToSchemeModel(this Neighborhood entity)
        {
            return new SchemeModel { Id = entity.Id, Name = entity.Name, City = entity.City };
        }

        public static Neighborhood ToEntity(this SchemeModel model)
        {
            return new Neighborhood { Id = model.Id, Name = model.Name, City=model.City };
        }

        public static List<SchemeModel> ToSchemeModelList(this List<Neighborhood> entitiesList)
        {
            List<SchemeModel> modelsList = new List<SchemeModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToSchemeModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }
        public static PropertyType ToPropertyTypeEntity(this PropertyTypesModel model)
        {
            return new PropertyType { Id = model.Id, Name = model.Name};
        }
        public static PropertyTypesModel ToPropertyTypesModel( this PropertyType obj)
        {
            return new PropertyTypesModel { Id=obj.Id,Name=obj.Name };

        }
        public static List<PropertyTypesModel> ToPropertyTypesList(this List<PropertyType> entity) {

            List<PropertyTypesModel> model = new List<PropertyTypesModel>();
            foreach (var item in entity)
            {
                model.Add(item.ToPropertyTypesModel());
            }
            return model;


        }

    }
}
