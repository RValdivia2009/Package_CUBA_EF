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

namespace Package_WebApp.PagesMembers
{
    public partial class Package_Edit : System.Web.UI.Page
    {

        string selectAgrega = "SELECT id_Package_Main, Date, Agen_Destination, Agen_Shipper, Tracking_Number, Congsinne, Note, EstadosPackege FROM dbo.TBL_Package_Main";
        SqlConnection connIn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        private DataTable dt;
        private SqlDataAdapter da;
        int posicion;
        int posicionFinal;

        protected void Page_Load(object sender, EventArgs e)
        {
            llenarcombodestino();
            llenarcomboShipper();
            llenarcomboCnee();
            llenarcomboestado();
            actualizarGridview();
          
          //     cargardatos();
            ID_Package.Enabled = false;
        }

        public void cargardatos()
        {
            da = new SqlDataAdapter(selectAgrega, connIn);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[posicion];
            ID_Package.Text = dr["id_Package_Main"].ToString();
            Tracking.Text = dr["Tracking_Number"].ToString();
            shipper.SelectedValue = dr["Agen_Shipper"].ToString();

            destino.SelectedValue = dr["Agen_Destination"].ToString();

            TextBox1.Text = dr["Agen_Destination"].ToString();
            llenarcomboCnee();
            cosignee.SelectedValue = dr["Congsinne"].ToString();
            llenarcomboCnee();

        }

        protected void actualizarGridview()
        {
            string SQL_Pack_Main = "SELECT dbo.TBL_Package_Main.id_Package_Main AS ID_Pack, Convert(varchar(10), Date, 103), dbo.TBL_Package_Main.Tracking_Number AS Tracking, dbo.tbl_N_Agen_Destination.Name_Agen_Destination AS Dest, dbo.tbl_N_Consignee.Nom_Consignee AS Cosignee, dbo.tbl_N_Agen_Shipper.Name_Agen_Shipper AS Shipper, dbo.tbl_N_Estado_Package.Estados AS Estado, dbo.TBL_Package_Main.Note, dbo.TBL_Package_Main.Agen_Destination, dbo.TBL_Package_Main.Agen_Shipper, dbo.TBL_Package_Main.Congsinne, dbo.TBL_Package_Main.EstadosPackege FROM dbo.TBL_Package_Main INNER JOIN dbo.tbl_N_Agen_Destination ON dbo.TBL_Package_Main.Agen_Destination = dbo.tbl_N_Agen_Destination.id_Agen_Destination INNER JOIN dbo.tbl_N_Consignee ON dbo.TBL_Package_Main.Congsinne = dbo.tbl_N_Consignee.id_Consignee INNER JOIN dbo.tbl_N_Agen_Shipper ON dbo.TBL_Package_Main.Agen_Shipper = dbo.tbl_N_Agen_Shipper.Id_Agen_Shipper INNER JOIN dbo.tbl_N_Estado_Package ON dbo.TBL_Package_Main.EstadosPackege = dbo.tbl_N_Estado_Package.id_estado";
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            SqlDataAdapter da = new SqlDataAdapter(SQL_Pack_Main, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            System.Data.DataSet DS1 = new System.Data.DataSet();
            da.Fill(DS1, SQL_Pack_Main);

            //   if (!IsPostBack)
            //   {
            GridView1.DataSource = DS1;
            GridView1.DataBind();
            //   }

            //Para ocultar columnas y titulos de columnas
            if (GridView1.Columns.Count > 0)
                GridView1.Columns[1].Visible = false;
            else
            {
                GridView1.HeaderRow.Cells[9].Visible = false;
                GridView1.HeaderRow.Cells[10].Visible = false;
                GridView1.HeaderRow.Cells[11].Visible = false;
                GridView1.HeaderRow.Cells[12].Visible = false;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    gvr.Cells[9].Visible = false;
                    gvr.Cells[10].Visible = false;
                    gvr.Cells[11].Visible = false;
                    gvr.Cells[12].Visible = false;
                }
            }
        }

        protected void btnActualizar_Click1(object sender, EventArgs e)
        {
            // Editar = true;
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView1.SelectedRow;

            ID_Package.Text = row.Cells[1].Text;
            Fecha.Text = row.Cells[2].Text;
            Tracking.Text = row.Cells[3].Text;
            destino.SelectedValue = row.Cells[6].Text;
            shipper.SelectedValue = row.Cells[7].Text;
            cosignee.SelectedValue = row.Cells[8].Text;
            estado.SelectedValue = row.Cells[9].Text;
            Nota.Text = row.Cells[10].Text;

        }
        public void LimpiarCajasTexto()
        {
            ID_Package.Text = "";
            Nota.Text = "";
            Fecha.Text = "";
            destino.SelectedValue = null;
            shipper.Text = null;
            Tracking.Text = null;
            cosignee.Text = null;
            estado.Text = null;

            ID_Package.Enabled = false;
            Nota.Enabled = false;
            Fecha.Enabled = false;
            destino.Enabled = false;
            shipper.Enabled = false;
            Tracking.Enabled = false;
            cosignee.Enabled = false;
            estado.Enabled = false;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Fecha.Text = Calendar1.SelectedDate.Date.ToString();
            //TextBox1.Text = Calendar1.SelectedDate.ToString("yyyy,MM, dd, HH, mm, ss");
            Calendar1.Visible = false;
        }

