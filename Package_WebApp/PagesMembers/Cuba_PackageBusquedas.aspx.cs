using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data;
using BusinessRefinery.Barcode.Web;
using BusinessRefinery.Barcode;
//using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.Security;
using Package_WebApp.Properties;
using System.Web.UI.HtmlControls;
using System.Media;


namespace Package_WebApp.PageAdmin
{
    public partial class Cuba_PackageBusquedas : System.Web.UI.Page
    {
         string str_sender = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Sender_City, Sender_Phone, Telefono FROM dbo.tbl_Cuba_N_Sender";
        string str_Destino = "SELECT id_Destinatario, Dest_Nombre, Dest_Apellido, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, aa FROM tbl_Cuba_N_Destinatario";
        string selectAgrega = "SELECT id_Cuba_Package_Main, Date, Destinatario, Sender, Note, Estado, Long, Wide, High, Weight, Volumen, Provincia, Municipio, TipoEntrega, Pagado, WR, Usuario, Rate, Precio, Manifiesto FROM dbo.TBL_Cuba_Package_Main";
        string selectAgregaDet = "SELECT id_Cuba_PackageMain_Detalles, Cuba_Package_Main, Descripcion, Cantidad FROM TBL_Cuba_Package_Main_Detalles";

        string mZonaDura = "";
        string mNombreSender = "";
        int nn = 0;
        int posicion;
        int posicionFinal;
        static int max, i = 1; // Para ver secuancia de registro
        private static int visitCounter = 0;

        static SqlCommand cmd;
      //  static int max, i = 1; // Para ver secuancia de registro
        SqlConnection connIn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        private DataTable dtsec;
        private SqlDataAdapter dasec;

        protected void Page_Load(object sender, EventArgs e)
        {
           
           // llenarcomboSender();
            
            if (!IsPostBack)
            {
                llenarcomboSender();
                BuscaUltimoRegistro();
                llenarTipo_Entraga();
                ActializarForms();

                llenarcomboProvincia();
                llenarcomboMunicipios();
                
                llenarcomboDetinatario();
                llenarcomboEstado();
                llenarcomboManifiesto();
             //   llenarcomboManifiestoIMP();
                llenarTipo_Entraga();
                BuscaUltimoRegistro();
                //AgreraPak.Visible = false;
                Label_Sender.Text = "";
                tb_Peso.Text = "3.0";
                lb_Rate.Text = "0.00";
                lb_Precio.Text = "0.00";
                lb_Vol.Text = "0.0";

                tb_Alto.Text = "0";
                tb_Ancho.Text = "0";
                tb_Largo.Text = "0";
                Panel1.Visible = true;
                Panel2.Visible = false;
             }

        }

