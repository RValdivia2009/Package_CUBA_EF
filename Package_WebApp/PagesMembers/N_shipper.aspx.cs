using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Package_WebApp.Properties;
using System.Data.ProviderBase;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Web.Security;



namespace Package_WebApp.PagesMembers
{
    public partial class N_shipper : System.Web.UI.Page
    {
        string str_Destino = "SELECT id_Destinatario, Dest_Nombre, Dest_Apellido, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, aa FROM tbl_Cuba_N_Destinatario";
        string selectSender = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Sender_City, Telefono FROM dbo.tbl_Cuba_N_Sender";
        string str_sender = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Sender_City, Sender_Phone, Telefono FROM dbo.tbl_Cuba_N_Sender";
        string mNombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarcomboProvincia();
           if (!IsPostBack)
           {
               llenarcomboProvincia();
               Panel1.Visible = false;
               Panel2.Visible = false;
               limpiarCajas();
               LlenarGridView1();
               Save.Enabled = false;
               mNombre = "";
           }
         
        }

        public void limpiarCajas()
        {
            TextBox1.Text = "";
            tb_Nombre.Text = "";
            tb_Apellido.Text = "";
            tb_Dir_1.Text = "";
            tb_Dir2.Text = "";
            tb_Dir2.Text = "";
            tb_city.Text = "";
        }
        public void limpiaCajasDest()
        {
            tb_DestCI.Text = "";
            tb_DestEntreCalles.Text = "";
            tb_DestNombre.Text = "";
            tb_DestApellido.Text = "";
            tb_DestCelle.Text = "";
            id_provincia.Text = "";
            Panel2.Visible = false;
          
        }
      
