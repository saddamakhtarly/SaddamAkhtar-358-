using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public static class TempDataHelper
    {
        public static void Set<T>(this ITempDataDictionary tempData,string key,AlertModel obj)
        {
            string jsonData = JsonConvert.SerializeObject(obj);
            tempData.Add(key, jsonData);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            string jsonData = Convert.ToString(tempData[key]);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }


    }
}
