using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBasicosParisina
{
    public partial class ConsultaInfo : System.Web.UI.Page
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
            string query = "SELECT * FROM WebAppBasicos_parisina WHERE fec_ultact = '" + variables.FechaConsulta + "'";
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
        decimal[] Sub_Totales = new decimal[35];

        /* Grand Totales */
        decimal[] Grand_Total = new decimal[35];
        //decimal Grand_Total2 = 0;


        int subTotalRowIndex = 0;

        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (!IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
                    string orderId = dt.Rows[e.Row.RowIndex]["telanom"].ToString();
                    Grand_Total[3] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["inv_int_trans"].ToString());
                    Grand_Total[4] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir"].ToString());
                    Grand_Total[5] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir_old"].ToString());
                    Grand_Total[6] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_surtidos"].ToString());
                    Grand_Total[7] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["ExistTotal"].ToString());
                    Grand_Total[8] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["com_sug_tarima"].ToString());
                    Grand_Total[9] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["sobra_desp_compra"].ToString());
                    Grand_Total[10] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["faltanteAlmacen"].ToString());
                    Grand_Total[11] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["faltAlmPedido"].ToString());
                    Grand_Total[12] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["max_tarima"].ToString());
                    Grand_Total[13] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["preorden_tarima"].ToString());
                    Grand_Total[14] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["temporada_tarima"].ToString());
                    Grand_Total[15] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["dispo_tarima"].ToString());
                    Grand_Total[16] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["resurtido_rollos"].ToString());
                    Grand_Total[17] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["resurtido_mts"].ToString());
                    Grand_Total[18] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["resurtido_tarima"].ToString());
                    Grand_Total[19] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["tarima_extra"].ToString());
                    Grand_Total[20] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["autorizadoXpedido"].ToString());
                    Grand_Total[21] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["demanda_residual"].ToString());
                    Grand_Total[22] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["compra_sugerida"].ToString());
                    Grand_Total[23] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["fabTemporadaTarima"].ToString());
                    Grand_Total[24] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["fabTemporadaDispo"].ToString());
                    Grand_Total[25] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["excedentePedido"].ToString());
                    Grand_Total[26] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["excedenteBodega"].ToString());
                    Grand_Total[27] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["skuSinExis"].ToString());
                    Grand_Total[28] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["skuBajoDisp"].ToString());
                    Grand_Total[29] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["contSku_cve"].ToString());
                    Grand_Total[30] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_tarima"].ToString());
                    Grand_Total[31] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollo_mts"].ToString());
                    if (orderId.Equals(currentId) == false)
                    {
                        if (e.Row.RowIndex > 0)
                        {
                            for (int y = 4; y < gvBP.Columns.Count; y++)
                            {
                                Sub_Totales[y] = 0;
                                for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                                {
                                    if (string.IsNullOrEmpty(gvBP.Rows[i].Cells[y].Text) == false)
                                    {
                                        Sub_Totales[y] += Convert.ToDecimal(gvBP.Rows[i].Cells[y].Text);
                                    }
                                }
                            }
                            AddTotalRow("Total", "");
                            subTotalRowIndex = e.Row.RowIndex;
                        }
                        currentId = orderId;
                    }
                }
            }
        }
        private void AddTotalRow(string labelText, string value)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.BackColor = ColorTranslator.FromHtml("#C9E1F6");
            if (labelText.Equals("Total") == true)
            {
                row.Cells.AddRange(new TableCell[32] { 
                                        new TableCell (),
                                        new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},
                                        new TableCell (),
                                        new TableCell (),
                                        new TableCell { Text = Sub_Totales[4].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[5].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[6].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[7].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[8].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[9].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[10].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[11].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[12].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[13].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[14].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[15].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[16].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[17].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[18].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[19].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[20].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[21].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[22].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[23].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[24].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[25].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[26].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[27].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[28].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[29].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[30].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = Sub_Totales[31].ToString("N2"), HorizontalAlign = HorizontalAlign.Right }
                                });
            }
            else if (labelText.Equals("Grand Total") == true)
            {
                row.Cells.AddRange(new TableCell[32] { 
                                    new TableCell (), //Empty Cell
                                    new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Left},
                                    new TableCell (), //Empty Cell
                                    new TableCell (), //Empty Cell
                                    new TableCell { Text = Grand_Total[4].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[5].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[6].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[7].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[8].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[9].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[10].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[11].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[12].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[13].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[14].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[15].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[16].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[17].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[18].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[19].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[20].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[21].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[22].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[23].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[24].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[25].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[26].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[27].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[28].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[29].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[30].ToString("N2"), HorizontalAlign = HorizontalAlign.Right },
                                    new TableCell { Text = Grand_Total[31].ToString("N2"), HorizontalAlign = HorizontalAlign.Right }
                                });
            }
            row.BorderColor = System.Drawing.Color.FromArgb(201, 225, 246);
            gvBP.Controls[0].Controls.Add(row);
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            for (int i = gvBP.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvBP.Rows[i];
                GridViewRow previousRow = gvBP.Rows[i - 1];
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
            }
            for (int y = 4; y < gvBP.Columns.Count; y++)
            {
                Sub_Totales[y] = 0;

                for (int i = subTotalRowIndex; i < gvBP.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(gvBP.Rows[i].Cells[y].Text) == false)
                    {
                        Sub_Totales[y] += Convert.ToDecimal(gvBP.Rows[i].Cells[y].Text);
                    }
                }
            }
            AddTotalRow("Total", "");
            AddTotalRow("Grand Total", "");
        }
        protected void btnGenPed_Click(object sender, EventArgs e)
        {
            //insertResurtido();
        }
    }
}