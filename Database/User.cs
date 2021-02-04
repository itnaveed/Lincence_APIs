using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class User
    {
        public User()
        {
            Authorizes = new HashSet<Authorize>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Cnic { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Authorize> Authorizes { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
