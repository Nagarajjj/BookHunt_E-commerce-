using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Signup
{
    public partial class AddBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

        }

        protected void btndlt_Click(object sender, EventArgs e)
        {

        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected void Sign_out_Click(object sender, EventArgs e)
        {
            Session.Remove("userName");
            Session.Abandon();  //remove the session variable
            Response.Redirect("Signin.aspx");//redirect to login page or some other page
        }
    }
}