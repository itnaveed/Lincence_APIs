using Database;
using Repositories.DataRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ManagmentSystem.Repositories.DBRepository
{
    public class UsersRepository : DataRepository<User>
    {
        Licence_APIsContext _context;

        public UsersRepository(Licence_APIsContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<User>();
            dbSet = _context.Set<User>();

        }
        public User LoginUser(string Email, string Password)
        {
            var User = (from u in _context.Users
                        where u.Email == Email && u.Password == Password
                        select u).FirstOrDefault<User>();

            return User;
        }
        public User RegisterUser(User us)
        {
            _context.Users.Add(us);
            _context.SaveChanges();
            var User = _context.Users.Last<User>();
            return User;
        }
    }
}
