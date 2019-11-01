using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.PropertyHub.WebUI.Models;


namespace EVS358.PropertyHub.WebUI.ModelsHelper
{
    public static class CountryHelper
    {
        public static CountryModel  ToCountryModel(this Country entity)
        {
            return new CountryModel { Id = entity.Id, Name = entity.Name, Code = entity.Code };
        }

        public static Country ToCountryEntity(this CountryModel obj)
        {
            return new Country { Id = obj.Id, Name = obj.Name, Code = obj.Code };
        }

        public static List<CountryModel> ToCountryList(this List<Country> entitylist)
        {
            List<CountryModel> obj = new List<CountryModel>();
            foreach (var item in entitylist)
            {
                obj.Add(item.ToCountryModel());
            }

            return obj;
        }
    }
}
