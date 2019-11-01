
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Province province { get; set; }

    }
}
