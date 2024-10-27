using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Movie_Ticket_Management
{
    public partial class logorsingup : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Write("<script>alert('You have logged in already')</script");
                Response.AddHeader("REFRESH", "0.1;URL=homepage.aspx");
            }

        }

        protected void aboutbtns_Click(object sender, EventArgs e)
        {
            Response.Redirect("abt.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }

        protected void contactbtns_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }


        protected void loginbtn_Click(object sender, EventArgs e)
        {
            int temp = 0;
            String check = "select count(*) from admin where id='" + usernametxtbox.Text + "'";
            conn.Open();
            SqlCommand cmdp = new SqlCommand(check, conn);
            temp = Convert.ToInt32(cmdp.ExecuteScalar().ToString().Replace(" ", ""));
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                String checkadminpass = "select pass from admin where id='" + usernametxtbox.Text + "'";
                SqlCommand cmdadminpass = new SqlCommand(checkadminpass, conn);
                String adminpass = cmdadminpass.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                if (adminpass == passtxtbox.Text)
                {
                    string red= Session["page"].ToString();
                    Response.Write("<script>alert('Password is correct')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=adminpage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Enter correct password')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=logorsigup.aspx");
                }

            }
            else
            {
                String checkq = "select count(*) from register where Username='" + usernametxtbox.Text + "'";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(checkq, conn);
                temp = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
                conn.Close();
                if (temp == 1)
                {
                    conn.Open();
                    String checkidpass = "select password from register where Username='" + usernametxtbox.Text + "'";
                    SqlCommand cmdidpass = new SqlCommand(checkidpass, conn);
                    String userpass = cmdidpass.ExecuteScalar().ToString().Replace(" ", "");
                    conn.Close();
                    if (userpass == passtxtbox.Text)
                    {
                        Session["user"] = usernametxtbox.Text;
                        Response.Write("<script>alert('Password is correct')</script>");
                        Response.AddHeader("REFRESH", "0.1;URL='"+Session["page"].ToString()+"'");
                    }
                    else
                    {
                        Response.Write("<script>alert('Enter correct password')</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=logorsigup.aspx");
                    }

                }
                else
                {
                    Response.Write("<script>alert(' Enter valid email id')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=logorsigup.aspx");
                }
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
                    Response.Write("<script>window.location.href='movieinfo.aspx?param=" + searchtxt.Text+"';</script>");
                    
                }
                else
                {
                    Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=logorsigup.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=logorsigup.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("logorsigup.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}