        protected void BuscaUltimoRegistro()
        {
            string selectLastRecord = "SELECT TOP 1 id_Cuba_Package_Main, Manifiesto FROM dbo.TBL_Cuba_Package_Main ORDER BY id_Cuba_Package_Main DESC";
            SqlConnection cnn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand(selectLastRecord, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            tb_Manifiesto.Text = dr["Manifiesto"].ToString();
            Label1.Text = dr["id_Cuba_Package_Main"].ToString();
            cnn.Close();
        }

        protected void Save_Click(object sender, ImageClickEventArgs e)
        {
            connIn.Open();
            cmd = new SqlCommand("select count(*) FROM dbo.TBL_Cuba_Package_Main", connIn); // Para ver secuancia de registro
            max = Convert.ToInt32(cmd.ExecuteScalar()); // Para ver secuancia de registro
            dasec = new SqlDataAdapter(selectAgrega, connIn);
            dtsec = new DataTable();
            dasec.Fill(dtsec);
            posicionFinal = (dtsec.Rows.Count) - 1;
            connIn.Close();


            if (tb_Sender.Text == "<-- Sender -->" || tb_Destinatario.Text == "<-- Destinatario -->" || tb_DestProvincia.Text == "<-- Provincia -->" || tb_DestMinicipio.Text == "<-- Municipio -->" || tb_TipoEntrega.Text == "<-- Tipo Entrega -->" || tb_Peso.Text == null || tb_Largo.Text == null || tb_Ancho.Text == null || tb_Alto.Text == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('No Campos: Sender, Destinatario, Provincia, Municipio and Tipo Entrega  are REQUIRED....');", true);
            }
            else
            {
                CalulaPrecio();
                CalulaPieCuv();
                //conecxion a la base de datos..
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
                SqlDataAdapter da = new SqlDataAdapter(selectAgrega, conn);   // creo dataadapter
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                SqlCommandBuilder cb = new SqlCommandBuilder(da);

                DataTable dt = new DataTable();
                da.Fill(dt);

                     // --------- BLOQUE PARA ASIGNAR CONCECUTIVO ANTES DE GUARDAR
                i = max; // Para ver secuancia de registro
                posicion = max;
                visitCounter = posicion;
                visitCounter++; // Increase each time a form is loaded
                TextBoxID.Text = visitCounter.ToString("WR000000"); // Format the counter
                WR.Text = TextBoxID.Text;
                // ---------- FIN DEL BLOQUE
                
                DataRow drnew = dt.NewRow();

                drnew["WR"] = WR.Text;
                drnew["Note"] = tb_Notas.Text;
                drnew["Date"] = FechaHoy.Text;
                drnew["Sender"] = tb_Sender.SelectedValue;
                drnew["Destinatario"] = tb_Destinatario.SelectedValue;
                drnew["Estado"] = 1;
                drnew["TipoEntrega"] = tb_TipoEntrega.SelectedValue;
                drnew["Provincia"] = tb_DestProvincia.SelectedValue;
                drnew["Municipio"] = tb_DestMinicipio.SelectedValue;
                drnew["Weight"] = tb_Peso.Text;
                drnew["Long"] = tb_Largo.Text;
                drnew["Wide"] = tb_Ancho.Text;
                drnew["High"] = tb_Alto.Text;
                drnew["Volumen"] = lb_Vol.Text;
                drnew["Rate"] = lb_Rate.Text;
                drnew["Precio"] = lb_Precio.Text;
                drnew["Manifiesto"] = tb_Manifiesto.Text;
                Label1.Text = drnew["id_Cuba_Package_Main"].ToString();


                //Long, Wide, High, Weight, Volumen, Decrip, Employee, Employee1, Provincia, Municipio, TipoEntrega, Pagado, PaqieteNo, WR, Usuario, WRImage
                //drnew["Usuario"] = user;


                // Se añade la nueva fila creada
                dt.Rows.Add(drnew);
                //Actualiza cambios
                da.Update(dt);
                dt.AcceptChanges();
                conn.Close();
                DeshabilitarCajasMain();
                Save.Visible = false;
                update.Visible = false;
                Edit.Visible = true;
                telefono.Text = null;
                GridView1.DataBind();
                Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
                Session["m_WR"] = WR.Text; // Pasar valor al otro forms
          

            }
        }
        protected void telefono_TextChanged(object sender, EventArgs e)
        {
            if(telefono.Text != null || telefono.Text != "")
            {
                str_sender = str_sender + " WHERE Telefono = '" + telefono.Text + "'";
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(str_sender, conn);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Telefono no asociado. Debe registrar al cliente previamente....');", true);

                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    Label_Sender.Text = dr["id_Sender"].ToString();
                //    AgreraPak.Text = "Agregar paquete a:" + " " + dr["Sender_Nombre"].ToString() + " " + dr["Sender_Apellido"].ToString() + "?";
                    id_Sender.Text = dr["id_Sender"].ToString();
                //   // id_Sender.Text = dr["Sender_Nombre"].ToString() + " " + dr["Sender_Apellido"].ToString();
                //    AgreraPak.Visible = true;
                
                }
                conn.Close();
                telefono.Text = null;
            }
            if (Label_Sender.Text != null || Label_Sender.Text != "")
            {
            }
            SqlDataSource1.SelectCommand = "SELECT id_Cuba_Package_Main, WR, Date, Estado FROM TBL_Cuba_Package_Main  WHERE Sender = '" + Label_Sender.Text + "'";
          
            // int aa = GridView1.Rows.Count;


            GridView1.SelectedIndex = -1;
        }

  //-------- Inicio Seccion Gridview1--------------------------------------------------
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Label1.Text = gr.Cells[1].Text;
            Panel1.Visible = true;
            LimpiarCajasMain();
            DeshabilitarCajasMain();

            SqlConnection connEdit = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connEdit.Open();
            string selectEdit = "SELECT id_Cuba_Package_Main, Date, Destinatario, Sender, Note, Estado, Long, Wide, High, Weight, Volumen, Provincia, TipoEntrega, Municipio, Estado, Pagado, WR, Usuario, Rate, Precio, Manifiesto, Tipo_Envio, zona FROM dbo.TBL_Cuba_Package_Main WHERE id_Cuba_Package_Main = '" + Label1.Text + "'";
            dasec = new SqlDataAdapter(selectEdit, connEdit);
            dtsec = new DataTable();
            dasec.Fill(dtsec);
            DataRow dr = dtsec.Rows[0];
            connIn.Close();


            //ID_Package.Text = dr["id_Cuba_Package_Main"].ToString();
            WR.Text = dr["WR"].ToString();
            tb_Sender.SelectedValue = dr["Sender"].ToString();
            llenarcomboSender();
            id_Sender.Text = tb_Sender.SelectedValue;
            llenarcomboDetinatario();
            tb_Destinatario.SelectedValue = dr["Destinatario"].ToString();
            tb_TipoEntrega.SelectedValue = dr["TipoEntrega"].ToString();
            FechaHoy.Text = dr["Date"].ToString();
            tb_Notas.Text = dr["Note"].ToString();
            tb_Manifiesto.SelectedValue = dr["Manifiesto"].ToString();                   
          
