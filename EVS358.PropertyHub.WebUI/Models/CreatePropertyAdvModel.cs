using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class CreatePropertyAdvModel : PropertyAdvModel
    {
        

        public string Description { get; set; }
        public DateTime StartDate { get; set; }


        public int CityId { get; set; }

        public int SchemeId { get; set; }

        public int BlockId { get; set; }
        public int AreaUnitId { get; set; }

        public int PropertyTypeId { get; set; }

        

        public int AdvType { get; set; }

        
    }
}
