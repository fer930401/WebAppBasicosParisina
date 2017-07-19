using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace LogicaNegocio
{
    public class LogicaNegocio
    {
        AccesoDatos.AccesoDatos datos;
        public LogicaNegocio()
        {
            datos = new AccesoDatos.AccesoDatos();
        }

        public List<Entidades.WebAppBasicosParisina_Result> consultaPedidos(string ef_cve, string tipdoc_cve)
        {
            return datos.consultaPedidos(ef_cve,tipdoc_cve);
        }
    }
}
