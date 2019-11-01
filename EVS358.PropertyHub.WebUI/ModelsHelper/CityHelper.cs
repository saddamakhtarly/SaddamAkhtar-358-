using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.PropertyHub.WebUI.Models;

namespace EVS358.PropertyHub.WebUI.ModelsHelper
{
    public static class CityHelper
    {
        public static CityModel ToCityModel(this City entity)
        {
            return new CityModel { Id = entity.Id, Name = entity.Name, province = entity.Province };
        }

        public static City ToCityEntity(this CityModel obj)
        {
            return new City { Id = obj.Id, Name = obj.Name, Province = obj.province };
        }

        public static List<CityModel> ToCityList(this List<City> entitylist)
        {
            List<CityModel> obj = new List<CityModel>();
            foreach (var item in entitylist)
            {
                obj.Add(item.ToCityModel());
            }

            return obj;
        }
    }
}
