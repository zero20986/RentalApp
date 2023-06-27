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
    public partial class frmCars : System.Web.UI.Page
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
                LoadCarNumbers();
                LoadCarNumbersDeleteBtn();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "INSERT INTO Car(CarNo,Make_Code,Body_Type_Code, Model, Kilometres_Travelled,Service_Kilometres,Available,RentalFee) " +
                "VALUES (@CarNo, @MakeCode, @BodyType, @Model, @KilosTravelled, @ServiceKilos, @Availabilty, @RentalFee)";
            dbComm = new SqlCommand(sql, dbConn);

            dbComm.Parameters.AddWithValue("@CarNo", txtCarNo.Text);
            dbComm.Parameters.AddWithValue("@MakeCode", txtMakeCode.Text);
            dbComm.Parameters.AddWithValue("@BodyType", txtBodyTypeCode.Text);
            dbComm.Parameters.AddWithValue("@Model", txtModel.Text);
            dbComm.Parameters.AddWithValue("@KilosTravelled", txtKilosTravelled.Text);
            dbComm.Parameters.AddWithValue("@ServiceKilos", txtServiceKilos.Text);
            dbComm.Parameters.AddWithValue("@Availabilty", txtAvailability.Text);
            dbComm.Parameters.AddWithValue("@RentalFee", txtRentalFee.Text);
            
            dbComm.ExecuteNonQuery();

            dbConn.Close();

            txtCarNo.Text = "";
            txtMakeCode.Text = "";
            txtBodyTypeCode.Text = "";
            txtModel.Text = "";
            txtKilosTravelled.Text = "";
            txtServiceKilos.Text = "";
            txtAvailability.Text = "";
            txtRentalFee.Text = "";
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "SELECT * FROM Car";
            dbComm = new SqlCommand(sql, dbConn);
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);
            dgvCar.DataSource = dt;
            dgvCar.DataBind();
            dbConn.Close();

            ddlUpdateCarNo.DataSource = dt;
            ddlUpdateCarNo.DataTextField = "CarNo";
            ddlUpdateCarNo.DataBind();

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "CarNo";
            ddlDelete.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            dbConn.Open();

            string sql = "UPDATE Car SET " + ddlUpdate.SelectedValue + " = @Value WHERE CarNo = @CarNo";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.Parameters.AddWithValue("@Value", txtUpdate.Text);
            dbComm.Parameters.AddWithValue("@CarNo", ddlUpdateCarNo.SelectedValue);

            int affectedRows = dbComm.ExecuteNonQuery();

            dbConn.Close();


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlDelete.SelectedItem != null)
            {
                string selectedCarNo = ddlDelete.SelectedValue;

                dbConn.Open();

                string sql = "DELETE FROM Car WHERE CarNo = @CarNo";
                dbComm = new SqlCommand(sql, dbConn);
                dbComm.Parameters.AddWithValue("@CarNo", selectedCarNo);
                dbComm.ExecuteNonQuery();

                dbConn.Close();

                LoadCarNumbersDeleteBtn();
            }
        }
        protected void LoadCarNumbersDeleteBtn()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Car";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlDelete.DataSource = dt;
            ddlDelete.DataTextField = "CarNo";
            ddlDelete.DataValueField = "CarNo"; 
            ddlDelete.DataBind();

            dbConn.Close();

            if (ViewState["SelectedCarNo"] != null)
            {
                ddlDelete.SelectedValue = ViewState["SelectedCarNo"].ToString();
            }
        }
        protected void LoadCarNumbers()
        {
            dbConn.Open();

            string sql = "SELECT * FROM Car";
            dbComm = new SqlCommand(sql, dbConn);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            ddlUpdateCarNo.DataSource = dt;
            ddlUpdateCarNo.DataTextField = "CarNo";
            ddlUpdateCarNo.DataBind();

            dbConn.Close();

            if (ViewState["SelectedCarNo"] != null)
            {
                ddlUpdateCarNo.SelectedValue = ViewState["SelectedCarNo"].ToString();
            }
        }

        protected void ddlUpdate_Load(object sender, EventArgs e)
        {
            ddlUpdate.Items.Add(new ListItem("CarNo"));
            ddlUpdate.Items.Add(new ListItem("Make_Code"));
            ddlUpdate.Items.Add(new ListItem("Body_Type_Code"));
            ddlUpdate.Items.Add(new ListItem("Model"));
            ddlUpdate.Items.Add(new ListItem("Kilometres_Travelled"));
            ddlUpdate.Items.Add(new ListItem("Service_Kilometres"));
            ddlUpdate.Items.Add(new ListItem("Available"));
            ddlUpdate.Items.Add(new ListItem("RentalFee"));
        }

        protected void ddlUpdateCarNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           ViewState["SelectedCarNo"] = ddlUpdateCarNo.SelectedValue;
        }

        protected void ddlDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["SelectedCarNo"] = ddlDelete.SelectedValue;
        }
    }
}