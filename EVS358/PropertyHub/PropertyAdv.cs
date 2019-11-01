using EVS358.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS358.PropertyHub
{
    public class PropertyAdv : IListable
    {
        public PropertyAdv()
        {
            Images = new List<PropertyImage>();
            Features = new List<PropertyAdvsFeatures>();
        }
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public float Price { get; set; }

        [Required]
        public virtual PropertyArea Area { get; set; }

        [Required]
        public virtual PropertyType PropertyType { get; set; }

        [Required]
        public virtual AdvType AdvType { get; set; }

        [Required]
        public virtual AdvStatus AdvStatus { get; set; }

        [Required]
        public virtual Neighborhood Neighborhood { get; set; }

        [Required]
        public virtual User PostedBy { get; set; }

        public virtual ICollection<PropertyImage> Images { get; set; }
        public virtual ICollection<PropertyAdvsFeatures> Features { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime StartOn { get; set; }

        

        public bool IsActive { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }



    }
}
