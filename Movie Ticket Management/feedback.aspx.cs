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
    public partial class feedback : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["page"] = "feedback.aspx";
            Session["pay"] = "no";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
                SqlCommand cmd = new SqlCommand("select * from register where Username='" + Session["user"].ToString() + "'", conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    userlabel.Text = rd[3].ToString();
                    phonelabel.Text = rd[5].ToString();
                }
                conn.Close();
            }
            else
            {
                Response.Redirect("logorsigup.aspx");
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
                    Response.AddHeader("REFRESH", "0.1;URL=feedback.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=feedback.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("feedback.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookhistory.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=SHASHANK\\SQLEXPRESS;Database=movie;Integrated Security=SSPI");
            if (TextBox1.Text == "")
            {
                Response.Write("<script>alert('Enter some text!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=feedback.aspx");
            }
            else
            {
                string date= DateTime.Now.ToString("M/d/yyyy"); 
                var regexItem = new Regex("@|!#$%/()=?»«@£§€{}-;<>_");
                if (System.Text.RegularExpressions.Regex.IsMatch(TextBox1.Text, "^[a-zA-Z0-9\x20]+$"))
                {
                    SqlCommand cmd = new SqlCommand("insert into feedback values('"+Session["user"].ToString()+"','"+TextBox1.Text+"','"+date+"')",conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('FeedBack Successfully, Thank You for your FeedBack.')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No special characters')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=feedback.aspx");

                }
            }
        }
    }
}