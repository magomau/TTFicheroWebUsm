using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class Carreras
    {
        public Carreras()
        {
            this.UsuarioCarrera = new HashSet<UsuarioCarrera>();
        }
        [Key]
        public byte IdCarrera { get; set; }
        public string RutJefeCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public Nullable<byte> IdDepartamento { get; set; }

        public virtual Departamentos Departamentos { get; set; }
        public virtual ICollection<UsuarioCarrera> UsuarioCarrera { get; set; }
    }
}
