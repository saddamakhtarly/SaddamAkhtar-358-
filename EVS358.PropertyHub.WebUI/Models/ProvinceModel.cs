using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Country country { get; set; }
    }
}
