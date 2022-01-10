using System;
using System.Collections.Generic;

#nullable disable

namespace Amedia.Model
{
    public partial class TVenta
    {
        public int IdVenta { get; set; }
        public int CodPelicula { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public int CodUsuario { get; set; }

        public virtual TPelicula CodPeliculaNavigation { get; set; }
        public virtual tUser CodUsuarioNavigation { get; set; }
    }
}
