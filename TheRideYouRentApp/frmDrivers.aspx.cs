using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheRideYouRentApp
{
    public partial class frmDrivers : System.Web.UI.Page
    {
        static string ConnString = "Server=tcp:duncan1.database.windows.net,1433;Initial Catalog=TheRideYouRent;Persist Security Info=False;User ID=st10071198;Password=Loveupon13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection dbConn = new SqlConnection(ConnString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDriverIDDeleteBtn();
                LoadDriverID();
            }

            LoadDriverID();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            string sqlEnableIdentityInsert = "SET IDENTITY_INSERT Driver ON";
            dbComm = new SqlCommand(sqlEnableIdentityInsert, dbConn);
            dbComm.ExecuteNonQuery();


            string sql = "INSERT INTO Driver(DriverID,Name,Surname, Address, Email,Mobile) " +
                "VALUES (@DriverID, @Name, @Surname, @Address, @Email, @Mobile)";
            dbComm = new SqlCommand(sql, dbConn);

            dbComm.Parameters.AddWithValue("@DriverID", txtDriverID.Text);
            dbComm.Parameters.AddWithValue("@Name", txtName.Text);
            dbComm.Parameters.AddWithValue("@Surname", txtSurname.Text);
            dbComm.Parameters.AddWithValue("@Address", txtAddress.Text);
            dbComm.Parameters.AddWithValue("@Email", txtEmail.Text);
            dbComm.Parameters.AddWithValue("@Mobile", txtMobile.Text);


            dbComm.ExecuteNonQuery();
            string sqlDisableIdentityInsert = "SET IDENTITY_INSERT Driver OFF";
            dbComm = new SqlCommand(sqlDisableIdentityInsert, dbConn);
            dbComm.ExecuteNonQuery();

            dbConn.Close();

            txtDriverID.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Driver";
            dbComm = new SqlCommand(sql, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvDriver.DataSource = dt;
            dgvDriver.DataBind();
            dbConn.Close();

            ddlUpdateDriverID.DataSource = dt;
            ddlUpdateDriverID.DataTextField = "DriverID";
            ddlUpdateDriverID.DataBind();

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "DriverID";
            ddlDelete.DataBind();
        }

        protected void ddlUpdateDriverID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SelectedDriverID"] = ddlUpdateDriverID.SelectedValue;
        }

        protected void ddlUpdate_Load(object sender, EventArgs e)
        {
            ddlUpdate.Items.Add(new ListItem("DriverID"));
            ddlUpdate.Items.Add(new ListItem("Name"));
            ddlUpdate.Items.Add(new ListItem("Surname"));
            ddlUpdate.Items.Add(new ListItem("Address"));
            ddlUpdate.Items.Add(new ListItem("Email"));
            ddlUpdate.Items.Add(new ListItem("Mobile"));
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "UPDATE Driver SET " + ddlUpdate.SelectedValue + " = @Value WHERE DriverID = @DriverID";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Value", txtUpdate.Text);
            dbComm.Parameters.AddWithValue("@DriverID", ddlUpdateDriverID.SelectedValue);

            int affectedRows = dbComm.ExecuteNonQuery();

            dbConn.Close();
        }

        protected void ddlDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SelectedDriverID"] = ddlDelete.SelectedValue;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (ddlDelete.SelectedItem != null)
            {
                string SelectedDriverID = ddlDelete.SelectedValue;

                dbConn.Open();

                string sql = "DELETE FROM Driver WHERE DriverID = @DriverID";
                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@DriverID", SelectedDriverID);
                dbComm.ExecuteNonQuery();

                dbConn.Close();

                LoadDriverIDDeleteBtn();
            }
        }

        protected void LoadDriverIDDeleteBtn()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Driver";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "DriverID";
            ddlDelete.DataValueField = "DriverID";
            ddlDelete.DataBind();

            dbConn.Close();

        }
        protected void LoadDriverID()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Driver";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlUpdateDriverID.DataSource = dt;
            ddlUpdateDriverID.DataTextField = "DriverID";
            ddlUpdateDriverID.DataBind();

            dbConn.Close();

           
        }
    }
}