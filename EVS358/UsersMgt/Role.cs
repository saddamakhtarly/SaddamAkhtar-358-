using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVS358.UsersMgt
{
    public class Role : IListable
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [Required]         
        [Column(TypeName = "varchar(50)")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
