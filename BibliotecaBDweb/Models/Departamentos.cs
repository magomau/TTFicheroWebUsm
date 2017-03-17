using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class Departamentos
    {
        public Departamentos()
        {
            this.Carreras = new HashSet<Carreras>();
        }
        [Key]
        public byte IdDepartamento { get; set; }
        public string RutJefeDepto { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
