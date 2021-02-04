using System;
using System.Collections.Generic;
using System.Text;
using ManagmentSystem.Repositories;
using Repositories.DataRepository;

namespace DataAccess
{
    interface IDBContext: IDisposable
    {
        T ExtRepositoryFor<T>() where T : class;
        void Dispose();
        void Save();
        void Dispose(bool disposing);

        //PHC.Inspection.DataAccess.PHC_Inspection_DBEntities GetContext();
        DataRepository<T> Repository<T>() where T : class;

    }
}
