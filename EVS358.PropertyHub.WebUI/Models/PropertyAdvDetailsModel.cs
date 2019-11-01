using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class PropertyAdvDetailsModel : PropertyAdvModel
    {
        public PropertyAdvDetailsModel()
        {
            ImageUrls = new List<string>();
        }

        public List<string> ImageUrls { get; set; }

        public string Description { get; set; }

        //more properties
    }
}
