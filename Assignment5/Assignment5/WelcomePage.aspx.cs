using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    //class for customer details
    public partial class WelcomePage : System.Web.UI.Page
    {
        //creating reference variables 
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader rdr;

        //this method will call while the page id loaded
        protected void Page_Load(object sender, EventArgs e)
        {
            //stablishing connection with SQL Server
            conn = new SqlConnection("Data Source=IKL-68\\SQL2016;Initial Catalog=Batch10;uid=sa;pwd=sa@1234;MultipleActiveResultSets = True");

            //checking if the page is rendered for the first time
            if (!Page.IsPostBack)
            {

                //applying try catch for exception handling
                try
                {
                    //Opening the Connection
                    conn.Open();

                    //assigning the SQL command to fetch the data from customer table
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = String.Format("select CustName from CustomerMaster");

                    //executing the command and storing in data reader
                    rdr = cmd.ExecuteReader();

                    //loop to read the data line by line
                    while (rdr.Read())
                    {
                        //adding the customer name in the dropdown list
                        drdCustName.Items.Add(rdr[0].ToString());
                    }
                    //closing the reader
                    rdr.Close();

                    //condition to check if the state of a connection is open
                    if (conn.State == ConnectionState.Open)
                    {
                        //fetching and displaying the data
                        FetchCustomer();
                        DisplayCustomer();
                    }

                }
                //if any sql related exception occures
                catch (SqlException ex)
                {
                    //displaying an error message
                    Response.Write(ex.Message);
                }
                finally
                {
                    //closing the connection
                    conn.Close();
                }
            }
        }

        //method to fetch data from customer table
        public void FetchCustomer()
        {
            //clearing the dropdown field
            drdCustName.Items.Clear();
            try
            {
                //initializing the SQL command to fetch the data
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select CustName from CustomerMaster");

                //executing the command and giving it to data reader
                rdr = cmd.ExecuteReader();

                //applying loop to read the data
                while (rdr.Read())
                {
                    //adding the customer name in the dropdown field
                    drdCustName.Items.Add(rdr[0].ToString());
                }
                //closing the reader
                rdr.Close();
            }
            catch (SqlException ex)
            {
                //displaying error message
                Response.Write(ex.Message);
            }


        }
        
        //method to display the customer details
        public void DisplayCustomer()
        {
            try
            {
                //initializing the SQL command to fetch the 
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from CustomerMaster where CustName='{0}'", drdCustName.Text);

                //executing the sql command to fetch the data and assigning it to data reader
                rdr = cmd.ExecuteReader();

                //applying loop to read the data
                while (rdr.Read())
                {
                    //displaying the data in the text boxs
                    txtCustID.Text = rdr["CustID"].ToString();
                    txtCustName.Text = rdr["CustName"].ToString();
                    txtMobNo.Text = rdr["MobileNumber"].ToString();
                    txtAddress.Text = rdr["Addresses"].ToString();
                }
                //closing data reader
                rdr.Close();

                //disabling the fields
                DisableTextBox();

            }
            catch (SqlException ex)
            {
                //displaying an error message
                Response.Write(ex.Message);
            }

        }

        //method to disable the field
        public void DisableTextBox()
        {
            //disabling the field
            txtAddress.Enabled = false;
            txtCustID.Enabled = false;
            txtCustName.Enabled = false;
            txtMobNo.Enabled = false;
        }

        //method to enable the fields
        public void EnableTextBox()
        {
            //enabling the fields
            txtAddress.Enabled = true;
            txtCustID.Enabled = true;
            txtCustName.Enabled = true;
            txtMobNo.Enabled = true;
        }

        //method to clear the fields
        public void ClearTextBox()
        {
            //clearing the fields
            txtAddress.Text = "";
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtMobNo.Text = "";
        }

        //method to enable and clear the fields to add new data
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            ClearTextBox();
        }

        //method to enable and fields to edit and update the data
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //enabling the fields
            EnableTextBox();
            //keeling the customer ID field on disable mode
            txtCustID.Enabled = false;
        }

        //method to save the new customer details
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //opening the connection
                conn.Open();
                
                //assigning the sql command to insert new data
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("insert into CustomerMaster(CustID,CustName,Addresses,MobileNumber)values({0},'{1}','{2}','{3}')", txtCustID.Text, txtCustName.Text, txtAddress.Text, txtMobNo.Text);
                
                //executing the command 
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    //displaying a message, once the data inserted successfully 
                    Response.Write("Record incerted sucessfully");
                }
                else
                {
                    //displaying an eror if data not inserted
                    Response.Write("Error");
                }

            }
            catch (SqlException ex)
            {
                //displaying an error message 
                Response.Write(ex.Message);
            }
            finally
            {
                //disabling the text boxes and dispalying the data  
                DisableTextBox();
                FetchCustomer();
                DisplayCustomer();
                conn.Close();
            }

        }

        //method to update the customer details
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //opening the connection
                conn.Open();

                //assigning the sql command to fetch and update the customer details
                cmd = new SqlCommand();
                cmd.Connection = conn;

                //fetching customer details
                cmd.CommandText = String.Format("select CustID from CustomerMaster where CustName='{0}'", drdCustName.SelectedItem);
                
                //fetching the custmer ID of an selected customer name
                int customerId = Convert.ToInt32(cmd.ExecuteScalar());

                //command to update the customer details
                cmd.CommandText = String.Format(" update CustomerMaster set CustName='{0}',Addresses='{1}',MobileNumber='{2}' where CustID={3}", txtCustName.Text, txtAddress.Text, txtMobNo.Text, customerId);

                //executing the update statement
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    //displaying a message, once the data updated
                    Response.Write("Record Updated sucessfully");
                }
                else
                {
                    //showing error if the data is not updated
                    Response.Write("Error");
                }

            }
            catch (SqlException ex)
            {
                //displaying an sql error message
                Response.Write(ex.Message);
            }
            finally
            {
                //displaying the data and disabling the fields
                FetchCustomer();
                DisplayCustomer();
                DisableTextBox();
                conn.Close();
            }

        }

        //method to delete the method
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //opening the connection
                conn.Open();
                
                //assiging the sql command to get and delete the custmer details
                cmd = new SqlCommand();
                cmd.Connection = conn;

                //fetching the customer ID
                cmd.CommandText = String.Format("select CustID from CustomerMaster where CustName='{0}'", drdCustName.SelectedItem);
                int customerId = Convert.ToInt32(cmd.ExecuteScalar());

                //commamnd to delete the customer detail
                cmd.CommandText = String.Format("delete from CustomerMaster where CustID={0}", customerId);
                
                //deleting the customer
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    //displying a message, once customer details get deleted
                    Response.Write("Record deleted sucessfully");
                }
                else
                {
                    //displaying an error if customer details not deleted
                    Response.Write("Error");
                }


            }
            catch (SqlException ex)
            {
                //displaying an error message
                Response.Write(ex.Message);
            }
            finally
            {
                //disabling the fields and showing the data
                FetchCustomer();
                DisplayCustomer();
                DisableTextBox();
                conn.Close();
            }
        }

        //method to add the customer name in the dropdown field
        protected void drdCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //opening the connection
                conn.Open();
                //command to fetch the names of a customers from database
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from CustomerMaster where CustName='{0}'", drdCustName.Text);

                //executing the command
                rdr = cmd.ExecuteReader();

                //loop to read the data
                while (rdr.Read())
                {
                    //displying the records in the fields
                    txtCustID.Text = rdr["CustID"].ToString();
                    txtCustName.Text = rdr["CustName"].ToString();
                    txtMobNo.Text = rdr["MobileNumber"].ToString();
                    txtAddress.Text = rdr["Addresses"].ToString();
                }
                //closing the reader
                rdr.Close();
                DisableTextBox();

            }
            catch (SqlException ex)
            {
                //displaying error message
                Response.Write(ex.Message);
            }
            finally
            {
                //closing the connection
                conn.Close();
            }

        }
    }
}
               