using Movie_Ticket_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Movie_Ticket_Management
{
    public partial class MovieDetails : Page
    {
        public string moviedate;
        public string movietime;
        static int[] bookedseat;
        static int[] tempbookseat;
        int ClicksCount;
        public decimal costofmovie;
        public decimal totalamts;
        public string param_movie_id;
        public int numofseats;
        private MovieTableInfos _MovieTableInfos;
        private List<MovieSeatSatus> _SeatSatus;
        Dictionary<int, Button> _SeatsButtonObjects;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            if (!IsPostBack)
            {
                if (Session["user"] != null)//check user
                {
                    welcomeuser.Visible = true;
                    welcomeuser.Text = "Welcome " + Session["user"].ToString();
                    signinbtn.Visible = false;
                    btnBeforeOk.Visible = true;
                    PlaceHolder2.Visible = true;
                }
                try
                {
                    param_movie_id = Request.QueryString["MovieDetails"];//aquiring movie name from url if it's from HomePage
                    param_movie_id = param_movie_id.Replace("?#modal", "");
                    param_movie_id = param_movie_id.Replace("?#modals", "");
                    param_movie_id = param_movie_id.Replace("?", "");
                }
                catch (Exception ex)
                {
                    string exception = ex.Message;
                }
                _MovieTableInfos = MovieDetailsDataAccess.GetMovieDataByID(MovieTableInfos.Decrypt(param_movie_id));
                Session["moviename"] = _MovieTableInfos.MovieName;
                Session["MovieIDasParam"] = param_movie_id;
                ViewState["MovieInfoData"] = _MovieTableInfos;


                //if (Session["user"] != null)//checking login or not
                //{
                //    if (Session["pay"].ToString() == "no")
                //    {
                //        Response.Write("<script>window.location.href='MovieDetails.aspx?MovieDetails=" + Session["MovieIDasParam"].ToString() + "?#modals';</script>");//payment popup
                //    }
                //}
                //else
                //{
                //    Response.Write("<script>window.location.href='MovieDetails.aspx?MovieDetails=" + Session["MovieIDasParam"].ToString() + "?#modal';</script>");//login popup
                //}

                if (ViewState["Clicks"] == null)
                {
                    ViewState["Clicks"] = 0;
                }

                _SeatSatus = MovieDetailsDataAccess.GetSeatStatusDataByMovieID(MovieTableInfos.Decrypt(param_movie_id));
                ViewState["SeatSatusInfoData"] = _SeatSatus;
            }
            else
            {
                _SeatSatus = (List<MovieSeatSatus>)ViewState["SeatSatusInfoData"];
                _MovieTableInfos = (MovieTableInfos)ViewState["MovieInfoData"];
                param_movie_id = (string)Session["MovieIDasParam"];
            }

            //Populate data into elements
            foreach (MovieSeatSatus seatsinfos in _SeatSatus)
            {
                DropDownList1.Items.Add(seatsinfos.MovieDateTime.Date.ToString("dd/MM/yyyy"));
            }
            movienamelabel.Text = _MovieTableInfos.MovieName;
            herolabel.Text = _MovieTableInfos.HeroName;
            heroinlabel.Text = _MovieTableInfos.HeroinName;
            directorlabel.Text = _MovieTableInfos.DirectorName;
            storylabel.Text = _MovieTableInfos.StoryWriterName;
            generbtn.Text = _MovieTableInfos.Genre;
            costofmovie = _MovieTableInfos.Cost;
            costlab.Text = costofmovie.ToString();
            ratinglabel.Text = _MovieTableInfos.Rating + "/ 5";
            durlab.Text = _MovieTableInfos.Duration.ToString();
            movieimg.ImageUrl = "data:image/png;base64," + _MovieTableInfos.ImageData;
        }
        private void Initialize()
        {
            bookedseat = new int[31];
            tempbookseat = Enumerable.Repeat(0, 31).ToArray();
            DropDownList1.Enabled = true;
            _SeatsButtonObjects = new Dictionary<int, Button>
            {
                { 1, s1 },
                { 2, s2 },
                { 3, s3 },
                { 4, s4 },
                { 5, s5 },
                { 6, s6 },
                { 7, s7 },
                { 8, s8 },
                { 9, s9 },
                { 10, s10 },
                { 11, s11 },
                { 12, s12 },
                { 13, s13 },
                { 14, s14 },
                { 15, s15 },
                { 16, s16 },
                { 17, s17 },
                { 18, s18 },
                { 19, s19 },
                { 20, s20 },
                { 21, s21 },
                { 22, s22 },
                { 23, s23 },
                { 24, s24 },
                { 25, s25 },
                { 26, s26 },
                { 27, s27 },
                { 28, s28 },
                { 29, s29 },
                { 30, s30 },

            };
        }
        //display of booking seats
        private void Alreadybooked()
        {
            int i = 0, j = 0;
            if (Session["date"] == null && movietime == "")
            {
                Label15.Visible = true;
                Label16.Visible = true;
            }
            else
            {
                if (Session["moviename"] != null)
                {
                    string nameofmovie = Session["moviename"].ToString();
                    string myquery = "select * from Seatstatus where name='" + nameofmovie + "' AND date='" + Session["date"].ToString() + "' AND time='" + movietime + "'";
                    SqlCommand cmd = new SqlCommand(myquery, con);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();

                    foreach (MovieSeatSatus seatsinfos in _SeatSatus.Where(seats => seats.MovieID == MovieTableInfos.Decrypt(param_movie_id) &&
                                                                                    seats.MovieDateTime.Date.ToString("dd/MM/yyyy") == moviedate &&
                                                                                    seats.MovieDateTime.ToString("HH:mm") == movietime))
                    {
                        for (i = 2; i <= 31; i += 1, j += 1)
                        {
                            string status = rd.GetString(i).Replace(" ", "");
                            if (status == "B")
                            {
                                bookedseat[j] = 1;
                                if (i == 2)
                                {
                                    s1.BackColor = System.Drawing.Color.Red;
                                    s1.Enabled = false;
                                }
                                if (i == 3)
                                {
                                    s2.BackColor = System.Drawing.Color.Red;
                                    s2.Enabled = false;
                                }
                                if (i == 4)
                                {
                                    s3.BackColor = System.Drawing.Color.Red;
                                    s3.Enabled = false;
                                }
                                if (i == 5)
                                {
                                    s4.BackColor = System.Drawing.Color.Red;
                                    s4.Enabled = false;
                                }
                                if (i == 6)
                                {
                                    s5.BackColor = System.Drawing.Color.Red;
                                    s5.Enabled = false;
                                }
                                if (i == 7)
                                {
                                    s6.BackColor = System.Drawing.Color.Red;
                                    s6.Enabled = false;
                                }
                                if (i == 8)
                                {
                                    s7.BackColor = System.Drawing.Color.Red;
                                    s7.Enabled = false;
                                }
                                if (i == 9)
                                {
                                    s8.BackColor = System.Drawing.Color.Red;
                                    s8.Enabled = false;
                                }
                                if (i == 10)
                                {
                                    s9.BackColor = System.Drawing.Color.Red;
                                    s9.Enabled = false;
                                }
                                if (i == 11)
                                {
                                    s10.BackColor = System.Drawing.Color.Red;
                                    s10.Enabled = false;
                                }
                                if (i == 12)
                                {
                                    s11.BackColor = System.Drawing.Color.Red;
                                    s11.Enabled = false;
                                }
                                if (i == 13)
                                {
                                    s12.BackColor = System.Drawing.Color.Red;
                                    s12.Enabled = false;
                                }
                                if (i == 14)
                                {
                                    s13.BackColor = System.Drawing.Color.Red;
                                    s13.Enabled = false;
                                }
                                if (i == 15)
                                {
                                    s14.BackColor = System.Drawing.Color.Red;
                                    s14.Enabled = false;
                                }
                                if (i == 16)
                                {
                                    s15.BackColor = System.Drawing.Color.Red;
                                    s15.Enabled = false;
                                }
                                if (i == 17)
                                {
                                    s16.BackColor = System.Drawing.Color.Red;
                                    s16.Enabled = false;
                                }
                                if (i == 18)
                                {
                                    s17.BackColor = System.Drawing.Color.Red;
                                    s17.Enabled = false;
                                }
                                if (i == 19)
                                {
                                    s18.BackColor = System.Drawing.Color.Red;
                                    s18.Enabled = false;
                                }
                                if (i == 20)
                                {
                                    s19.BackColor = System.Drawing.Color.Red;
                                    s19.Enabled = false;
                                }
                                if (i == 21)
                                {
                                    s20.BackColor = System.Drawing.Color.Red;
                                    s20.Enabled = false;
                                }
                                if (i == 22)
                                {
                                    s21.BackColor = System.Drawing.Color.Red;
                                    s21.Enabled = false;
                                }
                                if (i == 23)
                                {
                                    s22.BackColor = System.Drawing.Color.Red;
                                    s22.Enabled = false;
                                }
                                if (i == 24)
                                {
                                    s23.BackColor = System.Drawing.Color.Red;
                                    s23.Enabled = false;
                                }
                                if (i == 25)
                                {
                                    s24.BackColor = System.Drawing.Color.Red;
                                    s24.Enabled = false;
                                }
                                if (i == 26)
                                {
                                    s25.BackColor = System.Drawing.Color.Red;
                                    s25.Enabled = false;
                                }
                                if (i == 27)
                                {
                                    s26.BackColor = System.Drawing.Color.Red;
                                    s26.Enabled = false;
                                }
                                if (i == 28)
                                {
                                    s27.BackColor = System.Drawing.Color.Red;
                                    s27.Enabled = false;
                                }
                                if (i == 29)
                                {
                                    s28.BackColor = System.Drawing.Color.Red;
                                    s28.Enabled = false;
                                }
                                if (i == 30)
                                {
                                    s29.BackColor = System.Drawing.Color.Red;
                                    s29.Enabled = false;
                                }
                                if (i == 31)
                                {
                                    s30.BackColor = System.Drawing.Color.Red;
                                    s30.Enabled = false;
                                }
                                bookbtn.Enabled = true;
                                PlaceHolder10.Visible = true;
                            }
                            if (status == "A")
                            {
                                bookedseat[j] = 0;
                                if (i == 2)
                                {
                                    s1.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 3)
                                {
                                    s2.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 4)
                                {
                                    s3.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 5)
                                {
                                    s4.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 6)
                                {
                                    s5.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 7)
                                {
                                    s6.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 8)
                                {
                                    s7.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 9)
                                {
                                    s8.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 10)
                                {
                                    s9.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 11)
                                {
                                    s10.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 12)
                                {
                                    s11.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 13)
                                {
                                    s12.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 14)
                                {
                                    s13.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 15)
                                {
                                    s14.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 16)
                                {
                                    s15.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 17)
                                {
                                    s16.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 18)
                                {
                                    s17.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 19)
                                {
                                    s18.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 20)
                                {
                                    s19.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 21)
                                {
                                    s20.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 22)
                                {
                                    s21.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 23)
                                {
                                    s22.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 24)
                                {
                                    s23.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 25)
                                {
                                    s24.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 26)
                                {
                                    s25.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 27)
                                {
                                    s26.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 28)
                                {
                                    s27.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 29)
                                {
                                    s28.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 30)
                                {
                                    s29.BackColor = System.Drawing.Color.Gray;
                                }
                                if (i == 31)
                                {
                                    s30.BackColor = System.Drawing.Color.Gray;
                                }
                            }
                        }
                    }
                    con.Close();
                    rd.Close();

                }
                else
                {
                    Response.Write("<script>alert('Movie is not selected')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=movielist.aspx");
                }
            }
        }
        private void totalamt()
        {
            int click = (int)ViewState["Clicks"];
            totalamts = click * costofmovie;
            totaltxt.Text = totalamts.ToString();
        }
        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            if (searchtxt.Text != "")
            {
                string movien = "select count(*) from movielist where Name='" + searchtxt.Text + "'";
                SqlCommand cmd = new SqlCommand(movien, con);
                con.Open();
                int check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                con.Close();
                if (check == 1)
                {
                    Session["moviename"] = searchtxt.Text;
                    Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + searchtxt.Text + "';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Movie does not exist in database,please search for another movie')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=movieinfo.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Enter some text before search!')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=movieinfo.aspx");
            }
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "';</script>");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)//book button
        {
            int i, ccs = 0;
            for (i = 0; i <= 30; i++)
            {
                if (tempbookseat[i] == 1)
                {
                    ccs += 1;
                }
            }
            if (ccs > 0)//checking seat is selected or not
            {
                if (Session["user"] != null)//checking login or not
                {
                    if (Session["pay"].ToString() == "yes")
                    {
                        for (i = 0; i <= 30; i++)
                        {
                            if (tempbookseat[i] == 1)
                            {
                                numofseats += 1;
                                string f = "s" + i.ToString();
                                string kk = Session["moviename"].ToString();
                                String updatedata = "Update SeatStatus set " + f + " ='B' where name='" + kk + "'";
                                SqlCommand cmd = new SqlCommand(updatedata, con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                // Session["pay"] = "no";
                            }
                        }
                        Response.Write("<script>alert('" + totalamts + "')</script>");
                        string user = Session["user"].ToString();
                        SqlCommand hist = new SqlCommand("insert into bookedinfo values('" + user + "','" + totaltxt.Text + "','" + numofseats + "','" + Session["moviename"].ToString() + "')", con);
                        con.Open();
                        hist.ExecuteNonQuery();
                        con.Close();
                        Session["tempbooking"] = tempbookseat;
                        Response.Redirect("booked.aspx?#modal");
                    }
                    else
                    {

                        Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");//payment popup
                    }
                }
                else
                {
                    Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modal';</script>");//login popup
                }
            }
            else
            {
                Label14.Visible = true;
            }
        }
        protected void log_Click(object sender, EventArgs e)
        {
            if (user.Text != "" && pass.Text != "")
            {

                int temp = 0;
                String checkq = "select count(*) from register where Username='" + user.Text + "'";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(checkq, con);
                temp = Convert.ToInt32(cmd1.ExecuteScalar().ToString().Replace(" ", ""));
                con.Close();
                if (temp == 1)
                {
                    con.Open();
                    String checkidpass = "select password from register where Username='" + user.Text + "'";
                    SqlCommand cmdidpass = new SqlCommand(checkidpass, con);
                    String userpass = cmdidpass.ExecuteScalar().ToString().Replace(" ", "");
                    con.Close();
                    if (userpass == pass.Text)
                    {
                        Session["user"] = user.Text;
                        Response.AddHeader("REFRESH", "0.1;URL=movieinfo.aspx?param=" + Session["moviename"].ToString() + "");
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect Username or Password')</script>");
                        Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modal';</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('Incorrect Username or Password')</script>");
                    Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modal';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill all fields')</script>");
                Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modal';</script>");
            }
        }
        protected void paybtn_Click(object sender, EventArgs e)//payment
        {
            if (cardnumtxt.Text != "" && cvvtxt.Text != "" && expmonthtxt.Text != "" && expyear.Text != "" && Nametxt.Text != "")
            {
                int mon = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                int cyear = Convert.ToInt32(expyear.Text);
                int cmon = Convert.ToInt32(expmonthtxt.Text);
                long cardno = Convert.ToInt64(cardnumtxt.Text);
                int cvvno = Convert.ToInt32(cvvtxt.Text);
                int t = 0;
                var regexItem = new Regex("@|!#$%&/()=?»«@£§€{}.-;'<>_,[1-9]");
                if (System.Text.RegularExpressions.Regex.IsMatch(Nametxt.Text, "^[a-zA-Z\x20]+$"))
                {
                    if (cmon > 0 && cyear > 0)
                    {
                        t = 1;
                    }
                    if (cyear >= year && t == 1 && cmon <= 12)
                    {
                        if (cardnumtxt.Text.Length == 12 && cardno >= 0)
                        {
                            if (cvvtxt.Text.Length == 3 && cvvno >= 0)
                            {
                                Session["pay"] = "yes";
                                string user = Session["user"].ToString();
                                SqlCommand cardinfo = new SqlCommand("insert into cardinfo values('" + user + "','" + cardnumtxt.Text + "','" + Nametxt.Text + "','" + expmonthtxt.Text + "','" + expyear.Text + "','" + cvvtxt.Text + "')", con);
                                con.Open();
                                cardinfo.ExecuteNonQuery();
                                con.Close();
                                Response.AddHeader("REFRESH", "0.1;URL=movieinfo.aspx?param=" + Session["moviename"].ToString() + "");

                            }
                            else
                            {
                                Response.Write("<script>alert('Invalid CVV length')</script>");
                                Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid card number')</script>");
                            Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Incorrect card expiry')</script>");
                        Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter Correct Owner Name')</script>");
                    Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill all fields')</script>");
                Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modals';</script>");
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bookbtn.Enabled = false;
            string a = DropDownList1.SelectedItem.ToString();
            if (a == "Choose Date")
            {
                DropDownList2.Enabled = false;
                Label15.Visible = true;
            }
            else
            {
                DropDownList2.Enabled = true;
                moviedate = DropDownList1.SelectedItem.ToString();
                Session["date"] = moviedate;

                foreach (MovieSeatSatus seatsinfos in _SeatSatus.Where(seats => seats.MovieID == MovieTableInfos.Decrypt(param_movie_id) && seats.MovieDateTime.Date.ToString("dd/MM/yyyy") == moviedate))
                {
                    DropDownList2.Items.Add(seatsinfos.MovieDateTime.ToString("HH:mm"));
                }
            }
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = DropDownList2.SelectedItem.ToString();
            if (a == "Choose Time")
            {
                Label16.Visible = true;
            }
            else
            {
                movietime = DropDownList2.SelectedItem.ToString();
                Alreadybooked();
            }
        }

        #region Seats
        protected void s1_Click(object sender, EventArgs e)
        {
            if (tempbookseat[1] == 0)
            {
                s1.BackColor = System.Drawing.Color.Green;
                tempbookseat[1] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s1.BackColor = System.Drawing.Color.Blue;
                tempbookseat[1] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s2_Click(object sender, EventArgs e)
        {
            if (tempbookseat[2] == 0)
            {
                s2.BackColor = System.Drawing.Color.Green;
                tempbookseat[2] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s2.BackColor = System.Drawing.Color.Gray;
                tempbookseat[2] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s3_Click(object sender, EventArgs e)
        {
            if (tempbookseat[3] == 0)
            {
                s3.BackColor = System.Drawing.Color.Green;
                tempbookseat[3] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s3.BackColor = System.Drawing.Color.Gray;
                tempbookseat[3] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s4_Click(object sender, EventArgs e)
        {
            if (tempbookseat[4] == 0)
            {
                s4.BackColor = System.Drawing.Color.Green;
                tempbookseat[4] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s4.BackColor = System.Drawing.Color.Gray;
                tempbookseat[4] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s5_Click(object sender, EventArgs e)
        {
            if (tempbookseat[5] == 0)
            {
                s5.BackColor = System.Drawing.Color.Green;
                tempbookseat[5] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s5.BackColor = System.Drawing.Color.Gray;
                tempbookseat[5] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s6_Click(object sender, EventArgs e)
        {
            if (tempbookseat[6] == 0)
            {
                s6.BackColor = System.Drawing.Color.Green;
                tempbookseat[6] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s6.BackColor = System.Drawing.Color.Gray;
                tempbookseat[6] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s7_Click(object sender, EventArgs e)
        {
            if (tempbookseat[7] == 0)
            {
                s7.BackColor = System.Drawing.Color.Green;
                tempbookseat[7] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s7.BackColor = System.Drawing.Color.Gray;
                tempbookseat[7] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s8_Click(object sender, EventArgs e)
        {
            if (tempbookseat[8] == 0)
            {
                s8.BackColor = System.Drawing.Color.Green;
                tempbookseat[8] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s8.BackColor = System.Drawing.Color.Gray;
                tempbookseat[8] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s9_Click(object sender, EventArgs e)
        {
            if (tempbookseat[9] == 0)
            {
                s9.BackColor = System.Drawing.Color.Green;
                tempbookseat[9] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s9.BackColor = System.Drawing.Color.Gray;
                tempbookseat[9] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s10_Click(object sender, EventArgs e)
        {
            if (tempbookseat[10] == 0)
            {
                s10.BackColor = System.Drawing.Color.Green;
                tempbookseat[10] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s10.BackColor = System.Drawing.Color.Gray;
                tempbookseat[10] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s11_Click(object sender, EventArgs e)
        {
            if (tempbookseat[11] == 0)
            {
                s11.BackColor = System.Drawing.Color.Green;
                tempbookseat[11] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s11.BackColor = System.Drawing.Color.Gray;
                tempbookseat[11] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s12_Click(object sender, EventArgs e)
        {
            if (tempbookseat[12] == 0)
            {
                s12.BackColor = System.Drawing.Color.Green;
                tempbookseat[12] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s12.BackColor = System.Drawing.Color.Gray;
                tempbookseat[12] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s13_Click(object sender, EventArgs e)
        {
            if (tempbookseat[13] == 0)
            {
                s13.BackColor = System.Drawing.Color.Green;
                tempbookseat[13] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s13.BackColor = System.Drawing.Color.Gray;
                tempbookseat[13] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s14_Click(object sender, EventArgs e)
        {
            if (tempbookseat[14] == 0)
            {
                s14.BackColor = System.Drawing.Color.Green;
                tempbookseat[14] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s14.BackColor = System.Drawing.Color.Gray;
                tempbookseat[14] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s15_Click(object sender, EventArgs e)
        {
            if (tempbookseat[15] == 0)
            {
                s15.BackColor = System.Drawing.Color.Green;
                tempbookseat[15] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s15.BackColor = System.Drawing.Color.Gray;
                tempbookseat[15] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s16_Click(object sender, EventArgs e)
        {
            if (tempbookseat[16] == 0)
            {
                s16.BackColor = System.Drawing.Color.Green;
                tempbookseat[16] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s16.BackColor = System.Drawing.Color.Gray;
                tempbookseat[16] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s17_Click(object sender, EventArgs e)
        {
            if (tempbookseat[17] == 0)
            {
                s17.BackColor = System.Drawing.Color.Green;
                tempbookseat[17] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s17.BackColor = System.Drawing.Color.Gray;
                tempbookseat[17] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s18_Click(object sender, EventArgs e)
        {
            if (tempbookseat[18] == 0)
            {
                s18.BackColor = System.Drawing.Color.Green;
                tempbookseat[18] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s18.BackColor = System.Drawing.Color.Gray;
                tempbookseat[18] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s19_Click(object sender, EventArgs e)
        {
            if (tempbookseat[19] == 0)
            {
                s19.BackColor = System.Drawing.Color.Green;
                tempbookseat[19] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s19.BackColor = System.Drawing.Color.Gray;
                tempbookseat[19] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s20_Click(object sender, EventArgs e)
        {
            if (tempbookseat[20] == 0)
            {
                s20.BackColor = System.Drawing.Color.Green;
                tempbookseat[20] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s20.BackColor = System.Drawing.Color.Gray;
                tempbookseat[20] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s21_Click(object sender, EventArgs e)
        {
            if (tempbookseat[21] == 0)
            {
                s21.BackColor = System.Drawing.Color.Green;
                tempbookseat[21] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s21.BackColor = System.Drawing.Color.Gray;
                tempbookseat[21] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s22_Click(object sender, EventArgs e)
        {
            if (tempbookseat[22] == 0)
            {
                s22.BackColor = System.Drawing.Color.Green;
                tempbookseat[22] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s22.BackColor = System.Drawing.Color.Gray;
                tempbookseat[22] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s23_Click(object sender, EventArgs e)
        {
            if (tempbookseat[23] == 0)
            {
                s23.BackColor = System.Drawing.Color.Green;
                tempbookseat[23] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s23.BackColor = System.Drawing.Color.Gray;
                tempbookseat[23] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s24_Click(object sender, EventArgs e)
        {
            if (tempbookseat[24] == 0)
            {
                s24.BackColor = System.Drawing.Color.Green;
                tempbookseat[24] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s24.BackColor = System.Drawing.Color.Gray;
                tempbookseat[24] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s25_Click(object sender, EventArgs e)
        {
            if (tempbookseat[25] == 0)
            {
                s25.BackColor = System.Drawing.Color.Green;
                tempbookseat[25] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s25.BackColor = System.Drawing.Color.Gray;
                tempbookseat[25] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s26_Click(object sender, EventArgs e)
        {
            if (tempbookseat[26] == 0)
            {
                s26.BackColor = System.Drawing.Color.Green;
                tempbookseat[26] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s26.BackColor = System.Drawing.Color.Gray;
                tempbookseat[26] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s27_Click(object sender, EventArgs e)
        {
            if (tempbookseat[27] == 0)
            {
                s27.BackColor = System.Drawing.Color.Green;
                tempbookseat[27] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s27.BackColor = System.Drawing.Color.Gray;
                tempbookseat[27] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s28_Click(object sender, EventArgs e)
        {
            if (tempbookseat[28] == 0)
            {
                s28.BackColor = System.Drawing.Color.Green;
                tempbookseat[28] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s28.BackColor = System.Drawing.Color.Gray;
                tempbookseat[28] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s29_Click(object sender, EventArgs e)
        {
            if (tempbookseat[29] == 0)
            {
                s29.BackColor = System.Drawing.Color.Green;
                tempbookseat[29] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s29.BackColor = System.Drawing.Color.Gray;
                tempbookseat[29] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }

        }

        protected void s30_Click(object sender, EventArgs e)
        {
            if (tempbookseat[30] == 0)
            {
                s30.BackColor = System.Drawing.Color.Green;
                tempbookseat[30] = 1;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
            else
            {
                s30.BackColor = System.Drawing.Color.Gray;
                tempbookseat[30] = 0;
                ClicksCount = (int)ViewState["Clicks"] - 1;
                ViewState["Clicks"] = ClicksCount;
                totalamt();
            }
        }

        #endregion

    }
}