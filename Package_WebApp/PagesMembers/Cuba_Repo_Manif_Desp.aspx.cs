using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Package_WebApp.PageAdmin
{
    public partial class Cuba_Repo_Manif_Desp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              llenarcomboManifiesto();
              llenarcomboAWB();
            }

        }

        protected void tb_ManifiestoIMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["m_Mani"] = tb_ManifiestoIMP.SelectedValue; // Pasar valor al otro forms
        }

        protected void tb_AWB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["m_AWB"] = tb_AWB.SelectedValue; // Pasar valor al otro forms
        }

        public void llenarcomboManifiesto()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_Manifiestos
                                orderby c.id_Manifiestos descending
                                select new { c.id_Manifiestos, c.Nom_Manifiesto }).ToList();
               
                tb_ManifiestoIMP.DataValueField = "id_Manifiestos";
                tb_ManifiestoIMP.DataTextField = "Nom_Manifiesto";
                tb_ManifiestoIMP.DataSource = category;
                tb_ManifiestoIMP.DataBind();
            }
        }

        public void llenarcomboAWB()
        {
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in conect.TBL_Cuba_Package_Main
                                orderby c.id_Cuba_Package_Main descending
                                select new { AWB = c.AEB }).Distinct().ToList();

                tb_AWB.DataValueField = "AWB";
                tb_AWB.DataTextField = "AWB";
                tb_AWB.DataSource = category;
                tb_AWB.DataBind();

                 //group c by c.AEB into newGroup
                 //              orderby newGroup.Key
            }
        
        }

        protected void ImageButtonMani_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_ManifiestoIMP.Text == "<-- Manifiesto -->")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Seleccione Manifiesto a Imprimir....');", true);
            }

            Response.Redirect("~/PagesMembers/Reports/WareHouseManifiesto.aspx");     
        }

        protected void ImageButtonMani0_Click(object sender, ImageClickEventArgs e)
        {
            if (tb_ManifiestoIMP.Text == "<-- Manifiesto -->")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Seleccione Manifiesto a Imprimir....');", true);
            }

            Response.Redirect("~/PagesMembers/Reports/WareHouseManifiesto_AWB.aspx");

        }





    }
}