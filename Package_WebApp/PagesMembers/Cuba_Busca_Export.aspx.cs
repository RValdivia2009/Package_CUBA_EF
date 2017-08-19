
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Package_WebApp.Properties;
using System.Data.SqlClient;
using Ionic.Zip;





namespace Package_WebApp.PageAdmin
{
    public partial class Cuba_Busca_Export : System.Web.UI.Page
    {
        string mFiltroFichero = "";
        string mMyFiltro = "";
        string filepath, TableName, MyZip = "";


        OleDbConnection dBaseConnection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Panel1.Visible = false;
               // Label1.Visible = false;
                export.Visible = false;
   
            }
         }

        private void llenarGrid_1()
        {

           using(DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities()) // BUSCAR REGUSTROS PARA EXPORTAR
           {
               var MyDatos = (from p in conect.Cuba_Busqueda_All_Packages
                              where p.AEB == Tb_AWB.Text
                                           select new
                                           {
                                               Paquete = p.WR,
                                               Destinatario = p.Dest_Nombre,
                                               Sender = p.Sender_Nombre,
                                               Manifiesto = p.Nom_Manifiesto,
                                               AWB = p.AEB,
                                               LetraF = p.Fich_Letra,
                                           });
               int mm = MyDatos.Count();
               if (mm == 0)
               {
                   Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('No existen paquetes con este AWB....');", true);
               }
               else
               {
                   GridView1.DataSource = MyDatos;
                   GridView1.DataBind();
               }

           
           }
           using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
           {
               var MyMain = from q in conect.TBL_Cuba_Package_Main
                            where q.AEB == Tb_AWB.Text
                            group q by q.Fich_Letra into grupo
                            select new
                            {
                                grupo.Key,
                                Letra = grupo.FirstOrDefault()
                            };
                GridView2.DataSource = MyMain;
                GridView2.DataBind();
                Lab_Fiche.Text = MyMain.Count().ToString();
                Lab_FicheZIP.Text = "Cubapack" + Tb_AWB.Text + ".zip";

           }
           Panel1.Visible = true;
            

        }


        private DataTable GenerateData()
        {
            DataTable dt = new DataTable();
            if (Tb_AWB.Text == "" || Tb_AWB.Text == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Debe indicar el numero d AWB....');", true);
            }
            else
            {

                DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities();
                var MyDatos = (from p in conect.Cuba_Busqueda_All_Packages
                               where (p.AEB == Tb_AWB.Text && p.Fich_Letra == mMyFiltro)
                               select p);
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("CFIST", typeof(string)));
                dt.Columns.Add(new DataColumn("CLAST", typeof(string)));
                dt.Columns.Add(new DataColumn("RECFIRST", typeof(string)));
                dt.Columns.Add(new DataColumn("RECLAST", typeof(string)));
                dt.Columns.Add(new DataColumn("RECALLE", typeof(string)));
                dt.Columns.Add(new DataColumn("RNUMERO", typeof(string)));
                dt.Columns.Add(new DataColumn("RAPT", typeof(string)));
                dt.Columns.Add(new DataColumn("RENTRECALL", typeof(string)));
                dt.Columns.Add(new DataColumn("RLOCALIDAD", typeof(string)));
                dt.Columns.Add(new DataColumn("RPROVINCIA", typeof(string)));
                dt.Columns.Add(new DataColumn("PAQPESOTOT", typeof(string)));
                dt.Columns.Add(new DataColumn("PAQENVCOUR", typeof(string)));

                int totalRow = MyDatos.Count();

                foreach (var Myvalor in MyDatos)
                {
                    dr = dt.NewRow();
                    dr["CFIST"] = Myvalor.Sender_Nombre;
                    dr["CLAST"] = Myvalor.Sender_Apellido;
                    dr["RECFIRST"] = Myvalor.Dest_Nombre;
                    dr["RECLAST"] = Myvalor.Dest_Apellido;
                    dr["RECALLE"] = Myvalor.Calle;
                    dr["RNUMERO"] = Myvalor.Dest_No;
                    dr["RAPT"] = Myvalor.Dest_Apto;
                    dr["RENTRECALL"] = Myvalor.Entre_Calles;
                    dr["RLOCALIDAD"] = Myvalor.Municipios;
                    dr["RPROVINCIA"] = Myvalor.Provincia;
                    dr["PAQPESOTOT"] = Myvalor.Weight;
                    dr["PAQENVCOUR"] = Myvalor.WR;

                    dt.Rows.Add(dr);
                }
              
            }
            return dt;
        }

        private void CreateDBFFile()
        {

            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                string mm = mMyFiltro;
                var MyMain = from q in conect.TBL_Cuba_Package_Main
                             where q.AEB == Tb_AWB.Text
                             group q by q.Fich_Letra into grupo
                             select new
                             {
                                 grupo.Key,
                                 Letra = grupo.FirstOrDefault()
                             };
              //  GridView2.DataSource = MyMain;
             //   GridView2.DataBind();

                int mTotalRow = MyMain.Count();
                foreach (var MyValor in MyMain)
                {
                    mMyFiltro = MyValor.Letra.Fich_Letra;
                    mFiltroFichero = MyValor.Letra.Fich_Letra + Tb_AWB.Text;

                    filepath = null;
                    filepath = Server.MapPath("~//Download//");

                   // string TableName = "T" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace("AM", "").Replace("PM", "");
                    TableName = mFiltroFichero;

                    using (dBaseConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + " Data Source=" + filepath + "; " + "Extended Properties=dBase IV"))
                    {
                        dBaseConnection.Open();

                        OleDbCommand olecommand = dBaseConnection.CreateCommand();

                        if ((System.IO.File.Exists(filepath + "" + TableName + ".dbf")))
                        {
                            System.IO.File.Delete(filepath + "" + TableName + ".dbf");
                            olecommand.CommandText = "CREATE TABLE [" + TableName + "] ([CFIST] varchar(80), [CLAST] varchar(80), [RECFIRST] varchar(80), [RECLAST] varchar(80), [RECALLE] varchar(80), [RNUMERO] varchar(80), [RAPT] varchar(80), [RENTRECALL] varchar(80), [RLOCALIDAD] varchar(80), [RPROVINCIA] varchar(80), [PAQPESOTOT] Numeric(10), [PAQENVCOUR] varchar(80))";
                            olecommand.ExecuteNonQuery();
                        }
                        else
                        {
                            System.IO.File.Delete(filepath + "" + TableName + ".dbf");
                            olecommand.CommandText = "CREATE TABLE [" + TableName + "] ([CFIST] varchar(80), [CLAST] varchar(80), [RECFIRST] varchar(80), [RECLAST] varchar(80), [RECALLE] varchar(80), [RNUMERO] varchar(80), [RAPT] varchar(80), [RENTRECALL] varchar(80), [RLOCALIDAD] varchar(80), [RPROVINCIA] varchar(80), [PAQPESOTOT] Numeric(10), [PAQENVCOUR] varchar(80))";
                            olecommand.ExecuteNonQuery();
                        }

                        OleDbDataAdapter oleadapter = new OleDbDataAdapter(olecommand);
                        OleDbCommand oleinsertCommand = dBaseConnection.CreateCommand();



                        foreach (DataRow dr in GenerateData().Rows)
                        {
                            string CFIST = dr["CFIST"].ToString();
                            string CLAST = dr["CLAST"].ToString();
                            string RECFIRST = dr["RECFIRST"].ToString();
                            string RECLAST = dr["RECLAST"].ToString();
                            string RECALLE = dr["RECALLE"].ToString();
                            string RNUMERO = dr["RNUMERO"].ToString();
                            string RAPT = dr["RAPT"].ToString();
                            string RENTRECALL = dr["RENTRECALL"].ToString();
                            string RLOCALIDAD = dr["RLOCALIDAD"].ToString();
                            string RPROVINCIA = dr["RPROVINCIA"].ToString();
                            string PAQPESOTOT = dr["PAQPESOTOT"].ToString();
                            string PAQENVCOUR = dr["PAQENVCOUR"].ToString();

                            oleinsertCommand.CommandText = "INSERT INTO [" + TableName + "] ([CFIST], [CLAST], [RECFIRST], [RECLAST], [RECALLE], [RNUMERO], [RAPT], [RENTRECALL], [RLOCALIDAD], [RPROVINCIA], [PAQPESOTOT], [PAQENVCOUR]) VALUES ('" + CFIST + "','" + CLAST + "','" + RECFIRST + "','" + RECLAST + "','" + RECALLE + "','" + RNUMERO + "','" + RAPT + "','" + RENTRECALL + "','" + RLOCALIDAD + "','" + RPROVINCIA + "','" + PAQPESOTOT + "','" + PAQENVCOUR + "')";

                            //    oleinsertCommand.CommandText = "INSERT INTO [" + TableName + "] ([Column1], [Column2], [Column3], [Column4])                                                                                                  VALUES ('" + Column1 + "','" + Column2 + "','" + Column3 + "','" + Column4 + "')";

                            oleinsertCommand.ExecuteNonQuery();
                        }
                    }

                    // Creacion de .ZIP
                    try  
                    {
                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(filepath);
                            zip.Save(HttpContext.Current.Server.MapPath("~/Download/" + "Frontline" + Tb_AWB.Text + ".zip"));
                            MyZip = "Frontline" + Tb_AWB.Text;
                        }
                    }
                    catch
                    {
                    }
                   
                }

                // Borro los archivos con extencion *.dbf
                string[] files = Directory.GetFiles(filepath, "*.dbf");
                foreach (string file in files)
                {
                    System.IO.File.Delete(file);
                }
                //---

                FileStream sourceFile = new FileStream(filepath + "" + MyZip + ".zip", FileMode.Open);
                float FileSize = 0;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[Convert.ToInt32(Math.Truncate(FileSize))];
                sourceFile.Read(getContent, 0, Convert.ToInt32(sourceFile.Length));
                sourceFile.Close();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Buffer = true;
                Response.ContentType = "application/dbf";
                Response.AddHeader("Content-Length", getContent.Length.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" + MyZip + ".zip");
                Response.BinaryWrite(getContent);
                Response.Flush();

                // Borro los archivos con extencion *.ZIP
                string[] files1 = Directory.GetFiles(filepath, "*.zip");
                foreach (string file1 in files1)
                {
                    System.IO.File.Delete(file1);
                }
                //---
                
                //System.IO.File.Delete(filepath + "" + TableName + ".dbf");
                //Response.End();
            }
           
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            llenarGrid_1();
            export.Visible = true;
        }

        protected void export_Click(object sender, EventArgs e)
        {
            export.Visible = false;
            CreateDBFFile();
        }






  

    }
}