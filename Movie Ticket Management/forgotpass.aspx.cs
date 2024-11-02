using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Movie_Ticket_Management
{
    public partial class forgotpass : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Write("<script>alert('You have logged in already')</script");
                Response.AddHeader("REFRESH", "0.1;URL=home.aspx");
            }
        }

        protected void aboutbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("abt.aspx");
        }

        protected void contactbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }

        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
        }
    }
}