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
        int ClicksCount;
        public decimal costofmovie;
        public decimal totalamts;
        public Int64 _MovieID;
        public int numofseats;
        private MovieTableInfos _MovieTableInfos;
        private List<MovieSeatStatus> _SeatSatus;
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
                    string decrypted_movie_id = MovieTableInfos.Decrypt(Request.QueryString["MovieDetails"]).ToString();    //aquiring movie name from url if it's from HomePage
                    decrypted_movie_id = decrypted_movie_id.Replace("?#modal", "");
                    decrypted_movie_id = decrypted_movie_id.Replace("?#modals", "");
                    decrypted_movie_id = decrypted_movie_id.Replace("?", "");
                    _MovieID = Convert.ToInt64(decrypted_movie_id);
                }
                catch (Exception ex)
                {
                    string exception = ex.Message;
                }
                _MovieTableInfos = MovieDetailsDataAccess.GetMovieDataByID(_MovieID);
                Session["moviename"] = _MovieTableInfos.MovieName;
                Session["MovieIDasParam"] = _MovieID;
                ViewState["MovieInfoData"] = _MovieTableInfos;
                _SeatSatus = MovieDetailsDataAccess.GetSeatStatusDataByMovieID(_MovieID);
                ViewState["SeatSatusInfoData"] = _SeatSatus;
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
                //Populate data into elements
                foreach (MovieSeatStatus seatsinfos in _SeatSatus)
                {
                    ddl_movie_date.Items.Add(seatsinfos.MovieDateTime.Date.ToString("dd/MM/yyyy"));
                }
            }
            else
            {
                _SeatSatus = ViewState["SeatSatusInfoData"] as List<MovieSeatStatus>;
                _MovieTableInfos = ViewState["MovieInfoData"] as MovieTableInfos;
                _MovieID = Convert.ToInt64(Session["MovieIDasParam"]);
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
            ddl_movie_date.Enabled = true;
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
            if (string.IsNullOrEmpty(ddl_movie_date.SelectedItem.ToString()) && string.IsNullOrEmpty(ddl_movie_time.SelectedItem.ToString()))
            {
                Label15.Visible = true;
                Label16.Visible = true;
            }
            else
            {
                if (Session["moviename"] != null)
                {
                    phSeatDraw.Visible = true;
                    foreach (MovieSeatStatus seatsinfos in _SeatSatus.Where(seats => seats.MovieID == _MovieID &&
                                                                                    seats.MovieDateTime.Date.ToString("dd/MM/yyyy") == ddl_movie_date.SelectedItem.ToString() &&
                                                                                    seats.MovieDateTime.ToString("HH:mm") == ddl_movie_time.SelectedItem.ToString()))
                    {
                        #region condition
                        if (seatsinfos.s1.Trim() == "A")
                        {
                            _SeatsButtonObjects[1].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[1].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[1].Enabled = false;

                        }

                        if (seatsinfos.s2.Trim() == "A")
                        {
                            _SeatsButtonObjects[2].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[2].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[2].Enabled = false;
                        }

                        if (seatsinfos.s3.Trim() == "A")
                        {
                            _SeatsButtonObjects[3].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[3].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[3].Enabled = false;
                        }

                        if (seatsinfos.s4.Trim() == "A")
                        {
                            _SeatsButtonObjects[4].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[4].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[4].Enabled = false;
                        }

                        if (seatsinfos.s5.Trim() == "A")
                        {
                            _SeatsButtonObjects[5].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[5].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[5].Enabled = false;
                        }

                        if (seatsinfos.s6.Trim() == "A")
                        {
                            _SeatsButtonObjects[6].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[6].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[6].Enabled = false;
                        }

                        if (seatsinfos.s7.Trim() == "A")
                        {
                            _SeatsButtonObjects[7].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[7].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[7].Enabled = false;
                        }

                        if (seatsinfos.s8.Trim() == "A")
                        {
                            _SeatsButtonObjects[8].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[8].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[8].Enabled = false;
                        }

                        if (seatsinfos.s9.Trim() == "A")
                        {
                            _SeatsButtonObjects[9].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[9].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[9].Enabled = false;
                        }

                        if (seatsinfos.s10.Trim() == "A")
                        {
                            _SeatsButtonObjects[10].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[10].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[10].Enabled = false;
                        }

                        if (seatsinfos.s11.Trim() == "A")
                        {
                            _SeatsButtonObjects[11].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[11].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[11].Enabled = false;
                        }

                        if (seatsinfos.s12.Trim() == "A")
                        {
                            _SeatsButtonObjects[12].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[12].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[12].Enabled = false;
                        }

                        if (seatsinfos.s13.Trim() == "A")
                        {
                            _SeatsButtonObjects[13].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[13].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[13].Enabled = false;
                        }

                        if (seatsinfos.s14.Trim() == "A")
                        {
                            _SeatsButtonObjects[14].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[14].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[14].Enabled = false;
                        }

                        if (seatsinfos.s15.Trim() == "A")
                        {
                            _SeatsButtonObjects[15].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[15].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[15].Enabled = false;
                        }

                        if (seatsinfos.s16.Trim() == "A")
                        {
                            _SeatsButtonObjects[16].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[16].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[16].Enabled = false;
                        }

                        if (seatsinfos.s17.Trim() == "A")
                        {
                            _SeatsButtonObjects[17].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[17].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[17].Enabled = false;
                        }

                        if (seatsinfos.s18.Trim() == "A")
                        {
                            _SeatsButtonObjects[18].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[18].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[18].Enabled = false;
                        }

                        if (seatsinfos.s19.Trim() == "A")
                        {
                            _SeatsButtonObjects[19].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[19].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[19].Enabled = false;
                        }

                        if (seatsinfos.s20.Trim() == "A")
                        {
                            _SeatsButtonObjects[20].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[20].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[20].Enabled = false;
                        }

                        if (seatsinfos.s21.Trim() == "A")
                        {
                            _SeatsButtonObjects[21].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[21].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[21].Enabled = false;
                        }

                        if (seatsinfos.s22.Trim() == "A")
                        {
                            _SeatsButtonObjects[22].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[22].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[22].Enabled = false;
                        }

                        if (seatsinfos.s23.Trim() == "A")
                        {
                            _SeatsButtonObjects[23].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[23].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[23].Enabled = false;
                        }

                        if (seatsinfos.s24.Trim() == "A")
                        {
                            _SeatsButtonObjects[24].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[24].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[24].Enabled = false;
                        }

                        if (seatsinfos.s25.Trim() == "A")
                        {
                            _SeatsButtonObjects[25].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[25].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[25].Enabled = false;
                        }

                        if (seatsinfos.s26.Trim() == "A")
                        {
                            _SeatsButtonObjects[26].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[26].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[26].Enabled = false;
                        }

                        if (seatsinfos.s27.Trim() == "A")
                        {
                            _SeatsButtonObjects[27].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[27].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[27].Enabled = false;
                        }

                        if (seatsinfos.s28.Trim() == "A")
                        {
                            _SeatsButtonObjects[28].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[28].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[28].Enabled = false;
                        }

                        if (seatsinfos.s29.Trim() == "A")
                        {
                            _SeatsButtonObjects[29].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[29].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[29].Enabled = false;
                        }

                        if (seatsinfos.s30.Trim() == "A")
                        {
                            _SeatsButtonObjects[30].BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            _SeatsButtonObjects[30].BackColor = System.Drawing.Color.Gray;
                            _SeatsButtonObjects[30].Enabled = false;
                        }
                        #endregion
                    }
                }
                else
                {
                    Response.Write("<script>alert('Movie is not selected')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=movielist.aspx");
                }
            }
        }
        private void Totalamt()
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
        protected void BookSeats_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)//checking login or not
            {
                //yet to update to database all the information.
                String updatedata = "Update MovieSeatStatus set " + f + " ='B' where name='" + kk + "'";
                SqlCommand cmd = new SqlCommand(updatedata, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('" + totalamts + "')</script>");
                string user = Session["user"].ToString();
                SqlCommand hist = new SqlCommand("insert into bookedinfo values('" + user + "','" + totaltxt.Text + "','" + numofseats + "','" + Session["moviename"].ToString() + "')", con);
                con.Open();
                hist.ExecuteNonQuery();
                con.Close();
                Response.Redirect("booked.aspx?#modal");
            }
            else
            {
                Response.Write("<script>window.location.href='MovieDetails.aspx?param=" + Session["moviename"].ToString() + "?#modal';</script>");//login popup
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
            btnBookSeats.Enabled = false;
            if (ddl_movie_date.SelectedItem.ToString() == "Choose Date")
            {
                ddl_movie_time.Enabled = false;
                Label15.Visible = true;
            }
            else
            {
                ddl_movie_time.Enabled = true;
                foreach (MovieSeatStatus seatsinfos in _SeatSatus.Where(seats => seats.MovieID == _MovieID && seats.MovieDateTime.Date.ToString("dd/MM/yyyy") == ddl_movie_date.SelectedItem.ToString()))
                {
                    ddl_movie_time.Items.Add(seatsinfos.MovieDateTime.ToString("HH:mm"));
                }
            }
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_movie_time.SelectedItem.ToString() == "Choose Time")
            {
                Label16.Visible = true;
            }
            else
            {
                Alreadybooked();
            }
        }

        #region Seats
        protected void s1_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[1].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[1].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[1].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s2_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[2].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[2].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                
            }
            else
            {
                _SeatsButtonObjects[2].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s3_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[3].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[3].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[3].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s4_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[4].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[4].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[4].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s5_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[5].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[5].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[5].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }

        }

        protected void s6_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[6].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[6].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[6].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s7_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[7].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[7].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[7].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s8_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[8].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[8].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[8].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s9_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[9].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[9].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[9].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s10_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[10].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[10].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                
            }
            else
            {
                _SeatsButtonObjects[10].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s11_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[11].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[11].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[11].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s12_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[12].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[12].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[12].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s13_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[13].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[13].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[13].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s14_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[14].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[14].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[14].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s15_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[15].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[15].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[15].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s16_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[16].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[16].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
                ViewState["Clicks"] = ClicksCount;
                Totalamt();
            }
            else
            {
                _SeatsButtonObjects[16].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s17_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[17].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[17].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[17].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s18_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[18].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[18].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[18].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s19_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[19].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[19].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[19].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s20_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[20].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[20].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[20].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s21_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[21].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[21].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[21].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s22_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[22].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[22].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[22].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s23_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[23].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[23].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[23].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s24_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[24].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[24].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[24].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s25_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[25].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[25].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[25].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s26_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[26].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[26].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[26].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s27_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[27].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[27].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[27].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s28_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[28].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[28].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[28].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s29_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[29].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[29].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[29].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        protected void s30_Click(object sender, EventArgs e)
        {
            if (_SeatsButtonObjects[30].BackColor == System.Drawing.Color.Green)
            {
                _SeatsButtonObjects[30].BackColor = System.Drawing.Color.Yellow;
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            else
            {
                _SeatsButtonObjects[30].BackColor = System.Drawing.Color.Green;
                ClicksCount = (int)ViewState["Clicks"] - 1;
            }
            ViewState["Clicks"] = ClicksCount;
            Totalamt();
        }

        #endregion

    }
}