//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsmFicheroWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Edificios
    {
        public Edificios()
        {
            this.Salas = new HashSet<Salas>();
        }
    
        public string CodEdificios { get; set; }
        public Nullable<int> CantidadSalas { get; set; }
        public Nullable<int> NumerosBaños { get; set; }
        public Nullable<int> Oficinas { get; set; }
    
        public virtual ICollection<Salas> Salas { get; set; }
    }
}
