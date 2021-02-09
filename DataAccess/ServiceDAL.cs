using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using ViewModels;

namespace DataAccess
{
    public class ServiceDAL:BaseDAL
    {
        public Service AddService(Service service)
        {
            try
            {
                if (service.Id > 0)
                {
                    db.Repository<Service>().Update(service);

                }
                else
                {
                    db.Repository<Service>().Add(service);
                }
                
                return service;
            }
            catch (Exception exp)
            {
                return service;
            }
        }
        public IEnumerable<AllowedServicesVM> Allowed_service(int id)
        {
            string query = "exec sp_Allowed_services " + id;
            //var AllStudent = db.Repository<AdminRegistrationViewModel>().Helper.ExecuteQuery(query).ToList();
            return db.Repository<AllowedServicesVM>().RawQuery(query).ToList();
        }
        public IEnumerable<UserServicesVM> UserServices(int id)
        {
            string query = "exec sp_user_services " + id;
            //var AllStudent = db.Repository<AdminRegistrationViewModel>().Helper.ExecuteQuery(query).ToList();
            return db.Repository<UserServicesVM>().userServices(query).ToList();
        }
        public IEnumerable<Service> notAssignServices(int id)
        {
            string query = "exec sp_notassign_service " + id;
            //var AllStudent = db.Repository<AdminRegistrationViewModel>().Helper.ExecuteQuery(query).ToList();
            return db.Repository<Service>().customQuery(query).ToList();
        }
        public IEnumerable<Service> ServicesList()
        {
            return db.Repository<Service>().GetAll().ToList();
        }

    }
}
