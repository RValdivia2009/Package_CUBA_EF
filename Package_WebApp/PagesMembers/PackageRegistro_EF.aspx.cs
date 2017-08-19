using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.EntityModel;

using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net.Mail;
using System.Net; 



namespace Package_WebApp.PagesMembers
{
    public partial class PackageRegistro_EF : System.Web.UI.Page
    {
        DB_82130_itndatabaseEntities mm = new DB_82130_itndatabaseEntities();
        string ss, dd = "";
        private static int visitCounter = 0;
        string mZonaDura = "";
        string mMyAgenPack = "";
        string mMyAgen = "";

        //string mDestino = "";
        //string mSender = "";
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            mMyAgen = (string)Session["m_agencia"]; // Rcoge valores 
            mMyAgenPack = (string)Session["m_agenPack"]; // Rcoge valores
            //bt_DeCliente.Visible = false;
            lblMensajeError.Visible = false;
           // tb_Sender.Visible = false;
           
            if (!IsPostBack)
            {
                AgreraPak.Visible = false;
                llenarcomboSender();
                tb_FechaComprobante.Text = DateTime.Now.ToString(("yyyy-MM-dd"));
               
                actualizarForm();
               // llenarGridview4();
                llenarFormaPago();
                llenarTipo_Entraga();
                llenarcomboProvincia();
                llenarcomboMunicipios();
                llenarcomboTipoEnvio();
                llenarcomboDetinatario();
                llenarcomboEstado();
                llenarcomboManifiesto();
                Label_Sender.Text = "";
                Panel2.Visible = false;
                Panel_Dura_Detalle.Visible = false;
                Cancel_Main.Visible = false;
                llenarDropAduana();
            }

            if (Request.QueryString["habilitar"] == "1")
            {
                string a = Request.QueryString["habilitar"];
                AgreraPak.Visible = true;//(Request.QueryString["habilitar"] == "1"); // Recoge parametro de web cliente para habilitar boton
                string mDestino = (string)Session["m_Dest"];
                string mSender = (string)Session["m_sender"];
                id_Sender.Text = mSender;
                id_Destinatario.Text = mDestino;
               

              //  dd = Convert.ToInt32(id_Destinatario);
              //  tb_Destinatario_TextChanged(dd, null);


                string mSUDestino = (string)Session["m_SUDest"]; // Rcoge valores
                string mSUSender = (string)Session["m_SUsender"];

                // reflect to readonly property
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                Request.QueryString.Set("habilitar", "123");
                // make collection readonly again
                isreadonly.SetValue(this.Request.QueryString, true, null);
                AgreraPak.Text = "Agregar paquete a : " + mSUSender; // Asigna al boton

          }
            
        }

        private void actualizarForm()
        {
            DeshabilitarCajasMain();
            using (DB_82130_itndatabaseEntities dbPer = new DB_82130_itndatabaseEntities())
            {
                IQueryable<TBL_Cuba_Package_Main> MyMain = (from q in dbPer.TBL_Cuba_Package_Main
                                                            orderby q.id_Cuba_Package_Main
                                                            select q);
                List<TBL_Cuba_Package_Main> lista = MyMain.ToList();
                var mMain = lista.LastOrDefault();

                Label1.Text = mMain.id_Cuba_Package_Main.ToString();
                tb_Manifiesto.Text = mMain.Manifiesto.ToString();
                WR.Text = mMain.WR.ToString();
                tb_Sender.SelectedValue = mMain.Cod_Sender1.ToString();
                llenarcomboSender();
                id_Sender.Text = tb_Sender.SelectedValue;
                llenarcomboDetinatario();
                tb_Destinatario.SelectedValue = mMain.Dod_Destino1.ToString();
                id_Destinatario.Text = tb_Destinatario.SelectedValue;
                tb_TipoEntrega.SelectedValue = mMain.TipoEntrega.ToString();
                id_TipoEntrega.Text = tb_TipoEntrega.Text;

                
                FechaHoy.Text = mMain.Date.Value.Date.ToString("MM/dd/yyyy");
                
                
                
                tb_Notas.Text = mMain.Note.ToString();
                tb_Zona.Text = mMain.Zona.ToString();

                if (mMain.Descuento.ToString() == "") { tb_Desc.Text = "0.00"; }
                else { tb_Desc.Text = mMain.Descuento.ToString(); }
              //  llenarFormaPago();
                if (mMain.FormaPago.ToString() == "") { tb_FormaPago.Text = "1"; }
                else { tb_FormaPago.Text = mMain.FormaPago.ToString(); }
                id_formaPago.Text = tb_FormaPago.Text;
                lb_Total.Text = mMain.PrecioTotal.ToString();
               

                tb_Manifiesto.SelectedValue = mMain.Manifiesto.ToString();
                //llenarcomboEstado();
                string aa = mMain.Estado.ToString();
                tb_Estado.SelectedValue = aa;  //dr["Estado"].ToString();
                //llenarcomboTipoEnvio();
                string bb = mMain.Tipo_Envio.ToString();
                tb_Tipo_Envio.Text = bb;
                tb_Tipo_Envio.ForeColor = System.Drawing.Color.Black;
              
                



                if (bb == "1")
                {
                    det_New.Visible = true;
                    Button2.Visible = true;
                    Button1.Visible = false;
                }
                else if (bb == "2")
                {
                    det_New.Visible = false;
                    Button1.Visible = true;
                    Button2.Visible = false;
                }

                
                tb_DestProvincia.SelectedValue = mMain.Provincia.ToString();
                id_provincia.Text = tb_DestProvincia.SelectedValue;
                //llenarcomboMunicipios();
                tb_DestMinicipio.SelectedValue = mMain.Municipio.ToString();
                tb_Peso.Text = mMain.Weight.ToString();
                tb_Largo.Text = mMain.Long.ToString();
                tb_Ancho.Text = mMain.Wide.ToString();
                tb_Alto.Text = mMain.High.ToString();
                lb_Vol.Text = mMain.Volumen.ToString();
                lb_Rate.Text = mMain.Rate.ToString();
                lb_Precio.Text = mMain.Precio.ToString();
            
                Save.Visible = false;
                update.Visible = false;
                Edit.Visible = true;
                Panel2.Visible = false;

                //BLOQUE BUSCAR AGENCIA DE TRABAJO
                  int mAgen = Convert.ToInt32(mMain.Agencia.ToString());
                  if (mAgen == Convert.ToInt32(mMyAgen))
                  {
                      Edit.Enabled = true;
                      GridView2.Enabled = true;
                      Button1.Enabled = true;
                      det_New.Enabled = true;
                      Button2.Enabled = true;

                  }
                  if (mAgen != Convert.ToInt32(mMyAgen))
                  {
                      Edit.Enabled = false;
                      GridView2.Enabled = false;
                      Button1.Enabled = false;
                      det_New.Enabled = false;
                      Button2.Enabled = false;
                  }
                  tbl_Cuba_Agencias mGetAgen = (from qAgen in dbPer.tbl_Cuba_Agencias
                                                where qAgen.Cod_Agen == mAgen
                                                select qAgen).First();
                  agencia.Text = mGetAgen.Nom_Agencia;
                // FIN  BLOQUE BUSCAR AGENCIA DE TRABAJO

                det_Desc.Text = "";
                det_Cant.Text = "";
                Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
                Session["m_WR"] = WR.Text; // Pasar valor al otro forms
            }
        }

