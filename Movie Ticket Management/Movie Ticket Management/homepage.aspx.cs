using AjaxControlToolkit;
using Movie_Ticket_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Management
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["pay"] = "no";
            Session["page"] = "HomePage.aspx";
            if(!IsPostBack)
            {
                List<HomePageDataInfo> movieList = HomePageDataAccess.GetMovieDataList();
                MovieRepeater.DataSource = movieList;
                MovieRepeater.DataBind();
            }
            else if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
            }
        }
        protected void MovieRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)

            {
                Image movieImage = (Image)e.Item.FindControl("MovieImage");
                Literal ratingLiteral = (Literal)e.Item.FindControl("RatingLiteral");
                Literal movieNameLiteral = (Literal)e.Item.FindControl("MovieNameLiteral");

                HomePageDataInfo movieData = (HomePageDataInfo)e.Item.DataItem;

                movieImage.ImageUrl = "data:image/png;base64," + movieData.ImageData;
                ratingLiteral.Text = movieData.Rating + "/5";
                movieNameLiteral.Text = movieData.MovieName;
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
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand("select count(*) from movielist where Name='" + searchtxt.Text + "'", connection);
                    connection.Open();
                    int check = Convert.ToInt32(command.ExecuteScalar().ToString());
                    if (check == 1)
                    {
                        Session["moviename"] = searchtxt.Text;
                        Response.Write("<script>window.location.href='movieinfo.aspx?param=" + searchtxt.Text + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                        Response.AddHeader("REFRESH", "0.1;URL=HomePage.aspx");
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=HomePage.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("HomePage.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}