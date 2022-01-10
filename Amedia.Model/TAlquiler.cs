using System;
using System.Collections.Generic;

#nullable disable

namespace Amedia.Model
{
    public partial class TAlquiler
    {
        public int IdAlquiler { get; set; }
        public int CodPelicula { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public int CodUsuario { get; set; }
        public int? Devolucion { get; set; }

        public virtual TPelicula CodPeliculaNavigation { get; set; }
        public virtual tUser CodUsuarioNavigation { get; set; }
    }
}
