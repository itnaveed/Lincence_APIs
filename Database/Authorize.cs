using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class Authorize
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? UserId { get; set; }

        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
