using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.PropertyHub.WebUI.Models;

namespace EVS358.PropertyHub.WebUI.ModelsHelper
{
    public static class ProvinceHelper
    {
        public static ProvinceModel ToProvinceModel(this Province entity)
        {
            return new ProvinceModel { Id = entity.Id, Name = entity.Name, country = entity.Country };
        }

        public static Province ToProvinceEntity(this ProvinceModel obj)
        {
            return new Province { Id = obj.Id, Name = obj.Name, Country = obj.country };
        }

        public static List<ProvinceModel> ToProvinceList(this List<Province> entitylist)
        {
            List<ProvinceModel> obj = new List<ProvinceModel>();
            foreach (var item in entitylist)
            {
                obj.Add(item.ToProvinceModel());
            }

            return obj;
        }
    }
}
