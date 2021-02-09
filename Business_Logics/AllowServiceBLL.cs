using System;
using System.Collections.Generic;
using System.Text;
using Database;
using DataAccess;

namespace Business_Logics
{
    public class AllowServiceBLL
    {
        public Authorize Authorize(Authorize us)
        {
            Allow_ServiceDLL dal = new Allow_ServiceDLL();
            return dal.Allow_service(us);
        }
        public Authorize removeAuth(int Id=0)
        {
            Allow_ServiceDLL dal = new Allow_ServiceDLL();
            return dal.removeAuthorize(Id);

        }
    }
}
