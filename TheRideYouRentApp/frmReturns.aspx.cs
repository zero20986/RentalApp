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
    public partial class frmReturns : System.Web.UI.Page
    {
        static string ConnString = "Server=tcp:duncan1.database.windows.net,1433;Initial Catalog=TheRideYouRent;Persist Security Info=False;User ID=st10071198;Password=Loveupon13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection dbConn = new SqlConnection(ConnString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Returns_Table";
            dbComm = new SqlCommand(sql, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();
            dbConn.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string enableIdentityInsertSql = "SET IDENTITY_INSERT Returns_Table ON";
            SqlCommand enableIdentityInsertCmd = new SqlCommand(enableIdentityInsertSql, dbConn);
            enableIdentityInsertCmd.ExecuteNonQuery();


            string sql = "INSERT INTO Returns_Table(Return_ID,Rental_ID,InspectorNo, Over_Days, Fine_Amount,Return_Date) " +
                "VALUES (@Return_ID, @Rental_ID, @InspectorNo, @Over_Days, @Fine_Amount, @Return_Date)";
            dbComm = new SqlCommand(sql, dbConn);

            dbComm.Parameters.AddWithValue("@Return_ID", txtReturnID.Text);
            dbComm.Parameters.AddWithValue("@Rental_ID", txtRentalId.Text);
            dbComm.Parameters.AddWithValue("@InspectorNo", txtInspectorNo.Text);
            dbComm.Parameters.AddWithValue("@Over_Days", txtOverDays.Text);
            dbComm.Parameters.AddWithValue("@Fine_Amount", txtFineAmount.Text);
            dbComm.Parameters.AddWithValue("@Return_Date", txtReturnDate.Text);


            dbComm.ExecuteNonQuery();

            string disableIdentityInsertSql = "SET IDENTITY_INSERT Returns_Table OFF";
            SqlCommand disableIdentityInsertCmd = new SqlCommand(disableIdentityInsertSql, dbConn);
            disableIdentityInsertCmd.ExecuteNonQuery();

            dbConn.Close();

            txtReturnID.Text = "";
            txtRentalId.Text = "";
            txtInspectorNo.Text = "";
            txtOverDays.Text = "";
            txtFineAmount.Text = "";
            txtReturnDate.Text = "";
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Returns_Table WHERE Return_ID = @Return_ID";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Return_ID", txtRetrieve.Text); 
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();

            dbConn.Close();
        }
    }
}