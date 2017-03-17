using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsmFicheroWeb.Models;

namespace UsmFicheroWeb.Controllers
{
    public class CrearCalendario
    {
        /// <summary>
        /// Crear el calendario dependendo del usuario y mostrando algo.
        /// </summary>
        /// <returns></returns>
        public List<List<string>> Crear()
        {
            List<List<string>> Calendario = new List<List<string>>();
            List<string> horas = new List<string>();
            horas.Add("8:15 - 9:00");
            horas.Add("9:00 - 9:45");
            horas.Add("10:00 - 10:45");
            horas.Add("10:45 - 11:30");
            horas.Add("11:45 - 12:30");
            horas.Add("12:30 - 13:15");
            horas.Add("13:15 - 14:00");
            horas.Add("14:00 - 14:45");
            horas.Add("14:45 - 15:30");
            horas.Add("15:45 - 16:30");
            List<string> Asignaturas = new List<string>();

            for (int i = 0; i < 9; i++)
            {
                int indiceHoras = i + 1;
                //string hola = "null" + i;
                string nada = "  ";
                List<string> sublist = new List<string>();
                for (int v = 0; v < 6; v++)
                {
                    int indiceDias = v;
                    if (v == 0)
                    {
                        sublist.Add(horas[i]);
                    }
                    else
                    {
                        using (FicheroBDEntities1 context = new FicheroBDEntities1())
                        {
                            int rut = ModelosGlobales.GlobalValue;

                            //var calen = from u in context.Usuarios
                            //            join ua in context.UsuarioAsignatura on u.Rut equals ua.RutUsuario
                            //            join a in context.Asignaturas on ua.CodAsignatura equals a.CodAsig
                            //            join h in context.Horarios on a.CodAsig equals h.CodAsignatura
                            //            where (h.CodHora == indiceHoras) && (h.Dia == indiceDias) && (ua.Paralelo == h.Paralelo) && (u.Rut == rut)
                            //            select a.Nombre;

                            var calen = (from u in context.Usuarios
                                        join ua in context.UsuarioAsignatura on u.Rut equals ua.RutUsuario
                                        join a in context.Asignaturas on ua.CodAsignatura equals a.CodAsig
                                        join h in context.Horarios on a.CodAsig equals h.CodAsignatura
                                        where (h.CodHora == indiceHoras) && (h.Dia == indiceDias) && (ua.Paralelo == h.Paralelo) && (u.Rut == rut)
                                        select new { a.Nombre , h.Salas.CodSala, h.Salas.CodEdificio}).ToList();

                            foreach (var p in calen)
                            {
                                string union = " (" + p.CodEdificio.ToString() + "-" + p.CodSala.ToString() +") "+ p.Nombre;
                                Asignaturas.Add(union);
                            }

                        }
                        if (Asignaturas.Count > 0)
                        {
                            sublist.Add(Asignaturas[0]);
                            Asignaturas.Clear();
                        }
                        else
                        {

                            sublist.Add(nada);
                        }
                    }
                }
                Calendario.Add(sublist);
            }

            return Calendario;
        }

        /// <summary>
        /// Crear un calendario vacio para la visualizacion de este, y para crear pruebas. NO OCUPAR EN EL CODIGO-
        /// SI ES MODIFICADO.
        /// MODIFICADO: "NO";
        /// </summary>
        /// <returns></returns>
        public List<List<string>> CrearMuestra()
        {
            List<string> horas = new List<string>();
            horas.Add("(1)-8:15 - 9:00");
            horas.Add("(2)-9:00 - 9:45");
            horas.Add("(3)-10:00 - 10:45");
            horas.Add("(4)-10:45 - 11:30");
            horas.Add("(5)-11:45 - 12:30");
            horas.Add("(6)-12:30 - 13:15");
            horas.Add("(7)-13:15 - 14:00");
            horas.Add("(8)-14:00 - 14:45");
            horas.Add("(9)-14:45 - 15:30");
            horas.Add("(10)-15:45 - 16:30");

            List<List<string>> CalendarioMuestra = new List<List<string>>();
            for (int i = 0; i < 9; i++)
            {
                string nada = "  ";
                List<string> sublist = new List<string>();

                for (int v = 0; v < 6; v++)
                {
                    int indiceDias = v;
                    if (v == 0)
                    {
                        sublist.Add(horas[i]);
                    }
                    else
                    {
                        sublist.Add(nada);
                    }
                }

                CalendarioMuestra.Add(sublist);
                
            }
            return CalendarioMuestra;
        }

        public List<List<string>> CrearProfesor()
        {
            List<List<string>> Calendario = new List<List<string>>();
            List<string> horas = new List<string>();
            horas.Add("8:15 - 9:00");
            horas.Add("9:00 - 9:45");
            horas.Add("10:00 - 10:45");
            horas.Add("10:45 - 11:30");
            horas.Add("11:45 - 12:30");
            horas.Add("12:30 - 13:15");
            horas.Add("13:15 - 14:00");
            horas.Add("14:00 - 14:45");
            horas.Add("14:45 - 15:30");
            horas.Add("15:45 - 16:30");
            List<string> Asignaturas = new List<string>();

            for (int i = 0; i < 9; i++)
            {
                int indiceHoras = i + 1;
                //string hola = "null" + i;
                string nada = "  ";
                List<string> sublist = new List<string>();
                for (int v = 0; v < 6; v++)
                {
                    int indiceDias = v;
                    if (v == 0)
                    {
                        sublist.Add(horas[i]);
                    }
                    else
                    {
                        using (FicheroBDEntities1 context = new FicheroBDEntities1())
                        {
                            int rut = ModelosGlobales.GlobalValue;

                            var calen = from h in context.Horarios
                                        join a in context.Asignaturas on h.CodAsignatura equals a.CodAsig
                                        where (h.RutProfesor == rut) && (h.CodHora == indiceHoras) && (h.Dia == indiceDias)
                                        select a.Nombre;

                            foreach (var p in calen)
                            {
                                Asignaturas.Add(p);
                            }

                        }
                        if (Asignaturas.Count > 0)
                        {
                            sublist.Add(Asignaturas[0]);
                            Asignaturas.Clear();
                        }
                        else
                        {

                            sublist.Add(nada);
                        }
                    }
                }
                Calendario.Add(sublist);
            }

            return Calendario;

        }
    }
}