        protected void date_TextChanged(object sender, EventArgs e)
        {
            Fecha.Text = Calendar1.SelectedDate.Date.ToString();
            //TextBox1.Text = Calendar1.SelectedDate.ToString("yyyy,MM, dd, HH, mm, ss");
            Calendar1.Visible = false;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Para que funcione la paginacion del Gridview
            GridView1.PageIndex = e.NewPageIndex;
            actualizarGridview();
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            //conecxion a la base de datos..
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            SqlDataAdapter da = new SqlDataAdapter(selectAgrega, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
            da.UpdateCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetDeleteCommand();
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow drnew = dt.NewRow();
            DateTime fecha_inicial = Convert.ToDateTime(Fecha.Text);

            drnew["Note"] = Nota.Text;
            drnew["Date"] = fecha_inicial.ToString();
            drnew["Agen_Destination"] = destino.SelectedValue;
            drnew["Agen_Shipper"] = shipper.SelectedValue;
            drnew["Tracking_Number"] = Tracking.Text;
            drnew["Congsinne"] = cosignee.SelectedValue;
            drnew["EstadosPackege"] = estado.SelectedValue;
            // Se añade la nueva fila creada
            dt.Rows.Add(drnew);

            //Actualiza cambios
            da.Update(dt);
            dt.AcceptChanges();
            actualizarGridview();
            LimpiarCajasTexto();
            conn.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView1.SelectedRow;

            ID_Package.Text = row.Cells[1].Text;
            Fecha.Text = row.Cells[2].Text;
            Tracking.Text = row.Cells[3].Text;
            destino.SelectedValue = row.Cells[9].Text;
            TextBox1.Text = row.Cells[9].Text;
            shipper.SelectedValue = row.Cells[10].Text;
            llenarcomboCnee();
            cosignee.SelectedValue = row.Cells[11].Text;
            llenarcomboCnee();
            estado.SelectedValue = row.Cells[12].Text;
            Nota.Text = row.Cells[8].Text;
            //DateTime fecha_inicial = Convert.ToDateTime(Fecha.Text);
            //Fecha.Text = fecha_inicial.ToString();
            Fecha.Text = Fecha.Text;

        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            //ID_Package.Enabled = true;
            LimpiarCajasTexto();

            Nota.Enabled = true;
            Fecha.Enabled = true;
            destino.Enabled = true;
            shipper.Enabled = true;
            Tracking.Enabled = true;
            cosignee.Enabled = true;
            estado.Enabled = true;
            Calendar1.Enabled = true;
            //---------------------
            Nuevo.Enabled = false;

            Update.Enabled = false;
            Guardar.Enabled = true;
        }

        protected void Update_Click(object sender, EventArgs e)
        {

            //string date = DateTime.Parse(Fecha);

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            //DateTime fecha_inicial = Convert.ToDateTime(Fecha.Text);
            DateTime fecha_inicial = Convert.ToDateTime(Fecha.Text);
            String Query = "Update dbo.TBL_Package_Main set Date = '" + fecha_inicial.ToString() + "', Tracking_Number = '" + Tracking.Text + "', Agen_Destination = " + destino.SelectedValue + ", Agen_Shipper = " + shipper.SelectedValue + ", Congsinne = " + cosignee.SelectedValue + ", EstadosPackege = " + estado.SelectedValue + ", note = '" + Nota.Text + "' where id_Package_Main = '" + ID_Package.Text + "';";
            SqlCommand MiComando = new SqlCommand(Query, conn);
            conn.Open();
            int FilasAfectadas = MiComando.ExecuteNonQuery();
            actualizarGridview();
            conn.Close();
        }

        public void llenarcombodestino()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT id_Agen_Destination, Name_Agen_Destination, Sufij_Agen_Destination FROM tbl_N_Agen_Destination";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboShipper, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_N_Agen_Destination");
            destino.DataSource = ds.Tables[0].DefaultView;
            destino.DataValueField = "id_Agen_Destination";
            destino.DataTextField = "Name_Agen_Destination";
            TextBox1.Text = destino.SelectedValue;
            destino.DataBind();
            conn.Close();

        }

        public void llenarcomboCnee()
        {

            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            conn1.Open();
            String selectcombo = "SELECT id_Consignee, Nom_Consignee, Cod_Consignee, Agen_Destination FROM dbo.tbl_N_Consignee WHERE Agen_Destination = '" + TextBox1.Text + "';"; // where id_Package_Main = '" + ID_Package.Text + "';";
            SqlDataAdapter da1 = new SqlDataAdapter(selectcombo, conn1);   // creo dataadapter
            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds1 = new System.Data.DataSet();
            da1.Fill(ds1, "dbo.tbl_N_Consignee");
            cosignee.DataSource = ds1.Tables[0].DefaultView;
            cosignee.DataValueField = "id_Consignee";
            cosignee.DataTextField = "Nom_Consignee";
            cosignee.DataBind();
            conn1.Close();
        }



        public void llenarcomboestado()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT id_estado, Estados FROM tbl_N_Estado_Package";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboShipper, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_N_Estado_Package");
            estado.DataSource = ds.Tables[0].DefaultView;
            estado.DataValueField = "id_estado";
            estado.DataTextField = "Estados";
            estado.DataBind();
            conn.Close();
        }

        protected void destino_SelectedIndexChanged(object sender, EventArgs e)
        {
            destino.Text = TextBox1.Text;
        }

        public void llenarcomboShipper()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT Id_Agen_Shipper, Name_Agen_Shipper FROM tbl_N_Agen_Shipper";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboShipper, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_N_Agen_Shipper");
            shipper.DataSource = ds.Tables[0].DefaultView;
            shipper.DataValueField = "Id_Agen_Shipper";
            shipper.DataTextField = "Name_Agen_Shipper";
            shipper.DataBind();
            conn.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           cargardatos();
        }

     
    }
}