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
        int pos = 0;
        static decimal exisTotalC;
        public static decimal ExisTotalC
        {
            get { return _Default.exisTotalC; }
            set { _Default.exisTotalC = value; }
        }
        static decimal cst;
        public static decimal CST
        {
            get { return _Default.cst; }
            set { _Default.cst = value; }
        }
        static decimal scd;
        public static decimal SCD
        {
            get { return _Default.scd; }
            set { _Default.scd = value; }
        }
        static decimal faltAlm;
        public static decimal FaltAlm
        {
            get { return _Default.faltAlm; }
            set { _Default.faltAlm = value; }
        }
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
        decimal[] Sub_Totales = new decimal[35];
        decimal Sub_Totales2 = 0;

        /* Grand Totales */
        decimal Grand_Total = 0;
        decimal Grand_Total2 = 0;


        int subTotalRowIndex = 0;
        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            //Sub_Totales = 0;
            Sub_Totales2 = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
                string orderId = dt.Rows[e.Row.RowIndex]["telanom"].ToString();
                Grand_Total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir"]);
                Grand_Total2 += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir_old"]);
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
                                    //Sub_Totales2 += Convert.ToDecimal(gvBP.Rows[i].Cells[5].Text);
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
            for (int y = 4; y < gvBP.Columns.Count; y++)
            {
                Sub_Totales[y] = 0;

                for (int i = subTotalRowIndex; i < gvBP.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(gvBP.Rows[i].Cells[y].Text) == false)
                    {
                        Sub_Totales[y] += Convert.ToDecimal(gvBP.Rows[i].Cells[y].Text);
                        //Sub_Totales2 += Convert.ToDecimal(gvBP.Rows[i].Cells[5].Text);
                    }

                }
            } 
            AddTotalRow("Total", "");
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
            row.BorderColor = System.Drawing.Color.FromArgb(201, 225, 246);

            gvBP.Controls[0].Controls.Add(row);
        }
        public decimal ExisTotal(string valor1, string valor2, string valor3, string valor4)
        {
            decimal result = 0;
            decimal intTrans = decimal.Parse(valor1);
            decimal ped_surtir = decimal.Parse(valor2);
            decimal ped_surtit_old = decimal.Parse(valor3);
            decimal ped_surtidos = decimal.Parse(valor4);
            result = intTrans + ped_surtir + ped_surtit_old + ped_surtidos;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal restaColumnas()
        {
            decimal result = 0;
            result = CST - ExisTotalC;
            SCD = result;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        /* Faltante vs almacen: */
        public decimal restaExistSobrante()
        {
            decimal result = 0;
            result = ExisTotalC - SCD;
            FaltAlm = result;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        /* Faltante vs almacen + pedidos: */
        public decimal sumaFaltanteAlmacen(string valor1)
        {
            decimal result = 0;
            decimal rollos_ped_xsurtir = decimal.Parse(valor1);
            result = FaltAlm + rollos_ped_xsurtir;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal resurtidoMTS(string valor1, string valor2)
        {
            decimal result = 0;
            decimal rollo_tarima = decimal.Parse(valor1);
            decimal mtsRollos = decimal.Parse(valor2) * 0.9144m;
            result = (ExisTotalC * rollo_tarima) * mtsRollos;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        

        public decimal demandaResidual(string valor1, string valor2, string valor3)
        {
            decimal result = 0;

            result = decimal.Parse(valor1) + decimal.Parse(valor2) + decimal.Parse(valor3);

            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal excedenteBodega(string valor1, string valor2)
        {
            decimal result = 0;
            decimal stock = decimal.Parse(valor1);
            decimal max_parisina = decimal.Parse(valor2);

            if (stock > max_parisina)
            {
                result = stock - max_parisina;
            }
            else
            {
                result = 0;
            }            

            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public int skuSinExist(string valor1, string valor2)
        {
            int result = 0;
            decimal stock = decimal.Parse(valor1);
            int contSku_cve = Int32.Parse(valor2);

            if (stock <= 0)
            {
                result = contSku_cve;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public int skuBajoExist(string valor1, string valor2, string valor3)
        {
            int result = 0;
            decimal stock = decimal.Parse(valor1);
            decimal min_parisina = decimal.Parse(valor3);
            int contSku_cve = Int32.Parse(valor2);

            if (stock > 0 && ExisTotalC < min_parisina)
            {
                result = contSku_cve;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public decimal mtsRollos(string valor1)
        {
            decimal result = 0;
            decimal rollo_yardas = decimal.Parse(valor1);
            result = rollo_yardas * 0.9144m;

            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}