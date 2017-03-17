using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class AsignaturasProfesor 
    {
        int LargoLista = 1;
        public List<List<string>> BuscarAsignaturasPRUEBA()
        {
            List<List<string>> AsignaturasProfe = new List<List<string>>();
            List<string> Asignatura = new List<string>();
            Asignatura.Add("DA1");
            Asignatura.Add("Base de Datos");
            List<string> Descripcion = new List<string>();
            Descripcion.Add("O Desarrollo de Aplicaciones, aprenderemos el uso de cobol y el AS-400.");
            Descripcion.Add("Aprederemos para que sirve una base de datos y como crear una, mediante el lenguaje SQL.");

            for (int i = 0; i < 2; i++)
            {
                List<string> sublist = new List<string>();
                sublist.Add(Asignatura[i]);
                sublist.Add(Descripcion[i]);

                AsignaturasProfe.Add(sublist);
            }

                return AsignaturasProfe;
        }

        public List<List<string>> BuscarAsignaturas()
        {
            List<List<string>> AsignaturasProfe = new List<List<string>>();
            List<string> Asignatura = new List<string>();
            List<string> Descripcion = new List<string>();
            
            Asignatura = LlenarListaAsig();
            Descripcion = LlenarListaDescrip();

            int numAsig = NumeroAsig();

            for (int i = 0; i < numAsig; i++)
            {
                List<string> sublist = new List<string>();

                sublist.Add(Asignatura[i]);
                sublist.Add(Descripcion[i]);

                AsignaturasProfe.Add(sublist);
            }

                return AsignaturasProfe;
        }

        private List<string> LlenarListaDescrip()
        {
            List<string> Descripcion = new List<string>();
            string auxDescrip = "nada";
            using (FicheroBDEntities1 context = new FicheroBDEntities1())
            {
                int rut = ModelosGlobales.GlobalValue;

                //var descrip = (from u in context.Usuarios
                //               join ua in context.UsuarioAsignatura on u.Rut equals ua.RutUsuario
                //               join a in context.Asignaturas on ua.CodAsignatura equals a.CodAsig
                //               where (u.Rut == rut)
                //               select a.Descripcion);

                var descrip = (from h in context.Horarios
                               join a in context.Asignaturas on h.CodAsignatura equals a.CodAsig
                               where (h.RutProfesor == rut)
                               select a.Descripcion);

                // sublist.Add(descrip.ToString());
                foreach (var p in descrip)
                {
                    if (p != auxDescrip)
                    {
                        Descripcion.Add(p);
                    }
                    auxDescrip = p;
                }
            }

            return Descripcion;
        }

        private List<string> LlenarListaAsig()
        {
            List<string> Asignatura = new List<string>();
            string aux= "nada";
            using (FicheroBDEntities1 context = new FicheroBDEntities1())
            {
                int rut = ModelosGlobales.GlobalValue;

                //var asigna = (from u in context.Usuarios
                //              join ua in context.UsuarioAsignatura on u.Rut equals ua.RutUsuario
                //              join a in context.Asignaturas on ua.CodAsignatura equals a.CodAsig
                //              where (u.Rut == rut)
                //              select a.Nombre);
                var asigna = (from h in context.Horarios
                              join a in context.Asignaturas on h.CodAsignatura equals a.CodAsig
                              where (h.RutProfesor == rut)
                              select a.Nombre);

                //sublist.Add(asigna.ToString());
                foreach (var p in asigna)
                {

                    if (p != aux)
                    {
                        Asignatura.Add(p);
                    }
                    aux = p;
                    
                }
            }
            LargoLista = Asignatura.Count();
            return Asignatura;
        }

        public int NumeroAsig()
        {
             int Asig = 0;
             Asig = LargoLista;
            
         return Asig;
        }


        public string horarioAten()
        {
            string horario = null;

            using (FicheroBDEntities1 context = new FicheroBDEntities1())
            {
                int rut = ModelosGlobales.GlobalValue;

                var horaAte = (from u in context.Usuarios
                               where (u.Rut.Equals(rut))
                               select u.HorarioAtencion);

                if (horaAte.ToString().Equals(null))
                {
                    horario = "No tiene Horario de Atención Asignado";
                }
                else { horario = horaAte.ToString(); }

            }

            return horario;
        }


    }
}
