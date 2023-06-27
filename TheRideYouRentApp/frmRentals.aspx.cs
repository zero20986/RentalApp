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
    public partial class frmRentals : System.Web.UI.Page
    {
        static string ConnString = "Server=tcp:duncan1.database.windows.net,1433;Initial Catalog=TheRideYouRent;Persist Security Info=False;User ID=st10071198;Password=Loveupon13;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection dbConn = new SqlConnection(ConnString);
        SqlCommand dbComm;
        DataTable dt;
        SqlDataAdapter dbAdapter;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Rental";
            dbComm = new SqlCommand(sql, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();
            dbConn.Close();

        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Rental WHERE Rental_ID = @RentalID";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@RentalID", txtRetrieve.Text);
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

            string enableIdentityInsertSql = "SET IDENTITY_INSERT Rental ON";
            SqlCommand enableIdentityInsertCmd = new SqlCommand(enableIdentityInsertSql, dbConn);
            enableIdentityInsertCmd.ExecuteNonQuery();

            string sql = "INSERT INTO Rental(Rental_ID,Car_No,DriverID, InspectorNo, Start_Date,End_Date) " +
                "VALUES (@Rental_ID, @Car_No, @DriverID, @InspectorNo, @Start_Date, @End_Date)";
            dbComm = new SqlCommand(sql, dbConn);

            dbComm.Parameters.AddWithValue("@Rental_ID", txtRentalId.Text);
            dbComm.Parameters.AddWithValue("@Car_No", txtCarno.Text);
            dbComm.Parameters.AddWithValue("@DriverID", txtDriverID.Text);
            dbComm.Parameters.AddWithValue("@InspectorNo", txtInspectorNo.Text);
            dbComm.Parameters.AddWithValue("@Start_Date", txtStart.Text);
            dbComm.Parameters.AddWithValue("@End_Date", txtEnd.Text);


            dbComm.ExecuteNonQuery();
            
            string disableIdentityInsertSql = "SET IDENTITY_INSERT Rental OFF";
            SqlCommand disableIdentityInsertCmd = new SqlCommand(disableIdentityInsertSql, dbConn);
            disableIdentityInsertCmd.ExecuteNonQuery();

            dbConn.Close();

            txtRentalId.Text = "";
            txtCarno.Text = "";
            txtDriverID.Text = "";
            txtInspectorNo.Text = "";
            txtStart.Text = "";
            txtEnd.Text = "";
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            string sql = "SELECT Rental.Car_No, Returns_Table.Return_Date, Rental.End_Date, " +
             "DATEDIFF(day, Rental.End_Date, Returns_Table.Return_Date) AS Elapsed_Days, " +
             "CASE WHEN DATEDIFF(day, Rental.End_Date, Returns_Table.Return_Date) <= 0 THEN 0 " +
             "ELSE DATEDIFF(day, Rental.End_Date, Returns_Table.Return_Date) * 500 END AS Late_Fee " +
             "FROM Rental " +
             "INNER JOIN Returns_Table ON Rental.InspectorNo = Returns_Table.InspectorNo " +
             "AND Rental.Rental_ID = Returns_Table.Rental_ID " +
             "AND Rental.End_Date < Returns_Table.Return_Date;";

            dbComm = new SqlCommand(sql, dbConn);
            
            dbAdapter = new SqlDataAdapter(dbComm);
            
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();

            dbConn.Close();
        }
    }
}