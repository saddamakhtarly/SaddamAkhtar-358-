using EVS358.UsersMgt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVS358.PropertyHub.WebUI.Models
{
    public class UserModel
    {        
        public int Id { get; set; }

        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }   
        
        public DateTime? BirthDate { get; set; }
        
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public Role Role { get; set; }
    }
}
