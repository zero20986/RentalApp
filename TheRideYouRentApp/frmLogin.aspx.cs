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
    public partial class frmLogin : System.Web.UI.Page
    {
        static string ConnString = "Server=tcp:duncan1.database.windows.net,1433;Initial Catalog=TheRideYouRent;Persist Security Info=False;User ID=st10071198;Password=Loveupon13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection dbConn = new SqlConnection(ConnString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT Email, Password " +
             "FROM Inspector " +
             "WHERE Email = @Email AND Password = @Password";


            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Email", txtEmail.Text);
            dbComm.Parameters.AddWithValue("@Password", txtPassword.Text);

            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Redirect("frmMainMenu.aspx");
            }
            else
            {
                lblResult.Text = "Incorrect Email or Password entered";
                lblResult.Visible = true;
            }
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}