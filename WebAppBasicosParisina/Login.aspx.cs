﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsPostBack)
            {
                ddlUser_cve.DataSource = logicaNegocio.ListaUsuarios();
                ddlUser_cve.DataValueField = "user_cve";
                ddlUser_cve.DataTextField = "nombre";
                ddlUser_cve.DataBind();
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}