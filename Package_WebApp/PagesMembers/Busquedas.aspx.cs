using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.ProviderBase;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Package_WebApp.Properties;
using BusinessRefinery.Barcode.Web;
using BusinessRefinery.Barcode;
using Microsoft.Office.Interop.Excel;
using System.Web.UI.HtmlControls;


namespace Package_WebApp.PagesMembers
{
    public partial class Busquedas : System.Web.UI.Page
    {


      string selectInicio = "SELECT dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main, dbo.TBL_Cuba_Package_Main.WR, CONVERT(varchar,dbo.TBL_Cuba_Package_Main.Date, 101) AS Date, dbo.tbl_Cuba_N_Sender.Sender_Nombre + '  ' + dbo.tbl_Cuba_N_Sender.Sender_Apellido AS SenderNom, " + 
                    "dbo.tbl_Cuba_N_Destinatario.Dest_Nombre + ' ' + dbo.tbl_Cuba_N_Destinatario.Dest_Apellido AS DestNom, dbo.TBL_Cuba_Package_Main.Destinatario, dbo.TBL_Cuba_Package_Main.Sender, dbo.TBL_Cuba_Package_Main.Estado, dbo.TBL_Cuba_Package_Main.TipoEntrega, dbo.TBL_Cuba_Package_Main.Zona, " +
                    "dbo.TBL_Cuba_Package_Main.Tipo_Envio, dbo.TBL_Cuba_Package_Main.Weight, dbo.tbl_Cuba_N_Estados.Estado AS Est, " +
                    "dbo.tbl_Cuba_N_Tipo_Envio.Tipo_Envio AS TipoEnvio, " +
                    "dbo.tbl_Cuba_N_TipoEntrega.TipoEntrega AS TipoEnt, dbo.TBL_Cuba_Package_Main.AEB AS AWB " +
                    "FROM dbo.tbl_Cuba_N_Destinatario INNER JOIN dbo.TBL_Cuba_Package_Main ON dbo.tbl_Cuba_N_Destinatario.id_Destinatario = dbo.TBL_Cuba_Package_Main.Destinatario  " +

                    "INNER JOIN dbo.tbl_Cuba_N_Sender ON dbo.TBL_Cuba_Package_Main.Sender = dbo.tbl_Cuba_N_Sender.id_Sender " +
                    "INNER JOIN dbo.tbl_Cuba_N_Estados ON dbo.TBL_Cuba_Package_Main.Estado = dbo.tbl_Cuba_N_Estados.id_Estado " + 
                    "INNER JOIN dbo.tbl_Cuba_N_Tipo_Envio ON dbo.TBL_Cuba_Package_Main.Tipo_Envio = dbo.tbl_Cuba_N_Tipo_Envio.id_Tipo_Envio " + 
                    "INNER JOIN dbo.tbl_Cuba_N_TipoEntrega ON dbo.TBL_Cuba_Package_Main.TipoEntrega = dbo.tbl_Cuba_N_TipoEntrega.id_TipoEntrega";



