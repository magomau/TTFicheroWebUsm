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
    
    public partial class Salas
    {
        public Salas()
        {
            this.Horarios = new HashSet<Horarios>();
        }
    
        public byte CodSala { get; set; }
        public string CodEdificio { get; set; }
        public Nullable<int> MaxAlumnos { get; set; }
        public Nullable<int> NumeroSala { get; set; }
    
        public virtual Edificios Edificios { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
    }
}