using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class Service
    {
        public Service()
        {
            Authorizes = new HashSet<Authorize>();
            Logs = new HashSet<Log>();
        }

        public int Id { get; set; }
        public string AppName { get; set; }
        public string Detail { get; set; }
        public string Version { get; set; }
        public string App_Code { get; set; }
        public string Service_URL { get; set; }

        public virtual ICollection<Authorize> Authorizes { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
