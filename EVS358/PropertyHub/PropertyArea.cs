using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS358.PropertyHub
{
    public class PropertyArea
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int PropertyAdvId { get; set; }
        public virtual AreaUnit Unit { get; set; }
    }
}
