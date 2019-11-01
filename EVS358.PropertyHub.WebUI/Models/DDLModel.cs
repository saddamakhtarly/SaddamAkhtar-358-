using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class DDLModel
    {
        public string Name { get; set; }

        public string PropertyToBind { get; set; }

        public string GlyphIcon { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
