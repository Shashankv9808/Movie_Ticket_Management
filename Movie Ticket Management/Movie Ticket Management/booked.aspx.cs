using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Movie_Ticket_Management
{
    public partial class booked : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server=SHASHANK\\SQLEXPRESS;Database=movie;Integrated Security=SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pay"] = "no";
            Session["page"] = "booked.aspx";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
            }
            SqlCommand cmd = new SqlCommand("select * from bookedinfo where Id=(select MAX(Id) from bookedinfo)", conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                booknum.Text = "NCB16" + rd[0];
                name.Text = rd[1].ToString();
                seatsb.Text = rd[3].ToString();
            }
            conn.Close();
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
            Response.Redirect("logorsigup.aspx");
        }
        protected void ImageButton1_Click2(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }

        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect(Session["page"].ToString());
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
                    Response.Redirect("movieinfo.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=abt.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=abt.aspx");
            }
        }

        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}