        public void llenarcomboSender()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Sender
                            select new { c.Cod_Sender, Nombre = c.Sender_Nombre + " " + c.Sender_Apellido }).ToList();
                            tb_Sender.DataValueField = "Cod_Sender";
                            tb_Sender.DataTextField = "Nombre";
                            tb_Sender.DataSource = category;
                            id_Sender.Text = tb_Sender.SelectedValue;
                           
                            tb_Sender.DataBind();
                            tb_Sender.Items.Insert(0, "<-- Sender -->");
            }
        }
        public void llenarcomboDetinatario()
        {

            if (Request.QueryString["habilitar"] == "123")
            {
                string mSender = (string)Session["m_sender"];
                string mDestino = (string)Session["m_Dest"];
                id_Sender.Text = mSender;
                id_Destinatario.Text = mDestino;
                // reflect to readonly property
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                Request.QueryString.Set("habilitar", "1234");
                // make collection readonly again
                isreadonly.SetValue(this.Request.QueryString, true, null);
                using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
                {
                    string mVar = mDestino;
                    var category1 = (from c in dbconect.tbl_Cuba_N_Destinatario
                                     where c.Cod_Destino == mVar
                                     select new { c.Cod_Destino, Nombre = c.Dest_Nombre + " " + c.Dest_Apellido }).ToList();



                    tb_Destinatario.DataValueField = "Cod_Destino";
                    tb_Destinatario.DataTextField = "Nombre";
                    tb_Destinatario.DataSource = category1;
                   
                    tb_Destinatario.DataBind();
                    id_Destinatario.Text = tb_Destinatario.SelectedValue;
                   // tb_Destinatario.Items.Insert(0, "<-- Destinatario -->");

                }
            }
            else
            {
                using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
                {
                    string mVar = id_Sender.Text;
                    var category1 = (from c in dbconect.tbl_Cuba_N_Destinatario
                                     where c.Sender == mVar
                                     select new { c.Cod_Destino, Nombre = c.Dest_Nombre + " " + c.Dest_Apellido }).ToList();

                    int aa = category1.Count();

                    tb_Destinatario.DataValueField = "Cod_Destino";
                    tb_Destinatario.DataTextField = "Nombre";
                    tb_Destinatario.DataSource = category1;
                    id_Destinatario.Text = tb_Destinatario.SelectedValue;
                    tb_Destinatario.DataBind();
                    tb_Destinatario.Items.Insert(0, "<-- Destinatario -->");

                }
            }
          
        }

        public void llenarFormaPago()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category3 = (from c in dbconect.tbl_Cuba_N_FormaPago
                                 select new { c.id_FormaPago, c.FormaPago}).ToList();
                tb_FormaPago.DataValueField = "id_FormaPago";
                tb_FormaPago.DataTextField = "FormaPago";
                tb_FormaPago.DataSource = category3;
                id_formaPago.Text = tb_FormaPago.SelectedValue;
                tb_FormaPago.DataBind();
               // tb_FormaPago.Items.Insert(0, "0.00");
            }
        }

        public void llenarTipo_Entraga()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category2 = (from c in dbconect.tbl_Cuba_N_TipoEntrega
                                 select new { c.id_TipoEntrega, c.TipoEntrega }).ToList();
                tb_TipoEntrega.DataValueField = "id_TipoEntrega";
                tb_TipoEntrega.DataTextField = "TipoEntrega";
                tb_TipoEntrega.DataSource = category2;
             //   tb_TipoEntrega.Text = tb_TipoEntrega.SelectedValue;
                id_TipoEntrega.Text = tb_TipoEntrega.SelectedValue;
                tb_TipoEntrega.DataBind();
                tb_TipoEntrega.Items.Insert(0, "<-- Tipo Entrega -->");
            }
        }

        public void llenarcomboProvincia()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Provincias
                                select new { c.id_Provincia, c.Provincia }).ToList();
                tb_DestProvincia.DataValueField = "id_Provincia";
                tb_DestProvincia.DataTextField = "Provincia";
                tb_DestProvincia.DataSource = category;
                //tb_DestProvincia.Text = tb_DestProvincia.SelectedValue;
                id_provincia.Text = tb_DestProvincia.SelectedValue;
                tb_DestProvincia.DataBind();
                tb_DestProvincia.Items.Insert(0, "<-- Provincia -->");
            }
        }

        public void llenarcomboMunicipios()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Municipios
                                select new { c.id_Municipios, c.Municipios }).ToList();
                tb_DestMinicipio.DataValueField = "id_Municipios";
                tb_DestMinicipio.DataTextField = "Municipios";
                tb_DestMinicipio.DataSource = category;
             //   tb_DestMinicipio.Text = tb_DestMinicipio.SelectedValue;
                id_Destinatario.Text = tb_Destinatario.SelectedValue;
                tb_DestMinicipio.DataBind();
                tb_DestMinicipio.Items.Insert(0, "<-- Municipio -->");
            }
        }

        public void llenarcomboTipoEnvio()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Tipo_Envio
                                select new { c.id_Tipo_Envio, c.Tipo_Envio }).ToList();
                tb_Tipo_Envio.DataValueField = "id_Tipo_Envio";
                tb_Tipo_Envio.DataTextField = "Tipo_Envio";
                tb_Tipo_Envio.DataSource = category;
              //  tb_Tipo_Envio.Text = tb_Tipo_Envio.SelectedValue;
                tb_Tipo_Envio.DataBind();
                tb_Tipo_Envio.Items.Insert(0, "<-- Tipo Envio -->");
            }
        }

        public void llenarcomboEstado()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_N_Estados
                                select new { c.id_Estado, c.Estado }).ToList();
                tb_Estado.DataValueField = "id_Estado";
                tb_Estado.DataTextField = "Estado";
                tb_Estado.DataSource = category;
              //  tb_Estado.Text = tb_Estado.SelectedValue;
                tb_Estado.DataBind();
                tb_Estado.Items.Insert(0, "<-- Estado -->");
            }
        }

        public void llenarcomboManifiesto()
        {
            using (DB_82130_itndatabaseEntities dbconect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in dbconect.tbl_Cuba_Manifiestos
                                select new { c.id_Manifiestos, c.Nom_Manifiesto }).ToList();
                tb_Manifiesto.DataValueField = "id_Manifiestos";
                tb_Manifiesto.DataTextField = "Nom_Manifiesto";
                tb_Manifiesto.DataSource = category;
            //    tb_Manifiesto.Text = tb_Manifiesto.SelectedValue;
                tb_Manifiesto.DataBind();
            }
        }



         protected void telefono_TextChanged(object sender, EventArgs e)
        {
            if (telefono.Text != null || telefono.Text == "")
            {
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                      var resulta = from q in conect.tbl_Cuba_N_Sender
                                                  where q.Telefono == telefono.Text
                                                  select q;
                   int dt = resulta.Count();
                   if (dt == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Telefono no asociado. Debe registrar al cliente previamente....');", true);

                    }
                    else
                    {
                        string myPone = telefono.Text;
                        tbl_Cuba_N_Sender Mysender = (from q in conect.tbl_Cuba_N_Sender
                                                      where q.Telefono == telefono.Text
                                                      select q).First();
                        Label_Sender.Text = Mysender.Cod_Sender.ToString();
                        AgreraPak.Text = "Agregar paquete a:" + " " + Mysender.Sender_Nombre.ToString() + " " + Mysender.Sender_Apellido.ToString() + "?";
                        id_Sender.Text = Mysender.Cod_Sender.ToString();
                        AgreraPak.Visible = true;
                        //bt_DeCliente.Visible = false;

                    }
                }
             }
            //mSender = "1";
            //mDestino = "";

        }

        protected void AgreraPak_Click(object sender, EventArgs e)
        {
            LimpiarCajasMain();
            HabilitarCajasMain();
            AgreraPak.Visible = false;
           // Panel2.Visible = true;
            tb_Sender.Text = id_Sender.Text;
            ss = id_Sender.Text;
            tb_Sender_TextChanged(ss, null);
            tb_Destinatario.ForeColor = System.Drawing.Color.Red;
            tb_TipoEntrega.ForeColor = System.Drawing.Color.Red;
            tb_Tipo_Envio.ForeColor = System.Drawing.Color.Red;
            tb_Desc.ForeColor = System.Drawing.Color.Red;
            tb_FormaPago.ForeColor = System.Drawing.Color.Red;


            if (Request.QueryString["habilitar"] == "1234") // Se evalia si el agrego es de un nuevo destinatario o no
            {
                tb_Destinatario.Text = id_Destinatario.Text;

                dd = id_Destinatario.Text;
                tb_Destinatario_TextChanged(dd, null);

                id_Destinatario.Text = tb_Destinatario.SelectedValue;
                string mDestino = tb_Destinatario.SelectedValue;
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                    tbl_Cuba_N_Destinatario MyDest = (from q in conect.tbl_Cuba_N_Destinatario
                                                      where q.Cod_Destino == mDestino
                                                      select q).First();
                    var resulta = from h in conect.tbl_Cuba_N_Destinatario
                                  where h.Cod_Destino == mDestino
                                  select h;
                    int dt = resulta.Count();

                    if (dt == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('4444444444444444444....');", true);
                    }
                    else
                    {
                        tb_DestProvincia.Text = MyDest.Provincias.ToString();
                        id_provincia.Text = tb_DestProvincia.Text;
                        llenarcomboMunicipios();
                        tb_DestMinicipio.SelectedValue = MyDest.Municipio.ToString();
                        // -------------Busca la zona
                        int mPrincia = Convert.ToInt32(tb_DestProvincia.Text);
                        var MyzONA = (from mZona in conect.tbl_Cuba_N_Zonas
                                      from mProvi in mZona.tbl_Cuba_N_Provincias
                                      where mProvi.id_Provincia == mPrincia
                                      select new
                                      {
                                          Zona_tbl_Zona = mZona.Zona
                                      });
                        foreach (var Myvalor in MyzONA)
                        {
                            tb_Zona.Text = Myvalor.Zona_tbl_Zona.ToString();
                        }
                    }
                }


                
                  // reflect to readonly property
                  PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                  // make collection editable
                  isreadonly.SetValue(this.Request.QueryString, false, null);
                  Request.QueryString.Set("habilitar", "12345");
                  // make collection readonly again
                  isreadonly.SetValue(this.Request.QueryString, true, null);
                 
                  tb_TipoEntrega.ForeColor = System.Drawing.Color.Red;
                  tb_Tipo_Envio.ForeColor = System.Drawing.Color.Red;
                  tb_Destinatario.ForeColor = System.Drawing.Color.Black;
                  tb_Desc.ForeColor = System.Drawing.Color.Red;
                  tb_FormaPago.ForeColor = System.Drawing.Color.Red;
           
            }

          
            FechaHoy.Text = DateTime.Now.ToString();
            Panel2.Visible = false;
            det_New.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            det_Desc.Text = "";
            det_Cant.Text = "";
            Label1.Text = "";
          //  GridView5.DataBind();
            update.Visible = false;
            Edit.Visible = false;
            Save.Visible = true;
           // tb_Tipo_Envio.Text = "1";
            Cancel_Main.Visible = true;

           

            //mSender = "";
            //mDestino = "";
           
        }


        protected void tb_Sender_SelectedIndexChanged1(object sender, EventArgs e)
        {
            id_Sender.Text = tb_Sender.Text;
            llenarcomboDetinatario();
        }

        protected void tb_Sender_TextChanged(object sender, EventArgs e)
        {
            tb_Sender.Text = id_Sender.Text;
            llenarcomboDetinatario();
        }

        protected void tb_Destinatario_TextChanged(object sender, EventArgs e)
        {
           // tb_Destinatario.Text = id_Destinatario.Text;
            tb_Sender.Text = id_Sender.Text;
         //   llenarcomboDetinatario();
           tb_Destinatario.ForeColor = System.Drawing.Color.Black;
            
        }

        protected void tb_Destinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_Sender.Text = id_Sender.Text;
            
              //         tb_Destinatario.Text = id_Destinatario.Text;
            id_Destinatario.Text = tb_Destinatario.SelectedValue;
            string mDestino = tb_Destinatario.SelectedValue;
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                tbl_Cuba_N_Destinatario MyDest = (from q in conect.tbl_Cuba_N_Destinatario
                                                  where q.Cod_Destino == mDestino
                                                  select q).First();
                var resulta = from h in conect.tbl_Cuba_N_Destinatario
                              where h.Cod_Destino == mDestino
                              select h;
                int dt = resulta.Count();

                if (dt == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('4444444444444444444....');", true);
                }
                else
                {
                    tb_DestProvincia.Text = MyDest.Provincias.ToString();
                    id_provincia.Text = tb_DestProvincia.Text;
                    llenarcomboMunicipios();
                    tb_DestMinicipio.SelectedValue = MyDest.Municipio.ToString();
                    // -------------Busca la zona
                    int mPrincia = Convert.ToInt32(tb_DestProvincia.Text);
                    var MyzONA = (from mZona in conect.tbl_Cuba_N_Zonas
                                                    from mProvi in mZona.tbl_Cuba_N_Provincias
                                                    where mProvi.id_Provincia == mPrincia
                                                    select new
                                                    {
                                                       Zona_tbl_Zona = mZona.Zona
                                                    });
                    foreach (var Myvalor in MyzONA)
                    {
                        tb_Zona.Text = Myvalor.Zona_tbl_Zona.ToString();
                    }
                }
            }
        }

        protected void tb_DestProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_DestProvincia.Text = id_provincia.Text;
            llenarcomboMunicipios();

            // -------------Busca la zona
            // -------- Join en dos tablas
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                int mPrincia = Convert.ToInt32(tb_DestProvincia.Text);
                var  Myprov = (from mZona in conect.tbl_Cuba_N_Zonas
                                                  from mProvi in mZona.tbl_Cuba_N_Provincias
                                                  select new
                                                  {
                                                   Zona_tbl_Zona = mZona.Zona,
                                                  });
                                                        
                foreach (var Myvalor in Myprov)
                {
                    tb_Zona.Text = Myvalor.Zona_tbl_Zona.ToString();
                }

                

            }

        }

        protected void tb_DestMinicipio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tb_TipoEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_TipoEntrega.ForeColor = System.Drawing.Color.Black;
        }

        protected void tb_Peso_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_Largo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_Ancho_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_Alto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void det_Save_Click(object sender, ImageClickEventArgs e)
        {
            if (det_Cant.Text == "" || det_Desc.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Descripcion y Cantidad no deben ser nulos....');", true);
            }
            else
            {
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                    TBL_Cuba_Package_Main_Detalles Mydetail = new TBL_Cuba_Package_Main_Detalles
                    {
                          Cuba_Package_Main = Convert.ToInt32(Label1.Text),
                          Cantidad = Convert.ToDecimal(det_Cant.Text),
                          Descripcion = det_Desc.Text,
                          WR = WR.Text, 
                    };
                    conect.TBL_Cuba_Package_Main_Detalles.AddObject(Mydetail);
                    conect.SaveChanges();
 
                }
        
                Panel2.Visible = false;
            //    det_New.Visible = true;
                det_Desc.Text = "";
                det_Cant.Text = "";
               // llenarGridview6();
                GridView2.DataBind();

            }
            det_New.Focus();

            Actual_DetalleTMP();
        }

      

        protected void ImageButtonLabel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Rep_WareHouse_Label.aspx");
        }

        //protected void tb_ManifiestoIMP_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["m_Mani"] = tb_ManifiestoIMP.SelectedValue; // Pasar valor al otro forms
        //}

        //protected void ImageButtonMani_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (tb_ManifiestoIMP.Text == "<-- Manifiesto -->")
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Seleccione Manifiesto a Imprimir....');", true);
        //    }

        //    Response.Redirect("~/PagesMembers/Reports/WareHouseManifiesto.aspx");    
        //}

        protected void update_Click(object sender, ImageClickEventArgs e)
        {
            CalulaPrecio();
            CalulaPieCuv();

            int mFiltro = Convert.ToInt32(Label1.Text);

            using(DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                // Busbamos letra para fichero en Miscelaneas
                string mLetraFich = "";
                if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "A" && tb_TipoEntrega.Text == "2")
                {
                    mLetraFich = "CA";
                }
                else if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "B" && tb_TipoEntrega.Text == "2")
                {
                    mLetraFich = "CB";
                }
                else if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "C" && tb_TipoEntrega.Text == "2")
                {
                    mLetraFich = "CC";
                }
                else if (tb_Tipo_Envio.Text == "1" && tb_TipoEntrega.Text == "1")
                {
                    mLetraFich = "CR";
                }
                // Busbamos letra para fichero en Duraderos
                else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "A")
                {
                    mLetraFich = "DA";
                }
                else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "B")
                {
                    mLetraFich = "DB";
                }
                else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "C")
                {
                    mLetraFich = "DC";
                }

                try
                {
                    TBL_Cuba_Package_Main cMain = (from q in conect.TBL_Cuba_Package_Main
                                                   where q.id_Cuba_Package_Main == mFiltro
                                                   select q).First();
                    cMain.Dod_Destino1 = tb_Destinatario.SelectedValue;
                    cMain.Cod_Sender1 = tb_Sender.SelectedValue;
                    cMain.Note = tb_Notas.Text;
                    cMain.Long = Convert.ToDecimal(tb_Largo.Text);
                    cMain.Wide = Convert.ToDecimal(tb_Ancho.Text);
                    cMain.High = Convert.ToDecimal(tb_Alto.Text);
                    cMain.Weight = Convert.ToDecimal(tb_Peso.Text);
                    cMain.Provincia = Convert.ToInt32(tb_DestProvincia.SelectedValue);
                    cMain.Municipio = Convert.ToInt32(tb_DestMinicipio.SelectedValue);
                    cMain.Estado = Convert.ToInt32(tb_Estado.Text);
                    cMain.Pagado = 1;
                    cMain.TipoEntrega = Convert.ToInt32(tb_TipoEntrega.SelectedValue);
                    cMain.Volumen = Convert.ToDecimal(lb_Vol.Text);
                    cMain.Rate = Convert.ToDecimal(lb_Rate.Text);
                    cMain.Precio = Convert.ToDecimal(lb_Precio.Text);
                    cMain.Manifiesto = Convert.ToInt32(tb_Manifiesto.Text);
                    cMain.WR = WR.Text;
                    cMain.Tipo_Envio = Convert.ToInt32(tb_Tipo_Envio.Text);
                    cMain.Zona = tb_Zona.Text;
                    cMain.Fich_Letra = mLetraFich;
                    cMain.Descuento = Convert.ToDecimal(tb_Desc.Text);
                    cMain.PrecioTotal = Convert.ToDecimal(lb_Total.Text);
                    cMain.FormaPago = Convert.ToInt32(tb_FormaPago.SelectedValue);


                    conect.SaveChanges();
                    id_Destinatario.Text = Convert.ToString(tb_Destinatario.SelectedValue);
                 
                    if (tb_Tipo_Envio.SelectedValue == "1")
                    {
                        det_New.Visible = true;
                        Button1.Visible = false;
                        Button2.Visible = true;
                    }
                    else if (tb_Tipo_Envio.SelectedValue == "2")
                    {
                        det_New.Visible = false;
                        Button1.Visible = true;
                        Button2.Visible = false;
                    }
                }
                catch (Exception Ex)
                { 
                
                }
                Cancel_Main.Visible = false;
                DeshabilitarCajasMain();
                Edit.Visible = true;
                update.Visible = false;
            }
        }

        protected void Save_Click(object sender, ImageClickEventArgs e)
        {
            string mLb = "";
              CalulaPrecio();
              CalulaPieCuv();

            if (tb_Sender.Text == "<-- Sender -->" || tb_Destinatario.Text == "<-- Destinatario -->" || tb_DestProvincia.Text == "<-- Provincia -->" || tb_DestMinicipio.Text == "<-- Municipio -->" || tb_TipoEntrega.Text == "<-- Tipo Entrega -->" || tb_Peso.Text == null || tb_Largo.Text == null || tb_Ancho.Text == null || tb_Alto.Text == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('No Campos: Sender, Destinatario, Provincia, Municipio and Tipo Entrega  are REQUIRED....');", true);
            }
            else
            {
               // int mFiltro = Convert.ToInt32(Label1.Text);
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                     
                  // Busbamos letra para fichero en Miscelaneas
                    string mLetraFich = "";
                    if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "A" && tb_TipoEntrega.Text == "2")
                    {
                        mLetraFich = "CA";
                    }
                    else if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "B" && tb_TipoEntrega.Text == "2")
                    {
                        mLetraFich = "CB";
                    }
                    else if (tb_Tipo_Envio.Text == "1" && tb_Zona.Text == "C" && tb_TipoEntrega.Text == "2")
                    {
                        mLetraFich = "CC";
                    }
                    else if (tb_Tipo_Envio.Text == "1" && tb_TipoEntrega.Text == "1")
                    {
                        mLetraFich = "CR";
                    }
                  // Busbamos letra para fichero en Duraderos
                    else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "A")
                    {
                        mLetraFich = "DA";
                    }
                    else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "B")
                    {
                        mLetraFich = "DB";
                    }
                    else if (tb_Tipo_Envio.Text == "2" && tb_Zona.Text == "C")
                    {
                        mLetraFich = "DC";
                    }


                    IQueryable<TBL_Cuba_Package_Main> MyMain = (from q in conect.TBL_Cuba_Package_Main
                                                                orderby q.id_Cuba_Package_Main
                                                                select q);
                    List<TBL_Cuba_Package_Main> lista = MyMain.ToList();
                    var mMain = lista.Last();
                    int max = Convert.ToInt32(mMain.id_Cuba_Package_Main.ToString());

                     // --------- BLOQUE PARA ASIGNAR CONCECUTIVO ANTES DE GUARDAR
                    visitCounter = max;
                    visitCounter++; // Increase each time a form is loaded
                    TextBoxID.Text = visitCounter.ToString("1161001060000");  //mMyAgenPack); // Format the counter
                    WR.Text = Convert.ToString(TextBoxID.Text);
                    // --------- FIN BLOQUE

                    string userName = System.Web.HttpContext.Current.User.Identity.Name;//.Request.LogonUserIdentity.Name;
                   

                    TBL_Cuba_Package_Main cMain = new TBL_Cuba_Package_Main
                    {
                    Date = Convert.ToDateTime(DateTime.Now.ToString(("yyyy-MM-dd"))),
                    Dod_Destino1 = Convert.ToString(tb_Destinatario.SelectedValue),
                    Cod_Sender1 = Convert.ToString(tb_Sender.SelectedValue),
                    Note = tb_Notas.Text,
                    Long = Convert.ToDecimal(tb_Largo.Text),
                    Wide = Convert.ToDecimal(tb_Ancho.Text),
                    High = Convert.ToDecimal(tb_Alto.Text),
                    Weight = Convert.ToDecimal(tb_Peso.Text),
                    Provincia = Convert.ToInt32(tb_DestProvincia.SelectedValue),
                    Municipio = Convert.ToInt32(tb_DestMinicipio.SelectedValue),
                    Estado = Convert.ToInt32(tb_Estado.Text),
                    Pagado = 1,
                    TipoEntrega = Convert.ToInt32(tb_TipoEntrega.SelectedValue),
                    Volumen = Convert.ToDecimal(lb_Vol.Text),
                    Rate = Convert.ToDecimal(lb_Rate.Text),
                    Precio = Convert.ToDecimal(lb_Precio.Text),
                    Manifiesto = Convert.ToInt32(tb_Manifiesto.Text),
                    WR = WR.Text,
                    Tipo_Envio = Convert.ToInt32(tb_Tipo_Envio.Text),
                    Zona = tb_Zona.Text,
                    Fich_Letra = mLetraFich,
                    Agencia = Convert.ToInt32(mMyAgen),
                    Usuario = userName,
                    Descuento = Convert.ToDecimal(tb_Desc.Text),
                    PrecioTotal = Convert.ToDecimal(lb_Total.Text),
                    FormaPago =  Convert.ToInt32(tb_FormaPago.SelectedValue),
                    };
                  
                                        
                    conect.TBL_Cuba_Package_Main.AddObject(cMain);
                    conect.SaveChanges();
              }
            DeshabilitarCajasMain();
            Save.Visible = false;
            update.Visible = false;
            Edit.Visible = true;
            telefono.Text = null;
            Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
            Session["m_WR"] = WR.Text; // Pasar valor al otro forms
            Cancel_Main.Visible = false;
            actualizarForm();
            tb_Tipo_Envio.ForeColor = System.Drawing.Color.Black;
            tb_TipoEntrega.ForeColor = System.Drawing.Color.Black;
            tb_Destinatario.ForeColor = System.Drawing.Color.Black;
            tb_Desc.ForeColor = System.Drawing.Color.Black;
            tb_FormaPago.ForeColor = System.Drawing.Color.Black;
            
            }
        }

      
        public void DeshabilitarCajasMain()
        {
            FechaHoy.Enabled = false;
            tb_Sender.Enabled = false;
            tb_Destinatario.Enabled = false;
            tb_DestProvincia.Enabled = false;
            tb_DestMinicipio.Enabled = false;
            tb_TipoEntrega.Enabled = false;
            tb_Estado.Enabled = false;
            tb_Notas.Enabled = false;
            tb_Peso.Enabled = false;
            tb_Largo.Enabled = false;
            tb_Ancho.Enabled = false;
            tb_Alto.Enabled = false;
            tb_Manifiesto.Enabled = false;
            tb_Tipo_Envio.Enabled = false;
            tb_Desc.Enabled = false;
            tb_FormaPago.Enabled = false;

        }

        private void CalulaPrecio()
        {
            string mbusca = "";
            decimal mRate = 0;
            decimal mPeso = Convert.ToDecimal(tb_Peso.Text);
            string mLetraFiltro = "";
            if (tb_TipoEntrega.Text == "1")
            {
                mLetraFiltro = "R";
            }
            else
            {
                mLetraFiltro = tb_Zona.Text;
            }

            using(DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                if (tb_Tipo_Envio.Text == "1")
                {
                    // -------------Busca la tarifa degun zona en miscenaleas
                    
                    tbl_Cuba_N_Tarif_Miscelaneos mMnif = (from q in conect.tbl_Cuba_N_Tarif_Miscelaneos
                                                          where q.Zona == mLetraFiltro
                                                          select q).First();
                    mRate = Convert.ToDecimal(mMnif.M_Rate);

                }
          
                    // -------------Busca la tarifa degun zona en duraderos
                if (tb_Tipo_Envio.Text == "2")
                {
                    int mProv = Convert.ToInt32(tb_DestProvincia.Text);
                    var Myprov = (from mZonaD in conect.tbl_Cuba_N_Zonas_Dura
                                  
                                  from mProvi in mZonaD.tbl_Cuba_N_Provincias
                                  where mProvi.id_Provincia == mProv
                                  select new
                                  {
                                      Zona_tbl_Zona = mZonaD.Zona_Dura,
                                  });

                    foreach (var Myvalor in Myprov)
                    {
                       mZonaDura = Myvalor.Zona_tbl_Zona.ToString();
                    }

                    IQueryable<tbl_Cuba_N_tarif_Duraderos> mDura = (from q in conect.tbl_Cuba_N_tarif_Duraderos
                                                                    where mPeso >= q.Desde && mPeso <= q.Hasta && q.Zonas == mZonaDura
                                                                    select q);

                    List<tbl_Cuba_N_tarif_Duraderos> lista = mDura.ToList();
                    var mRegistros = lista.FirstOrDefault();
                    int dtd = lista.Count();
                    if (dtd == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Peso fuera de rango en Tarifa....');", true);
                    }
                    else
                    {
                       mRate = Convert.ToDecimal(mRegistros.D_Rate); 
                    }
                }
                decimal mPrecio = mRate * mPeso;
                lb_Rate.Text = Convert.ToString(mRate);
                lb_Precio.Text = Convert.ToString(Math.Round(mPrecio, 2));
                decimal mDesc = Convert.ToDecimal(tb_Desc.Text);
                decimal mTotal = mPrecio - mDesc;
                lb_Total.Text = Convert.ToString(Math.Round(mTotal, 2));

            }
        }

   
        public void HabilitarCajasMain()
        {
            FechaHoy.Enabled = true;
            tb_Sender.Enabled = true;
            tb_Destinatario.Enabled = true;
           // tb_DestProvincia.Enabled = true;
           // tb_DestMinicipio.Enabled = true;
            tb_TipoEntrega.Enabled = true;
            tb_Estado.Enabled = true;
            tb_Notas.Enabled = true;
            tb_Peso.Enabled = true;
            tb_Largo.Enabled = true;
            tb_Ancho.Enabled = true;
            tb_Alto.Enabled = true;
            tb_Manifiesto.Enabled = true;
            tb_Tipo_Envio.Enabled = true;
            tb_Desc.Enabled = true;
            tb_FormaPago.Enabled = true;
        }

        protected void Edit_Click(object sender, ImageClickEventArgs e)
        {
            HabilitarCajasMain();
            tb_Sender.Enabled = false;
            tb_Destinatario.Enabled = true;
            tb_DestProvincia.Enabled = false;
            tb_DestMinicipio.Enabled = false;
            Edit.Visible = false;
            update.Visible = true;
            Cancel_Main.Visible = true;
        }

        private void CalulaPieCuv()
        {
            decimal mL = Convert.ToDecimal(tb_Largo.Text);
            decimal mA = Convert.ToDecimal(tb_Ancho.Text);
            decimal mH = Convert.ToDecimal(tb_Alto.Text);
            decimal mV = (mA * mL * mH) / 1728;
            lb_Vol.Text = Convert.ToString(Math.Round(mV, 2));
        }

        public void LimpiarCajasMain()
        {
            agencia.Text = "";
            WR.Text = "WR";
            FechaHoy.Text = null;
            tb_Sender.Text = null;
            tb_Destinatario.Text = null;
            tb_DestProvincia.Text = null;
            tb_DestMinicipio.Text = null;
            tb_TipoEntrega.Text = null;
            tb_Tipo_Envio.Text = null;
            tb_Notas.Text = null;
            tb_Zona.Text = null;
            tb_Peso.Text = "0.0";
            lb_Rate.Text = "0.00";
            tb_Largo.Text = "0.0";
            tb_Ancho.Text = "0.0";
            tb_Alto.Text = "0.0";
            lb_Precio.Text = "0.00";
            lb_Vol.Text = "0.0";
        }

   
        //protected void det_New_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (Label1.Text == null || Label1.Text == "")
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Debe guardar cambios antes de continuar....');", true);
        //    }
        //    else
        //    {
        //        Panel2.Visible = true;
        //     //   det_New.Visible = false;
        //        det_Id_sender.Text = Label1.Text;
        //        det_Desc.Focus();
              
        //    }
        //}

        protected void Cancel_Main_Click1(object sender, ImageClickEventArgs e)
        {
            LimpiarCajasMain();
            Cancel_Main.Visible = false;
            actualizarForm();
            Edit.Visible = true;
            telefono.Text = "";
            tb_Tipo_Envio.ForeColor = System.Drawing.Color.Black;
            tb_TipoEntrega.ForeColor = System.Drawing.Color.Black;
            tb_Destinatario.ForeColor = System.Drawing.Color.Black;
            tb_Desc.ForeColor = System.Drawing.Color.Black;
            tb_FormaPago.ForeColor = System.Drawing.Color.Black;
        }

       
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (NoPaquete.Text != null)
            {
                string mWR = NoPaquete.Text;
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                    IQueryable<TBL_Cuba_Package_Main> MyMain = (from q in conect.TBL_Cuba_Package_Main
                                                                where q.WR == mWR
                                                                select q);
                    List<TBL_Cuba_Package_Main> lista = MyMain.ToList();

                    var mMain = lista.FirstOrDefault();

                    if (lista.Count == 0)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Paquete no encontrado....');", true);
                    }
                    else
                    {

                        Label1.Text = mMain.id_Cuba_Package_Main.ToString();
                        tb_Manifiesto.Text = mMain.Manifiesto.ToString();



                        WR.Text = mMain.WR.ToString();
                        tb_Sender.SelectedValue = mMain.Cod_Sender1.ToString();
                        llenarcomboSender();
                        id_Sender.Text = tb_Sender.SelectedValue;
                        llenarcomboDetinatario();

             
                        tb_Destinatario.SelectedValue = mMain.Dod_Destino1.ToString();

                        id_Destinatario.Text = tb_Destinatario.SelectedValue;
                        tb_TipoEntrega.SelectedValue = mMain.TipoEntrega.ToString();
                        id_TipoEntrega.Text = tb_TipoEntrega.Text;
                        //llenarTipo_Entraga();
                        FechaHoy.Text = mMain.Date.Value.Date.ToString("MM/dd/yyyy");
                        
                        tb_Notas.Text = mMain.Note.ToString();
                        tb_Zona.Text = mMain.Zona.ToString();
                        tb_Manifiesto.SelectedValue = mMain.Manifiesto.ToString();
                        llenarcomboEstado();
                        string aa = mMain.Estado.ToString();
                        tb_Estado.SelectedValue = aa;  //dr["Estado"].ToString();
                        //llenarcomboTipoEnvio();
                        string bb = mMain.Tipo_Envio.ToString();


                        if (mMain.Descuento.ToString() == "") { tb_Desc.Text = "0.00"; }
                        else { tb_Desc.Text = mMain.Descuento.ToString(); }
                        //  llenarFormaPago();
                        if (mMain.FormaPago.ToString() == "") { tb_FormaPago.Text = "1"; }
                        else { tb_FormaPago.Text = mMain.FormaPago.ToString(); }
                        id_formaPago.Text = tb_FormaPago.Text;
                        lb_Total.Text = mMain.PrecioTotal.ToString();

                      

                        tb_Tipo_Envio.Text = bb;
                        //          tb_Zona.Text = mMain.Zona.ToString();
                        if (tb_Tipo_Envio.SelectedValue == "1")
                        {
                            det_New.Visible = true;
                            Button1.Visible = false;
                            Button2.Visible = true;
                        }
                        else if (tb_Tipo_Envio.SelectedValue == "2")
                        {
                            det_New.Visible = false;
                            Button1.Visible = true;
                            Button2.Visible = false;
                        }

                        tb_DestProvincia.SelectedValue = mMain.Provincia.ToString();
                        id_provincia.Text = tb_DestProvincia.SelectedValue;
                        //llenarcomboMunicipios();
                        tb_DestMinicipio.SelectedValue = mMain.Municipio.ToString();
                        tb_Peso.Text = mMain.Weight.ToString();
                        tb_Largo.Text = mMain.Long.ToString();
                        tb_Ancho.Text = mMain.Wide.ToString();
                        tb_Alto.Text = mMain.High.ToString();
                        lb_Vol.Text = mMain.Volumen.ToString();
                        lb_Rate.Text = mMain.Rate.ToString();
                        lb_Precio.Text = mMain.Precio.ToString();

                        //BLOQUE BUSCAR AGENCIA DE TRABAJO
                        int mAgen = Convert.ToInt32(mMain.Agencia.ToString());
                        if (mAgen == Convert.ToInt32(mMyAgen))
                        {
                            Edit.Enabled = true;
                            GridView2.Enabled = true;
                            Button1.Enabled = true;
                            det_New.Enabled = true;
                            Button2.Enabled = true;

                        }
                        if (mAgen != Convert.ToInt32(mMyAgen))
                        {
                            Edit.Enabled = false;
                            GridView2.Enabled = false;
                            Button1.Enabled = false;
                            det_New.Enabled = false;
                            Button2.Enabled = false;
                        }



                        tbl_Cuba_Agencias mGetAgen = (from qAgen in conect.tbl_Cuba_Agencias
                                                      where qAgen.Cod_Agen == mAgen
                                                      select qAgen).First();
                        agencia.Text = mGetAgen.Nom_Agencia;
                        // FIN  BLOQUE BUSCAR AGENCIA DE TRABAJO

                        Save.Visible = false;
                        update.Visible = false;
                        Edit.Visible = true;
                        Panel2.Visible = false;
                      //  det_New.Visible = true;
                        det_Desc.Text = "";
                        det_Cant.Text = "";
                        Session["m_id_Despacho"] = Label1.Text; // Pasar valor al otro forms
                        Session["m_WR"] = WR.Text; // Pasar valor al otro forms
                    }

                }


                NoPaquete.Text = null;
                
            }


        }

        protected void Calcel_Detalles_Click(object sender, ImageClickEventArgs e)
        {
           // LimpiarCajasMain();
           // Cancel_Main.Visible = false;
            det_Desc.Text = "";
            det_Cant.Text = "";
            Panel2.Visible = false;
          //  det_New.Visible = true;
        }

        private void Actual_DetalleTMP()
        {
            using (DB_82130_itndatabaseEntities connect_Main = new DB_82130_itndatabaseEntities())
            {
                string mId = WR.Text;                          //Convert.ToInt32(Label1.Text);
                var My_Main = (from p in connect_Main.TBL_Cuba_Package_Main
                               where p.WR == mId                 //.id_Cuba_Package_Main == mId
                               select p).First();
                My_Main.Descrip_Detalles = "";
                connect_Main.SaveChanges();
            }
            using (DB_82130_itndatabaseEntities connect_Main = new DB_82130_itndatabaseEntities())
            {
                string mId = WR.Text;                          //Convert.ToInt32(Label1.Text);
                var My_Main = (from p in connect_Main.TBL_Cuba_Package_Main
                               where p.WR == mId                 //.id_Cuba_Package_Main == mId
                               select p).First();

                var MyDetalle = from m in connect_Main.TBL_Cuba_Package_Main_Detalles
                                where m.WR == mId                //.Cuba_Package_Main == mId
                                select m;

                string mTexto = "";
                foreach (var t in MyDetalle)
                {
                    mTexto = mTexto + " " + t.Cantidad + " " + t.Descripcion + ",";
                }
                My_Main.Descrip_Detalles = mTexto;
                connect_Main.SaveChanges();


            }
        }

        protected void GridView2_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            Actual_DetalleTMP();
        }

        protected void GridView2_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Actual_DetalleTMP();
        }


        public void AgreraPak_Click_Cliente()
        {


   
        }

        protected void bt_DeCliente_Click(object sender, EventArgs e)
        {

        }

        protected void tb_Tipo_Envio_SelectedIndexChanged(object sender, EventArgs e)
        {
           tb_Tipo_Envio.ForeColor = System.Drawing.Color.Black;
         
        }

       

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
           
            string mFrom, mFronMal,  mTo, mToMail, mDeta = "";
            string mSender = id_Sender.Text, mDetino = id_Destinatario.Text;
            int mId = Convert.ToInt32(Label1.Text);


            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var From = (from p in conect.tbl_Cuba_N_Sender
                           where p.Cod_Sender == mSender
                           select p).First();

                var To = (from q in conect.tbl_Cuba_N_Destinatario
                          where q.Cod_Destino == mDetino
                          select q).First();
                var Deta = (from w in conect.TBL_Cuba_Package_Main
                            where w.id_Cuba_Package_Main == mId
                            select w).First();

                mDeta = Deta.Descrip_Detalles;
                mFrom = From.Sender_Nombre + " " + From.Sender_Apellido;
                mFronMal = From.Sender_Email;
                mTo = To.Dest_Nombre + " " + To.Dest_Apellido;
                mToMail = To.Dest_Email;

                if (mFronMal == "")
                {
                    mFronMal = "aaaaa12@nauta.com";
                }
                if (mToMail == "")
                { 
                    mToMail = "bbbbb12@nauta.com";
                }
            }
            

               MailMessage correo = new MailMessage();

                correo.From = new MailAddress(mFrom + "<" + mFronMal + ">");
  

                String s = "", x = "";

                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                        if (CheckBoxList1.Items[i].Selected == true)
                        {
                            x = "1";
                            s = CheckBoxList1.Items[i].Text;
                            if (s == "Sender")
                            {
                                correo.To.Add(new MailAddress(mFronMal));
                                s = "";
                            }
                            else if (s == "Destinatario")
                            {
                                correo.To.Add(new MailAddress(mToMail));
                                s = "";
                            }
                        }
                }
                if (x == "1")
                {
                    correo.Subject = "Emvio de paquete: " + WR.Text;
                    correo.Body = "A traves de FrontLine: " + mFrom + " a enviado un paquete dirigido a: " + mTo + " con fecha " + FechaHoy.Text + " de " + tb_Peso.Text + " libras de peso" + "." + " CONTENIDO: " + mDeta;

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Credentials = new System.Net.NetworkCredential("frontline.cservice@gmail.com", "frontline2010");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(correo);
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = " Mensaje enviado correctamente, Gracias";
                    //     lblMensajeError.ForeColor = Color.YellowGreen;
                    CheckBoxList1.SelectedValue = null;
                    correo.Attachments.Clear();
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = " No ha seleccionado destinatarios";
                }

                if (mFronMal == "aaaaa12@nauta.com")
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = " El Sender no tiene direccion de Email registrada";
                }
                if (mToMail == "bbbbb12@nauta.com")
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = " El Destinatario no tiene direccion de Email registrada";
                }

            }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel_Dura_Detalle.Visible = true;
            Panel_Mise_Detalle.Visible = false;
        }



        private void llenarAduana()
        {
            // mClase = Convert.ToInt32(DropAduanaClase.Text);

            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var MyGrid = (from p in conect.tbl_Cuba_Aduana
                             // where p.Clase == DropAduanaClase.Text
                              select new
                              {
                              Capitulo = p.CAPITULOS,
                              Articulo = p.Articulos,
                              Valor = p.Valor,
                              });
                int mm = MyGrid.Count();
                //GridView3.DataSource = MyGrid;
                //GridView3.DataBind();


            
           
            }
        }
        private void llenarDropAduana()
        {
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var category = (from c in conect.tbl_Cuba_Aduana
                                orderby c.Clase descending
                                select new { Clase = c.Clase }).Distinct().ToList();

                DropAduanaClase.DataValueField = "Clase";
                DropAduanaClase.DataTextField = "Clase";
                DropAduanaClase.DataSource = category;
                DropAduanaClase.DataBind();
            }
        }

        protected void DropAduanaClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView3.DataBind();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView3.SelectedRow;

            string mArt = row.Cells[2].Text;
            string mcant = "1";
            decimal mValor = Convert.ToDecimal(row.Cells[3].Text);

            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                TBL_Cuba_Package_Main_Detalles Mydetail = new TBL_Cuba_Package_Main_Detalles
                {
                    Cuba_Package_Main = Convert.ToInt32(Label1.Text),
                    Cantidad = Convert.ToDecimal(mcant),
                    Descripcion = mArt,
                    Valor = mValor,
                    WR = WR.Text,
                };
                conect.TBL_Cuba_Package_Main_Detalles.AddObject(Mydetail);
                conect.SaveChanges();

            }

            Panel_Mise_Detalle.Visible = true;
            Panel_Dura_Detalle.Visible = false;
            Panel2.Visible = false;
         //   det_New.Visible = true;
            det_Desc.Text = "";
            det_Cant.Text = "";
            // llenarGridview6();
            GridView2.DataBind();

            Actual_DetalleTMP();
        }

      
        protected void Calcel_DetallesDura_Click(object sender, ImageClickEventArgs e)
        {
            Panel_Dura_Detalle.Visible = false;
            Panel_Mise_Detalle.Visible = true;
        }

        protected void det_New_Click1(object sender, EventArgs e)
        {
            if (Label1.Text == null || Label1.Text == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('Debe guardar cambios antes de continuar....');", true);
            }
            else
            {
                Panel2.Visible = true;
                //   det_New.Visible = false;
                det_Id_sender.Text = Label1.Text;
                det_Desc.Focus();

            }
        }

        protected void DuraBusca_Click(object sender, ImageClickEventArgs e)
        {
            using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
            {
                var MyGrid = (from p in conect.tbl_Cuba_Aduana
                              .Where(p => p.Clase.Contains(tb_AduanaArticulo.Text)) //  ==   DropAduanaClase.Text
                              select new
                              {
                                  Capitulo = p.CAPITULOS,
                                  Articulo = p.Articulos,
                                  Valor = p.Valor,
                              });
                int mm = MyGrid.Count();
                SqlDataSource3.SelectCommand = "SELECT id_Aduana, CAPITULOS, Clase, Articulos, Valor, Cant FROM tbl_Cuba_Aduana  WHERE Articulos LIKE '%" + tb_AduanaArticulo.Text + "%'";

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
                using (DB_82130_itndatabaseEntities conect = new DB_82130_itndatabaseEntities())
                {
                    TBL_Cuba_Package_Main_Detalles Mydetail = new TBL_Cuba_Package_Main_Detalles
                    {
                        Cuba_Package_Main = Convert.ToInt32(Label1.Text),
                        Cantidad = Convert.ToDecimal("1"),
                        Descripcion = " Bolsa de Miscelaneos",
                        Valor = Convert.ToDecimal("30.00"),
                        WR = WR.Text,
                    };
                    conect.TBL_Cuba_Package_Main_Detalles.AddObject(Mydetail);
                    conect.SaveChanges();

                }

                Panel2.Visible = false;
                //    det_New.Visible = true;
                det_Desc.Text = "";
                det_Cant.Text = "";
                // llenarGridview6();
                GridView2.DataBind();

            det_New.Focus();

            Actual_DetalleTMP();

        }

        protected void ButtonListaE_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Rep_Lista_Embarque.aspx");
        }

        protected void ButtonWR_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Rep_WareHouseReceive.aspx");
        }

        protected void Btton_Recivos_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/PagesMembers/Rep_Recibos_Paquete.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PagesMembers/Rep_ComprobanteEntrega.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Session["m_Destino"] = id_Sender.Text; // Pasar valor al otro forms
            Session["m_Fecha"] = tb_FechaComprobante.Text; // Pasar valor al otro forms
            Response.Redirect("~/PagesMembers/Rep_ComprobanteMultiple.aspx");
        }

        protected void tb_Desc_TextChanged(object sender, EventArgs e)
        {
            tb_Desc.ForeColor = System.Drawing.Color.Black;
        }

        protected void tb_FormaPago_TextChanged(object sender, EventArgs e)
        {
            tb_FormaPago.ForeColor = System.Drawing.Color.Black;
        }

        protected void ImageButtonMani_Click(object sender, ImageClickEventArgs e)
        {

        }

      

        





    }
}