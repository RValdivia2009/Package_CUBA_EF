using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BusinessRefinery.Barcode.Web;
using BusinessRefinery.Barcode;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.Security;
using Package_WebApp.Properties;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;
using System.Media;

using System.Data.OleDb;

namespace Package_WebApp.PagesMembers
{
    public partial class LUIS_Inventario : System.Web.UI.Page
    {
        double totalWeight = 0;
        decimal totalValor, TotalVolumen = 0;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
              
                Panel1.Visible = false;
                Unload.Enabled = false;
                T_Paquetes1.Text = "";
                HyperLink1.Visible = false;
                LinkButton2.Visible = false;
                linkEliminar.Visible = false;
                id_paq_ToDelete.Text = "";

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //  id_PaqNo.Text = Trackeo.Text;
            Trackeo.Focus();
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView1.SelectedRow;
            id_Unload.Text = row.Cells[8].Text;
            Unload.Enabled = true;
        }

        protected void Unload_Click(object sender, EventArgs e)
        {
            if (id_Unload.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('You must select register  before.....');", true);
            }
            else
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion

                String Query = "Update  dbo.LUIS_Scanning set Inv = null, Repack = null where Paquete = '" + id_Unload.Text + "';";

                SqlCommand MiComando = new SqlCommand(Query, conn);
                conn.Open();
                int FilasAfectadas = MiComando.ExecuteNonQuery();
                conn.Close();
                GridView1.DataBind();
                GridView2.DataBind();
                Unload.Enabled = false;
                id_Unload.Text = "";
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            id_Despacho.Text = Despacho.Text;
            Session["m_id_Despacho"] = id_Despacho.Text; // Pasar valor al otro forms
            GridView1.DataBind();
            int mD = GridView1.Rows.Count;
            if (mD == 0)
            {
                HyperLink1.Visible = false;
                LinkButton2.Visible = false;
                Panel1.Visible = false;
            }
            else
            {
                HyperLink1.Visible = true;
                LinkButton2.Visible = true;
                Panel1.Visible = true;
            }
            GridView1.DataBind();
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string KeyID = e.Row.Cells[5].Text;    // e.Row.RowIndex].Value.ToString();
            if (KeyID == "1")
            {
                System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                imagen.ImageUrl = "~/checkmark.png";
            }



            //  totalizar Gridview
            if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowType != DataControlRowType.EmptyDataRow))
            {
                totalValor += Convert.ToDecimal(e.Row.Cells[2].Text);
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = Convert.ToString(totalValor);
                T_Peso.Text = e.Row.Cells[1].Text;

                double a = 2.2046;
                double b = 0;

                totalWeight = Convert.ToDouble(T_Peso.Text) / a;
                b = Convert.ToDouble(T_Peso.Text) * a;
                b = Math.Round(b, 2);
                T_PesoLb.Text = Convert.ToString(b);
            }
            int nn = GridView1.Rows.Count;
            T_Paquetes.Text = Convert.ToString(nn);
            //------------------


        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView2.SelectedRow;
            id_Unload.Text = row.Cells[1].Text;
            Unload.Enabled = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion

            //"Update  dbo.LUIS_Scanning set Repack = '" + Repack.Text + "', Inv = " + mProcess + " where

            String Query = "Update  dbo.LUIS_Scanning set Inv = null, Repack = null";

            SqlCommand MiComando = new SqlCommand(Query, conn);
            conn.Open();
            int FilasAfectadas = MiComando.ExecuteNonQuery();
            conn.Close();
            GridView1.DataBind();
            GridView2.DataBind();
            Unload.Enabled = false;
            id_Unload.Text = "";
            T_Paquetes1.Text = "";
        }

        protected void Trackeo_TextChanged(object sender, EventArgs e)
        {
            id_PaqNo.Text = Trackeo.Text;
            if (id_PaqNo.Text == "" || Repack.Text == "")
            {
                //System.Media.SystemSounds.Question.Play(); // SystemSounds.Question.Play();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Debe seleccionar Numero de Inventario y No Bag andes de comenzar a escanear...');", true);
                //---sonido
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.Stream = Properties.Resources.S_Fail;
                player.Play();
            }
            else
            {
                int mProcess = 1;
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
                String Query = "Update  dbo.LUIS_Scanning set Repack = '" + Repack.Text + "', Inv = " + mProcess + " where Paquete LIKE '%" + id_PaqNo.Text + "%' AND DireccionRem  LIKE '" + id_Despacho.Text + "'";

                SqlCommand MiComando = new SqlCommand(Query, conn);
                conn.Open();

                int FilasAfectadas = MiComando.ExecuteNonQuery();
                if (FilasAfectadas == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                    player.Stream = Properties.Resources.S_Fail;
                    player.Play();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Paquete inexistente en este Manifiesto...');", true);
                }

                conn.Close();
                GridView2.DataBind();

                int nn = GridView2.Rows.Count;
                T_Paquetes.Text = Convert.ToString(nn);

                GridView1.DataBind();
                Trackeo.Text = "";
                Trackeo.Focus();
            }
        }



        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs z)
        {
            int nn = GridView2.Rows.Count;
            T_Paquetes1.Text = Convert.ToString(nn);


        }

        protected void ImageButtonExcel_Click(object sender, ImageClickEventArgs e)
        {
         

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            GridView2.EnableViewState = false;
           

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(GridView2);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");

          
            


            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }

        private void recorreGrid()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                string mBarCode = row.Cells[1].Text;

                //string mBarCode = e.Row.Cells[1].Text;

                // LLENAR EL BARCODE
                Linear barcode = new Linear();
                barcode.Symbology = Symbology.CODE128;
                barcode.Code = mBarCode;  //"re0123456789";
                barcode.Resolution = 104;
                // barcode.Rotate = Rotate.Rotate180;
                barcode.Format = ImageFormat.Gif;
                String path = Server.MapPath("~/");
                barcode.drawBarcode2ImageFile(path + "Barcode1.gif");
                Image2.ImageUrl = "~/Barcode1.gif";
                //----------------------------------
                //System.Web.UI.WebControls.Image imagen3 = (System.Web.UI.WebControls.Image)e.Row.FindControl("barcodes");
                //imagen3.ImageUrl = "~/Barcode1.gif";
                System.Web.UI.WebControls.Image imagen3 = (System.Web.UI.WebControls.Image)row.FindControl("barcodes");
                imagen3.ImageUrl = "~/Barcode1.gif";

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // id_Despacho.Text = Despacho.Text;

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            // Session["Nombre"] = Convert.ToInt32(ID_Package.Text); // Pasar valor al otro forms
            Session["m_id_Despacho"] = id_Despacho.Text; // Pasar valor al otro forms
        }

        protected void Despacho_TextChanged(object sender, EventArgs e)
        {
            id_Despacho.Text = Despacho.Text;
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            id_paq_ToDelete.Text = row.Cells[7].Text;
            linkEliminar.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {


            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.Stream = Properties.Resources.S_Fail;
            //player.Play();


            //Stream audio = Resources.ResourceManager.GetStream("S_Fail.wav");
            //SoundPlayer player = new SoundPlayer(audio);
            //player.Play();

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = @"e:\S_Fail.wav";
            //player.Play();

            // Console.Beep();





        }

        protected void linkEliminar_Click(object sender, EventArgs e)
        {
            string a = linkEliminar.OnClientClick;

            if (id_paq_ToDelete.Text == null || id_paq_ToDelete.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('DEBE SELECCIONAR EL REGISTRO A ELIMINAR....');", true);
            }
            else
            {
                string SqlString = "DELETE dbo.LUIS_Scanning FROM dbo.LUIS_Scanning where id_Paquete = '" + id_paq_ToDelete.Text + "';";
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    using (SqlCommand MiComando = new SqlCommand(SqlString, conn))
                    {
                        conn.Open();
                        int FilasAfectadas = MiComando.ExecuteNonQuery();
                        conn.Close();
                        GridView1.DataBind();
                        linkEliminar.Visible = false;
                    }
                }
                id_paq_ToDelete.Text = "";
            }
            GridView2.DataBind();

        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int mcuenta = GridView1.Rows.Count;

            string SqlString = "DELETE LUIS_Scanning FROM LUIS_Scanning WHERE DireccionRem = '" + id_Despacho.Text + "';";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                if (id_Despacho.Text == null || id_Despacho.Text == "")
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('DEBE SELECCIONAR UN MANIFIESTO A ELIMINAR....');", true);
                }
                else
                {
                    //DialogResult dial = MessageBox.Show("¿ Esta seguro que Desea Eliminar este Manifiesto? ", "Mensaje de ALERTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);// == DialogResult.No)
                    if (mcuenta != 0)
                    {
                        using (SqlCommand MiComando = new SqlCommand(SqlString, conn))
                        {
                            conn.Open();
                            int FilasAfectadas = MiComando.ExecuteNonQuery();
                            conn.Close();
                            GridView1.DataBind();
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Mamifiesto REMOVED....');", true);
                        }
                        Button1.Enabled = false;
                        GridView1.DataBind();
                        GridView2.DataBind();
                    }
                }
                Despacho.Text = "";
                Panel1.Visible = false;
            }
        }
    }
}