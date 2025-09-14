using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using Movie_Ticket_Management.DataAccess;

namespace Movie_Ticket_Management
{
    public partial class logorsingup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Write("<script>alert('You have logged in already')</script");
                Response.AddHeader("REFRESH", "0.1;URL=HomePage.aspx");
            }

        }

        protected void aboutbtns_Click(object sender, EventArgs e)
        {
            Response.Redirect("abt.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void contactbtns_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }


        protected void loginbtn_Click(object sender, EventArgs e)
        {
            UserAccountInfos login_user_info = new UserAccountInfos
            {
                UserName = usernametxtbox.Text,
                EncryptedPassword =  UserAccountInfos.Encrypt(passtxtbox.Text),
            };
            bool is_user_admin = false;
            if(LoginDataAccess.IsUserAuthencication(login_user_info,out is_user_admin))
            {
                Session["user"] = usernametxtbox.Text;
                Response.Write("<script>alert('User Authenticated Successfully')</script>");
                if (is_user_admin)
                {
                    Response.Redirect("adminpage.aspx");
                }
                else
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
            else
            {

                Response.Write("<script>alert('Invalid Credentials, Please try again.')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=LoginPage.aspx");
            }
        }

        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("LoginPage.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}