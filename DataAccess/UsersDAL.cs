using Database;
using ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class UsersDAL:BaseDAL
    {
        public User RegisterUser(User user)
        {
            try
            {
                User us = UserVerification(user.Email);
                if (us==null)
                {
                    db.Repository<User>().Add(user);
                    return user;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception exp)
            {
                return user;
            }
        }
        public User LoginUser(string Email, string Password)
        {
           
            User user = db.Repository<User>().GetAll().Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();

            return user;
        }
        public IEnumerable<User> UsersList()
        {
            return db.Repository<User>().GetAll().ToList();
        }
        public User UserVerification(string Email)
        {
           
            User user = db.Repository<User>().GetAll().Where(u => u.Email == Email).FirstOrDefault();

            return user;
        }
    }
}
