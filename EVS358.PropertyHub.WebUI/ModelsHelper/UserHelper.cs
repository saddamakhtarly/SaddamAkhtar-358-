using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.UsersMgt;
using EVS358.PropertyHub.WebUI.Models;
namespace EVS358.PropertyHub.WebUI.ModelsHelper
{
    public static class UserHelper
    {
       
        public static UserModel ToUserModel( this User entity)
        {
            return new UserModel {
                Id = entity.Id,
                Name = entity.Name,
                ContactNumber = entity.ContactNumber,
                Email = entity.Email,
                ImageUrl = entity.ImageUrl,
                LoginId=entity.LoginId,
                Password=entity.Password,

                Address=entity.Address,
                BirthDate=entity.BirthDate,
                
                SecurityQuestion=entity.SecurityQuestion,
                SecurityAnswer=entity.SecurityAnswer
                ,Role=entity.Role
            };
        }        
        public static User ToUserEntity(this UserModel obj)
        {
            return new User {
                Id=obj.Id,
                Name =obj.Name,
                ContactNumber =obj.ContactNumber,
                Email =obj.Email,
                ImageUrl =obj.ImageUrl,
                LoginId=obj.LoginId,
                Password=obj.Password,
                Address=obj.Address,
                BirthDate=obj.BirthDate,
                IsActive=true,
                SecurityQuestion=obj.SecurityQuestion,
                SecurityAnswer=obj.SecurityAnswer,
                Role=obj.Role
                
            };
        }        
        public static List<UserModel> ToUserList(this List<User> entitylist)
        {
            List<UserModel> obj = new List<UserModel>();
            foreach (var item in entitylist)
            {
                obj.Add(item.ToUserModel());
            }
            return obj;
        }

















    }
}
