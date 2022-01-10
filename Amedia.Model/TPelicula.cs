using System;
using System.Collections.Generic;

#nullable disable

namespace Amedia.Model
{
    public partial class TPelicula
    {
        public TPelicula()
        {
            TAlquilers = new HashSet<TAlquiler>();
            TGeneroPeliculas = new HashSet<TGeneroPelicula>();
            TVenta = new HashSet<TVenta>();
        }

        public int CodPelicula { get; set; }
        public string TxtDesc { get; set; }
        public int? CantDisponiblesAlquiler { get; set; }
        public int? CantDisponiblesVenta { get; set; }
        public decimal? PrecioAlquiler { get; set; }
        public decimal? PrecioVenta { get; set; }

        public virtual ICollection<TAlquiler> TAlquilers { get; set; }
        public virtual ICollection<TGeneroPelicula> TGeneroPeliculas { get; set; }
        public virtual ICollection<TVenta> TVenta { get; set; }
    }
}
