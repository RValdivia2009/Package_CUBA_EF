using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Package_WebApp.Properties;

using System.Web.Security;

namespace Package_WebApp.PageAdmin
{
    public partial class AccessUser : System.Web.UI.Page
    {
        string mMiembro = "cd1105fb-c70e-447d-894f-fa7431c7bdc2";
        string mAdmin = "bc2d3a65-8692-43ed-a3cf-f5805739d5e9";
        string mID = "";
        string mUserNew = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            actual_GridViewUsers();
        }

        protected void actual_GridViewUsers()
        {
            string SqlUser = "SELECT  UserName, Userid FROM aspnet_Users"; //WHERE UserName = '" + m_Users + "';";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin))
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlUser, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                  if (GridView1.Columns.Count > 0)
                  {
                    GridView1.HeaderRow.Cells[2].Visible = false;
                    foreach (GridViewRow gvr in GridView1.Rows)
                    {
                        gvr.Cells[2].Visible = false;
                    }
                  
                }

                  conn.Close();
             }
         }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList1.Text = null;
            //Capturar los datos de la DataGrid y asignarlos a las cajas de texto   
            GridViewRow row = GridView1.SelectedRow;
            TextBox_User.Text = row.Cells[1].Text;
            string m_Users = TextBox_User.Text;
            string SqlUser = "SELECT  UserName, Userid FROM aspnet_Users WHERE UserName = '" + m_Users + "';";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin))
            {
                SqlDataAdapter das = new SqlDataAdapter(SqlUser, conn);
                System.Data.DataTable dts = new System.Data.DataTable();
                das.Fill(dts);
                System.Data.DataRow rows = dts.Rows[0];

                string mName = rows["UserName"].ToString();
                mID = rows["Userid"].ToString();
                TextBox_User.Text = mName;
                TextBox_ID_User.Text = mID;
            }

            string m_UsersID = TextBox_ID_User.Text;

            string SqlRoles = "SELECT  RoleId, Userid FROM aspnet_UsersInRoles WHERE Userid = '" + m_UsersID + "';";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin))
            {
                SqlDataAdapter da = new SqlDataAdapter(SqlRoles, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                string mCuenta = dt.Rows.Count.ToString();
                if (mCuenta != "0")
                {
                    System.Data.DataRow rows = dt.Rows[0];
                    string mRoleActual = rows["RoleId"].ToString();

                    
                    if (mRoleActual == mMiembro)
                    {
                        RadioButtonList1.Text = "Usuario";
                    }
                    if (mRoleActual == mAdmin)
                    {
                        RadioButtonList1.Text = "Admin";
                    }
                 }
                if (mCuenta == "0")
                {
                    LabelUser.Text = "New";
                }

                conn.Close();
            }
            
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.Text != "")
            {
                if (LabelUser.Text == "New") // Para Cuando el Usuario-Rol es nuevo
                {
                    TextBox_IdRol.Text = mMiembro;
                    if (RadioButtonList1.Text == "Usuario")
                    {
                        TextBox_IdRol.Text = mMiembro;
                    }
                    if (RadioButtonList1.Text == "Admin")
                    {
                        TextBox_IdRol.Text = mAdmin;
                    }

                    string m_UserID = TextBox_ID_User.Text;

                    string selectAgrega = "SELECT RoleId, UserId FROM aspnet_UsersInRoles";
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin); // se establece conexion
                    SqlDataAdapter da = new SqlDataAdapter(selectAgrega, conn);   // creo dataadapter
                    //da.MissingSchemaAction = MissingSchemaAction.AddWithKey;       // usa ID en tablas
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.UpdateCommand = cb.GetUpdateCommand();
                    da.UpdateCommand = cb.GetInsertCommand();
                    da.UpdateCommand = cb.GetDeleteCommand();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    da.Fill(dt);

                    System.Data.DataRow drnew = dt.NewRow();

                    drnew["RoleId"] = TextBox_IdRol.Text;
                    drnew["UserId"] = TextBox_ID_User.Text;
                    // Se añade la nueva fila creada
                    dt.Rows.Add(drnew);

                    //Actualiza cambios
                    da.Update(dt);
                    dt.AcceptChanges();
                }

                else      // Solo para actualizar el role
                {
                    TextBox_IdRol.Text = mMiembro;
                    if (RadioButtonList1.Text == "Usuario")
                    {
                        TextBox_IdRol.Text = mMiembro;
                    }
                    if (RadioButtonList1.Text == "Admin")
                    {
                        TextBox_IdRol.Text = mAdmin;
                    }
                    string m_UserID = TextBox_ID_User.Text;
                    string SqlString = "Update aspnet_UsersInRoles set RoleId = '" + TextBox_IdRol.Text + "' where Userid = '" + m_UserID + "';";
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin))
                    {
                        using (SqlCommand MiComando = new SqlCommand(SqlString, conn))
                        {
                            conn.Open();
                            int FilasAfectadas = MiComando.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }

            TextBox_IdRol.Text = "";
            TextBox_IdRol.Text = "";
            LabelUser.Text = "";
           // TextBox_ID_User.Text = "";
            
 
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string SqlString = "DELETE aspnet_UsersInRoles WHERE UserId = '" + TextBox_ID_User.Text + "';";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConectionLogin))
            {
                using (SqlCommand MiComando = new SqlCommand(SqlString, conn))
                {
                    conn.Open();
                    int FilasAfectadas = MiComando.ExecuteNonQuery();
                    conn.Close();
                    
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clave", "alert('ROLE REMOVED....');", true);
                }
            }
        }

       }
}