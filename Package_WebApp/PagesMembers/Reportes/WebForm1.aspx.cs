using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Reporting.WebForms;
using System.Configuration; 



namespace Package_WebApp.PagesMembers.Reportes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string filepath;
        ReportDocument rdoc = new ReportDocument();
       
        public int val;
        protected void Page_Load(object sender, EventArgs e)
        {
           int mYo = (int)Session["Nombre"]; // Tomar valor del otro forms
          
            string selectLabel = " SELECT dbo.TBL_Package_Main.id_Package_Main, dbo.TBL_Package_Main.Date, dbo.TBL_Package_Main_Detalles.Tracking, dbo.TBL_Package_Main_Detalles.Long, " +
                       "dbo.TBL_Package_Main_Detalles.High, dbo.TBL_Package_Main_Detalles.Weight, dbo.TBL_Package_Main_Detalles.Quantity, " +
                       "dbo.TBL_Package_Main_Detalles.Descrip, dbo.TBL_Package_Main_Detalles.id_WR, dbo.TBL_Package_Main_Detalles.Wide, dbo.TBL_Package_Main_Detalles.Value, " +
                       "dbo.TBL_Package_Main_Detalles.TotalValue, dbo.tbl_N_Agen_Shipper.Name_Agen_Shipper, dbo.tbl_N_Agen_Destination.Name_Agen_Destination, dbo.tbl_N_Consignee.Nom_Consignee, " +
                       "dbo.tbl_N_Estado_Package.Estados, dbo.tbl_N_Location.Name_Location, dbo.TBL_Package_Main.WR, dbo.TBL_Package_Main.Usuario " +

                       //"FROM ((((((dbo.TBL_Package_Main INNER JOIN dbo.TBL_Package_Main_Detalles ON dbo.TBL_Package_Main.id_Package_Main = dbo.TBL_Package_Main_Detalles.Package_Main) " +
                       //       "INNER JOIN dbo.tbl_N_Agen_Shipper ON dbo.TBL_Package_Main.Agen_Shipper = dbo.tbl_N_Agen_Shipper.Id_Agen_Shipper) " +
                       //       "INNER JOIN dbo.tbl_N_Agen_Destination ON dbo.TBL_Package_Main.Agen_Destination = dbo.tbl_N_Agen_Destination.id_Agen_Destination) " +
                       //       "INNER JOIN dbo.tbl_N_Consignee ON dbo.TBL_Package_Main.Congsinne = dbo.tbl_N_Consignee.id_Consignee) " +
                       //       "INNER JOIN dbo.tbl_N_Estado_Package ON dbo.TBL_Package_Main.EstadosPackege = dbo.tbl_N_Estado_Package.id_estado) " +
                       //       "INNER JOIN dbo.tbl_N_Location ON dbo.TBL_Package_Main.Location = dbo.tbl_N_Location.id_Location)" +

                      "FROM ((((((dbo.TBL_Package_Main INNER JOIN dbo.tbl_N_Agen_Shipper ON dbo.TBL_Package_Main.Agen_Shipper = dbo.tbl_N_Agen_Shipper.Id_Agen_Shipper) " + 
                              "INNER JOIN dbo.tbl_N_Agen_Destination ON dbo.TBL_Package_Main.Agen_Destination = dbo.tbl_N_Agen_Destination.id_Agen_Destination) " +
                              "INNER JOIN dbo.tbl_N_Consignee ON dbo.TBL_Package_Main.Congsinne = dbo.tbl_N_Consignee.id_Consignee) " +
                              "INNER JOIN dbo.tbl_N_Estado_Package ON dbo.TBL_Package_Main.EstadosPackege = dbo.tbl_N_Estado_Package.id_estado) " + 
                              "INNER JOIN dbo.tbl_N_Location ON dbo.TBL_Package_Main.Location = dbo.tbl_N_Location.id_Location) " + 
                              "LEFT OUTER JOIN dbo.TBL_Package_Main_Detalles ON dbo.TBL_Package_Main.id_Package_Main = dbo.TBL_Package_Main_Detalles.Package_Main) " +

                        "WHERE id_Package_Main = " + mYo + ";";

           
            

            string conexion = Properties.Settings.Default.ConnectionString;
            using (SqlConnection sqlconexion = new SqlConnection(conexion))
            {
                //-- Crea el dataAdapter
                SqlDataAdapter da = new SqlDataAdapter(selectLabel, sqlconexion);
                //-- Crea un Datatable
                System.Data.DataTable dtmio = new System.Data.DataTable();
                //-- llena el DataTable con el dataAdapter
                da.Fill(dtmio);
                DataSet ds = new DataSet();
               // da.Fill(ds);
               
                PagesMembers.Reportes.LabelPackage report = new LabelPackage();
                report.SetDataSource(dtmio);
                CrystalReportViewer1.ReportSource = report;


               // rdoc.Load(Server.MapPath("~/PagesMembers/Reportes/LabelPackage.rpt"));
               // rdoc.FileName = Server.MapPath("~/PagesMembers/Reportes/LabelPackage.rpt");
               // rdoc.SetDataSource(ds);
               // CrystalReportViewer1.ReportSource = rdoc;
               // pdfcontroller();
               // sqlconexion.Close();


            }
        }
       public void pdfcontroller()
      {
            Response.Clear();
            filepath = Server.MapPath("~/" + "sample.pdf");
            rdoc.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filepath);
            Response.AddHeader("Content-Disposition", "inline; filename = sample.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(fileInfo.FullName);
     
          
  
          

      }
        
    }
}