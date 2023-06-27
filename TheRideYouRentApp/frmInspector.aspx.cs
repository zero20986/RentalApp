using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheRideYouRentApp
{
    public partial class frmInspector : System.Web.UI.Page
    {
        static string ConnString = "Server=tcp:duncan1.database.windows.net,1433;Initial Catalog=TheRideYouRent;Persist Security Info=False;User ID=st10071198;Password=Loveupon13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection dbConn = new SqlConnection(ConnString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInspectorNumbersDeleteBtn();
            LoadSInspectorNumbers();

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "INSERT INTO Inspector(InspectorNo,Name,Surname,Email,Mobile,Password) " +
                "VALUES (@InspectorNo, @Name, @Surname, @Email, @Mobile, @Password)";
            dbComm = new SqlCommand(sql, dbConn);

            dbComm.Parameters.AddWithValue("@InspectorNo", txtInspectorNo.Text);
            dbComm.Parameters.AddWithValue("@Name", txtName.Text);
            dbComm.Parameters.AddWithValue("@Surname", txtSurname.Text);
            dbComm.Parameters.AddWithValue("@Email", txtEmail.Text);
            dbComm.Parameters.AddWithValue("@Mobile", txtMobile.Text);
            dbComm.Parameters.AddWithValue("@Password", txtPassword.Text);

            dbComm.ExecuteNonQuery();

            dbConn.Close();

            txtInspectorNo.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtPassword.Text = "";
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Inspector";
            dbComm = new SqlCommand(sql, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();
            dbConn.Close();

            ddlUpdateInspecterNo.DataSource = dt;
            ddlUpdateInspecterNo.DataTextField = "InspectorNo";
            ddlUpdateInspecterNo.DataBind();

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "InspectorNo";
            ddlDelete.DataBind();
        }

        protected void ddlUpdateInspecterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SelectedInspectorNo"] = ddlUpdateInspecterNo.SelectedValue;
        }

        protected void ddlUpdate_Load(object sender, EventArgs e)
        {
            ddlUpdate.Items.Add(new ListItem("InspectorNo"));
            ddlUpdate.Items.Add(new ListItem("Name"));
            ddlUpdate.Items.Add(new ListItem("Surname"));
            ddlUpdate.Items.Add(new ListItem("Email"));
            ddlUpdate.Items.Add(new ListItem("Mobile"));
            ddlUpdate.Items.Add(new ListItem("Password"));
        }

        protected void ddlDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SelectedInspectorNo"] = ddlDelete.SelectedValue;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlDelete.SelectedItem != null)
            {
                string selectedInspectorNo = ddlDelete.SelectedValue;

                dbConn.Open();

                string sql = "DELETE FROM Inspector WHERE InspectorNo = @InspectorNo";
                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@InspectorNo", selectedInspectorNo);
                dbComm.ExecuteNonQuery();

                dbConn.Close();

                LoadInspectorNumbersDeleteBtn();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "UPDATE Inspector SET " + ddlUpdate.SelectedValue + " = @Value WHERE InspectorNo = @InspectorNo";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Value", txtUpdate.Text);
            dbComm.Parameters.AddWithValue("@InspectorNo", ddlUpdateInspecterNo.SelectedValue);

            int affectedRows = dbComm.ExecuteNonQuery();
        }
        protected void LoadInspectorNumbersDeleteBtn()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Inspector";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "InspectorNo";
            ddlDelete.DataValueField = "InspectorNo";
            ddlDelete.DataBind();

            dbConn.Close();

            if (ViewState["SelectedInspectorNo"] != null)
            {
                ddlDelete.SelectedValue = ViewState["SelectedInspectorNo"].ToString();
            }
        }
        protected void LoadSInspectorNumbers()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Inspector";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlUpdateInspecterNo.DataSource = dt;
            ddlUpdateInspecterNo.DataTextField = "InspectorNo";
            ddlUpdateInspecterNo.DataBind();

            dbConn.Close();

            if (ViewState["SelectedInspectorNo"] != null)
            {
                ddlUpdateInspecterNo.SelectedValue = ViewState["SelectedInspectorNo"].ToString();
            }
        }

    }
}