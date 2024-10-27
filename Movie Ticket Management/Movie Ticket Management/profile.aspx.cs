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
    public partial class profile : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["page"] = "profile.aspx";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
                Session["slog"] = "no";
                SqlCommand cmd = new SqlCommand("select * from register where Username='" + Session["user"].ToString() + "'", conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    userlabel.Text = rd[3].ToString();
                    phonelabel.Text = rd[5].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('You haven't logged In,please log in.This will redirect to log in page.</script>");
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
                    Response.AddHeader("REFRESH", "0.1;URL=profile.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=profile.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("homepage.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }

        protected void check_btn_Click(object sender, EventArgs e)
        {
            //login
            string pass;
            string us= Session["user"].ToString();
            int temp = 0;
            String check = "select count(*) from register where Username='" + us+ "'";
            conn.Open();
            SqlCommand cmdp = new SqlCommand(check, conn);
            temp = Convert.ToInt32(cmdp.ExecuteScalar().ToString().Replace(" ", ""));
            conn.Close();
            String checkp = "select password from register where Username='" + us + "'";
            conn.Open();
            SqlCommand cmdpp = new SqlCommand(checkp, conn);
            pass = cmdpp.ExecuteScalar().ToString();
            conn.Close();
            if (temp!=0 && pass==txt_passcom.Text)
            {
                txt_passcom.Visible = false;
                PlaceHolder1.Visible = true;
                Session["slog"] = "yes";
                Label6.Visible = false;
                Label10.Visible = false;
                update_btn.Enabled = true;
                
            }
            else
            {
                Response.Write("<script>alert('Incorrect Passowrd')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=profile.aspx");
            }
            check_btn.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookhistory.aspx");
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            if(Session["slog"].ToString()=="yes")
            {
                SqlCommand checkman = new SqlCommand("select * from register where Username='" + Session["user"].ToString() + "'", conn);

                SqlCommand upd = new SqlCommand("update register set fname='" + txt_firstname.Text + "',lname='" + txt_lastname.Text + "',phone='" + txt_phone.Text + "',email='" + txt_email + "'", conn);
            }
            else
            {
                Label9.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            SqlCommand del = new SqlCommand("delete register where Username='" + Session["user"].ToString() + "'",conn);
            conn.Open();
            del.ExecuteNonQuery();
            Session["user"] = null;
            Response.Write("<script>alert('Your account has been deleted successfully')</script>");
            Response.AddHeader("REFRESH", "0.1;URL=homepage.aspx");
            conn.Close();
            
        }

        protected void txt_currpass_TextChanged(object sender, EventArgs e)
        {
            string d;
            SqlCommand cmd = new SqlCommand("select password from register where Username='" + Session["user"].ToString() + "'", conn);
            conn.Open();
            d = cmd.ExecuteScalar().ToString();
            conn.Close();
            if(d==txt_currpass.Text)
            {
                txt_update_pass.Enabled = true;
                txt_update_comfpass.Enabled = true;
                Label11.Visible = false;
                txt_currpass.Enabled = false;
                change_btn.Visible = true;
                Button2.Visible = false;
            }
            else
            {
                Label11.Visible = true;
            }
        }

        protected void change_btn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update register set password='" + txt_update_pass.Text + "' where Username='" + Session["user"].ToString() + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Label14.Visible = true;
            PlaceHolder1.Visible = false;
            txt_passcom.Visible = true;
            check_btn.Visible = true;
            Session["slog"] = "no";
        }
    }
}
