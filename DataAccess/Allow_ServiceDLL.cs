using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace DataAccess
{
    public class Allow_ServiceDLL:BaseDAL
    {
        public Authorize Allow_service(Authorize user)
        {
            try
            {
                db.Repository<Authorize>().Add(user);
                return user;
            }
            catch (Exception exp)
            {
                return user;
            }
        }
        public Authorize removeAuthorize(int Id=0)
        {
           var auth = db.Repository<Authorize>().GetAll().Where(x=>x.Id == Id).FirstOrDefault();
            if(auth != null)
            {
                db.Repository<Authorize>().Delete(auth);
            }
            
            return auth;
        }
    }
}