        string dateStringDesde = null;
        string dateStringHasta = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                f_desde.Enabled = false;
                f_hasta.Enabled = false;
                // actualIzaGridView();
                llenarcomboCnee();
                llenarcomboestado();
                llenarcombodestino();
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFechas.Checked == true)
            {
                f_desde.Enabled = true;
                f_hasta.Enabled = true;
            }
            else
            {
                f_desde.Enabled = false;
                f_hasta.Enabled = false;
            }
        }

        private void actualIzaGridView()
        {

           if (checkFechas.Checked == false)
            {
                dateStringDesde = "01/01/2014";
                Convert.ToDateTime(dateStringDesde);
                dateStringHasta = "01/01/2200";
                Convert.ToDateTime(dateStringHasta);
                f_desde.Text = dateStringDesde;
                f_hasta.Text = dateStringHasta;
                selectInicio = selectInicio + " WHERE ( Date  Between '" + dateStringDesde + "' and '" + dateStringHasta + "')";
                if (tb_Sender.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Sender = " + tb_Sender.SelectedValue; 
                }
                if (tb_Estado.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Estado = " + tb_Estado.SelectedValue; 
                }
                if (tb_Tipo_Envio.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and TBL_Cuba_Package_Main.Tipo_Envio = " + tb_Tipo_Envio.SelectedValue; 
                }
                if (telefono.Text != "")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Sender  =  " + id_Sender.Text; 

                }
                if ( TextBoxAWB.Text != "")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.AEB LIKE '%" + TextBoxAWB.Text + "%'";
                }


            }

            else
            {
                dateStringDesde = f_desde.Text + " " + "00:00:00.000";
                dateStringHasta = f_hasta.Text + " " + "23:59:59.000";
                selectInicio = selectInicio + " WHERE ( Date  Between '" + dateStringDesde + "' and '" + dateStringHasta + "')";
                if (tb_Sender.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Sender = " + tb_Sender.SelectedValue; 
                }
                if (tb_Estado.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Estado = " + tb_Estado.SelectedValue; 
                }
                if (tb_Tipo_Envio.SelectedValue.ToString() != "<-- Select -->")
                {
                    selectInicio = selectInicio + " and TBL_Cuba_Package_Main.Tipo_Envio = " + tb_Tipo_Envio.SelectedValue; 
                }
                if (telefono.Text != "")
                {
                    selectInicio = selectInicio + " and dbo.TBL_Cuba_Package_Main.Sender  =  " + id_Sender.Text; 
                }
                if (TextBoxAWB.Text != "")
                {
                    selectInicio = selectInicio + " and dbo.tbl_Despachos.AWB LIKE '%" + TextBoxAWB.Text + "%'";
                  
                }
            }

           selectInicio = selectInicio + "ORDER BY dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main DESC";

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            SqlDataAdapter da = new SqlDataAdapter(selectInicio, conn);   // creo dataadapter
            System.Data.DataTable DT = new System.Data.DataTable();
            da.Fill(DT);
            GridView1.DataSource = DT;
            GridView1.AllowSorting = false;
            GridView1.AllowPaging = false;

            GridView1.DataBind();

            
            if (DT.Rows.Count > 0)
            {
                
     //string selectInicio = "SELECT (0 )dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main, (1 )dbo.TBL_Cuba_Package_Main.WR, (2 )CONVERT(varchar,dbo.TBL_Cuba_Package_Main.Date, 101) AS Date, (3 )dbo.tbl_Cuba_N_Sender.Sender_Nombre + '  ' + dbo.tbl_Cuba_N_Sender.Sender_Apellido AS SenderNom, " + 
     //               "(4 )dbo.tbl_Cuba_N_Destinatario.Dest_Nombre + ' ' + dbo.tbl_Cuba_N_Destinatario.Dest_Apellido AS DestNom, (5)dbo.TBL_Cuba_Package_Main.Destinatario, (6)dbo.TBL_Cuba_Package_Main.Sender, (7)dbo.TBL_Cuba_Package_Main.Estado, (8)dbo.TBL_Cuba_Package_Main.TipoEntrega, (9)dbo.TBL_Cuba_Package_Main.Zona, " +
     //               "(10)dbo.TBL_Cuba_Package_Main.Tipo_Envio, (11)dbo.TBL_Cuba_Package_Main.Weight, (12)dbo.tbl_Cuba_N_Estados.Estado AS Est, " +
     //               "(13)dbo.tbl_Cuba_N_Tipo_Envio.Tipo_Envio AS TipoEnvio, " +
     //               "(14)dbo.tbl_Cuba_N_TipoEntrega.TipoEntrega AS TipoEnt, (15)dbo.TBL_Cuba_Package_Main.AEB AS AWB " +

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridView1.HeaderRow.Cells[0].Visible = false;
                    GridView1.HeaderRow.Cells[5].Visible = false;
                    GridView1.HeaderRow.Cells[6].Visible = false;
                    GridView1.HeaderRow.Cells[7].Visible = false;
                    GridView1.HeaderRow.Cells[8].Visible = false;
                    GridView1.HeaderRow.Cells[10].Visible = false;
                  //  GridView1.HeaderRow.Cells[22].Visible = false;

                    GridView1.Rows[i].Cells[0].Visible = false;
                    GridView1.Rows[i].Cells[5].Visible = false;
                    GridView1.Rows[i].Cells[6].Visible = false;
                    GridView1.Rows[i].Cells[7].Visible = false;
                    GridView1.Rows[i].Cells[8].Visible = false;
                    GridView1.Rows[i].Cells[10].Visible = false;
                  //  GridView1.Rows[i].Cells[22].Visible = false;

                }
            }

         //   CommandField command = new CommandField();
            
             conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            actualIzaGridView();
        }

        public void llenarcomboCnee()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Tipo_Envio
                                select new { c.id_Tipo_Envio, c.Tipo_Envio }).ToList();
                tb_Tipo_Envio.DataValueField = "id_Tipo_Envio";
                tb_Tipo_Envio.DataTextField = "Tipo_Envio";
                tb_Tipo_Envio.DataSource = category;
                //  tb_Tipo_Envio.Text = tb_Tipo_Envio.SelectedValue;
                tb_Tipo_Envio.DataBind();
                tb_Tipo_Envio.Items.Insert(0, "<-- Select -->");
            }

        }
            public void llenarcomboestado()
            {
                using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
                {
                    var category = (from c in dbconect.tbl_Cuba_N_Estados
                                    select new { c.id_Estado, c.Estado }).ToList();
                    tb_Estado.DataValueField = "id_Estado";
                    tb_Estado.DataTextField = "Estado";
                    tb_Estado.DataSource = category;
                    //  tb_Estado.Text = tb_Estado.SelectedValue;
                    tb_Estado.DataBind();
                    tb_Estado.Items.Insert(0, "<-- Select -->");
                }
           }
            public void llenarcombodestino()
            {
                using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
                {
                    var category = (from c in dbconect.tbl_Cuba_N_Sender
                                    select new { c.id_Sender, Nombre = c.Sender_Nombre + " " + c.Sender_Apellido }).ToList();
                    tb_Sender.DataValueField = "id_Sender";
                    tb_Sender.DataTextField = "Nombre";
                    tb_Sender.DataSource = category;
                    tb_Sender.DataBind();
                    tb_Sender.Items.Insert(0, "<-- Select -->");
                }

            
           }

            protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
            {
                actualIzaGridView();
            }

            protected void ImageButtonExcel_Click(object sender, ImageClickEventArgs e)
            {

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                System.Web.UI.Page page = new System.Web.UI.Page();
                HtmlForm form = new HtmlForm();

                GridView1.EnableViewState = false;

                // Deshabilitar la validación de eventos, sólo asp.net 2
                page.EnableEventValidation = false;

                // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
                page.DesignerInitialize();

                page.Controls.Add(form);
                form.Controls.Add(GridView1);

                page.RenderControl(htw);

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(sb.ToString());
                Response.End();
             
           //     Response.ClearContent();
           //     Response.Charset = "";
           //     Response.ContentType = "application/vnd.ms-excel";
           //     Response.AddHeader("content-disposition", "attachment; filename=Mail_Box.xls");
           //     StringWriter stringWriter = new StringWriter();
           //     HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);

           //     GridView1.RenderControl(htmlTextWriter);
           //     Response.Write(stringWriter.ToString());
           //     Response.End();
              
            }

            protected void telefono_TextChanged(object sender, EventArgs e)
            {
                if (telefono.Text != null || telefono.Text == "")
                {
                    using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                    {
                        var resulta = from q in conect.tbl_Cuba_N_Sender
                                      where q.Telefono == telefono.Text
                                      select q;
                        int dt = resulta.Count();
                        if (dt == 0)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Telefono no asociado. Debe registrar al cliente previamente....');", true);

                        }
                        else
                        {
                            string myPone = telefono.Text;
                            tbl_Cuba_N_Sender Mysender = (from q in conect.tbl_Cuba_N_Sender
                                                          where q.Telefono == telefono.Text
                                                          select q).First();
                           // Label_Sender.Text = Mysender.id_Sender.ToString();
                           // AgreraPak.Text = "Agregar paquete a:" + " " + Mysender.Sender_Nombre.ToString() + " " + Mysender.Sender_Apellido.ToString() + "?";
                            id_Sender.Text = Mysender.id_Sender.ToString();
                            //AgreraPak.Visible = true;
                            //bt_DeCliente.Visible = false;

                        }
                    }
                }
            }

    }
}