using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBasicosParisina
{
    public partial class Contact : Page
    {
        LogicaNegocio.LogicaNegocio logicaNegocio = new LogicaNegocio.LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["u"]) == false)
            {
                string user = Decrypt(HttpUtility.UrlDecode(Request.QueryString["u"]));

                var usuario = from p in logicaNegocio.ListaUsuarios() where p.user_cve.Equals(user) select p.user_cve;             

                /*foreach (var item in logicaNegocio.ListaUsuarios())
                {*/
                    if (string.IsNullOrEmpty(usuario.SingleOrDefault()) == false)
                    {
                        Session["user_cve"] = usuario.SingleOrDefault();
                        Response.Redirect("Inicio.aspx", false);
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            ddlUser_cve.DataSource = logicaNegocio.ListaUsuarios();
                            ddlUser_cve.DataValueField = "user_cve";
                            ddlUser_cve.DataTextField = "nombre";
                            ddlUser_cve.DataBind();
                        }
                    }
                /*}*/
            }
            else
            {
                if (!IsPostBack)
                {
                    ddlUser_cve.DataSource = logicaNegocio.ListaUsuarios();
                    ddlUser_cve.DataValueField = "user_cve";
                    ddlUser_cve.DataTextField = "nombre";
                    ddlUser_cve.DataBind();
                }
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string usr_cve = ddlUser_cve.SelectedValue.ToString();
            string pass = txtPass.Text;
            var res = logicaNegocio.Login("001", usr_cve, pass);
            
            if (res == null)
            {
                Response.Write("<script type=\"text/javascript\">alert('Contraseña incorrecta, intente de nuevo'); window.location.href = 'Login.aspx';</script>");
            }
            else
            {
                Session["user_cve"] = res;
                Response.Redirect("Inicio.aspx");
            }
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}