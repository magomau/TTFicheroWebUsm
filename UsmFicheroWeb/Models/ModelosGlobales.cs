using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsmFicheroWeb.Models
{
    public class ModelosGlobales
    {
      public const string GlobalString = "Important Text";

        static int _globalValue;
        static byte? _globalValue2;
        static byte _globalValue3;
        static byte? _globalValue4;
        static string _globalValueUsuarioNombre;
        static string _globalValueUsuarioApellidos;
        static string _globalValueUsuarioPass;
        static string _globalHorarioAtencion;
        static string _globalValueNomCarrera;

        public static string GlobalValuePass
        {
            get {
                return _globalValueUsuarioPass;
            }
            set
            {

                _globalValueUsuarioPass = value;
            }
        }

        public static int GlobalValue
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }

        public static string GlobalValueNomCarrera
        {
            get
            {
                return _globalValueNomCarrera;
            }
            set
            {
                _globalValueNomCarrera = value;
            }
        }

        public static byte? GlobalValue2
        {
            get
            {
                return _globalValue2;
            }
            set
            {
                _globalValue2 = value;
            }

        }

        public static byte GlobalValue3
        {
            get
            {
                return _globalValue3;
            }
            set
            {
                _globalValue3 = value;
            }

        }

        public static byte? GlobalValue4
        {
            get
            {
                return _globalValue4;
            }
            set
            {
                _globalValue4 = value;
            }

        }

        public static string GlobalValueNombre
        {
            get
            {
                return _globalValueUsuarioNombre;
            }
            set
            {
                _globalValueUsuarioNombre = value;
            }
        }

        public static string GlobalValueApellidos
        {
            get
            {
                return _globalValueUsuarioApellidos;
            }
            set
            {
                _globalValueUsuarioApellidos = value;
            }
        }

        public static string GlobalHorarioAtencion
        {
            get
            {
                return _globalHorarioAtencion;
            }
            set
            {
                _globalHorarioAtencion = value;
            }

        }


        public static bool GlobalBoolean;

    }
}