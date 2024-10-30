using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
namespace Movie_Ticket_Management
{
    public partial class registration : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        public char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "registration.aspx";
            if (Session["user"] != null)
            {
                Response.Write("<script>alert('You have logged in already')</script");
                Response.AddHeader("REFRESH", "0.1;URL=home.aspx");
            }
        }
        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("logorsigup.aspx");
        }

        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            if (searchtxt.Text != null)
            {
                string movien = "select count(*) from movielist where Name='" + searchtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(movien, conn);
                conn.Open();
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
                if (check == 1)
                {
                    Session["moviename"] = searchtxt.Text;
                    Response.Write("<script>window.location.href='movieinfo.aspx?param=" + searchtxt.Text + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=registration.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=registration.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("registration.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void signupbtn_Click(object sender, EventArgs e)
        {
            //code implement
            var regexItem = new Regex("@|!#$%&/()=?»«@£§€{}.-;'<>_,[1-9]");
            if (Regex.IsMatch(username.Text, "^[a-zA-Z0-9\x20]+$") && Regex.IsMatch(fnametxtbox.Text, "^[a-zA-Z\x20]+$") && Regex.IsMatch(lnametxtbox.Text, "^[a-zA-Z\x20]+$"))
            {
                string usercheck = "select count(*) from register where Username='" + username.Text + "'";
                SqlCommand usercmd = new SqlCommand(usercheck, conn);
                conn.Open();
                int existuser = (int)usercmd.ExecuteScalar();
                conn.Close();
                if (existuser == 0)        //usercheck
                {
                    string validem = Emailtxtbox.Text.Replace("@gmail.com", "");
                    string emailcheck = "select count(*) from register where email='" + validem + "'";
                    SqlCommand emailcmd = new SqlCommand(emailcheck, conn);
                    conn.Open();
                    int exist = (int)emailcmd.ExecuteScalar();
                    conn.Close();
                    if (exist == 0)      //e-mail check
                    {
                        string insert = "insert into register values('"+ username.Text + "','" + passtxt.Text + "','" + fnametxtbox.Text + "','" + lnametxtbox.Text + "','" + Phonetxtbox.Text + "','" + Emailtxtbox.Text + "')";
                        SqlCommand cmd = new SqlCommand(insert, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        //email else loop
                        Response.Write("<script>alert('E-mail id already exists in database')</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=registration.aspx");
                    }
                }
                else
                {
                    //username else loop
                    Response.Write("<script>alert('UserName is already exists in database')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=registration.aspx");
                }
            }
            else
            {
                //special char
                Response.Write("<script>alert('Special Symbols are not allowed')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=registration.aspx");
            }
        }
    }
}