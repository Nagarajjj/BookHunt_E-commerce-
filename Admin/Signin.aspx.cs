using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Signup
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            {
                SqlConnection con = new SqlConnection(@"Data Source=w-h44py03-0;Initial Catalog=BookHunt;Persist Security Info=True;User ID=sa;Password=admin");
                SqlCommand cmd = new SqlCommand("select * from VendorTable where VendorEmailId=@emailid and VendorPassword=@password", con);
                cmd.Parameters.AddWithValue("@emailid", txtName.Text);
                cmd.Parameters.AddWithValue("@password", txtMobile.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("AddBooks.aspx");
                }
                else
                {
                    Label3.Text = "Your username or Password is incorrect";
                    Label3.ForeColor = System.Drawing.Color.Crimson;

                }

            }
        }
    }


}
