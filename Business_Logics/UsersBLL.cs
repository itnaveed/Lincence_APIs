using DataAccess;
using Database;
using ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business_Logics
{
    public class UsersBLL
    {
        public User RegisterUser(User us)
        {
            UsersDAL dal = new UsersDAL();
            return dal.RegisterUser(us);
           
        }
        public User LoginUser(string Email, string Password)
        {
            UsersDAL dal = new UsersDAL();
            return dal.LoginUser(Email, Password);

        }
        public IEnumerable<User> UsersList()
        {
            UsersDAL users = new UsersDAL();

            return users.UsersList();
        }
        public User UserVerification(string Email)
        {
            UsersDAL dal = new UsersDAL();
            return dal.UserVerification(Email);

        }
        public User getDetail(int Id=0)
        {
            UsersDAL users = new UsersDAL();

            return users.getDetail(Id);
        }
    }
}
