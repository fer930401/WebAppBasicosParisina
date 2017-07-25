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
using System.Collections.Specialized;
using System.Text;


namespace WebAppBasicosParisina
{
    public partial class _Default : Page
    {
        LogicaNegocio.LogicaNegocio logicaNegocio = new LogicaNegocio.LogicaNegocio();
        int pos = 0;

        static decimal invIntTran;
        public static decimal InvIntTran
        {
            get { return _Default.invIntTran; }
            set { _Default.invIntTran = value; }
        }
        static decimal invIntTranT;
        public static decimal InvIntTranT
        {
            get { return _Default.invIntTranT; }
            set { _Default.invIntTranT = value; }
        }

        static decimal exisTotalC;
        public static decimal ExisTotalC
        {
            get { return _Default.exisTotalC; }
            set { _Default.exisTotalC = value; }
        }
        static decimal exisTotalCT;
        public static decimal ExisTotalCT
        {
            get { return _Default.exisTotalCT; }
            set { _Default.exisTotalCT = value; }
        }

        static decimal cst;
        public static decimal CST
        {
            get { return _Default.cst; }
            set { _Default.cst = value; }
        }
        static decimal cstT;
        public static decimal CSTT
        {
            get { return _Default.cstT; }
            set { _Default.cstT = value; }
        }

        static decimal scd;
        public static decimal SCD
        {
            get { return _Default.scd; }
            set { _Default.scd = value; }
        }
        static decimal scdT;
        public static decimal SCDT
        {
            get { return _Default.scdT; }
            set { _Default.scdT = value; }
        }

        static decimal faltAlm;
        public static decimal FaltAlm
        {
            get { return _Default.faltAlm; }
            set { _Default.faltAlm = value; }
        }
        static decimal faltAlmT;
        public static decimal FaltAlmT
        {
            get { return _Default.faltAlmT; }
            set { _Default.faltAlmT = value; }
        }

        static decimal fap;
        public static decimal FAP
        {
            get { return _Default.fap; }
            set { _Default.fap = value; }
        }
        static decimal fapT;
        public static decimal FAPT
        {
            get { return _Default.fapT; }
            set { _Default.fapT = value; }
        }

        static decimal rMTS;
        public static decimal RMTS
        {
            get { return _Default.rMTS; }
            set { _Default.rMTS = value; }
        }
        static decimal rMTST;
        public static decimal RMTST
        {
            get { return _Default.rMTST; }
            set { _Default.rMTST = value; }
        }

        static decimal rtarima;
        public static decimal RTarima
        {
            get { return _Default.rtarima; }
            set { _Default.rtarima = value; }
        }
        static decimal rtarimat;
        public static decimal RTarimaT
        {
            get { return _Default.rtarimat; }
            set { _Default.rtarimat = value; }
        }

        static decimal demRes;
        public static decimal DemRes
        {
            get { return _Default.demRes; }
            set { _Default.demRes = value; }
        }
        static decimal demResT;
        public static decimal DemResT
        {
            get { return _Default.demResT; }
            set { _Default.demResT = value; }
        }

        static decimal tempDispo;
        public static decimal TempDispo
        {
            get { return _Default.tempDispo; }
            set { _Default.tempDispo = value; }
        }
        static decimal tempDispoT;
        public static decimal TempDispoT
        {
            get { return _Default.tempDispoT; }
            set { _Default.tempDispoT = value; }
        }

        static decimal excPedido;
        public static decimal ExcPedido
        {
            get { return _Default.excPedido; }
            set { _Default.excPedido = value; }
        }
        static decimal excPedidoT;
        public static decimal ExcPedidoT
        {
            get { return _Default.excPedidoT; }
            set { _Default.excPedidoT = value; }
        }

        static decimal exdBod;
        public static decimal ExdBod
        {
            get { return _Default.exdBod; }
            set { _Default.exdBod = value; }
        }
        static decimal exdBodT;
        public static decimal ExdBodT
        {
            get { return _Default.exdBodT; }
            set { _Default.exdBodT = value; }
        }

        static decimal sse;
        public static decimal SSE
        {
            get { return _Default.sse; }
            set { _Default.sse = value; }
        }
        static decimal sseT;
        public static decimal SSET
        {
            get { return _Default.sseT; }
            set { _Default.sseT = value; }
        }

        static decimal sbe;
        public static decimal SBE
        {
            get { return _Default.sbe; }
            set { _Default.sbe = value; }
        }
        static decimal sbeT;
        public static decimal SBET
        {
            get { return _Default.sbeT; }
            set { _Default.sbeT = value; }
        }

