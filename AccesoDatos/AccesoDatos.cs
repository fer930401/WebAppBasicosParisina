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
        /*public List<string> ListaUser_cve()
        {
            return ((from u in contexto.xcdconapl_cl where u.sp_cve.Equals("CesionPag") select u.spd_cve).ToList());
        }*/
        public List<xcuser> ListaUsuarios()
        {
            return (from u in contexto.xcuser where u.ef_cve == "001" && u.status == 1 select u).Distinct().ToList();
        }

        public string Login(string ef_cve, string user_cve, string password)
        {
            string usr_cve;
            var result = (from usuario in contexto.xcuser
                          where
                            usuario.ef_cve.Equals(ef_cve) &&
                            usuario.user_cve.Equals(user_cve) &&
                            usuario.password.Equals(password)
                          select usuario).SingleOrDefault();

            if (result == null)
            {
                return usr_cve = null;
            }
            else
            {
                if (string.IsNullOrEmpty(result.user_cve) == false)
                {
                    usr_cve = result.user_cve;
                    return usr_cve;
                }
                else
                {
                    return usr_cve = null;
                }
            }
        }

        public List<WebAppBasicosParisina_Result> consultaPedidos(string ef_cve, string tipdoc_cve)
        {
            List<Entidades.WebAppBasicosParisina_Result> consultaPedidos = contexto.WebAppBasicosParisina(ef_cve, tipdoc_cve).ToList();
            return consultaPedidos;
        }
    }
}
