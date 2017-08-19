using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

using BusinessRefinery.Barcode.Web;
using BusinessRefinery.Barcode;
using System.Drawing.Imaging;
//using Bytescout.BarCode;
using Microsoft.Reporting.WebForms;
using System.IO;


namespace Package_WebApp.PagesMembers.Reports
{
    public partial class WareHouse_Label : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mYo = (string)Session["m_id_Despacho"]; // Tomar valor del otro forms
            string mWR = (string)Session["m_WR"]; // Tomar valor del otro forms  

            TextBoxManif.Text = mYo;
            TextBox1.Text = mWR;

            if (TextBoxManif.Text == null || TextBoxManif.Text == "")
            {
                TextBoxManif.Text = "4654";
               // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Seleccione paquete a Imprimir....');", true);
            }

            if (TextBoxManif.Text == "4654")
            {
                Response.Redirect("~/PagesMembers/Cuba_PackageRegistro.aspx");
            }
            else
            {
            // Fill the datasource from DB
                LUIS_Warehouse1TableAdapters.DataTable1TableAdapter ta = new LUIS_Warehouse1TableAdapters.DataTable1TableAdapter();
                
                LUIS_Warehouse1.DataTable1DataTable dt = new LUIS_Warehouse1.DataTable1DataTable();




                ta.FillBy(dt, TextBox1.Text);

            int aa = dt.Count;
                //Create an instance of Barcode Professional
                Neodynamic.WebControls.BarcodeProfessional.BarcodeProfessional bcp = new Neodynamic.WebControls.BarcodeProfessional.BarcodeProfessional();
                //Barcode settings
                bcp.Symbology = Neodynamic.WebControls.BarcodeProfessional.Symbology.Code128;
                bcp.BarHeight = 0.25f;
                bcp.DisplayChecksum = false;

                foreach (LUIS_Warehouse1.DataTable1Row row in dt.Rows)
                {
                    //Set the value to encode
                    bcp.Code = TextBox1.Text;
                    //Generate the barcode image and store it into the Barcode Column
                    row.Barcode = bcp.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png);
                }
                // -------- CREAR BARCOD EN EL FORMULARIO -------------//
                System.Data.DataRow dr = dt.Rows[0];
                TextBox1.Text = dr["WR"].ToString();
                Linear barcode = new Linear();
                barcode.Symbology = Symbology.CODE128;
                barcode.Code = TextBox1.Text;  //"re0123456789";
                barcode.Resolution = 104;
                // barcode.Rotate = Rotate.Rotate180;
                barcode.Format = ImageFormat.Png;
                String path = Server.MapPath("~/Iconos/");
                barcode.drawBarcode2ImageFile(path + "BarcodePNG.png");
                //----------
                ReportDataSource RD = new ReportDataSource();
                RD.Value = dt;
                RD.Name = "DataSet1";
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(RD);
                ReportViewer1.LocalReport.ReportEmbeddedResource = "PagesMembers/LabelBarcode.rdlc";
                ReportViewer1.LocalReport.ReportPath = @"PagesMembers/rdlc__LabelBarcode.rdlc";   //   ~/PagesMembers/Reports/
                ReportViewer1.LocalReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;
                string reportsTitle = "LabelReport";
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //FileStream fs = new FileStream(@"d\output.pdf", FileMode.Create); // para crearlo en un dir fisico en memoria
                FileStream fs = new FileStream(Server.MapPath("~/PagesMembers/" + reportsTitle + "." + "pdf"), FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                Label1.Text = "Report exported";
                // Fin exporter fichero
                // System.Diagnostics.Process.Start(@"d:\output.pdf"); // Abre fichero en formato PDF

                // Abrir PDF en un tab del propio navegador
                string FilePath = Server.MapPath("~/PagesMembers/LabelReport.pdf");
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