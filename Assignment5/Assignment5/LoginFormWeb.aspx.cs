using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    //defining class for admin login
    public partial class LoginFormWeb : System.Web.UI.Page
    {
        //setting the user ID and password of an admin
        string UserID = "Admin", Password = "admin@1234#$!";

        //method to check and redirect the user to the product page
        protected void lnkProdPage_Click(object sender, EventArgs e)
        {
            try
            {
                //checking the user ID and password
                if (txtUserID.Text == UserID && txtPassword.Text == Password)
                {
                    //redirecting to product page
                    Response.Redirect("ProductPageWeb.aspx");
                }
                else
                {
                    //displaying error if user entered invalid details
                    Response.Write("Invalid UserID and Password");
                }
            }
            catch (Exception ex)
            {
                //displaying an error message
                Response.Write(ex.Message);
            }


        }

        //method to check and redirect the user to the customer page
        protected void lnkCust_Click(object sender, EventArgs e)
        {
            try
            {
                //checking the user ID and password
                if (txtUserID.Text == UserID && txtPassword.Text == Password)
                {
                    //redirecting to customer page page
                    Response.Redirect("WelcomePage.aspx");
                }
                else
                {
                    //displaying error if user entered invalid details
                    Response.Write("Invalid UserID and Password");
                }
            }
            catch (Exception ex)
            {
                //displaying an error message
                Response.Write(ex.Message);
            }

        }


        //method to check and redirect the user to the Billing page
        protected void lnkBill_Click(object sender, EventArgs e)
        {
            try
            {
                //checking the user ID and password
                if (txtUserID.Text == UserID && txtPassword.Text == Password)
                {
                    //redirecting to customer page page
                    Response.Redirect("BillDetailsWeb.aspx");
                }
                else
                {
                    //displaying error if user entered invalid details
                    Response.Write("Invalid UserID and Password");
                }
            }
            catch (Exception ex)
            {
                //displaying an error message
                Response.Write(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