        public void LlenarGridView1()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            SqlDataAdapter da = new SqlDataAdapter(selectSender, conn);   // creo dataadapter
            DataTable DT = new System.Data.DataTable();
            da.Fill(DT);
            //GridView1.DataSource = DT;
            //GridView1.DataBind();

        }
    
       protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
               // Para que funcione la paginacion del Gridview
            //GridView1.PageIndex = e.NewPageIndex;
            LlenarGridView1();
        }

     
     

 
      
       protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
       {
           if (telefono.Text != null || telefono.Text != "")
           {
               str_sender = str_sender + " WHERE Telefono = '" + telefono.Text + "'";
               SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
               SqlDataAdapter da = new SqlDataAdapter(str_sender, conn);
               da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
               DataTable dt = new DataTable();
               da.Fill(dt);
               if (dt.Rows.Count == 0)
               {
                   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Numero de telefono inexistente....');", true);
               }
               else
               {
                   DataRow dr = dt.Rows[0];
                   Label_Sender.Text = dr["id_Sender"].ToString();
                   SqlDataSource1.SelectCommand = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Phone FROM tbl_Cuba_N_Sender WHERE id_Sender = '" + Convert.ToInt32(Label_Sender.Text) + "'";

               }

           }


           if (Label_Sender.Text != null || Label_Sender.Text != "")
           {
           }
           //  SqlDataSource1.SelectCommand = "SELECT id_Cuba_Package_Main, WR, Date, Estado FROM TBL_Cuba_Package_Main  WHERE Sender = '" + Label_Sender.Text + "'";
           // int aa = GridView1.Rows.Count;
           
       }

       protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
       {
           GridViewRow gr = GridView1.SelectedRow;
           id_sender.Text = gr.Cells[2].Text;
           Label_Nombre.Text = gr.Cells[3].Text + " " + gr.Cells[4].Text;
           GridView2.DataBind();
       }

       protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
       {
           if (id_sender.Text == null || id_sender.Text == "") { Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Primero seleccione el SENDRE....');", true); }
           Panel2.Visible = true;
         
        
        //   llenarcomboMunicipios();
       }

       protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
       {
           tb_DestProvincia.Text = id_provincia.Text;
           //conecxion a la base de datos..
           SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
           SqlDataAdapter da = new SqlDataAdapter(str_Destino, conn);   // creo dataadapter
           da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
           SqlCommandBuilder cb = new SqlCommandBuilder(da);


           //id_Destinatario, Dest_Nombre, Dest_Apellido, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, aa
           DataTable dt = new DataTable();
           da.Fill(dt);
           DataRow drnew = dt.NewRow();
           drnew["Dest_Nombre"] = tb_DestNombre.Text;
           drnew["Dest_Apellido"] = tb_DestApellido.Text;
           drnew["Telefono"] = tb_DestTelefono.Text;
           drnew["Calle"] = tb_DestCelle.Text;
           drnew["Entre_Calles"] = tb_DestEntreCalles.Text;
           drnew["Provincias"] = tb_DestProvincia.SelectedValue;
           drnew["Municipio"] = tb_DestMinicipio.SelectedValue;
           drnew["CI"] = tb_DestCI.Text;
           drnew["Sender"] = id_sender.Text;

           // Se añade la nueva fila creada
           dt.Rows.Add(drnew);
           //Actualiza cambios
           da.Update(dt);
           dt.AcceptChanges();
           limpiarCajas();
           Panel1.Visible = false;

           conn.Close();
           GridView2.DataBind();
           Panel2.Visible = false;
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
           tb_DestProvincia.Items.Insert(0, "<-- Select -->");
       }
       public void llenarcomboMunicipios()
       {
           SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
           String selectcomboMuni = "SELECT id_Municipios, Municipios, id_Provincias FROM dbo.tbl_Cuba_N_Municipios WHERE id_Provincias = '" + id_provincia.Text + "' ORDER BY Municipios;";
           SqlDataAdapter da = new SqlDataAdapter(selectcomboMuni, conn);   // creo dataadapter
           da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
           System.Data.DataSet ds = new System.Data.DataSet();
           da.Fill(ds, "tbl_Cuba_N_Municipios");
           tb_DestMinicipio.DataSource = ds.Tables[0].DefaultView;
           tb_DestMinicipio.DataValueField = "id_Municipios";
           tb_DestMinicipio.DataTextField = "Municipios";
           tb_DestMinicipio.DataBind();
           conn.Close();
           tb_DestMinicipio.Items.Insert(0, "<-- Select -->");
       }

       protected void tb_DestProvincia_SelectedIndexChanged(object sender, EventArgs e)
       {
           tb_DestProvincia.Text = id_provincia.Text;
           llenarcomboMunicipios();
       }

       protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
       {
           limpiaCajasDest();
       }

       protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
       {
           Panel1.Visible = true;
           New.Enabled = false;
           Save.Enabled = true;
       }

       protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
       {
           //conecxion a la base de datos..
           SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
           SqlDataAdapter da = new SqlDataAdapter(selectSender, conn);   // creo dataadapter
           da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
           SqlCommandBuilder cb = new SqlCommandBuilder(da);


           //Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City
           DataTable dt = new DataTable();
           da.Fill(dt);
           DataRow drnew = dt.NewRow();
           drnew["Sender_Nombre"] = tb_Nombre.Text;
           drnew["Sender_Apellido"] = tb_Apellido.Text;
           drnew["Sender_Direcc_1"] = tb_Dir_1.Text;
           drnew["Sender_Direcc_2"] = tb_Dir2.Text;
           drnew["Telefono"] = tb_telefono.Text;
           drnew["Sender_City"] = tb_city.Text;
           id_sender.Text = drnew["id_Sender"].ToString();
      
           Label_Nombre.Text = tb_Nombre.Text;
           
          
           // Se añade la nueva fila creada
           dt.Rows.Add(drnew);
           //Actualiza cambios
           da.Update(dt);
           dt.AcceptChanges();
           limpiarCajas();
           Panel1.Visible = false;

           conn.Close();
           GridView1.DataBind();
           SqlDataSource1.SelectCommand = "SELECT id_Sender, Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Phone FROM tbl_Cuba_N_Sender WHERE id_Sender = '" + id_sender.Text + "'";

          
       }

      
    }
}