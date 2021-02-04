using System;
using System.Collections.Generic;
using System.Text;
using Database;
using DataAccess;
using ViewModels;

namespace Business_Logics
{
    public class ServiceBLL
    {

        public Service AddService(Service service)
        {
            ServiceDAL ser = new ServiceDAL();
            return ser.AddService(service);

        }
        public IEnumerable<AllowedServicesVM> UserServices(int id)
        {
            ServiceDAL ser = new ServiceDAL();
            var serviceURL = ser.Allowed_service(id);
            return serviceURL;

        }

        public IEnumerable<Service> ServicesList()
        {
            ServiceDAL service = new ServiceDAL();

            return service.ServicesList();
        }
         public IEnumerable<UserServicesVM> userServices(int ID=0)
        {
            ServiceDAL service = new ServiceDAL();

            return service.UserServices(ID);
        }

        public IEnumerable<Service> notAssignServices(int ID = 0)
        {
            ServiceDAL service = new ServiceDAL();

            return service.notAssignServices(ID);
        }
    }
}
