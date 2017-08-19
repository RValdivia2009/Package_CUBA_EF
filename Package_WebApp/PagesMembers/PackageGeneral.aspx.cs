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
    public partial class PackageGeneral : System.Web.UI.Page
    {
        MembershipUser user = Membership.GetUser();

        string selectAgrega = "SELECT id_Package_Main, Date, Agen_Destination, Agen_Shipper, Tracking_Number, Congsinne, Note, EstadosPackege, Long, Wide, High, Weight, Volumen, Decrip, Usuario, Location, WR FROM dbo.TBL_Package_Main";

        // string selectInicio = "SELECT  id_Package_Main, Date, Agen_Destination, Agen_Shipper, Tracking_Number, Congsinne, Note, EstadosPackege, Long, Wide, High, Weight, Volumen, Decrip, Employee, "+
        //           "Employee1, Location FROM TBL_Package_Main";
        string selectInicio = "SELECT dbo.TBL_Package_Main.id_Package_Main, dbo.TBL_Package_Main.Date, dbo.TBL_Package_Main.Tracking_Number, dbo.TBL_Package_Main.Usuario, dbo.TBL_Package_Main.WR, dbo.tbl_N_Agen_Destination.Name_Agen_Destination AS Dest, " +
                              "dbo.tbl_N_Consignee.Nom_Consignee AS Cosignee, dbo.tbl_N_Agen_Shipper.Name_Agen_Shipper AS Shipper, dbo.tbl_N_Estado_Package.Estados AS Estado, dbo.TBL_Package_Main.Note, " +
                              "dbo.TBL_Package_Main.Agen_Destination, dbo.TBL_Package_Main.Agen_Shipper, dbo.TBL_Package_Main.Congsinne, dbo.TBL_Package_Main.EstadosPackege, dbo.TBL_Package_Main.Weight AS Pound, " +
                              "dbo.TBL_Package_Main.Long AS L, dbo.TBL_Package_Main.Wide AS W, dbo.TBL_Package_Main.High AS H, dbo.TBL_Package_Main.Volumen, dbo.TBL_Package_Main.Decrip, " +
                              "dbo.TBL_Package_Main.Location, dbo.tbl_N_Location.Name_Location " +

                              "FROM (((((dbo.TBL_Package_Main INNER JOIN dbo.tbl_N_Agen_Destination ON dbo.TBL_Package_Main.Agen_Destination = dbo.tbl_N_Agen_Destination.id_Agen_Destination) " +

                              "INNER JOIN dbo.tbl_N_Consignee ON dbo.TBL_Package_Main.Congsinne = dbo.tbl_N_Consignee.id_Consignee) " +
                              "INNER JOIN dbo.tbl_N_Agen_Shipper ON dbo.TBL_Package_Main.Agen_Shipper = dbo.tbl_N_Agen_Shipper.Id_Agen_Shipper) " +
                              "INNER JOIN dbo.tbl_N_Estado_Package ON dbo.TBL_Package_Main.EstadosPackege = dbo.tbl_N_Estado_Package.id_estado) " +
            //    "INNER JOIN dbo.Login ON dbo.TBL_Package_Main.Employee = dbo.Login.user_ID) "+
                              "INNER JOIN dbo.tbl_N_Location ON dbo.TBL_Package_Main.Location = dbo.tbl_N_Location.id_Location)";

        private DataTable dt;
        private SqlDataAdapter da;
        int po;
        int posicion;
        int posicionFinal;
        static SqlCommand cmd;
        static int max, i = 1; // Para ver secuancia de registro
        SqlConnection connIn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlConnection connInDetalle = new SqlConnection(Properties.Settings.Default.ConnectionString);

        string mDest = "";

        private static int visitCounter = 0;
        //  string mDest = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            llenarcombodestino();
            llenarcombolocation();
            cargardatos();
            Button_Next.Enabled = true;
            if (i == 1)
            {
                Button_preview.Enabled = false;
                Button_first.Enabled = false;
            }
            if (!IsPostBack)
            {
                i = 1;
                mover(0);
                llenarcomboShipper();
                llenarcomboestado();
                llenarcomboCnee();
                llenarcombolocation();
                // int mDestino, mCnee;
                Guardar.Enabled = false;
                Nuevo.Enabled = true;
                Update.Enabled = false;
                //     Nota.Enabled = false;
                //     Fecha.Enabled = false;
                //     destino.Enabled = false;
                //     shipper.Enabled = false;
                //     Tracking.Enabled = false;
                //     cosignee.Enabled = false;
                //     estado.Enabled = false;
                //     location.Enabled = false; 
                //     TextBoxID.Text = visitCounter.ToString("WR00000");
            }
            ID_Package.Enabled = false;


        }
        private void cargardatos()
        {
            connIn.Open();
            cmd = new SqlCommand("select count(*) FROM dbo.TBL_Package_Main", connIn); // Para ver secuancia de registro
            max = Convert.ToInt32(cmd.ExecuteScalar()); // Para ver secuancia de registro
            da = new SqlDataAdapter(selectInicio, connIn);
            dt = new DataTable();
            da.Fill(dt);
            posicionFinal = (dt.Rows.Count) - 1;
            Label1.Text = i + "  de  " + max;  // Para ver secuancia de registro
            connIn.Close();

        }

        private void mover(int paso)
        {
            // int c;
            if (TextBoxPosition.Text != "")
            {
                posicion = Convert.ToInt32(TextBoxPosition.Text);
            }
            if (paso == max - 1)
            {
                paso = 0;
            }
            posicion = posicion + paso;
            DataRow dr = dt.Rows[posicion];
            ID_Package.Text = dr["id_Package_Main"].ToString();
            WR.Text = dr["WR"].ToString();

            Tracking.Text = dr["Tracking_Number"].ToString();
            shipper.SelectedValue = dr["Agen_Shipper"].ToString();
            destino.SelectedValue = dr["Agen_Destination"].ToString();
            TextBoxDest.Text = dr["Agen_Destination"].ToString();


            llenarcomboCnee();
            cosignee.SelectedValue = dr["Congsinne"].ToString();
            TextBoxCnee.Text = dr["Congsinne"].ToString();
            llenarcomboCnee();
            llenarcombolocation();
            location.SelectedValue = dr["Location"].ToString();
            llenarcombolocation();
            Fecha.Text = dr["Date"].ToString();
            Nota.Text = dr["Note"].ToString();
            estado.SelectedValue = dr["EstadosPackege"].ToString();
            //-----------

            //    connInDetalle.Open();
            //    string selectAgregaDetalle = "SELECT Package_Main, Tracking, Weight, Long AS L, Wide AS W, High AS H, Quantity AS PCs, Value AS Val, TotalValue AS TotalVal, id_PackageMain_Detalles FROM dbo.TBL_Package_Main_Detalles WHERE Package_Main = '" + ID_Package.Text + "';";
            //    daDet = new SqlDataAdapter(selectAgregaDetalle, connInDetalle);
            //    dtDet = new DataTable();
            //    daDet.Fill(dtDet);
            //    GridView1.DataSource = dtDet;
            //    GridView1.DataBind();
            //    if (GridView1.Columns.Count > 0)
            //    {
            //        GridView1.Columns[0].Visible = false;
            //    }
            //    else
            //    {
            //        GridView1.HeaderRow.Cells[0].Visible = false;
            //        GridView1.HeaderRow.Cells[9].Visible = false;
            //        foreach (GridViewRow gvr in GridView1.Rows)
            //        {
            //            gvr.Cells[0].Visible = false;
            //            gvr.Cells[9].Visible = false;
            //        }
            //    }
            //     connInDetalle.Close();

        }

        protected void Button_first_Click(object sender, EventArgs e)
        {
            i = 1; // Para ver secuancia de registro
            posicion = 0;
            TextBoxPosition.Text = "0";
            mover(0);
            Label1.Text = i + "  de  " + max; // Para ver secuancia de registro
            Button_first.Enabled = false;
            Button_preview.Enabled = false;
            Button_last.Enabled = true;
        }
        protected void Button_Next_Click(object sender, EventArgs e)
        {

            if (posicion == max - 1)
            {
                // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('No hay mas registros....');", true);
                Button_Next.Enabled = false;
            }
            else
            {
                i++; // Para ver secuancia de registro
                mover(1);
                Label1.Text = i + "  de  " + max; // Para ver secuancia de registro
                TextBoxPosition.Text = posicion.ToString();
                Button_preview.Enabled = true;
                Button_first.Enabled = true;
                if (posicion == max - 1)
                {
                    Button_Next.Enabled = false;
                    Button_last.Enabled = false;
                }
            }
        }
        protected void Button_preview_Click(object sender, EventArgs e)
        {
            if (i > 1)
            {
                i--; // Para ver secuancia de registro
                mover(-1);
                Label1.Text = i + "  de  " + max; // Para ver secuancia de registro
                TextBoxPosition.Text = posicion.ToString();
                if (i == 1)
                {
                    Button_preview.Enabled = false;
                    Button_first.Enabled = false;
                }
                Button_last.Enabled = true;
            }
        }
        protected void Button_last_Click(object sender, EventArgs e)
        {
            i = max; // Para ver secuancia de registro
            posicion = max - 1;
            // TextBox2.Text = "0";
            TextBoxPosition.Text = posicion.ToString();

            mover(max - 1);
            Label1.Text = i + "  de  " + max; // Para ver secuancia de registro
            Button_Next.Enabled = false;
            Button_preview.Enabled = true;
            Button_first.Enabled = true;
            Button_last.Enabled = false;
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
            // Calendar1.Visible = true;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // Fecha.Text = Calendar1.SelectedDate.Date.ToString();
            //TextBox1.Text = Calendar1.SelectedDate.ToString("yyyy,MM, dd, HH, mm, ss");
            // Calendar1.Visible = false;
        }

        protected void date_TextChanged(object sender, EventArgs e)
        {
            // Fecha.Text = Calendar1.SelectedDate.Date.ToString();
            //TextBox1.Text = Calendar1.SelectedDate.ToString("yyyy,MM, dd, HH, mm, ss");
            // Calendar1.Visible = false;
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            //conecxion a la base de datos..
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            SqlDataAdapter da = new SqlDataAdapter(selectAgrega, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow drnew = dt.NewRow();
            //  DateTime fecha_inicial = Convert.ToDateTime(Fecha.Text);

            drnew["Note"] = Nota.Text;
            //   drnew["Date"] = Fecha.Text; // fecha_inicial.ToString();
            drnew["Agen_Destination"] = TextBoxDest.Text;
            drnew["Agen_Shipper"] = shipper.SelectedValue;
            drnew["Tracking_Number"] = Tracking.Text;
            drnew["Congsinne"] = TextBoxCnee.Text;
            drnew["EstadosPackege"] = estado.SelectedValue;
            drnew["location"] = location.SelectedValue;
            drnew["Usuario"] = user;


            // Se añade la nueva fila creada
            dt.Rows.Add(drnew);
            //Actualiza cambios
            da.Update(dt);
            dt.AcceptChanges();
            LimpiarCajasTexto();
            conn.Close();
            cargardatos();
            mover(0);
            Guardar.Enabled = false;
            Update.Enabled = false;
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
            // Calendar1.Enabled = true;
            //---------------------
            TextBoxDest.Text = "";
            TextBoxCnee.Text = "";
            llenarcomboCnee();
            llenarcombolocation();
            Nuevo.Enabled = false;
            Update.Enabled = false;
            Guardar.Enabled = true;
        }

        public void llenarcombolocation()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT id_Location, Name_Location, Agen_Destination FROM dbo.tbl_N_Location WHERE Agen_Destination = '" + TextBoxDest.Text + "' ORDER BY Name_Location;";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboShipper, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "dbo.tbl_N_Location");
            location.DataSource = ds.Tables[0].DefaultView;
            location.DataValueField = "id_Location";
            location.DataTextField = "Name_Location";
            // TextBox1.Text = location.SelectedValue;
            location.DataBind();
            conn.Close();
        }

        public void llenarcombodestino()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT id_Agen_Destination, Name_Agen_Destination, Sufij_Agen_Destination FROM tbl_N_Agen_Destination ORDER BY Name_Agen_Destination";
            SqlDataAdapter da = new SqlDataAdapter(selectcomboShipper, conn);   // creo dataadapter
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "tbl_N_Agen_Destination");
            destino.DataSource = ds.Tables[0].DefaultView;
            destino.DataValueField = "id_Agen_Destination";
            destino.DataTextField = "Name_Agen_Destination";
            TextBoxDest.Text = destino.SelectedValue;
            destino.DataBind();
            conn.Close();
        }

        public void llenarcomboCnee()
        {
            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            conn1.Open();
            String selectcombo = "SELECT id_Consignee, Nom_Consignee, Cod_Consignee, Agen_Destination FROM dbo.tbl_N_Consignee WHERE Agen_Destination = '" + TextBoxDest.Text + "' ORDER BY Nom_Consignee;"; // where id_Package_Main = '" + ID_Package.Text + "';";
            SqlDataAdapter da1 = new SqlDataAdapter(selectcombo, conn1);   // creo dataadapter
            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
            System.Data.DataSet ds1 = new System.Data.DataSet();
            da1.Fill(ds1, "dbo.tbl_N_Consignee");
            cosignee.DataSource = ds1.Tables[0].DefaultView;
            cosignee.DataValueField = "id_Consignee";
            cosignee.DataTextField = "Nom_Consignee";
            TextBoxCnee.Text = cosignee.SelectedValue;
            cosignee.DataBind();
            conn1.Close();
        }

        public void llenarcomboestado()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT id_estado, Estados FROM tbl_N_Estado_Package ORDER BY Estados";
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
            // if (TextBox1.Text != "")
            // {
            destino.Text = TextBoxDest.Text;
            llenarcomboCnee();

            //   mDestino = Convert.ToInt32(TextBox1.Text);
            // }
        }

        public void llenarcomboShipper()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String selectcomboShipper = "SELECT Id_Agen_Shipper, Name_Agen_Shipper FROM tbl_N_Agen_Shipper ORDER BY Name_Agen_Shipper";
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
            mover(0);
        }

        protected void cosignee_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxCnee.Text = cosignee.SelectedValue;
            destino.Text = TextBoxDest.Text;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            cargardatos();
            mover(0);
            //      return;



        }

        protected void Button3_Click1(object sender, EventArgs e)
        {

            visitCounter++; // Increase each time a form is loaded
            TextBoxID.Text = visitCounter.ToString("WR00000"); // Format the counter

            // TextBoxID.Text = (Convert.ToInt32(TextBoxID.Text) + 1).ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView1.SelectedRow;

            mDest = TextBoxDest.Text;

            Text_Desc.Text = row.Cells[3].Text;
            TextTracking.Text = row.Cells[4].Text;
            TextPcs.Text = row.Cells[5].Text;
            TextWeight.Text = row.Cells[6].Text;
            TextLong.Text = row.Cells[7].Text;
            TextBoxWide.Text = row.Cells[8].Text;
            TextHigh.Text = row.Cells[9].Text;
            TextValue.Text = row.Cells[10].Text;
            TextTValue.Text = row.Cells[11].Text;

            // llenarcombodestino();

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            SqlConnection connEdit = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connEdit.Open();

            string selectEdit = "SELECT id_Package_Main, Date, Agen_Destination, Agen_Shipper, Tracking_Number, Congsinne, Note, EstadosPackege, Long, Wide, High, Weight, Volumen, Decrip, Usuario, Location, WR FROM dbo.TBL_Package_Main WHERE id_Package_Main = '" + ID_Package.Text + "'";
            da = new SqlDataAdapter(selectEdit, connEdit);
            dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.Rows[0];
            connIn.Close();
            LimpiarCajasTexto();


            ID_Package.Text = dr["id_Package_Main"].ToString();
            WR.Text = dr["WR"].ToString();
            Tracking.Text = dr["Tracking_Number"].ToString();
            shipper.SelectedValue = dr["Agen_Shipper"].ToString();
            destino.SelectedValue = dr["Agen_Destination"].ToString();
            TextBoxDest.Text = dr["Agen_Destination"].ToString();
            llenarcomboCnee();
            cosignee.SelectedValue = dr["Congsinne"].ToString();
            //TextBoxCnee.Text = dr["Congsinne"].ToString();
            //llenarcomboCnee();
            //llenarcombolocation();
            location.SelectedValue = dr["Location"].ToString();
            //llenarcombolocation();
            Fecha.Text = dr["Date"].ToString();
            Nota.Text = dr["Note"].ToString();
            estado.SelectedValue = dr["EstadosPackege"].ToString();



            destino.Enabled = true;
            shipper.Enabled = true;
            Tracking.Enabled = true;
            cosignee.Enabled = true;
            estado.Enabled = true;
            location.Enabled = true;
            Nota.Enabled = true;
            Guardar.Enabled = true;
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            String Query = "Update dbo.TBL_Package_Main set Tracking_Number = '" + Tracking.Text + "', Agen_Destination = " + TextBoxDest.Text + ", Agen_Shipper = " + shipper.SelectedValue + ", Congsinne = " + cosignee.SelectedValue + ", EstadosPackege = " + estado.SelectedValue + ", Location = " + location.SelectedValue + ",  note = '" + Nota.Text + "' where id_Package_Main = '" + ID_Package.Text + "';";
            SqlCommand MiComando = new SqlCommand(Query, conn);
            conn.Open();
            int FilasAfectadas = MiComando.ExecuteNonQuery();
            conn.Close();
        }

       
    }
}