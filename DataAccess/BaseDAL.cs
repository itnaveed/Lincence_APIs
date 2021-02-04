using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BaseDAL
    {
        public DbContext db = new DbContext();

        public BaseDAL()
        {
           
        }
    }
}