        static decimal mRollo;
        public static decimal MRollo
        {
            get { return _Default.mRollo; }
            set { _Default.mRollo = value; }
        }
        static decimal mRolloT;
        public static decimal MRolloT
        {
            get { return _Default.mRolloT; }
            set { _Default.mRolloT = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                ddlBusqueda.DataSource = logicaNegocio.FiltroFechas();
                ddlBusqueda.DataTextField = "fec_ultact";
                ddlBusqueda.DataValueField = "fec_ultact";
                ddlBusqueda.DataBind();
                ddlBusqueda.Items.Insert(0, new ListItem("Selecciona una fecha", "NA"));
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
                    Grand_Total[3] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped"].ToString());
                    Grand_Total[4] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir"].ToString());
                    Grand_Total[5] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_xsurtir_old"].ToString());
                    Grand_Total[6] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_ped_surtidos"].ToString());
                    Grand_Total[7] += ExisTotalC;
                    Grand_Total[8] += CST;
                    Grand_Total[9] += SCD;
                    Grand_Total[10] += FaltAlm;
                    Grand_Total[11] += FAP;
                    Grand_Total[12] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["max_tarima"].ToString());
                    Grand_Total[13] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["preorden_tarima"].ToString());
                    Grand_Total[14] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["temporada_tarima"].ToString());
                    Grand_Total[15] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["dispo_tarima"].ToString());
                    Grand_Total[16] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["resurtido_rollos"].ToString());
                    Grand_Total[17] += RMTS;
                    Grand_Total[18] += RTarima;
                    Grand_Total[21] += DemRes;
                    Grand_Total[22] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["compra_sugerida"].ToString());
                    Grand_Total[23] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["temporada_tarima"].ToString());
                    Grand_Total[24] += TempDispo;
                    Grand_Total[25] += ExcPedido;
                    Grand_Total[26] += ExdBod;
                    Grand_Total[27] += SSE;
                    Grand_Total[28] += SBE;
                    Grand_Total[29] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["contSku_cve"].ToString());
                    Grand_Total[30] += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["rollos_tarima"].ToString());
                    Grand_Total[31] += MRollo;
                    if (orderId.Equals(currentId) == false)
                    {
                        if (e.Row.RowIndex > 0)
                        {
                            for (int y = 3; y < gvBP.Columns.Count; y++)
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
                            Sub_Totales[7] += ExisTotalCT;
                            Sub_Totales[8] += CSTT;
                            Sub_Totales[9] += SCDT;
                            Sub_Totales[10] += FaltAlmT;
                            Sub_Totales[11] += FAPT;
                            Sub_Totales[17] += RMTST;
                            Sub_Totales[18] += RTarimaT;
                            Sub_Totales[21] += DemResT;
                            Sub_Totales[24] += TempDispoT;
                            Sub_Totales[25] += ExcPedidoT;
                            Sub_Totales[26] += ExdBodT;
                            Sub_Totales[27] += SSET;
                            Sub_Totales[28] += SBET;
                            Sub_Totales[31] += MRolloT;

                            AddTotalRow("Total", "");
                            subTotalRowIndex = e.Row.RowIndex;
                        }
                        currentId = orderId;
                    }
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
            }
            for (int y = 3; y < gvBP.Columns.Count; y++)
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
            Sub_Totales[7] += ExisTotalCT;
            Sub_Totales[8] += CSTT;
            Sub_Totales[9] += SCDT;
            Sub_Totales[10] += FaltAlmT;
            Sub_Totales[11] += FAPT;
            Sub_Totales[17] += RMTST;
            Sub_Totales[18] += RTarimaT;
            Sub_Totales[21] += DemResT;
            Sub_Totales[24] += TempDispoT;
            Sub_Totales[25] += ExcPedidoT;
            Sub_Totales[26] += ExdBodT;
            Sub_Totales[27] += SSET;
            Sub_Totales[28] += SBET;
            Sub_Totales[31] += MRolloT;
            AddTotalRow("Total", "");
            AddTotalRow("Grand Total", "");
        }

        private void AddTotalRow(string labelText, string value)
        {
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.BackColor = ColorTranslator.FromHtml("#C9E1F6");
            if (labelText.Equals("Total") == true)
            {
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
            InvIntTranT = 0;
            ExisTotalCT = 0;
            CSTT = 0;
            SCDT = 0;
            FaltAlmT = 0;
            FAPT = 0;
            RMTST = 0;
            RTarimaT = 0;
            DemResT = 0;
            TempDispoT = 0;
            ExcPedidoT = 0;
            ExdBodT = 0;
            SSET = 0;
            SBET = 0;
            MRolloT = 0;
            gvBP.Controls[0].Controls.Add(row);
        }

        public decimal inventarioIntTrans(string valor1, string valor2, string valor3, string valor4, string valor5, string valor6)
        {
            decimal result = 0;
            decimal rollos_ped = decimal.Parse(valor1);
            decimal rollos_ped_surtidos = decimal.Parse(valor2);
            decimal rollos_ped_xsurtir = decimal.Parse(valor3);
            decimal rollos_ped_xsurtir_old = decimal.Parse(valor4);
            decimal resurtido_rollos = decimal.Parse(valor5);
            decimal rollos_tarima = decimal.Parse(valor6);
            if (rollos_tarima > 0)
            {
                result = (rollos_ped + rollos_ped_surtidos + rollos_ped_xsurtir + rollos_ped_xsurtir_old + resurtido_rollos) / rollos_tarima;
            }
            else
            {
                result = 0;
            }
            InvIntTran = result;
            InvIntTranT += InvIntTran;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal ExisTotal(string valor1, string valor2, string valor3, string valor4)
        {
            decimal result = 0;
            decimal stock = decimal.Parse(valor1);
            decimal rollos_ped_surtidos = decimal.Parse(valor2);
            decimal rollos_ped_xsurtir = decimal.Parse(valor3);
            decimal rollos_ped_xsurtir_old = decimal.Parse(valor4);
            result = stock + rollos_ped_surtidos + rollos_ped_xsurtir + rollos_ped_xsurtir_old;
            ExisTotalC = result;
            ExisTotalCT += ExisTotalC;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal compraSugerida(string valor1, string valor2)
        {
            decimal result = 0;
            decimal comSugerida = decimal.Parse(valor1);
            decimal rollo_tarima = decimal.Parse(valor2);
            if (rollo_tarima > 0)
            {
                result = comSugerida/rollo_tarima;
            }
            else
            {
                result = 0;
            }
            
            CST = result;
            CSTT += CST;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal restaColumnas()
        {
            decimal result = 0;
            result = ExisTotalC - CST;
            SCD = result;
            SCDT += SCD;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        
        public decimal restaExistSobrante()
        {
            decimal result = 0;
            result = ExisTotalC - SCD;
            FaltAlm = result;
            FaltAlmT += FaltAlm;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }
        
        public decimal sumaFaltanteAlmacen(string valor1)
        {
            decimal result = 0;
            decimal rollos_ped_xsurtir = decimal.Parse(valor1);
            result = FaltAlm + rollos_ped_xsurtir;
            FAP = result;
            FAPT += FAP;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal resurtidoMTS(string valor1, string valor2)
        {
            decimal result = 0;
            decimal rollo_tarima = decimal.Parse(valor1);
            decimal mtsRollos = decimal.Parse(valor2) * 0.9144m;
            if (rollo_tarima > 0)
            {
                result = (ExisTotalC / rollo_tarima) * mtsRollos;
            }
            else
            {
                result = 0;
            }
            
            RMTS = result;
            RMTST += RMTS;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal resurtidoTarima(string valor1, string valor2)
        {
            decimal result = 0;
            decimal resurtido_tarima = decimal.Parse(valor1);
            decimal rollo_tarima = decimal.Parse(valor2);
            if (rollo_tarima > 0)
            {
                result = resurtido_tarima / rollo_tarima;
            }
            else
            {
                result = 0;
            }
            RTarima = result;
            RTarimaT += RTarima;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        /*public decimal demandaResidual(string valor1, string valor2, string valor3)
        {
            decimal result = 0;

            result = decimal.Parse(valor1) + decimal.Parse(valor2) + decimal.Parse(valor3);
            DemRes = result;
            DemResT += DemRes;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }*/

        public decimal temporadaDispo(string valor1, string valor2)
        {
            decimal result = 0;
            decimal temporada_tarima = decimal.Parse(valor1);
            decimal dispo_tarima = decimal.Parse(valor2);

            if (dispo_tarima > 0)
            {
                result = temporada_tarima / dispo_tarima;
            }
            else
            {
                result = 0;
            }
            
            TempDispo = result;
            TempDispoT += TempDispo;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        public decimal excedentePedido(string valor1, string valor2)
        {
            /*
                revisar
                IF [Disponible]-([max_tarima]+[temporada_tarima]) > 0
                then [Disponible]-([max_tarima]+[temporada_tarima])
                END

                Disponible = [Exis Tot]-[Compra Sugerida Tarima]

                Exis_tot = [Inv]+[Pedidos total]
 
            */
            decimal result = 0;
            decimal stock = decimal.Parse(valor1);
            decimal compra_sugerida = decimal.Parse(valor2);

            if (compra_sugerida >= 0)
            {
                result = stock - compra_sugerida;
            }
            else
            {
                result = 0;
            }

            ExcPedido = result;
            ExcPedidoT += excPedido;
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
            ExdBod = result;
            ExdBodT += ExdBod;
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
            SSE = result;
            SSET += SSE;
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
            SBE = result;
            SBET += SBE;
            return result;
        }

        public decimal mtsRollos(string valor1)
        {
            decimal result = 0;
            decimal rollo_yardas = decimal.Parse(valor1);
            result = rollo_yardas * 0.9144m;
            MRollo = result;
            MRolloT += MRollo;
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        protected void btnGenPed_Click(object sender, EventArgs e)
        {
            insertResurtido();
        }

        public void insertResurtido()
        {
            string error = "";

            string Producto = string.Empty;
            string colorVariante = string.Empty;
            string descCliente = string.Empty;
            decimal invInteTrans = 0m;
            decimal ped_surtir = 0m;
            decimal ped_viejos_surtir = 0m;
            decimal ped_surtidos = 0m;
            decimal exis_total = 0m;
            decimal com_sug_tarima = 0m;
            decimal sob_des_comp = 0m;
            decimal faltAlm = 0m;
            decimal falAlmPed = 0m;
            decimal max_tarima = 0m;
            decimal punReorden = 0m;
            decimal temp_tarima = 0m;
            decimal tarima_dispo = 0m;
            decimal fabResurtido = 0m;
            decimal fabResurtidoMts = 0m;
            decimal fabResurtidoTarima = 0m;
            decimal tarimaExtraPed = 0m;
            decimal autorizaPed = 0m;
            decimal demResidual = 0m;
            decimal demParisina = 0m;
            decimal fabTempTarima = 0m;
            decimal fabTempDispo = 0m;
            decimal excIncPed = 0m;
            decimal excBodega = 0m;
            decimal skuSinExis = 0m;
            decimal skuBajoDispo = 0m;
            decimal totSku = 0m;
            decimal rollos_tarima = 0m;
            decimal mts_rollos = 0m;

            foreach (GridViewRow GVRow in gvBP.Rows)
            {
                if (string.IsNullOrEmpty(GVRow.Cells[4].Text) == false)
                {
                    Producto = HttpUtility.HtmlDecode(GVRow.Cells[0].Text);
                    colorVariante = GVRow.Cells[1].Text;
                    descCliente = GVRow.Cells[2].Text;
                    invInteTrans = decimal.Parse("0");//cambiar
                    ped_surtir = decimal.Parse(GVRow.Cells[4].Text);
                    ped_viejos_surtir = decimal.Parse(GVRow.Cells[5].Text);
                    ped_surtidos = decimal.Parse(GVRow.Cells[6].Text);
                    Label lblExisTotal = (Label)GVRow.Cells[7].FindControl("lblExisTotal");
                    exis_total = decimal.Parse(lblExisTotal.Text);
                    Label lblCST = (Label)GVRow.Cells[8].FindControl("lblCST");
                    com_sug_tarima = decimal.Parse(lblCST.Text);
                    Label lblSDC = (Label)GVRow.Cells[9].FindControl("lblSDC");
                    sob_des_comp = decimal.Parse(lblSDC.Text);
                    Label lblFA = (Label)GVRow.Cells[10].FindControl("lblFA");
                    faltAlm = decimal.Parse(lblFA.Text);
                    Label lblFAP = (Label)GVRow.Cells[11].FindControl("lblFAP");
                    falAlmPed = decimal.Parse(lblFAP.Text);
                    max_tarima = decimal.Parse(GVRow.Cells[12].Text);
                    punReorden = decimal.Parse(GVRow.Cells[13].Text);
                    temp_tarima = decimal.Parse(GVRow.Cells[14].Text);
                    tarima_dispo = decimal.Parse(GVRow.Cells[15].Text);
                    fabResurtido = decimal.Parse(GVRow.Cells[16].Text);
                    Label lblFRMTS = (Label)GVRow.Cells[17].FindControl("lblFRMTS");
                    fabResurtidoMts = decimal.Parse(lblFRMTS.Text);
                    Label lblFRT = (Label)GVRow.Cells[18].FindControl("lblFRT");
                    fabResurtidoTarima = decimal.Parse(lblFRT.Text);
                    tarimaExtraPed = decimal.Parse("0");//cambiar

                    TextBox txt = (TextBox)GVRow.Cells[20].FindControl("txtNumTarimas"); //se busca el input donde se inserta la cantidad
                    if (txt != null)
                    {
                        if (txt.Text.Equals("0") == false && string.IsNullOrEmpty(txt.Text) == false)
                        {
                            //aqui se realizara la transaccion
                            autorizaPed = decimal.Parse(txt.Text);
                        }
                        else
                        {
                            autorizaPed = decimal.Parse("0");
                        }
                    }
                    Label lblDemResi = (Label)GVRow.Cells[21].FindControl("lblDemResi");
                    demResidual = decimal.Parse(lblDemResi.Text);
                    demParisina = decimal.Parse(GVRow.Cells[22].Text);
                    fabTempTarima = decimal.Parse(GVRow.Cells[23].Text);
                    Label lblFTD = (Label)GVRow.Cells[24].FindControl("lblFTD");
                    fabTempDispo = decimal.Parse(lblFTD.Text);
                    Label lblEIP = (Label)GVRow.Cells[25].FindControl("lblEIP");
                    excIncPed = decimal.Parse(lblEIP.Text);
                    Label lblExcBod = (Label)GVRow.Cells[26].FindControl("lblExcBod");
                    excBodega = decimal.Parse(lblExcBod.Text);
                    Label lblSkuSinExis = (Label)GVRow.Cells[27].FindControl("lblSkuSinExis");
                    skuSinExis = decimal.Parse(lblSkuSinExis.Text);
                    Label lblSkuBajoDispo = (Label)GVRow.Cells[28].FindControl("lblSkuBajoDispo");
                    skuBajoDispo = decimal.Parse(lblSkuBajoDispo.Text);
                    totSku = decimal.Parse(GVRow.Cells[29].Text);
                    rollos_tarima = decimal.Parse(GVRow.Cells[30].Text);
                    Label lblMTSR = (Label)GVRow.Cells[31].FindControl("lblMTSR");
                    mts_rollos = decimal.Parse(lblMTSR.Text);


                    using (SqlConnection scn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BPconnetion"].ConnectionString))
                    {
                        SqlCommand scm = new SqlCommand();
                        scm.Connection = scn;
                        scm.CommandText = String.Format("INSERT INTO WebAppBasicos_parisina " +
                        "(telanom, color_bar, desc_cliente, inv_int_trans, rollos_ped_xsurtir, rollos_ped_xsurtir_old, " +
                        "rollos_ped_surtidos, ExistTotal, com_sug_tarima, sobra_desp_compra, faltanteAlmacen, faltAlmPedido," +
                        "max_tarima, preorden_tarima, temporada_tarima, dispo_tarima, resurtido_rollos, resurtido_mts, " +
                        "resurtido_tarima, tarima_extra, autorizadoXpedido, demanda_residual, compra_sugerida, fabTemporadaTarima, " +
                        "fabTemporadaDispo, excedentePedido, excedenteBodega, skuSinExis, skuBajoDisp, contSku_cve, rollos_tarima, rollo_mts, fec_ultact) " +
                        "VALUES ('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},'{32}')", Producto, colorVariante,
                        descCliente, invInteTrans, ped_surtir, ped_viejos_surtir, ped_surtidos, exis_total, com_sug_tarima, sob_des_comp,
                        faltAlm, falAlmPed, max_tarima, punReorden, temp_tarima, tarima_dispo, fabResurtido, fabResurtidoMts, fabResurtidoTarima,
                        tarimaExtraPed, autorizaPed, demResidual, demParisina, fabTempTarima, fabTempDispo, excIncPed, excBodega, skuSinExis,
                        skuBajoDispo, totSku, rollos_tarima, mts_rollos, DateTime.Now.ToString("MM/dd/yyyy"));
                        try
                        {
                            scn.Open();
                            scm.ExecuteNonQuery();
                            scn.Close();
                        }
                        catch (Exception ex)
                        {
                            scn.Close();
                            error = ex.Message;
                        }
                    }
                }
            }
            if (string.IsNullOrEmpty(error) == true)
            {
                Response.Write("<script type=\"text/javascript\">alert('Procesado Exitosamente'); window.location.href = 'Inicio.aspx';</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Ocurrio un error" + error + "'); window.location.href = 'Inicio.aspx';</script>");
            }            
        }

        protected void ddlBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBusqueda.SelectedIndex.ToString().Equals("0") == false)
            {
                DateTime fecha = DateTime.Parse(ddlBusqueda.SelectedValue.ToString());
                variables.FechaConsulta = fecha.ToString("MM/dd/yyyy");
                Response.Redirect("ConsultaInfo.aspx");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('seleccione otro valor');</script>");
            }
            
        }
    }
}