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
    public partial class ProductPageWeb : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader rdr;
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
                    if (conn.State == ConnectionState.Open)
                    {
                        FetchProduct();
                        DisplayProduct();
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
        public void DisplayProduct()
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from ProductMaster where ProductName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtProdId.Text = rdr["ProdID"].ToString();
                    txtProdName.Text = rdr["ProductName"].ToString();
                    txtProdPrice.Text = rdr["Price"].ToString();
                    txtProdQty.Text = rdr["Qty"].ToString();
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
            txtProdQty.Enabled = false;
            txtProdName.Enabled = false;
            txtProdId.Enabled = false;
            txtProdPrice.Enabled = false;
        }
        public void EnableTextBox()
        {
            txtProdQty.Enabled = true;
            txtProdName.Enabled = true;
            txtProdId.Enabled = true;
            txtProdPrice.Enabled = true;
        }
        public void ClearTextBox()
        {
            txtProdPrice.Text = "";
            txtProdId.Text = "";
            txtProdName.Text = "";
            txtProdQty.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            ClearTextBox();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            txtProdId.Enabled = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("insert into ProductMaster(ProdID,ProductName,Qty,Price)values({0},'{1}',{2},{3})", txtProdId.Text, txtProdName.Text, txtProdQty.Text, txtProdPrice.Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Record incerted sucessfully");
                }
                else
                {
                    Response.Write("Error");
                }

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {

                DisableTextBox();
                FetchProduct();
                DisplayProduct();
                conn.Close();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select ProdID from ProductMaster where ProductName='{0}'", drdProdName.SelectedItem);
                int ProductId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = String.Format(" update ProductMaster set ProductName='{0}',Qty={1},Price={2}where ProdID={3}", txtProdName.Text, txtProdQty.Text, txtProdPrice.Text, ProductId);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Record Updated sucessfully");
                }
                else
                {
                    Response.Write("Error");
                }

            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {
                FetchProduct();
                DisplayProduct();
                DisableTextBox();
                conn.Close();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format("select ProdID from ProductMaster where ProductName='{0}'", drdProdName.SelectedItem);
                int ProductId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = String.Format("delete from ProductMaster where ProdID={0}", ProductId);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    Response.Write("Record deleted sucessfully");
                }
                else
                {
                    Response.Write("Error");
                }


            }
            catch (SqlException ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {
                FetchProduct();
                DisplayProduct();
                DisableTextBox();
                conn.Close();
            }
        }

        protected void drdProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = String.Format(" select * from ProductMaster where ProductName='{0}'", drdProdName.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtProdId.Text = rdr["ProdID"].ToString();
                    txtProdName.Text = rdr["ProductName"].ToString();
                    txtProdPrice.Text = rdr["Price"].ToString();
                    txtProdQty.Text = rdr["Qty"].ToString();
                }
                rdr.Close();
                DisableTextBox();

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
}
