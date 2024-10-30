using Movie_Ticket_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Management
{
    public partial class WebForm1 : Page
    {
        List<MovieTableInfos> _AllMovieDetailsList = new List<MovieTableInfos>();
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["pay"] = "no";
            Session["page"] = "HomePage.aspx";
            if(!IsPostBack)
            {
                _AllMovieDetailsList = HomePageDataAccess.GetMovieDataList();
            }
            else if (Session["user"] != null)
            {
                welcomeuser.Visible = true;
                welcomeuser.Text = "Welcome " + Session["user"].ToString();
                signinbtn.Visible = false;
                btnBeforeOk.Visible = true;
                PlaceHolder2.Visible = true;
            }
            MovieRepeater.DataSource = _AllMovieDetailsList;
            MovieRepeater.DataBind();
        }
        protected void MovieRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)

            {
                Image movieImage = (Image)e.Item.FindControl("MovieImage");
                Literal ratingLiteral = (Literal)e.Item.FindControl("RatingLiteral");
                Literal movieNameLiteral = (Literal)e.Item.FindControl("MovieNameLiteral");

                MovieTableInfos movieData = (MovieTableInfos)e.Item.DataItem;

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
                MovieRepeater.DataSource = _AllMovieDetailsList.Where(movieinfo => movieinfo.MovieName.ToLower().Contains(searchtxt.Text.Trim().ToLower())).ToList();
                MovieRepeater.DataBind();
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