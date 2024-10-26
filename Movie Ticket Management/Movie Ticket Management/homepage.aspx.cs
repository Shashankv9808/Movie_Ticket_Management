using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace Movie_Ticket_Management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string a, rating;
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["pay"] = "no";
            Session["page"] = "homepage.aspx";
            if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
            }
            Image heart = new Image();
            for (int i = 1; i <= 8; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("select * from movielist where Id='" + i + "'", connection))
                    {
                        connection.Open();
                        using (SqlDataReader rd = command.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                a = rd[1].ToString();
                                rating = rd[8].ToString();
                            }
                        }
                    }

                }
                HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
                createDiv.ID = "createDiv" + i;
                createDiv.Attributes.Add("class", "c1");
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetImageById", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramId = new SqlParameter()
                    {
                        ParameterName = "@Id",
                        Value = i
                    };
                    cmd.Parameters.Add(paramId);
                    connection.Open();
                    byte[] bytes = (byte[])cmd.ExecuteScalar();
                    string strBase64 = Convert.ToBase64String(bytes);
                    string cc = "\"";
                    string imgdata = "<img style='left: 100px;height: 280px; width: 210px; right: 584px;border-radius: 13px;'src=" + cc + "data:Image/png;base64," + strBase64 + cc + ">";
                    string Desc = "<a onclick='somefunction(this);' runat ='server' style ='height: 261px; width: 210px;cursor:pointer;'name='" + a + "'>" + imgdata + "<a><a><img style='width:17px;height:17px;padding-top:17px;' src='/images/The-heart.png'></a>  " + rating + "%" + " &nbsp&nbsp&nbsp " + a + "";
                    createDiv.InnerHtml = Desc;
                    createDiv.Controls.Add(heart);
                    PlaceHolder1.Controls.Add(createDiv);
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
                SqlCommand cmd = new SqlCommand(movien, connection_string);
                connection_string.Open();
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                connection_string.Close();
                if (check == 1)
                {
                    Session["moviename"] = searchtxt.Text;
                    Response.Write("<script>window.location.href='movieinfo.aspx?param=" + searchtxt.Text + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=homepage.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=homepage.aspx");
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
    }
}