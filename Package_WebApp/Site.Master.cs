using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Package_WebApp
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("m_agencia", "100000"); // Pasar valor al otro forms
            Session.Add("m_agenPack", "1161001060000"); // Pasar valor al otro forms
           
        }
    }
}
