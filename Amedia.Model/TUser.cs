using System;
using System.Collections.Generic;

#nullable disable

namespace Amedia.Model
{
    public partial class tUser
    {
       

        public int cod_usuario { get; set; }
        public string txt_user { get; set; }
        public string txt_password { get; set; }
        public string txt_nombre { get; set; }
        public string txt_apellido { get; set; }
        public string nro_doc { get; set; }
        public int cod_rol { get; set; }
        public int sn_activo { get; set; }

        public virtual TRol CodRolNavigation { get; set; }
        public virtual ICollection<TAlquiler> TAlquilers { get; set; }
        public virtual ICollection<TVenta> TVenta { get; set; }
    }
}
