using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
    public class Usuarios
    {

        public Usuarios()
        {
            this.Horarios = new HashSet<Horarios>();
            this.Noticias = new HashSet<Noticias>();
            this.UsuarioAsignatura = new HashSet<UsuarioAsignatura>();
            this.UsuarioCarrera = new HashSet<UsuarioCarrera>();
        }
        [Key]
        public int Rut { get; set; }
        public string Dv { get; set; }
        public Nullable<byte> TipoUser { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Fono { get; set; }
        public string Contraseña { get; set; }
        public Nullable<byte> IdCarrera { get; set; }
        public Nullable<byte> IdNoticias { get; set; }

        public virtual ICollection<Horarios> Horarios { get; set; }
        public virtual ICollection<Noticias> Noticias { get; set; }
        public virtual ICollection<UsuarioAsignatura> UsuarioAsignatura { get; set; }
        public virtual ICollection<UsuarioCarrera> UsuarioCarrera { get; set; }

    }
}
