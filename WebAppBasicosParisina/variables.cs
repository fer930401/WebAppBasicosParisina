using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppBasicosParisina
{
    public class variables
    {
        static string fechaConsulta;
        public static string FechaConsulta
        {
            get { return variables.fechaConsulta; }
            set { variables.fechaConsulta = value; }
        }
    }
}