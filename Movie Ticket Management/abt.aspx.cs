using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Movie_Ticket_Management
{
    public partial class abt : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pay"] = "no";
            Session["page"] = "abr.aspx";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
        protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect(Session["page"].ToString());
        }

        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}