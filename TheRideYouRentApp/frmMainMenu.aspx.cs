using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheRideYouRentApp
{
    public partial class frmMainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCarsEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCars.aspx");
        }

        protected void btnInspectorsEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmInspector.aspx");
        }

        protected void btnDriversEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmDrivers.aspx");
        }

        protected void btnReturnsEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReturns.aspx");
        }

        protected void btnRentalsEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRentals.aspx");
        }
    }
}