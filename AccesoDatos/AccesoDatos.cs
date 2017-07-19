using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatos
    {
        BasicosParisinaEntities contexto;
        
        public AccesoDatos(){
            contexto = new BasicosParisinaEntities();
        }

        public List<WebAppBasicosParisina_Result> consultaPedidos(string ef_cve, string tipdoc_cve)
        {
            List<Entidades.WebAppBasicosParisina_Result> consultaPedidos = contexto.WebAppBasicosParisina(ef_cve, tipdoc_cve).ToList();
            return consultaPedidos;
        }
    }
}
