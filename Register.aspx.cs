using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Signup
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //const string str = "Insert into "
            SqlConnection con = new SqlConnection(@"Data Source=w-h44py03-0;Initial Catalog=BookHunt;Persist Security Info=True;User ID=sa;Password=admin");
            SqlCommand cmd = new SqlCommand("insert into VendorTable values(@Name,@EmailId,@Password,@Phnumber)", con);
            cmd.Parameters.AddWithValue("Name", txtName.Text);
            cmd.Parameters.AddWithValue("Phnumber", txtMobile.Text);
            cmd.Parameters.AddWithValue("EmailId", txtUsername.Text);
            cmd.Parameters.AddWithValue("Password", txtPassword.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("AddBooks.aspx");

            txtName.Text = "";
            txtMobile.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";

            txtName.Focus();

            lblSuccessMessage.Text = "User Successfully Registered";


        }
    }
}