using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

using Bytescout.BarCode;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace Package_WebApp.PagesMembers.Reports
{
    public partial class WareHouseManifiesto : System.Web.UI.Page
    {
        string aa;
        protected void Page_Load(object sender, EventArgs e)
        {
            string mYo = (string)Session["m_Mani"]; // Tomar valor del otro forms
            TextBoxManif.Text = mYo;

            if (TextBoxManif.Text == null || TextBoxManif.Text == "")
            {
                TextBoxManif.Text = "4654";
            }
            if (TextBoxManif.Text == "4654")
            {
                Response.Redirect("~/PagesMembers/Cuba_PackageManifiesto.aspx");
            }
            else
            {
                
                
                ManifiestoNew1TableAdapters.DataTable1TableAdapter ta = new ManifiestoNew1TableAdapters.DataTable1TableAdapter();
                ManifiestoNew1.DataTable1DataTable dt = new ManifiestoNew1.DataTable1DataTable();


                ta.FillBy(dt, Convert.ToInt32(TextBoxManif.Text));

                int aa = dt.Count;

                

                if (dt.Count == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('No hay label a Imprimir revice Comodities....');", true);

                }

                // Create and setup an instance of Bytescout Barcode SDK
                Barcode bc = new Barcode(SymbologyType.Code128);

                bc.RegistrationName = "demo";
                bc.RegistrationKey = "demo";
                bc.DrawCaption = false;
                

                // Update DataTable with barcode image
                foreach (ManifiestoNew1.DataTable1Row row in dt.Rows)
                {
                    // Set the value to encode
                    bc.Value = row.WR.ToString();
                 //   aa = Convert.ToInt32(row.Zona.ToString());

                    // Generate the barcode image and store it into the Barcode Column
                    row.Barcode = bc.GetImageBytesPNG();
                }
                ReportDataSource RD = new ReportDataSource();
                RD.Value = dt;
                RD.Name = "DataSet1";

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(RD);
                ReportViewer1.LocalReport.ReportEmbeddedResource = "PagesMembers/WareHouseManifiesto.rdlc";
                ReportViewer1.LocalReport.ReportPath = @"PagesMembers/rdlc__WareHouseManifiesto.rdlc";   //   ~/PagesMembers/Reports/
                ReportViewer1.LocalReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string reportsTitle = "Manifiesto";
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //FileStream fs = new FileStream(@"d\output.pdf", FileMode.Create); // para crearlo en un dir fisico en memoria
                FileStream fs = new FileStream(Server.MapPath("~/PagesMembers/" + reportsTitle + "." + "pdf"), FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                Label1.Text = "Report exported";
                // Fin exporter fichero
                // System.Diagnostics.Process.Start(@"d:\output.pdf"); // Abre fichero en formato PDF

                // Abrir PDF en un tab del propio navegador
                string FilePath = Server.MapPath("~/PagesMembers/Manifiesto.pdf");
                System.Net.WebClient User = new System.Net.WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
     
  }


        }
    }
}