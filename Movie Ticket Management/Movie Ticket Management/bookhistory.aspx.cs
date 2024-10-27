using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Movie_Ticket_Management
{
    public partial class bookhistory : System.Web.UI.Page
    {
        string name, seat, price;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["pay"] = "no";
            Session["page"] = "bookhistory.aspx";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;

                SqlCommand cmd = new SqlCommand("select * from register where Username='" + Session["user"].ToString() + "'", conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    userlabel.Text = rd[3].ToString();
                    phonelabel.Text = rd[5].ToString();
                }
                conn.Close();
                
                
               
                cmd = new SqlCommand("select * from bookedinfo where Username='" + Session["user"].ToString() + "'", conn);
                conn.Open();
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    createDiv.ID = "createDiv";
                    createDiv.Attributes.Add("class", "c1");
                    name = rd[4].ToString();
                    seat = rd[3].ToString();
                    price = rd[2].ToString();
                    string Desc = "<h3>Movie Name:" + name + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No. of seats booked:" + seat + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total Amount Paid:" + price + "</h3>";
                    createDiv.InnerHtml = Desc;
                    PlaceHolder1.Controls.Add(createDiv);
                }
                
                    
                
                conn.Close();            
                PlaceHolder2.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('You haven't logged In,please log in.This will redirect to log in page.</script>");
                Response.Redirect("logorsigup.aspx");
            }
            
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect(Session["page"].ToString());
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
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
                    Response.AddHeader("REFRESH", "0.1;URL=bookhistory.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=bookhistory.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
    }
}