using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EVS358.PropertyHub
{
    public class PropertyAdvsFeatures
    {
        public int Id { get; set; }

        [Required]
        public virtual PropertyAdv Advertisement { get; set; }

        [Required]
        public virtual PropertyFeature Feature { get; set; }
    }
}