            llenarcomboEstado();
            string aa = dr["Estado"].ToString();
            tb_Estado.SelectedValue = aa;  //dr["Estado"].ToString();
            tb_Zona.Text = dr["Zona"].ToString(); 

            tb_DestProvincia.SelectedValue = dr["Provincia"].ToString();
            id_provincia.Text = tb_DestProvincia.SelectedValue;
            llenarcomboMunicipios();
            tb_DestMinicipio.SelectedValue = dr["Municipio"].ToString();
            tb_Peso.Text = dr["Weight"].ToString();
            tb_Largo.Text = dr["Long"].ToString();
            tb_Ancho.Text = dr["Wide"].ToString();
            tb_Alto.Text = dr["High"].ToString();
            lb_Vol.Text = dr["Volumen"].ToString();
            lb_Rate.Text = dr["Rate"].ToString();
            lb_Precio.Text = dr["Precio"].ToString();


            llenarcomboTipoEnvio();
            string bb = dr["Tipo_Envio"].ToString();
            tb_Tipo_Envio.Text = bb;


            Save.Visible = false;
            update.Visible = false;
            Edit.Visible = true;
            Panel2.Visible = false;
            det_New.Visible = true;
            det_Desc.Text = "";
            det_Cant.Text = "";
            Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
            Session["m_WR"] = WR.Text; // Pasar valor al otro forms
            GridView1.SelectedIndex = -1;
        }

