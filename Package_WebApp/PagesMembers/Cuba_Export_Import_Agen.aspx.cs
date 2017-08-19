using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Package_WebApp;
using System.Configuration;
using System.IO;
using ClosedXML.Excel;
using System.Data.OleDb;  

namespace Package_WebApp.PagesMembers
{
    public partial class Cuba_Export_Import_Agen : System.Web.UI.Page
    {
        int mAGENCIA = 1;
        string mPrefAgen = "1000";
        string aa = "";
        string carpeta;
        string mWR= "";
        string mRepi = "";
        string mDest = "";
        string mSend = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Insert.Enabled = false;
            Panel1.Visible = false;
            Label1.Text = aa;
            if (!IsPostBack)
            {
               
               // Label1.Visible = false;
            }
            carpeta = Path.Combine(Request.PhysicalApplicationPath, "Data_Import"); 

        }

        // ----- COMIENZO EXPORTACION DE FHICHEROS ----------------------------------------------------------------------------------------

                    private DataTable getAll_PackageMain()
                    {
                        string constr = Properties.Settings.Default.ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_Cuba_Package_Main WHERE AEB = '" + tb_AWB.Text + "' "))
                            {
                                using (SqlDataAdapter da = new SqlDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    da.SelectCommand = cmd;
                                    da.Fill(dt);
                                    Label1.Visible = true;
                                    aa = "Se exportaron " + dt.Rows.Count + " registros.....";
                                    Label1.Text = aa;
                                    return dt;
                                }
                            }
                        }
                    }
                    private DataTable getAll_PackageDetalles()
                    {
                        string constr = Properties.Settings.Default.ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main, dbo.TBL_Cuba_Package_Main.AEB, dbo.TBL_Cuba_Package_Main_Detalles.id_Cuba_PackageMain_Detalles, " +
                                                                    "dbo.TBL_Cuba_Package_Main_Detalles.Cuba_Package_Main, dbo.TBL_Cuba_Package_Main_Detalles.Cantidad, dbo.TBL_Cuba_Package_Main_Detalles.Descripcion, " +
                                                                    "dbo.TBL_Cuba_Package_Main_Detalles.Valor,  dbo.TBL_Cuba_Package_Main_Detalles.WR FROM dbo.TBL_Cuba_Package_Main INNER JOIN dbo.TBL_Cuba_Package_Main_Detalles ON dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main = dbo.TBL_Cuba_Package_Main_Detalles.Cuba_Package_Main WHERE AEB = '" + tb_AWB.Text + "' ORDER BY WR"))
                            {
                                using (SqlDataAdapter da = new SqlDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    da.SelectCommand = cmd;
                                    da.Fill(dt);


                                    return dt;
                                }
                            }
                        }

                    }

                    private DataTable getAll_Sender()
                    {
                        string constr = Properties.Settings.Default.ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.tbl_Cuba_N_Sender.Sender_Nombre, dbo.tbl_Cuba_N_Sender.Sender_Apellido, dbo.tbl_Cuba_N_Sender.Sender_Direcc_1, dbo.tbl_Cuba_N_Sender.Sender_Direcc_2, " +
                                                                   "dbo.tbl_Cuba_N_Sender.Telefono, dbo.tbl_Cuba_N_Sender.Sender_City, dbo.tbl_Cuba_N_Sender.Sender_Phone, dbo.tbl_Cuba_N_Sender.Sender_Email, dbo.tbl_Cuba_N_Sender.Agencia, " +
                                                                   "dbo.tbl_Cuba_N_Sender.Cod_Sender, dbo.TBL_Cuba_Package_Main.AEB " +
                                                                   "FROM dbo.tbl_Cuba_N_Sender INNER JOIN dbo.TBL_Cuba_Package_Main ON dbo.tbl_Cuba_N_Sender.Cod_Sender = dbo.TBL_Cuba_Package_Main.Cod_Sender1 " +
                                                                   "WHERE dbo.TBL_Cuba_Package_Main.AEB = '" + tb_AWB.Text + "' "))

                            {
                                using (SqlDataAdapter da = new SqlDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    da.SelectCommand = cmd;
                                    da.Fill(dt);



                                    return dt;
                                }
                            }
                        }
                    }

                    private DataTable getAll_Destino()
                    {
                        string constr = Properties.Settings.Default.ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT dbo.tbl_Cuba_N_Destinatario.id_Destinatario, dbo.tbl_Cuba_N_Destinatario.Dest_Nombre, dbo.tbl_Cuba_N_Destinatario.Telefono, dbo.tbl_Cuba_N_Destinatario.Calle, " +
                                                                   "dbo.tbl_Cuba_N_Destinatario.Entre_Calles, dbo.tbl_Cuba_N_Destinatario.Provincias, dbo.tbl_Cuba_N_Destinatario.Municipio, dbo.tbl_Cuba_N_Destinatario.Sender, dbo.tbl_Cuba_N_Destinatario.CI, " +
                                                                   "dbo.tbl_Cuba_N_Destinatario.aa, dbo.tbl_Cuba_N_Destinatario.Dest_Apellido, dbo.tbl_Cuba_N_Destinatario.Dest_Apto, dbo.tbl_Cuba_N_Destinatario.Dest_No, " +
                                                                   "dbo.tbl_Cuba_N_Destinatario.Dest_Email, dbo.tbl_Cuba_N_Destinatario.Abencia, dbo.tbl_Cuba_N_Destinatario.Cod_Destino, dbo.TBL_Cuba_Package_Main.AEB " +
                                                                   "FROM dbo.tbl_Cuba_N_Destinatario INNER JOIN dbo.TBL_Cuba_Package_Main ON dbo.tbl_Cuba_N_Destinatario.Cod_Destino = dbo.TBL_Cuba_Package_Main.Dod_Destino1 " +
                                                                   "WHERE dbo.TBL_Cuba_Package_Main.AEB = '" + tb_AWB.Text + "' "))

                             {
                                using (SqlDataAdapter da = new SqlDataAdapter())
                                {
                                    DataTable dt = new DataTable();
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = con;
                                    da.SelectCommand = cmd;
                                    da.Fill(dt);
                                    return dt;
                                }
                            }
                        }
                    }

                    public DataSet getDataSetExportToExcel()
                    {

                        DataSet ds = new DataSet();
                        DataTable dtMain = new DataTable("TBL_Cuba_Package_Main");
                        dtMain = getAll_PackageMain();

                        DataTable dtDetalle = new DataTable("TBL_Cuba_Package_Main_Detalles");
                        dtDetalle = getAll_PackageDetalles();

                        DataTable dtSender = new DataTable("tbl_Cuba_N_Sender");
                        dtSender = getAll_Sender();

                        DataTable dtDestino = new DataTable("tbl_Cuba_N_Destinatario");
                        dtDestino = getAll_Destino();

                        ds.Tables.Add(dtMain);
                        ds.Tables.Add(dtDetalle);
                        ds.Tables.Add(dtSender);
                        ds.Tables.Add(dtDestino);
                        return ds;
                    }

                    protected void btn_Export_Click(object sender, EventArgs e)
                    {
                        DataSet ds = getDataSetExportToExcel();
                        ds.Tables[0].TableName = "TBL_Cuba_Package_Main";
                        ds.Tables[1].TableName = "TBL_Cuba_Package_Main_Detalles";
                        ds.Tables[2].TableName = "tbl_Cuba_N_Sender";
                        ds.Tables[3].TableName = "tbl_Cuba_N_Destinatario";


                        using (XLWorkbook wb = new XLWorkbook())
                        {

                            wb.Worksheets.Add(ds);
                            wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            wb.Style.Font.Bold = true;
                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename= File_Exportacion.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }

        // -------- FIN EXPORTACION DE FHICHEROS ------------------------------------------------------------------
        
        // ----- COMIENZO IMPORTACION DE FHICHEROS ------------------------------------------------------------------

        protected void Button2_Click(object sender, EventArgs e)
        {
           // System.Threading.Thread.Sleep(5000);

            if (FileUpload1.PostedFile.FileName == "")
            {
                Label3.Text = "DEBE SELECCIONAR UN FICHERO";
                Label3.Visible = true;
            }
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            //SI LAS EXTENCIONES DEL FICHERO SON LAS CORRECTAS
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                return;
            }

            ////OBTENGO EL PATH PARA SALVAR LUEGO EL ARCHIVO
            string fileLocation = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //SI EL FILE EXISTE LO BORRO
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }
            
            //SALVAR FICHERO ANTES DE CARGARLO
            try
                {
                    string archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    //nomble del archivo
                    Label3.Text = archivo;
                    string folder_final = Path.Combine(carpeta, archivo);
                    FileUpload1.PostedFile.SaveAs(folder_final);
                    Label3.Text = "File copied correctly";
                    Label4.Text = archivo;
                    Label3.Visible = true;
                }
                 catch (Exception ex)
                 {
                     Label3.Text = "Error" + ex.Message;

                 }

            //cREAR STRING SEGUN VERSION DE EXCEL
             string mPath = Path.Combine(carpeta, Label4.Text);
            string strConn = "";
            switch (fileExtension)
            {
                case ".xls":
                    //Excel 1997-2003  
                    strConn = ("Provider=Microsoft.Jet.OLEDB.4.0;" + ("Data Source=" + (mPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"")));
                    break;
                case ".xlsx":
                    //Excel 2007-2010  
                    strConn =  ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (mPath + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));
                    break;
            }
            //Get the sheets data and bind that data to the grids  
            BindData(strConn);

            //Delete the excel file from the server  
            File.Delete(fileLocation);
            Panel1.Visible = true;
            Insert.Enabled = true;
        }

        private void BindData(string strConn)
        {
            OleDbConnection objConn = new OleDbConnection(strConn);
            objConn.Open();

            // Get the data table containg the schema guid.  
            DataTable dt = null;

            dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            objConn.Close();

            if (dt.Rows.Count > 0)
            {
                int i = 0;

                // Bind the sheets to the Grids  
                foreach (DataRow row in dt.Rows)
                {
                    DataTable dt_sheet = null;
                    dt_sheet = getSheetData(strConn, row["TABLE_NAME"].ToString());
                    switch (i)
                    {
                        case 0:
                            
                            GridView1.DataSource = dt_sheet;
                            GridView1.DataBind();
                            break;
                        case 1:
                           
                            GridView2.DataSource = dt_sheet;
                            GridView2.DataBind();
                            break;
                        case 2:
                            Lb_CantPaquetes.Text = Convert.ToString(dt_sheet.Rows.Count);
                            GridView3.DataSource = dt_sheet;
                            GridView3.DataBind();
                            break;
                        case 3:

                            GridView4.DataSource = dt_sheet;
                            GridView4.DataBind();
                            break;
                    }
                    i++;
                }
            }
            Panel1.Visible = true;
        }

        private DataTable getSheetData(string strConn, string sheet)
        {
            string query = "select * from [" + sheet + "]";
            OleDbConnection objConn;
            OleDbDataAdapter oleDA;
            DataTable dt = new DataTable();
            objConn = new OleDbConnection(strConn);
            objConn.Open();
            oleDA = new OleDbDataAdapter(query, objConn);
            oleDA.Fill(dt);
            objConn.Close();
            oleDA.Dispose();
            objConn.Dispose();
            return dt;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void AsyncButton_OnClick(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);

            if (FileUpload1.PostedFile.FileName == "")
            {
                Label3.Text = "DEBE SELECCIONAR UN FICHERO";
                Label3.Visible = true;
            }
            string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            //SI LAS EXTENCIONES DEL FICHERO SON LAS CORRECTAS
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                return;
            }

            ////OBTENGO EL PATH PARA SALVAR LUEGO EL ARCHIVO
            string fileLocation = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //SI EL FILE EXISTE LO BORRO
            if (File.Exists(fileLocation))
            {
                File.Delete(fileLocation);
            }

            //SALVAR FICHERO ANTES DE CARGARLO
            try
            {
                string archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);

                //nomble del archivo
                Label3.Text = archivo;
                string folder_final = Path.Combine(carpeta, archivo);
                FileUpload1.PostedFile.SaveAs(folder_final);
                Label3.Text = "File copied correctly";
                Label4.Text = archivo;
                Label3.Visible = true;
            }
            catch (Exception ex)
            {
                Label3.Text = "Error" + ex.Message;

            }

            //cREAR STRING SEGUN VERSION DE EXCEL
            string mPath = Path.Combine(carpeta, Label4.Text);
            string strConn = "";
            switch (fileExtension)
            {
                case ".xls":
                    //Excel 1997-2003  
                    strConn = ("Provider=Microsoft.Jet.OLEDB.4.0;" + ("Data Source=" + (mPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"")));
                    break;
                case ".xlsx":
                    //Excel 2007-2010  
                    strConn = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (mPath + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));
                    break;
            }
            //Get the sheets data and bind that data to the grids  
            BindData(strConn);

            //Delete the excel file from the server  
            File.Delete(fileLocation);
            Panel1.Visible = true;
        }

        // ----- FIN IMPORTACION DE FHICHEROS ------------------------------------------------------------------


        protected void Insert_Click(object sender, EventArgs e)
        {
         


            //------------------- INSERT SENDER TO SQL --------------------
            string SqlString_SENDER = "Insert Into tbl_Cuba_N_Sender(Sender_Nombre, Sender_Apellido, Sender_Direcc_1, Sender_Direcc_2, Telefono, Sender_City, Sender_Email, Agencia, Cod_Sender)" +
                                       "Values (@parametro1,@parametro2,@parametro3,@parametro4,@parametro5,@parametro6,@parametro7,@parametro8,@parametro9)";

            //DataRow dr = new DataRow();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SqlString_SENDER, conn))
                {
                    conn.Close();

                    foreach (GridViewRow row in GridView2.Rows)
                    {
                        cmd.Parameters.Add("@parametro1", SqlDbType.NVarChar).Value = row.Cells[0].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro2", SqlDbType.NVarChar).Value = row.Cells[1].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro3", SqlDbType.NVarChar).Value = row.Cells[2].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro4", SqlDbType.NVarChar).Value = row.Cells[3].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro5", SqlDbType.NVarChar).Value = row.Cells[4].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro6", SqlDbType.NVarChar).Value = row.Cells[5].Text.Replace("&nbsp;", "");
                        cmd.Parameters.Add("@parametro7", SqlDbType.NVarChar).Value = row.Cells[6].Text.Replace("&nbsp;", "");
                        
                        cmd.Parameters.Add("@parametro8", SqlDbType.Int).Value = row.Cells[8].Text.Replace("&nbsp;", "");
                 
                        cmd.Parameters.Add("@parametro9", SqlDbType.NVarChar).Value = row.Cells[9].Text.Replace("&nbsp;", "");
                   
                        mSend = row.Cells[9].Text;

                        conn.Open();


                        string xx = "select Cod_Sender from tbl_Cuba_N_Sender WHERE Cod_Sender = '" + mSend + "'";
                        SqlConnection conet = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        SqlDataAdapter da = new SqlDataAdapter(xx, conet);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        int aa = dt.Rows.Count;
                        if (aa == 0)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        conet.Close();
                        cmd.Parameters.RemoveAt("@parametro1");
                        cmd.Parameters.RemoveAt("@parametro2");
                        cmd.Parameters.RemoveAt("@parametro3");
                        cmd.Parameters.RemoveAt("@parametro4");
                        cmd.Parameters.RemoveAt("@parametro5");
                        cmd.Parameters.RemoveAt("@parametro6");
                        cmd.Parameters.RemoveAt("@parametro7");
                        cmd.Parameters.RemoveAt("@parametro8");
                        cmd.Parameters.RemoveAt("@parametro9");
               
                    }
                    Label3.Visible = true;
                    Label3.Text = "Records added successfully";
                }
            }
            //------------------- FIN INSERT SENDER --------------------

            //------------------- INSERT DETINATARIOS TO SQL --------------------
            string SqlString_DESTINO = "Insert Into tbl_Cuba_N_Destinatario(Dest_Nombre, Telefono, Calle, Entre_Calles, Provincias, Municipio, Sender, CI, Dest_Apellido, Dest_Apto, Dest_No, Dest_Email, Abencia, Cod_Destino)" +
                                           "Values (@parametro1,@parametro2,@parametro3,@parametro4,@parametro5,@parametro6,@parametro7,@parametro8,@parametro9,@parametro10,@parametro11,@parametro12,@parametro13,@parametro14)";

                //DataRow dr = new DataRow();
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString_DESTINO, conn))
                    {
                        conn.Close();

                        foreach (GridViewRow row in GridView1.Rows)
                        {

                            cmd.Parameters.Add("@parametro1", SqlDbType.NVarChar).Value = row.Cells[1].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro2", SqlDbType.NVarChar).Value = row.Cells[2].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro3", SqlDbType.NVarChar).Value = row.Cells[3].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro4", SqlDbType.NVarChar).Value = row.Cells[4].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro5", SqlDbType.Int).Value = row.Cells[5].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro6", SqlDbType.Int).Value = row.Cells[6].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro7", SqlDbType.NVarChar).Value = row.Cells[7].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro8", SqlDbType.NVarChar).Value = row.Cells[8].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro9", SqlDbType.NVarChar).Value = row.Cells[10].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro10", SqlDbType.NVarChar).Value = row.Cells[11].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro11", SqlDbType.NVarChar).Value = row.Cells[12].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro12", SqlDbType.NVarChar).Value = row.Cells[13].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro13", SqlDbType.Int).Value = row.Cells[14].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro14", SqlDbType.NVarChar).Value = row.Cells[15].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro15", SqlDbType.NVarChar).Value = row.Cells[16].Text.Replace("&nbsp;", "");
                            mDest = row.Cells[15].Text;

                            conn.Open();


                            string xx = "select Cod_Destino from tbl_Cuba_N_Destinatario WHERE Cod_Destino = '" + mDest + "'";
                            SqlConnection conet = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlDataAdapter da = new SqlDataAdapter(xx, conet);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int aa = dt.Rows.Count;
                            if (aa == 0)
                            {
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                            conet.Close();
                            cmd.Parameters.RemoveAt("@parametro1");
                            cmd.Parameters.RemoveAt("@parametro2");
                            cmd.Parameters.RemoveAt("@parametro3");
                            cmd.Parameters.RemoveAt("@parametro4");
                            cmd.Parameters.RemoveAt("@parametro5");
                            cmd.Parameters.RemoveAt("@parametro6");
                            cmd.Parameters.RemoveAt("@parametro7");
                            cmd.Parameters.RemoveAt("@parametro8");
                            cmd.Parameters.RemoveAt("@parametro9");
                            cmd.Parameters.RemoveAt("@parametro10");
                            cmd.Parameters.RemoveAt("@parametro11");
                            cmd.Parameters.RemoveAt("@parametro12");
                            cmd.Parameters.RemoveAt("@parametro13");
                            cmd.Parameters.RemoveAt("@parametro14");
                            cmd.Parameters.RemoveAt("@parametro15");

                        }
                        Label3.Visible = true;
                        Label3.Text = "Records added successfully";
                    }
                }
                //------------------- FIN INSERT DETINATARIOS --------------------

                // ------------------- INSERT PAQUECGE MAIN  TO SQL--------------------
                string SqlString = "Insert Into TBL_Cuba_Package_Main (Date, Destinatario, Sender, Note, Long, Wide, High, Provincia, Municipio, Estado, Pagado, Usuario, TipoEntrega, Rate, Precio, Volumen, Manifiesto, WR, Tipo_Envio, Zona, Caja, Descrip_Detalles, AEB, Weight, Fich_Letra, SenderNombre, SenderApellido, Dest_Nombre, Dest_Apellido, Agencia, Cod_Sender1, Dod_Destino1)" +
                                    "Values (@parametro1,@parametro2,@parametro3,@parametro4,@parametro5,@parametro6,@parametro7,@parametro8,@parametro9,@parametro10,@parametro11,@parametro12,@parametro13,@parametro14,@parametro15,@parametro16,@parametro17,@parametro18,@parametro19,@parametro20,@parametro21,@parametro22,@parametro23,@parametro24,@parametro25,@parametro26,@parametro27,@parametro28,@parametro29,@parametro30,@parametro31,@parametro32)";

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                    {
                        conn.Close();

                        foreach (GridViewRow row in GridView3.Rows)
                        {

                            cmd.Parameters.Add("@parametro1", SqlDbType.DateTime).Value = row.Cells[1].Text;
                            cmd.Parameters.Add("@parametro2", SqlDbType.Int).Value = row.Cells[2].Text;
                            cmd.Parameters.Add("@parametro3", SqlDbType.Int).Value = row.Cells[3].Text;
                            cmd.Parameters.Add("@parametro4", SqlDbType.NVarChar).Value = row.Cells[4].Text;
                            cmd.Parameters.Add("@parametro5", SqlDbType.Decimal).Value = row.Cells[5].Text;
                            cmd.Parameters.Add("@parametro6", SqlDbType.Decimal).Value = row.Cells[6].Text;
                            cmd.Parameters.Add("@parametro7", SqlDbType.Decimal).Value = row.Cells[7].Text;
                            cmd.Parameters.Add("@parametro8", SqlDbType.Int).Value = row.Cells[8].Text;
                            cmd.Parameters.Add("@parametro9", SqlDbType.Int).Value = row.Cells[9].Text;
                            cmd.Parameters.Add("@parametro10", SqlDbType.Int).Value = row.Cells[10].Text;
                            cmd.Parameters.Add("@parametro11", SqlDbType.Int).Value = row.Cells[11].Text;
                            cmd.Parameters.Add("@parametro12", SqlDbType.NVarChar).Value = row.Cells[12].Text;
                            cmd.Parameters.Add("@parametro13", SqlDbType.Int).Value = row.Cells[13].Text;
                            cmd.Parameters.Add("@parametro14", SqlDbType.Decimal).Value = row.Cells[14].Text;
                            cmd.Parameters.Add("@parametro15", SqlDbType.Decimal).Value = row.Cells[15].Text;
                            cmd.Parameters.Add("@parametro16", SqlDbType.Decimal).Value = row.Cells[16].Text;
                            cmd.Parameters.Add("@parametro17", SqlDbType.Int).Value = row.Cells[17].Text;
                            cmd.Parameters.Add("@parametro18", SqlDbType.NVarChar).Value = row.Cells[18].Text;
                            mWR = row.Cells[18].Text;
                            cmd.Parameters.Add("@parametro19", SqlDbType.Int).Value = row.Cells[19].Text;
                            cmd.Parameters.Add("@parametro20", SqlDbType.NVarChar).Value = row.Cells[20].Text;
                            cmd.Parameters.Add("@parametro21", SqlDbType.NVarChar).Value = row.Cells[21].Text;
                            cmd.Parameters.Add("@parametro22", SqlDbType.NVarChar).Value = row.Cells[22].Text;
                            cmd.Parameters.Add("@parametro23", SqlDbType.NVarChar).Value = row.Cells[23].Text;
                            cmd.Parameters.Add("@parametro24", SqlDbType.Decimal).Value = row.Cells[24].Text;
                            cmd.Parameters.Add("@parametro25", SqlDbType.NVarChar).Value = row.Cells[25].Text;
                            cmd.Parameters.Add("@parametro26", SqlDbType.NVarChar).Value = row.Cells[26].Text;
                            cmd.Parameters.Add("@parametro27", SqlDbType.NVarChar).Value = row.Cells[27].Text;
                            cmd.Parameters.Add("@parametro28", SqlDbType.NVarChar).Value = row.Cells[28].Text;
                            cmd.Parameters.Add("@parametro29", SqlDbType.NVarChar).Value = row.Cells[29].Text;
                            cmd.Parameters.Add("@parametro30", SqlDbType.Int).Value = row.Cells[30].Text;
                            cmd.Parameters.Add("@parametro31", SqlDbType.NVarChar).Value = row.Cells[31].Text;
                            cmd.Parameters.Add("@parametro32", SqlDbType.NVarChar).Value = row.Cells[32].Text;

                            conn.Open();


                            string xx = "select WR from TBL_Cuba_Package_Main WHERE WR = '" + mWR + "'";
                            SqlConnection conet = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlDataAdapter da = new SqlDataAdapter(xx, conet);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int aa = dt.Rows.Count;

                            if (aa == 0)
                            {
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                            conet.Close();
                            cmd.Parameters.RemoveAt("@parametro1");
                            cmd.Parameters.RemoveAt("@parametro2");
                            cmd.Parameters.RemoveAt("@parametro3");
                            cmd.Parameters.RemoveAt("@parametro4");
                            cmd.Parameters.RemoveAt("@parametro5");
                            cmd.Parameters.RemoveAt("@parametro6");
                            cmd.Parameters.RemoveAt("@parametro7");
                            cmd.Parameters.RemoveAt("@parametro8");
                            cmd.Parameters.RemoveAt("@parametro9");
                            cmd.Parameters.RemoveAt("@parametro10");
                            cmd.Parameters.RemoveAt("@parametro11");
                            cmd.Parameters.RemoveAt("@parametro12");
                            cmd.Parameters.RemoveAt("@parametro13");
                            cmd.Parameters.RemoveAt("@parametro14");
                            cmd.Parameters.RemoveAt("@parametro15");
                            cmd.Parameters.RemoveAt("@parametro16");
                            cmd.Parameters.RemoveAt("@parametro17");
                            cmd.Parameters.RemoveAt("@parametro18");
                            cmd.Parameters.RemoveAt("@parametro19");
                            cmd.Parameters.RemoveAt("@parametro20");
                            cmd.Parameters.RemoveAt("@parametro21");
                            cmd.Parameters.RemoveAt("@parametro22");
                            cmd.Parameters.RemoveAt("@parametro23");
                            cmd.Parameters.RemoveAt("@parametro24");
                            cmd.Parameters.RemoveAt("@parametro25");
                            cmd.Parameters.RemoveAt("@parametro26");
                            cmd.Parameters.RemoveAt("@parametro27");
                            cmd.Parameters.RemoveAt("@parametro28");
                            cmd.Parameters.RemoveAt("@parametro29");
                            cmd.Parameters.RemoveAt("@parametro30");
                            cmd.Parameters.RemoveAt("@parametro31");
                            cmd.Parameters.RemoveAt("@parametro32");

                        }
                        Label3.Visible = true;
                        Label3.Text = "Records added successfully";
                    }
                }
                //------------------- FIN INSERT PAQUECGE MAIN --------------------
                //------------------- INSERT PAQUECGE DETALLES TO SQL --------------------

                string SqlString_Detalle = "Insert Into TBL_Cuba_Package_Main_Detalles(Cuba_Package_Main, Cantidad, Descripcion, Valor, WR)" +
                                           "Values (@parametro1,@parametro2,@parametro3,@parametro4,@parametro5)";

                //DataRow dr = new DataRow();
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlString_Detalle, conn))
                    {
                        conn.Close();

                        foreach (GridViewRow row in GridView4.Rows)
                        {

                            cmd.Parameters.Add("@parametro1", SqlDbType.Int).Value = row.Cells[3].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro2", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[4].Text.Replace("&nbsp;", ""));
                            cmd.Parameters.Add("@parametro3", SqlDbType.NVarChar).Value = row.Cells[5].Text.Replace("&nbsp;", "");
                            cmd.Parameters.Add("@parametro4", SqlDbType.Decimal).Value = Convert.ToDecimal(row.Cells[6].Text.Replace("&nbsp;", ""));
                            cmd.Parameters.Add("@parametro5", SqlDbType.NVarChar).Value = row.Cells[7].Text.Replace("&nbsp;", "");
                            mWR = row.Cells[7].Text;
                            conn.Open();


                            string xx = "select WR from TBL_Cuba_Package_Main_Detalles WHERE WR = '" + mWR + "'";
                            SqlConnection conet = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlDataAdapter da = new SqlDataAdapter(xx, conet);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            int aa = dt.Rows.Count;
                            if (aa == 0 || mRepi == mWR)
                            {
                                cmd.ExecuteNonQuery();
                                mRepi = mWR;

                            }
                            conn.Close();
                            conet.Close();
                            cmd.Parameters.RemoveAt("@parametro1");
                            cmd.Parameters.RemoveAt("@parametro2");
                            cmd.Parameters.RemoveAt("@parametro3");
                            cmd.Parameters.RemoveAt("@parametro4");
                            cmd.Parameters.RemoveAt("@parametro5");

                           
                        }
                        Label3.Visible = true;
                        Label3.Text = "Records added successfully";




                    }

                 
                }
            //------------------- FIN INSERT PAQUECGE DETALLES --------------------

               
        }
       

   
    }
}