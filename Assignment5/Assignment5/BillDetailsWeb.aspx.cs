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
    //class for bill details
    public partial class BillDetailsWeb : System.Web.UI.Page
    {
        //
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
        int ProdPrice;
        int requiredQty;
        int finalBill, avilableQty, restQuantity;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=IKL-68\\SQL2016;Initial Catalog=Batch10;uid=sa;pwd=sa@1234;MultipleActiveResultSets = True");
            if (!Page.IsPostBack)
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = String.Format("select ProductName from ProductMaster");
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        drdProdName.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                    cmd.CommandText = String.Format("select CustName from CustomerMaster");
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        drdCustName.Items.Add(rdr[0].ToString());
                    }
                    rdr.Close();
                    if (conn.State == ConnectionState.Open)
                    {
                        FetchProduct();
                        DisplayProduct();
                        FetchCustomer();
                        DisplayCustomer();
                    }

                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public void FetchCustomer()
        {
            drdCustName.Items.Clear();
            try
            {

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select CustName from CustomerMaster");
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    drdCustName.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }


        }
        public void DisplayCustomer()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from CustomerMaster where CustName='{0}'", drdCustName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblCustIDRes.Text = rdr["CustID"].ToString();
                    lblCustName.Text = rdr["CustName"].ToString();
                    lblMobileRes.Text = rdr["MobileNumber"].ToString();
                    lblAddressRes.Text = rdr["Addresses"].ToString();
                }
                rdr.Close();
                DisableTextBox();

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }
        public void FetchProduct()
        {
            drdProdName.Items.Clear();
            try
            {

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select ProductName from ProductMaster");
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    drdProdName.Items.Add(rdr[0].ToString());
                }
                rdr.Close();
            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }

        protected void drdProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select * from ProductMaster where ProductName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdId.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProductName"].ToString();
                    lblPrdPrice.Text = rdr["Price"].ToString();
                    lblResQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        protected void drdCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from CustomerMaster where CustName='{0}'", drdCustName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblCustIDRes.Text = rdr["CustID"].ToString();
                    lblCustName.Text = rdr["CustName"].ToString();
                    lblMobileRes.Text = rdr["MobileNumber"].ToString();
                    lblAddressRes.Text = rdr["Addresses"].ToString();
                }
                rdr.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnFillDetails_Click(object sender, EventArgs e)
        {
            txtReqQty.Enabled = true;
            txtBillNo.Enabled = true;
            txtBillNo.Text = "";
            txtReqQty.Text = "";
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                requiredQty = Convert.ToInt32(txtReqQty.Text);
                finalBill = requiredQty * ProdPrice;
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select * from ProductMaster where ProductName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdId.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProductName"].ToString();

                    lblPrdPrice.Text = rdr["Price"].ToString();
                    ProdPrice = Convert.ToInt32(lblPrdPrice.Text);
                    lblResQty.Text = rdr["Qty"].ToString();
                    avilableQty = Convert.ToInt32(lblResQty.Text);
                }
                rdr.Close();
                cmd.CommandText = String.Format(" select * from CustomerMaster where CustName='{0}'", drdCustName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblCustIDRes.Text = rdr["CustID"].ToString();
                    lblCustName.Text = rdr["CustName"].ToString();
                    lblMobileRes.Text = rdr["MobileNumber"].ToString();
                    lblAddressRes.Text = rdr["Addresses"].ToString();
                }
                rdr.Close();
                if (avilableQty >= requiredQty)
                {
                    restQuantity = avilableQty - requiredQty;
                    finalBill = requiredQty * ProdPrice;

                    cmd.CommandText = String.Format("insert into BillDetails(BillNo,CustID,ProdID,Qty,Total_Bill)values({0},{1},{2},{3},{4})", txtBillNo.Text, lblCustIDRes.Text, lblResProdId.Text, requiredQty, finalBill);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Response.Write("Order placed sucessfully!!!!!!!!!");
                        cmd.CommandText = String.Format("update ProductMaster set Qty={0}", restQuantity);
                        int updatedRow = cmd.ExecuteNonQuery();
                        if (updatedRow > 0)
                        {
                            Response.Write("Product master updated");
                        }
                    }
                    lblTotalBill.Text = "Rs. "+finalBill.ToString();


                }
                else
                {
                    Response.Write("Invalid Item");
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                FetchProduct();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblPrdPrice.Text = "";
            lblResProdId.Text = "";
            lblResQty.Text = "";
            lblMobileRes.Text = "";
            lblAddressRes.Text = "";
            
            lblResProdName.Text = "";
            lblCustIDRes.Text = "";
            lblCustName.Text = "";
            
        }

        public void DisplayProduct()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select * from ProductMaster where ProductName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblResProdId.Text = rdr["ProdID"].ToString();
                    lblResProdName.Text = rdr["ProductName"].ToString();
                    lblPrdPrice.Text = rdr["Price"].ToString();
                    lblResQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
                DisableTextBox();

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }

        }
        public void DisableTextBox()
        {
            txtReqQty.Enabled = false;
            txtBillNo.Enabled = false;
        }

    }
}
