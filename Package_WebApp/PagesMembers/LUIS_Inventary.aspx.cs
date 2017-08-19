using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Package_WebApp.PagesMembers
{
    public partial class LUIS_Inventary : System.Web.UI.Page
    {
        double totalWeight = 0;
        decimal totalValor, TotalVolumen = 0;
        string carpeta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Text = carpeta;
                Label3.Visible = false;
                //      Panel1.Visible = false;
                Panel2.Visible = false;
                insert.Visible = false;
                cancel.Visible = false;


            }
            // donde guardamos el file
            carpeta = Path.Combine(Request.PhysicalApplicationPath, "Data_Import");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

            //verificar si se seleccionó el archivo
            if (FileUpload1.PostedFile.FileName == "")
            {
                Label3.Text = "You have not selected any file";
                Label3.Visible = true;
            }
            else
            {
                //verificar extencion
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                switch (extension.ToLower())
                {
                    //validar
                    case ".xls":
                    case ".xlsx":
                        break;
                    //no validamos
                    default:
                        Label3.Text = "Extension no valida";
                        return;
                }
                // Copiar archivo
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

            }
            actualizarGrid();
            TextBoxDest.Text = TextBoxDest.Text;
            Panel1.Visible = true;
            Panel2.Visible = true;
        }

        public void actualizarGrid()
        {
            if (Label4.Text == "Label")
            {
                Label3.Text = "You have not selected and update any file";
                Label3.Visible = true;
            }
            else
            {
                string archivo = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string mPath = Path.Combine(carpeta, Label4.Text);

                OleDbConnection objConn = new OleDbConnection();
                OleDbCommand objCmd = new OleDbCommand();
                OleDbDataAdapter objDa = new OleDbDataAdapter();

                objConn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;" + ("Data Source=" + (mPath + ";Extended Properties=\"Excel 12.0;HDR=YES\"")));
                objConn.Open();
                objCmd.CommandText = "SELECT * FROM [Manifiesto_Cpack$]";
                objCmd.Connection = objConn;
                objDa.SelectCommand = objCmd;
                System.Data.DataTable dt = new System.Data.DataTable();
                objDa.Fill(dt);
                GridView1.DataSource = dt;//.Tables[0];
                GridView1.DataBind();

                T_Paquetes.Text = Convert.ToString(dt.Rows.Count);


                if (dt.Rows.Count > 0)
                {
                    cancel.Visible = true;
                    insert.Visible = true;
                }
                else
                {

                }


            }
            //        Panel1.Visible = false;

        }

        //protected void destino_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   // destino.Text = TextBoxDest.Text;
        //    Panel1.Visible = true;

        //}

        protected void insert_Click(object sender, EventArgs e)
        {
            if (TextBoxDest.Text == "" || TextBoxDest.Text == "<-- Select -->")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Before, enter  MANIFEST OR INVENTARY NUMBER  ....');", true);
            }
            else
            {
                //string SqlString = "Insert Into tbl_N_Consignee (Nom_Consignee, Email, Agen_Destination) Values (@parametro1,@parametro2,@parametro3)";

                //SELECT id_Paquete, [Paquete No.], [Peso (Kgs)], Zona, [Tipo de Recogida], Envio, Duraderos, Caja, [Nombre Rem.], [Direccion Rem.], [Nombre Dest.], 
                //[Direcion Dest.], [Tel.Dest.], [No. Carnet Id.], Contenido FROM dbo.LUIS_Scanning

                //id_Paquete, Paquete, Peso, Zona, TipoRecogida, Envio, Duraderos, Caja, NombreRem, DireccionRem, 
                //NombreDest, DirecionDest, NoCarnet, Contenido, Inv, Repack FROM         dbo.LUIS_Scanning

              //  string SqlString1 = "INSERT INTO Customers (CustomerName, Country) SELECT SupplierName, Country FROM Suppliers WHERE Country='Germany'";

                string SqlString = "Insert Into dbo.LUIS_Scanning (Paquete, Peso, Zona, TipoRecogida, Envio, Duraderos, Caja, NombreRem, DireccionRem, NombreDest, DirecionDest, NoCarnet) Values (@parametro1,@parametro2,@parametro3,@parametro4,@parametro5,@parametro6,@parametro7,@parametro8,@parametro9,@parametro10,@parametro11,@parametro12)";
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlString, conn))
                        {
                            conn.Close();
                            // cmd.CommandType = System.Data.CommandType.Text;

                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                cmd.Parameters.Add("@parametro1", SqlDbType.NVarChar).Value = row.Cells[0].Text;
                                cmd.Parameters.Add("@parametro2", SqlDbType.Decimal).Value = row.Cells[1].Text;
                                cmd.Parameters.Add("@parametro3", SqlDbType.NVarChar).Value = row.Cells[3].Text;
                                cmd.Parameters.Add("@parametro4", SqlDbType.NVarChar).Value = row.Cells[4].Text;
                                cmd.Parameters.Add("@parametro5", SqlDbType.NVarChar).Value = row.Cells[5].Text;
                                cmd.Parameters.Add("@parametro6", SqlDbType.NVarChar).Value = row.Cells[6].Text;
                                cmd.Parameters.Add("@parametro7", SqlDbType.NVarChar).Value = row.Cells[7].Text;
                                cmd.Parameters.Add("@parametro8", SqlDbType.NVarChar).Value = row.Cells[8].Text;
                                cmd.Parameters.Add("@parametro9", SqlDbType.NVarChar).Value = TextBoxDest.Text;//row.Cells[2].Text; 
                                cmd.Parameters.Add("@parametro10", SqlDbType.NVarChar).Value = row.Cells[10].Text;
                                cmd.Parameters.Add("@parametro11", SqlDbType.NVarChar).Value = row.Cells[11].Text;
                                cmd.Parameters.Add("@parametro12", SqlDbType.NVarChar).Value = row.Cells[12].Text;
                                //  cmd.Parameters.Add("@parametro13", SqlDbType.NVarChar).Value = row.Cells[13].Text;
                                //   cmd.Parameters.Add("@parametro14", SqlDbType.NVarChar).Value = row.Cells[14].Text;

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
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
                                //    cmd.Parameters.RemoveAt("@parametro13");
                                //    cmd.Parameters.RemoveAt("@parametro14");
                            }
                            Label3.Visible = true;
                            Label3.Text = "Records added successfully";
                        }
                    }

                }
                GridView1.DataSource = null;
                GridView1.DataBind();
                insert.Visible = false;
                cancel.Visible = false;
            }
            T_Paquetes.Text = "";
            T_PesoLb.Text = "";
            Panel2.Visible = false;
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            insert.Visible = false;
            cancel.Visible = false;
            T_Paquetes.Text = "";
            T_PesoLb.Text = "";
            Panel2.Visible = false;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowType != DataControlRowType.EmptyDataRow))
            {

                // totalWeight += Convert.ToInt32(e.Row.Cells[1].Text);
                totalValor += Convert.ToDecimal(e.Row.Cells[1].Text);
                // TotalVolumen += Convert.ToDecimal(e.Row.Cells[13].Text);

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].Text = "Totales";

                // e.Row.Cells[4].Text = "WeightTotal: ";
                e.Row.Cells[1].Text = Convert.ToString(totalValor);
                T_Peso.Text = e.Row.Cells[1].Text;


                double a = 2.2046;
                double b = 0;

                totalWeight = Convert.ToDouble(T_Peso.Text) / a;
                b = Convert.ToDouble(T_Peso.Text) * a;
                b = Math.Round(b, 2);
                T_PesoLb.Text = Convert.ToString(b);


                // e.Row.Cells[7].Text = "Valor: ";
                // e.Row.Cells[8].Text = Convert.ToString(totalValor);

                // e.Row.Cells[10].Text = "Volumen: ";
                // e.Row.Cells[11].Text = Convert.ToString(TotalVolumen);




            }
        }
    }
}