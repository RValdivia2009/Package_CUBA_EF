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
    public partial class Cuba_PackageManifiesto : System.Web.UI.Page
    {
        string str_Manifiesto = "SELECT id_Manifiestos, nom_Manifiesto, fecha FROM tbl_Cuba_Manifiestos";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Panel1.Visible = false;
                GridView1.DataBind();
                llenarcomboManifiesto();
            }

        }


        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {

            if (tb_Manifiesto.Text == null || tb_Manifiesto.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('El Numero de manifiesto es REQUIRED....');", true);
            }

            else
            {
                //conecxion a la base de datos..
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
                conn.Open();
                SqlCommand cmd = new SqlCommand("ManifiestoALL", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoAccion", 1);
                cmd.Parameters.AddWithValue("@Nom_Manifiesto", tb_Manifiesto.Text);
                cmd.Parameters.AddWithValue("@id_Manifiestos", 0);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                SqlDataReader dr = cmd.ExecuteReader();
                tb_Manifiesto.Text = "";
                conn.Close();
                Panel1.Visible = false;
                GridView1.DataBind();
                det_New.Visible = true;


                //SqlDataAdapter da = new SqlDataAdapter(str_Manifiesto, conn);   // creo dataadapter
                //da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                //SqlCommandBuilder cb = new SqlCommandBuilder(da);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                //DataRow drnew = dt.NewRow();
                //drnew["nom_Manifiesto"] = tb_Manifiesto.Text;
                //drnew["fecha"] = DateTime.Now;
                //dt.Rows.Add(drnew);
                //da.Update(dt);
                //dt.AcceptChanges();
                //Panel1.Visible = false;
                //tb_Manifiesto.Text = "";
                //conn.Close();
                //GridView1.DataBind();
                //det_New.Visible = true;
            }

        }

        protected void det_New_Click(object sender, ImageClickEventArgs e)
        {
            Panel1.Visible = true;
            det_New.Visible = false;
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            tb_Manifiesto.Text = "";
            Panel1.Visible = false;
            det_New.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            Panel1.Visible = true;
            tb_Manifiesto.Text = gr.Cells[2].Text;
            string idm = gr.Cells[1].Text;
        }

        protected void tb_ManifiestoIMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["m_Mani"] = tb_ManifiestoIMP.SelectedValue; // Pasar valor al otro forms
        }

        protected void ImageButtonMani_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_ManifiestoIMP.Text == "<-- Manifiesto -->")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Seleccione Manifiesto a Imprimir....');", true);
            }

            Response.Redirect("~/PagesMembers/Rep_WareHouseManifiesto.aspx");
        }

        public void llenarcomboManifiesto()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_Manifiestos
                                select new { c.id_Manifiestos, c.Nom_Manifiesto }).ToList();
                tb_ManifiestoIMP.DataValueField = "id_Manifiestos";
                tb_ManifiestoIMP.DataTextField = "Nom_Manifiesto";
                tb_ManifiestoIMP.DataSource = category;
                //    tb_Manifiesto.Text = tb_Manifiesto.SelectedValue;
                tb_ManifiestoIMP.DataBind();
            }
        }

    }
}