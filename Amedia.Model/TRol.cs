using System;
using System.Collections.Generic;

#nullable disable

namespace Amedia.Model
{
    public partial class TRol
    {
        public TRol()
        {
            tUsers = new HashSet<tUser>();
        }

        public int CodRol { get; set; }
        public string TxtDesc { get; set; }
        public int? SnActivo { get; set; }

        public virtual ICollection<tUser> tUsers { get; set; }
    }
}
