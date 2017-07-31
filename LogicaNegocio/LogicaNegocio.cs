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

        public List<Entidades.xcuser> ListaUsuarios()
        {
            return datos.ListaUsuarios(datos.ListaUser_cve());
        }

        public string Login(string ef_cve, string user_cve, string password)
        {
            return datos.Login(ef_cve, user_cve, password);
        }

        public List<Entidades.WebAppBasicosParisina_Result> consultaPedidos(string ef_cve, string tipdoc_cve)
        {
            return datos.consultaPedidos(ef_cve, tipdoc_cve);
        }

        public List<Entidades.WebAppBasicos_parisina> FiltroFechas()
        {
            return datos.FiltroFechas();
        }

        public List<Entidades.WebAppBasicos_parisina> llenaConsulta(string fecha)
        {
            return datos.llenaConsulta(fecha);
        }

        public Entidades.WebAppInsertaResurdoParisina_Result insertaResurtido(string ef_cve, string tipdoc_cve, string producto, string color_variante, int? autorizar, string id_ultact)
        {
            return datos.insertaResurtido(ef_cve, tipdoc_cve, producto, color_variante, autorizar, id_ultact);
        }
    }
}
