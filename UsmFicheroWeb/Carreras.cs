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
    
    public partial class Carreras
    {
        public Carreras()
        {
            this.Noticias = new HashSet<Noticias>();
            this.UsuarioCarrera = new HashSet<UsuarioCarrera>();
        }
    
        public byte IdCarrera { get; set; }
        public string RutJefeCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public Nullable<byte> IdDepartamento { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<UsuarioCarrera> UsuarioCarrera { get; set; }
    }
}