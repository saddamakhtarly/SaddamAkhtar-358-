using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public abstract class PropertyAdvModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public float Price { get; set; }

        public string Location { get; set; }

        public int Area { get; set; }
        public int Beds { get; set; }

        public int Baths { get; set; }

        public string Type { get; set; }

        public string AdvAge { get; set; }
        public string MainImageUrl { get; set; }
        public string AlternateImageUrl { get; set; }
        public string AltImgName { get; set; }
        public PropertyAdvsFeatures propertyAdvsFeatures { get; set; }
    }
}