        protected void update_Click(object sender, ImageClickEventArgs e)
        {
     
            CalulaPrecio();
            CalulaPieCuv();

            //String Query = "Update dbo.TBL_Cuba_Package_Main set date = '" + FechaHoy.Text + "', Destinatario = " + tb_Destinatario.SelectedValue + ", Long = " + mL + ", Wide = " + mA + ", High = " + mH + ", Rate = " + mRate + ", Precio = " + mPrecio + ", Volumen = " + mV + ", Weight = " + mPeso + ", Sender = " + tb_Sender.SelectedValue + ", Provincia = " + tb_DestProvincia.SelectedValue + ", Estado = " + tb_Estado.SelectedValue + ", Municipio = " + tb_DestMinicipio.SelectedValue + ", TipoEntrega = " + tb_TipoEntrega.SelectedValue + ", note = '" + tb_Notas.Text + "', Manifiesto = " + tb_Manifiesto.SelectedValue + " where id_Cuba_Package_Main = '" + Label1.Text + "';";           //, Weight = '" + tb_Peso.Text + "', Long = '" + tb_Largo.Text + "', High = '" + tb_Alto.Text + "', Volumen = '" + lb_Vol.Text + "', Rate = '" + lb_Rate.Text + "', Precio = '" + lb_Precio.Text + "', Wide = '" + tb_Ancho.Text + "' where id_Package_Main = '" + Label1.Text + "';";
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            conn.Open();
            //SqlCommand MiComando = new SqlCommand(Query, conn);
            //int FilasAfectadas = MiComando.ExecuteNonQuery();
            //conn.Close();
            SqlCommand cmdr = new SqlCommand("RegistroALL", conn);
            cmdr.CommandType = CommandType.StoredProcedure;
            cmdr.Parameters.AddWithValue("@TipoAccion", 2);
            cmdr.Parameters.AddWithValue("@id_Cuba_Package_Main", Label1.Text);
            cmdr.Parameters.AddWithValue("@Date", FechaHoy.Text);
            cmdr.Parameters.AddWithValue("@Destinatario", tb_Destinatario.SelectedValue);
            cmdr.Parameters.AddWithValue("@Sender", tb_Sender.SelectedValue);
            cmdr.Parameters.AddWithValue("@Note", tb_Notas.Text);
            cmdr.Parameters.AddWithValue("@Long", tb_Largo.Text);
            cmdr.Parameters.AddWithValue("@Wide", tb_Ancho.Text);
            cmdr.Parameters.AddWithValue("@High", tb_Alto.Text);
            cmdr.Parameters.AddWithValue("@Weight", tb_Peso.Text);
            cmdr.Parameters.AddWithValue("@Provincia", tb_DestProvincia.SelectedValue);
            cmdr.Parameters.AddWithValue("@Municipio", tb_DestMinicipio.SelectedValue);
            cmdr.Parameters.AddWithValue("@Estado", tb_Estado.Text);
            cmdr.Parameters.AddWithValue("@Pagado", 1);
            cmdr.Parameters.AddWithValue("@Usuario", "all");
            cmdr.Parameters.AddWithValue("@TipoEntrega", tb_TipoEntrega.SelectedValue);
            cmdr.Parameters.AddWithValue("@Volumen", lb_Vol.Text);
            cmdr.Parameters.AddWithValue("@Rate", lb_Rate.Text);
            cmdr.Parameters.AddWithValue("@Precio", lb_Precio.Text);
            cmdr.Parameters.AddWithValue("@Manifiesto", tb_Manifiesto.Text);
            cmdr.Parameters.AddWithValue("@WR", WR.Text);
            cmdr.Parameters.AddWithValue("@Tipo_Envio", tb_Tipo_Envio.Text);
            cmdr.Parameters.AddWithValue("@Zona", tb_Zona.Text);

            SqlDataReader dr = cmdr.ExecuteReader();
            conn.Close();
            GridView1.DataBind();
            GridView1.SelectedIndex = -1;
            update.Visible = false;
            Edit.Visible = true;
            
            DeshabilitarCajasMain();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string KeyID = e.Row.Cells[5].Text;    // e.Row.RowIndex].Value.ToString();
                if (KeyID == "1")
                {
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                    imagen.ImageUrl = "/Iconos/Ball_Purple-icon.png";
                }
                if (KeyID == "2")
                {
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                    imagen.ImageUrl = "/Iconos/Ball_Yellow-icon.png";
                }
                if (KeyID == "3")
                {
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                    imagen.ImageUrl = "/Iconos/ball_Red-icon.png";
                }
                if (KeyID == "4")
                {
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                    imagen.ImageUrl = "/Iconos/Ball_Green-icon.png";
                }
                if (KeyID == "5")
                {
                    System.Web.UI.WebControls.Image imagen = (System.Web.UI.WebControls.Image)e.Row.FindControl("ImgSemaforo");
                    imagen.ImageUrl = "/Iconos/Ball_Blue-icon.png";
                }
            }
        }

        public void llenarcomboTipoEnvio()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboTipoEnvio = "SELECT id_Tipo_Envio, Tipo_Envio FROM dbo.tbl_Cuba_N_Tipo_Envio";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboTipoEnvio, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Tipo_Envio");
            tb_Tipo_Envio.DataSource = ds.Tables[0].DefaultView;
            tb_Tipo_Envio.DataValueField = "id_Tipo_Envio";
            tb_Tipo_Envio.DataTextField = "Tipo_Envio";
            //filt_Manifiesto.Text = tb_Manifiesto.SelectedValue;
            tb_Tipo_Envio.DataBind();
            conn.Close();
            //tb_Tipo_Envio.Items.Insert(0, "<-- Tipo Envio -->");
        }

        public void llenarcomboManifiesto()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboManif = "SELECT id_Manifiestos, Nom_Manifiesto, Fecha FROM dbo.tbl_Cuba_Manifiestos";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboManif, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_Manifiestos");
            tb_Manifiesto.DataSource = ds.Tables[0].DefaultView;
            tb_Manifiesto.DataValueField = "id_Manifiestos";
            tb_Manifiesto.DataTextField = "Nom_Manifiesto";
            //filt_Manifiesto.Text = tb_Manifiesto.SelectedValue;
            tb_Manifiesto.DataBind();
            conn.Close();
           // tb_Sender.Items.Insert(0, "<-- Sender -->");
        }
        //public void llenarcomboManifiestoIMP()
        //{
        //    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
        //    String selectcomboManif = "SELECT id_Manifiestos, Nom_Manifiesto, Fecha FROM dbo.tbl_Cuba_Manifiestos";
        //    SqlDataAdapter da = new SqlDataAdapter(selectcomboManif, conn);   // creo dataadapter
        //    da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
        //    System.Data.DataSet ds = new System.Data.DataSet();
        //    da.Fill(ds, "tbl_Cuba_Manifiestos");
        //    tb_ManifiestoIMP.DataSource = ds.Tables[0].DefaultView;
        //    tb_ManifiestoIMP.DataValueField = "id_Manifiestos";
        //    tb_ManifiestoIMP.DataTextField = "Nom_Manifiesto";
        //    tb_ManifiestoIMP.DataBind();
        //    conn.Close();
        //    tb_ManifiestoIMP.Items.Insert(0, "<-- Manifiesto -->");
        //} 

        public void llenarcomboSender()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboMuni = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Sender_City, Sender_Phone, Telefono FROM tbl_Cuba_N_Sender  ORDER BY Sender_Nombre";// WHERE id_Provincias = '" + id_provincia.Text + "' ORDER BY Municipios;";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboMuni, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Sender");
            tb_Sender.DataSource = ds.Tables[0].DefaultView;
            tb_Sender.DataValueField = "id_Sender";
            tb_Sender.DataTextField = "Sender_Nombre";
            id_Sender.Text = tb_Sender.SelectedValue;
            tb_Sender.DataBind();
            conn.Close();
            tb_Sender.Items.Insert(0, "<-- Sender -->");
        }
        public void llenarcomboDetinatario()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboMuni = "SELECT id_Destinatario, Dest_Nombre, Dest_Apellido, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, aa FROM tbl_Cuba_N_Destinatario WHERE Sender = '" + id_Sender.Text + "' ORDER BY Dest_Nombre;";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboMuni, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Sender");
            tb_Destinatario.DataSource = ds.Tables[0].DefaultView;
            tb_Destinatario.DataValueField = "id_Destinatario";
            tb_Destinatario.DataTextField = "Dest_Nombre";
            id_Destinatario.Text = tb_Destinatario.SelectedValue;
            tb_Destinatario.DataBind();
            conn.Close();
            tb_Destinatario.Items.Insert(0, "<-- Destinatario -->");
        }

        public void llenarcomboProvincia()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboProv = "SELECT id_Provincia, Provincia FROM dbo.tbl_Cuba_N_Provincias ORDER BY id_Provincia";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboProv, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Provincias");
            tb_DestProvincia.DataSource = ds.Tables[0].DefaultView;
            tb_DestProvincia.DataValueField = "id_Provincia";
            tb_DestProvincia.DataTextField = "Provincia";
            id_provincia.Text = tb_DestProvincia.SelectedValue;
            tb_DestProvincia.DataBind();
            conn.Close();
            tb_DestProvincia.Items.Insert(0, "<-- Provincia -->");
        }
        public void llenarcomboMunicipios()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboMuni = "SELECT id_Municipios, Municipios, id_Provincias FROM dbo.tbl_Cuba_N_Municipios WHERE id_Provincias = '" + tb_DestProvincia.Text + "' ORDER BY Municipios;";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboMuni, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Municipios");
            tb_DestMinicipio.DataSource = ds.Tables[0].DefaultView;
            tb_DestMinicipio.DataValueField = "id_Municipios";
            tb_DestMinicipio.DataTextField = "Municipios";
            id_Destinatario.Text = tb_Destinatario.SelectedValue;
            tb_DestMinicipio.DataBind();
            conn.Close();
            tb_DestMinicipio.Items.Insert(0, "<-- Municipio -->");
        }
        public void llenarTipo_Entraga()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboEnt = "SELECT id_TipoEntrega, TipoEntrega, Rate FROM tbl_Cuba_N_TipoEntrega";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboEnt, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_TipoEntrega");
            tb_TipoEntrega.DataSource = ds.Tables[0].DefaultView;
            tb_TipoEntrega.DataValueField = "id_TipoEntrega";
            tb_TipoEntrega.DataTextField = "TipoEntrega";
            id_TipoEntrega.Text = tb_TipoEntrega.SelectedValue;
            tb_TipoEntrega.DataBind();
            conn.Close();
            tb_TipoEntrega.Items.Insert(0, "<-- Tipo Entrega -->");
        }

        public void llenarcomboEstado()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboEst = "SELECT id_Estado, Estado FROM dbo.tbl_Cuba_N_Estados";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboEst, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_Cuba_N_Estados");
            tb_Estado.DataSource = ds.Tables[0].DefaultView;
            tb_Estado.DataValueField = "id_Estado";
            tb_Estado.DataTextField = "Estado";
            tb_Estado.DataBind();
            conn.Close();
            tb_Estado.Items.Insert(0, "<-- Estado -->");
        }

        protected void tb_DestProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_DestProvincia.Text = id_provincia.Text;
            llenarcomboMunicipios();
        }

       
       protected void tb_Destinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Sender.Text = id_Sender.Text;
          //  tb_Destinatario.Text = id_Destinatario.Text;
            id_Destinatario.Text = tb_Destinatario.SelectedValue;

            str_Destino = str_Destino + " WHERE id_Destinatario = '" + id_Destinatario.Text + "'";
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(str_Destino, conn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('4444444444444444444....');", true);
            }
            else
            {
                DataRow dr = dt.Rows[0];
               // Label_Sender.Text = dr["id_Sender"].ToString();
            
                tb_DestProvincia.Text = dr["Provincias"].ToString();
                id_provincia.Text = tb_DestProvincia.Text;
                string mm = dr["Municipio"].ToString();
                //id_Municipio.Text = dr["Municipio"].ToString();
                llenarcomboMunicipios();
                tb_DestMinicipio.SelectedValue = dr["Municipio"].ToString();
                //tb_DestMinicipio.SelectedValue = id_Municipio.Text;
                // -------------Busca la zona
                String selectcZona = "SELECT dbo.tbl_Cuba_N_Provincias.id_Provincia, dbo.tbl_Cuba_N_Provincias.Provincia, dbo.tbl_Cuba_N_Zonas.Zona, dbo.tbl_Cuba_N_Zonas.id_Zona FROM dbo.tbl_Cuba_N_Provincias INNER JOIN dbo.tbl_Cuba_N_Zonas ON dbo.tbl_Cuba_N_Provincias.Zona = dbo.tbl_Cuba_N_Zonas.id_Zona";
                selectcZona = selectcZona + " WHERE tbl_Cuba_N_Provincias.id_Provincia = " + id_provincia.Text + ";";
                SqlDataAdapter daz = new SqlDataAdapter(selectcZona, conn);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                DataTable dtz = new DataTable();
                daz.Fill(dtz);
                DataRow drz = dtz.Rows[0];
                tb_Zona.Text = drz["Zona"].ToString();
            }
        }
   
        protected void AgreraPak_Click(object sender, EventArgs e)
       {
           LimpiarCajasMain();
           HabilitarCajasMain();
           //AgreraPak.Visible = false;
           Panel1.Visible = true;
           tb_Sender.Text = id_Sender.Text;
           nn = Convert.ToInt32(id_Sender.Text);
           tb_Sender_TextChanged(nn, null);
           FechaHoy.Text = DateTime.Now.ToString();
           Panel2.Visible = false;
           det_New.Visible = true;
           det_Desc.Text = "";
           det_Cant.Text = "";
           Label1.Text = "";
           GridView2.DataBind();
           update.Visible = false;
           Edit.Visible = false;
           Save.Visible = true;
           GridView1.SelectedIndex = -1;
         

       }

        protected void tb_Sender_SelectedIndexChanged1(object sender, EventArgs e)
        {
            id_Sender.Text = tb_Sender.Text;
            llenarcomboDetinatario();

        }

        protected void tb_Sender_TextChanged(object sender, EventArgs e)
        {
            tb_Sender.Text = id_Sender.Text;
            llenarcomboDetinatario();
        }

        protected void tb_DestMinicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tb_TipoEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_TipoEntrega.Text = tb_TipoEntrega.SelectedValue;
            string str_Entrega = "SELECT id_TipoEntrega, TipoEntrega, Rate FROM tbl_Cuba_N_TipoEntrega WHERE id_TipoEntrega = '" + id_TipoEntrega.Text + "' ORDER BY TipoEntrega;";
          
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(str_Entrega, conn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            conn.Close();
            lb_Rate.Text = dr["Rate"].ToString();

            //decimal mRate = Convert.ToDecimal(lb_Rate.Text);
            //decimal mPeso = Convert.ToDecimal(tb_Peso.Text);
            //decimal mPrecio = mRate * mPeso;
            //lb_Precio.Text = Convert.ToString(Math.Round(mPrecio, 2));
        }

        private void CalulaPrecio()
        {
            string mbusca = "";
            decimal mRate = 0;
            decimal mPeso = Convert.ToDecimal(tb_Peso.Text);
            string mLetraFiltro = "";
            if (tb_TipoEntrega.Text == "1")
            {
                mLetraFiltro = "R";
            }
            else
            {
                mLetraFiltro = tb_Zona.Text;
            }

            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                if (tb_Tipo_Envio.Text == "1")
                {
                    // -------------Busca la tarifa degun zona en miscenaleas

                    tbl_Cuba_N_Tarif_Miscelaneos mMnif = (from q in conect.tbl_Cuba_N_Tarif_Miscelaneos
                                                          where q.Zona == mLetraFiltro
                                                          select q).First();
                    mRate = Convert.ToDecimal(mMnif.M_Rate);

                }

                // -------------Busca la tarifa degun zona en duraderos
                if (tb_Tipo_Envio.Text == "2")
                {
                    int mProv = Convert.ToInt32(tb_DestProvincia.Text);
                    var Myprov = (from mZonaD in conect.tbl_Cuba_N_Zonas_Dura

                                  from mProvi in mZonaD.tbl_Cuba_N_Provincias
                                  where mProvi.id_Provincia == mProv
                                  select new
                                  {
                                      Zona_tbl_Zona = mZonaD.Zona_Dura,
                                  });

                    foreach (var Myvalor in Myprov)
                    {
                        mZonaDura = Myvalor.Zona_tbl_Zona.ToString();
                    }

                    IQueryable<tbl_Cuba_N_tarif_Duraderos> mDura = (from q in conect.tbl_Cuba_N_tarif_Duraderos
                                                                    where mPeso >= q.Desde && mPeso <= q.Hasta && q.Zonas == mZonaDura
                                                                    select q);

                    List<tbl_Cuba_N_tarif_Duraderos> lista = mDura.ToList();
                    var mRegistros = lista.FirstOrDefault();
                    int dtd = lista.Count();
                    if (dtd == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Peso fuera de rango en Tarifa....');", true);
                    }
                    else
                    {
                        mRate = Convert.ToDecimal(mRegistros.D_Rate);
                    }
                }
                decimal mPrecio = mRate * mPeso;
                lb_Rate.Text = Convert.ToString(mRate);
                lb_Precio.Text = Convert.ToString(Math.Round(mPrecio, 2));

            }
        
        }
        private void CalulaPieCuv()
        {
            decimal mL = Convert.ToDecimal(tb_Largo.Text);
            decimal mA = Convert.ToDecimal(tb_Ancho.Text);
            decimal mH = Convert.ToDecimal(tb_Alto.Text);
            decimal mV = (mA * mL * mH) / 1728;
            lb_Vol.Text = Convert.ToString(Math.Round(mV, 2));
        }

        protected void tb_Ancho_TextChanged(object sender, EventArgs e)
        {
            CalulaPieCuv();
            tb_Alto.Focus();
        }

        protected void tb_Alto_TextChanged(object sender, EventArgs e)
        {
            CalulaPieCuv();
        }

        protected void tb_Largo_TextChanged(object sender, EventArgs e)
        {
            CalulaPieCuv();
            tb_Ancho.Focus();
        }

        protected void tb_Peso_TextChanged(object sender, EventArgs e)
        {
            CalulaPrecio();
            tb_Largo.Focus();
        }

     

        protected void tb_Largo_PreRender(object sender, EventArgs e)
        {
            CalulaPrecio();
        }
        public void DeshabilitarCajasMain()
        {
            FechaHoy.Enabled = false;
            tb_Sender.Enabled = false;
            tb_Destinatario.Enabled = false;
            tb_DestProvincia.Enabled = false;
            tb_DestMinicipio.Enabled = false;
            tb_TipoEntrega.Enabled = false;
            tb_Estado.Enabled = false;
            tb_Notas.Enabled = false;
            tb_Peso.Enabled = false;
            tb_Largo.Enabled = false;
            tb_Ancho.Enabled = false;
            tb_Alto.Enabled = false;
            tb_Manifiesto.Enabled = false;
            tb_Tipo_Envio.Enabled = false;
        }
        public void HabilitarCajasMain()
        {
            FechaHoy.Enabled = true;
            tb_Sender.Enabled = true;
            tb_Destinatario.Enabled = true;
            tb_DestProvincia.Enabled = true;
            tb_DestMinicipio.Enabled = true;
            tb_TipoEntrega.Enabled = true;
            tb_Estado.Enabled = true;
            tb_Notas.Enabled = true;
            tb_Peso.Enabled = true;
            tb_Largo.Enabled = true;
            tb_Ancho.Enabled = true;
            tb_Alto.Enabled = true;
            tb_Manifiesto.Enabled = true;
            tb_Tipo_Envio.Enabled = true;
        }
        public void LimpiarCajasMain()
        {
            WR.Text = "WR";
            FechaHoy.Text = null;
            tb_Sender.Text = null;
            tb_Destinatario.Text = null;
            tb_DestProvincia.Text = null;
            tb_DestMinicipio.Text = null;
            tb_TipoEntrega.Text = null;
            tb_Tipo_Envio.Text = null;
            tb_Notas.Text = null;
            tb_Peso.Text = "0.0";
            lb_Rate.Text = "0.00";
            tb_Largo.Text = "0.0";
            tb_Ancho.Text = "0.0";
            tb_Alto.Text = "0.0";
            lb_Precio.Text = "0.00";
            lb_Vol.Text = "0.0";
        }

     

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            HabilitarCajasMain();
            tb_Sender.Enabled = false;
            tb_Destinatario.Enabled = true;
            tb_DestProvincia.Enabled = false;
            tb_DestMinicipio.Enabled = false;
            Edit.Visible = false;
            update.Visible = true;
        
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            if (Label1.Text == null || Label1.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Debe guardar cambios antes de continuar....');", true);
            }
            else
            {
                Panel2.Visible = true;
                det_New.Visible = false;
                det_Id_sender.Text = Label1.Text;
                det_Desc.Focus();
            }

        }

        protected void det_Save_Click(object sender, ImageClickEventArgs e)
        {
            if (det_Cant.Text == "" || det_Desc.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Descripcion y Cantidad no deben ser nulos....');", true);
            }
            else
            {
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                    TBL_Cuba_Package_Main_Detalles Mydetail = new TBL_Cuba_Package_Main_Detalles
                    {
                        Cuba_Package_Main = Convert.ToInt32(Label1.Text),
                        Cantidad = Convert.ToDecimal(det_Cant.Text),
                        Descripcion = det_Desc.Text
                    };
                    conect.TBL_Cuba_Package_Main_Detalles.AddObject(Mydetail);
                    conect.SaveChanges();

                }

                Panel2.Visible = false;
                det_New.Visible = true;
                det_Desc.Text = "";
                det_Cant.Text = "";
                // llenarGridview6();
                GridView2.DataBind();

            }
            det_New.Focus();

            Actual_DetalleTMP();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.SelectedIndex = -1;
        }

        protected void ImageButtonWR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Reports/WareHouseReceive.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/N_shipper.aspx");
        }

        protected void ImageButtonLabel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Reports/WareHouse_Label.aspx");
        }

        protected void tb_Manifiesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            filt_Manifiesto.Text = tb_Manifiesto.SelectedValue;
        }

        protected void NoPaquete_TextChanged(object sender, EventArgs e)
        {

            if (NoPaquete.Text != null)
            {
                selectAgrega = selectAgrega + " WHERE WR = '" + NoPaquete.Text + "'";
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(selectAgrega, conn);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Paquete inexistente....');", true);

                }
                else
                {
                    DataRow dr = dt.Rows[0];
                    Label1.Text = dr["id_Cuba_Package_Main"].ToString();
                    SqlDataSource1.SelectCommand = "SELECT id_Cuba_Package_Main, WR, Date, Estado FROM TBL_Cuba_Package_Main  WHERE id_Cuba_Package_Main = '" + Label1.Text + "'";
                    GridView1.SelectedIndex = -1;
                }
                conn.Close();
                NoPaquete.Text = null;
       

            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT id_Cuba_Package_Main, WR, Date, Estado FROM TBL_Cuba_Package_Main";
                GridView1.DataBind();
                GridView1.SelectedIndex = -1;
               
                DeshabilitarCajasMain();

            }
        }
        protected void ActializarForms()
        {
            LimpiarCajasMain();
            DeshabilitarCajasMain();
            llenarcomboTipoEnvio();

            SqlConnection connEdit = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connEdit.Open();
            string selectEdit = "SELECT id_Cuba_Package_Main, Date, Destinatario, Sender, Note, Estado, Long, Wide, High, Weight, Volumen, Provincia, TipoEntrega, Municipio, Estado, Pagado, WR, Usuario, Rate, Precio, Manifiesto, Tipo_Envio, zona FROM dbo.TBL_Cuba_Package_Main WHERE id_Cuba_Package_Main = '" + Label1.Text + "'";
            dasec = new SqlDataAdapter(selectEdit, connEdit);
            dtsec = new DataTable();
            dasec.Fill(dtsec);
            DataRow dr = dtsec.Rows[0];
            connIn.Close();
            //ID_Package.Text = dr["id_Cuba_Package_Main"].ToString();
            WR.Text = dr["WR"].ToString();
            tb_Sender.SelectedValue = dr["Sender"].ToString();
            llenarcomboSender();
            id_Sender.Text = tb_Sender.SelectedValue;
            llenarcomboDetinatario();
            tb_Destinatario.SelectedValue = dr["Destinatario"].ToString();
            tb_TipoEntrega.SelectedValue = dr["TipoEntrega"].ToString();
            FechaHoy.Text = dr["Date"].ToString();
            tb_Notas.Text = dr["Note"].ToString();
            tb_Manifiesto.SelectedValue = dr["Manifiesto"].ToString();
            
            llenarcomboEstado();
            string aa = dr["Estado"].ToString();
            tb_Estado.SelectedValue = aa;  //dr["Estado"].ToString();
            
            llenarcomboTipoEnvio();
            string bb = dr["Tipo_Envio"].ToString();
            tb_Tipo_Envio.Text = bb;
            tb_Zona.Text = dr["Zona"].ToString();

            tb_DestProvincia.SelectedValue = dr["Provincia"].ToString();
            id_provincia.Text = tb_DestProvincia.SelectedValue;
            llenarcomboMunicipios();
            tb_DestMinicipio.SelectedValue = dr["Municipio"].ToString();
            tb_Peso.Text = dr["Weight"].ToString();
            tb_Largo.Text = dr["Long"].ToString();
            tb_Ancho.Text = dr["Wide"].ToString();
            tb_Alto.Text = dr["High"].ToString();
            lb_Vol.Text = dr["Volumen"].ToString();
            lb_Rate.Text = dr["Rate"].ToString();
            lb_Precio.Text = dr["Precio"].ToString();
            

            Save.Visible = false;
            update.Visible = false;
            Edit.Visible = true;
            Panel2.Visible = false;
            det_New.Visible = true;
            det_Desc.Text = "";
            det_Cant.Text = "";
            Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
            Session["m_WR"] = WR.Text; // Pasar valor al otro forms

        }

        private void Actual_DetalleTMP()
        {
            using (DB_82130_itndatabaseEntities connect_Main = new DB_82130_itndatabaseEntities())
            {
                int mId = Convert.ToInt32(Label1.Text);
                var My_Main = (from p in connect_Main.TBL_Cuba_Package_Main
                               where p.id_Cuba_Package_Main == mId
                               select p).First();
                My_Main.Descrip_Detalles = "";
                connect_Main.SaveChanges();
            }
            using (DB_82130_itndatabaseEntities connect_Main = new DB_82130_itndatabaseEntities())
            {



                int mId = Convert.ToInt32(Label1.Text);
                var My_Main = (from p in connect_Main.TBL_Cuba_Package_Main
                               where p.id_Cuba_Package_Main == mId
                               select p).First();

                var MyDetalle = from m in connect_Main.TBL_Cuba_Package_Main_Detalles
                                where m.Cuba_Package_Main == mId
                                select m;

                string mTexto = "";
                foreach (var t in MyDetalle)
                {
                    mTexto = mTexto + " " + t.Cantidad + " " + t.Descripcion + ",";
                }
                My_Main.Descrip_Detalles = mTexto;
                connect_Main.SaveChanges();


            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Actual_DetalleTMP();
        }

        protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Actual_DetalleTMP();
        }

      
    }
}