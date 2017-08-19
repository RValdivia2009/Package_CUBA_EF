using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Package_WebApp.PagesMembers
{
    public partial class CubaRegister : System.Web.UI.Page
    {
        string cmdText = "SELECT dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main, dbo.TBL_Cuba_Package_Main.Date, dbo.TBL_Cuba_Package_Main.Destinatario, dbo.TBL_Cuba_Package_Main.Sender, " +
                                    "dbo.TBL_Cuba_Package_Main.Note, dbo.TBL_Cuba_Package_Main.Long, dbo.TBL_Cuba_Package_Main.Wide, dbo.TBL_Cuba_Package_Main.High, dbo.TBL_Cuba_Package_Main.Weight, " +
                                    "dbo.TBL_Cuba_Package_Main.Volumen, dbo.TBL_Cuba_Package_Main.Decrip, dbo.TBL_Cuba_Package_Main.Employee, dbo.TBL_Cuba_Package_Main.Employee1, " +
                                    "dbo.TBL_Cuba_Package_Main.Provincia, dbo.TBL_Cuba_Package_Main.Municipio, dbo.TBL_Cuba_Package_Main.Estado, dbo.TBL_Cuba_Package_Main.Pagado, " +
                                    "dbo.TBL_Cuba_Package_Main.PaqieteNo, dbo.TBL_Cuba_Package_Main.WR, dbo.TBL_Cuba_Package_Main.Usuario, dbo.TBL_Cuba_Package_Main.WRImage, " +
                                    "dbo.tbl_Cuba_N_Provincias.Provincia AS ProviNombre, dbo.tbl_Cuba_N_Municipios.Municipios, dbo.tbl_Cuba_N_Sender.Sender_Nombre, dbo.tbl_Cuba_N_Sender.Sender_Apellido, " +
                                    "tbl_Cuba_N_Destinatario_1.Dest_Nombre, tbl_Cuba_N_Destinatario_1.Dest_Apellido, dbo.TBL_Cuba_Package_Main.TipoEntrega " +

                              "FROM ((((((dbo.tbl_Cuba_N_Destinatario INNER JOIN dbo.TBL_Cuba_Package_Main ON dbo.tbl_Cuba_N_Destinatario.id_Destinatario = dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main) " +
                                    "INNER JOIN dbo.tbl_Cuba_N_Provincias ON dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main = dbo.tbl_Cuba_N_Provincias.id_Provincia) " +
                                    "INNER JOIN dbo.tbl_Cuba_N_Sender ON dbo.TBL_Cuba_Package_Main.Sender = dbo.tbl_Cuba_N_Sender.id_Sender) " +
                                    "INNER JOIN dbo.tbl_Cuba_N_Municipios ON dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main = dbo.tbl_Cuba_N_Municipios.id_Municipios) " +
                                    "INNER JOIN dbo.tbl_Cuba_N_Destinatario AS tbl_Cuba_N_Destinatario_1 ON dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main = tbl_Cuba_N_Destinatario_1.id_Destinatario) " +
                                    "FULL OUTER JOIN dbo.TBL_Cuba_Package_Main_Detalles ON dbo.TBL_Cuba_Package_Main.id_Cuba_Package_Main = dbo.TBL_Cuba_Package_Main_Detalles.Cuba_Package_Main)";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //===== To bind employee's records from database.
                           bindEmployeeDetailsToListView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //======= Insert Query.
            string cmdText = "INSERT INTO employee (Name,Email,Age,Salary) VALUES (@Name,@Email,@Age,@Salary)";

            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);

            //===== Adding parameters/Values.
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
            cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(txtSalary.Text));

            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //===== Execute Query.
            cmd.ExecuteNonQuery();

            //===== close the connection.
            con.Close();

            //===== Clear text from textboxes
            clearInputControls();

            //===== Bind data to ListView.
            bindEmployeeDetailsToListView();

        }

        //========= Update Button
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //======= Insert Query.
            string cmdText = "UPDATE employee SET Name=@Name,Email=@Email,Age=@Age,Salary=@Salary WHERE Id=@Id";

            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);

            //===== Adding parameters/Values.
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
            cmd.Parameters.AddWithValue("@Salary", Convert.ToDouble(txtSalary.Text));

            //====== Remember we have stored primary key in hiddenfield during 
            //====== binding values into textboxes method:(bindEmployeeDetailToEdit).
            //====== We will use same id to pass id parameter.
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(hfSelectedRecord.Value));


            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //===== Execute Query.
            cmd.ExecuteNonQuery();

            //===== close the connection.
            con.Close();

            //===== Clear text from textboxes
            clearInputControls();

            //===== Bind data to listview.
            bindEmployeeDetailsToListView();

            //===== Show Save button and hide update button.
            btnSave.Visible = true;
            btnUpdate.Visible = false;

            //===== Clear Hiddenfield
            hfSelectedRecord.Value = string.Empty;
        }

        //========= Edit,Delete buttons inside ListView.
        protected void lstViewEmployeeDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            //====== Here we use switch state to distinguish which link button is clicked based 
            //====== on command name supplied to the link button.
            switch (e.CommandName)
            {
                //==== This case will fire when link button placed
                //==== inside Listview having command name "Delte" is clicked.

                case ("Del"):
                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    int id = Convert.ToInt32(e.CommandArgument);

                    //==== Call delete method and pass id as argument.
                    deleteEmployee(id);

                    break;

                //==== This case will fire when link button placed
                //==== inside ListView having command name "Edt" is clicked.
                case ("Edt"):

                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                    id = Convert.ToInt32(e.CommandArgument);

                    //==== Call delete method and pass id as argument.
                    bindEmployeeDetailToEdit(id);

                    //=== we will store id into hiddenfield so that we can use it later during update process.
                    hfSelectedRecord.Value = id.ToString();

                    break;


            }
        }

        //===== Cancel button.
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputControls();
        }

        //===== Method to bind employee records to ListView control.
        void bindEmployeeDetailsToListView()
        {
            //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.

            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion
            /////SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //======= Select Query.
            //string cmdText = "SELECT * FROM employee";
           

















            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);

            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //===== Execute Query and bind data to ListView.
            lstViewEmployeeDetails.DataSource = cmd.ExecuteReader();
            lstViewEmployeeDetails.DataBind();
        }

        //===== Clear Inut control's data.
        void clearInputControls()
        {
            txtAge.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSalary.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        //===== Method to delete employee from database.
        void deleteEmployee(int id)
        {
            //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);

            //======= Delete Query.
            string cmdText = "DELETE FROM employee WHERE Id=@Id";

            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);

            //===== Adding parameters/Values.
            cmd.Parameters.AddWithValue("@Id", id);

            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //===== Execute Query.
            cmd.ExecuteNonQuery();

            //===== close the connection.
            con.Close();

            //===== Bind data to listview.
            bindEmployeeDetailsToListView();
        }

        //==== Method to bind data to textboxes for update.
        public void bindEmployeeDetailToEdit(int id)
        {
            //====== Getting connection string defined in the web.config file. Pointed to the database we want to use.
            ///////SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString);
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString); // se establece conexion

            //======= Query.
            //string cmdText = //"SELECT * FROM employee WHERE Id=@Id";
            cmdText = cmdText + "WHERE id_Cuba_Package_Main=@id_Cuba_Package_Main";

            //====== Providning information to SQL command object about which query to 
            //====== execute and from where to get database connection information.
            SqlCommand cmd = new SqlCommand(cmdText, con);

            //===== Adding parameters/Values.
            cmd.Parameters.AddWithValue("@id_Cuba_Package_Main", id);

            //===== To check current state of the connection object. If it is closed open the connection
            //===== to execute the insert query.
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            //===== Execute Query.
            SqlDataReader dr = cmd.ExecuteReader();

            //=== Read Data.
            if (dr.HasRows)
            {
                dr.Read();
                txtEmail.Text = dr["id_Cuba_Package_Main"].ToString();
                txtAge.Text = dr["Destinatario"].ToString();
                txtName.Text = dr["Sender"].ToString();
                txtSalary.Text = dr["Estado"].ToString();




                //=== Make update button visible and save button invisible
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }

            //===== close the connection.
            con.Close();
        }





    }
}