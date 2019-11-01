using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EVS358;
using EVS358.UsersMgt;
using EVS358.Handler;


namespace EVS358.Handler
{
   public class UserHandler
    {
        public List<User> GetUsers()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users select u).ToList();
            }
        }
        public List<Role> GetRole()
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Roles select u).ToList();
            }
        }

        public User GetUser(int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                return (from u in context.Users
                        .Include(u=>u.Address.City.Province.Country)
                        .Include(u => u.Address.City.Province)
                        .Include(u => u.Address.City)
                        .Include(u => u.Role)

                        where u.Id == Id select u).FirstOrDefault();
            }
        }
        public User AddUser(User entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Entry(entity.Address.City).State = EntityState.Unchanged;
                context.Entry(entity.Address.City.Province).State = EntityState.Unchanged;
                context.Entry(entity.Address.City.Province.Country).State = EntityState.Unchanged;
                context.Entry(entity.Role).State = EntityState.Unchanged;
                context.Users.Add(entity);
                

                context.SaveChanges();
            }
            return entity;
        }
        public User UpdateUser(User entity, int Id)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                //City found = context.Find<City>(Id);
                User found = context.Find<User>(Id);
                found.Name = entity.Name;
                found.ContactNumber = entity.ContactNumber;
                found.Email = entity.Email;
                
                context.Entry(found.Id).State = EntityState.Unchanged;
                context.Entry(found.Role).State = EntityState.Unchanged;                
                context.Users.Update(found);
                context.SaveChanges();
            }
            return entity;
        }
        public User DeleteUser(User entity)
        {
            using (PropertyHubContext context = new PropertyHubContext())
            {
                context.Users.Remove(entity);
                context.SaveChanges();
            }
            return entity;
        }






















    }
}
