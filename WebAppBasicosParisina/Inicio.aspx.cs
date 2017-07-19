using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;


namespace WebAppBasicosParisina
{
    public partial class _Default : Page
    {
        LogicaNegocio.LogicaNegocio logicaNegocio = new LogicaNegocio.LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string query = "exec WebAppBasicosParisina '001','VTBASP' ";
            string conString = ConfigurationManager.ConnectionStrings["BPconnetion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvBP.DataSource = dt;
                            gvBP.DataBind();
                        }
                    }
                }
            }
        }

        string currentId = "";
        /* Totales */
        decimal Sub_Totales = 0; 

        /* Grand Totales */
        decimal Grand_Total = 0;


        int subTotalRowIndex = 0;
        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            Sub_Totales = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
                string orderId = dt.Rows[e.Row.RowIndex]["telanom"].ToString();
                Grand_Total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir"]);
                if (orderId.Equals(currentId) == false)
                {
                    if (e.Row.RowIndex > 0)
                    {
                        for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                        {
                            Sub_Totales += Convert.ToDecimal(gvBP.Rows[i].Cells[4].Text);
                        }
                        AddTotalRow("Total", Sub_Totales.ToString("N2"));
                        subTotalRowIndex = e.Row.RowIndex;
                    }
                    currentId = orderId;
                }
            }
        }

        protected void OnDataBound(object sender, EventArgs e)
        {
            for (int i = gvBP.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvBP.Rows[i];
                GridViewRow previousRow = gvBP.Rows[i - 1];
                /* agrupa la columma de Producto */
                for (int j = 0; j < 1; j++)
                {
                    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
                /* agrupa la columna de Descripcion Cliente */
                //for (int j = 2; j < 3; j++)
                //{
                //    if (row.Cells[j].Text == previousRow.Cells[j].Text)
                //    {
                //        if (previousRow.Cells[j].RowSpan == 0)
                //        {
                //            if (row.Cells[j].RowSpan == 0)
                //            {
                //                previousRow.Cells[j].RowSpan += 2;
                //            }
                //            else
                //            {
                //                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                //            }
                //            row.Cells[j].Visible = false;
                //        }
                //    }
                //}
            }
            for (int i = subTotalRowIndex; i < gvBP.Rows.Count; i++)
            {
                Sub_Totales += Convert.ToDecimal(gvBP.Rows[i].Cells[4].Text);
            }
            AddTotalRow("Total", Sub_Totales.ToString("N2"));
            AddTotalRow("Grand Total", Grand_Total.ToString("N2"));
        }

        private void AddTotalRow(string labelText, string value)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.BackColor = ColorTranslator.FromHtml("#C9E1F6");
            row.Cells.AddRange(new TableCell[32] { 
                                    new TableCell (), //Empty Cell
                                    new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Left},
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell { Text = value, HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                });
            row.BorderColor = System.Drawing.Color.FromArgb(201,225,246);

            gvBP.Controls[0].Controls.Add(row);
        }
    }
}