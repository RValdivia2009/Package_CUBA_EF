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


namespace Package_WebApp
{
    public partial class Cuba_PackageTarifas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.SelectedIndex = -1;
            if (!IsPostBack)
            {
                llena_DropZona();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            //id_sender.Text = gr.Cells[2].Text;
        }

        protected void llena_DropZona()
        {
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var MyZona = (from p in conect.tbl_Cuba_N_tarif_Duraderos
                              orderby p.Zonas
                              select new {p.Zonas}).Distinct().ToList();

                Drop_Zonas.DataValueField = "Zonas";
                Drop_Zonas.DataTextField = "Zonas";
                Drop_Zonas.DataSource = MyZona;
                Drop_Zonas.DataBind();

            }
        
        }

        protected void Drop_Zonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

    }
}