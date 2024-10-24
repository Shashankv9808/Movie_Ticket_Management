using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Movie_Ticket_Management
{
    public partial class addmovie : System.Web.UI.Page
    {
        public char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',',','.',';',':','}','{','-','=','!','@','#','$','%','^','&','*','(',')','_','+','*','|' };
        SqlConnection conn = new SqlConnection("Server=SHASHANK\\SQLEXPRESS;Database=movie;Integrated Security=SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Visible = false;
                hyperlink.Visible = false;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int temp,tempo,d=1,tel=0,timetell=0;
            string nameofimg = "select count(*) from tblImages where Name='"+nametxt.Text+"'";
            SqlCommand checkn = new SqlCommand(nameofimg, conn);
            conn.Open();
            temp = Convert.ToInt32(checkn.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 0)//new movie
            {
                tempo = Convert.ToInt32(ratingtxt.Text);
                int f = Convert.ToInt32(costtxt.Text);
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int fileSize = postedFile.ContentLength;
                var regexItem = new Regex("@|!#$%&/()=?»«@£§€{}.-;'<>_,[1-9]");
                int dur = Convert.ToInt32(durationtxt.Text);
                if (System.Text.RegularExpressions.Regex.IsMatch(nametxt.Text, "^[a-zA-Z0-9\x20]+$") && System.Text.RegularExpressions.Regex.IsMatch(directortxt.Text, "^[a-zA-Z\x20]+$") && System.Text.RegularExpressions.Regex.IsMatch(genertxt.Text, "^[a-zA-Z\x20]+$") && System.Text.RegularExpressions.Regex.IsMatch(storytxt.Text, "^[a-zA-Z\x20]+$") && System.Text.RegularExpressions.Regex.IsMatch(herotxt.Text, "^[a-zA-Z\x20]+$") && System.Text.RegularExpressions.Regex.IsMatch(herointxt.Text, "^[a-zA-Z\x20]+$"))
                {
                    d = 0;
                }
                try
                {
                    string asa = TextBox7.Text;
                    var parameterDate = DateTime.ParseExact(asa, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    var todaysDate = DateTime.Today;

                    if (parameterDate <= todaysDate)
                    {
                        timetell = 1;
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Enter date in correct format')</script> ");

                }
                if (TextBox7.Text == "" || System.Text.RegularExpressions.Regex.IsMatch(TextBox7.Text, "^[a-zA-Z\x20]+$") || timetell == 0)
                {
                    Label29.Visible = true;
                    tel = 1;

                }

                if (d != 1 && tempo >= 0 && tempo <= 100 && f > 50 && f <= 500 && dur >= 0.3 && dur <= 4 && tel == 0)
                {
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
                        || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(cs))
                        {
                            SqlCommand cmd = new SqlCommand("spUploadImage", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            SqlParameter paramName = new SqlParameter()
                            {
                                ParameterName = @"Name",
                                Value = nametxt.Text
                            };
                            cmd.Parameters.Add(paramName);

                            SqlParameter paramSize = new SqlParameter()
                            {
                                ParameterName = "@Size",
                                Value = fileSize
                            };
                            cmd.Parameters.Add(paramSize);

                            SqlParameter paramImageData = new SqlParameter()
                            {
                                ParameterName = "@ImageData",
                                Value = bytes
                            };
                            cmd.Parameters.Add(paramImageData);

                            SqlParameter paramNewId = new SqlParameter()
                            {
                                ParameterName = "@NewId",
                                Value = -1,
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(paramNewId);
                            string ins = "insert into movielist values('" + nametxt.Text + "','" + herotxt.Text + "','" + herointxt.Text + "','" + directortxt.Text + "','" + storytxt.Text + "','" + genertxt.Text + "','" + costtxt.Text + "','" + ratingtxt.Text + "','" + durationtxt.Text + "')";
                            SqlCommand inscmd = new SqlCommand(ins, con);
                            string bookadd = "insert into Seatstatus values('" + nametxt.Text + "','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','" + TextBox7.Text + "','" + DropDownList1.SelectedValue + "')";
                            SqlCommand cmdbook = new SqlCommand(bookadd, con);
                            con.Open();
                            inscmd.ExecuteNonQuery();
                            cmd.ExecuteNonQuery();
                            cmdbook.ExecuteNonQuery();
                            con.Close();
                            lblMessage.Visible = true;
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Text = "Upload Successful";
                            hyperlink.Visible = true;
                            hyperlink.NavigateUrl = "~/WebForm2.aspx?Id=" + cmd.Parameters["@NewId"].Value.ToString();
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                        hyperlink.Visible = false;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Entry')</script>");

                }
            }
            else//new date and time for old movie
            {
                try
                {
                    string asa = TextBox7.Text;
                    var parameterDates = DateTime.ParseExact(asa, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    var todaysDates = DateTime.Today;

                    if (parameterDates <= todaysDates)
                    {
                        SqlCommand datec = new SqlCommand("select date from Seatstatus where name='" + nametxt.Text + "'", conn);
                        conn.Open();
                        string dateexist = datec.ExecuteScalar().ToString();
                        conn.Close();
                        
                        string datestr = TextBox7.Text;
                        var parameterDate = DateTime.ParseExact(dateexist, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        var todaysDate = DateTime.ParseExact(datestr, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                        if (parameterDate == todaysDate)//same date but new time
                        {
                            SqlCommand insnewd = new SqlCommand("insert into Seatstatus values('" + nametxt.Text + "','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','" + TextBox7.Text + "','" + DropDownList1.SelectedValue + "')", conn);
                            conn.Open();
                            insnewd.ExecuteNonQuery();
                            Response.Write("<script>alert('Movies old data is been taken and add,but date and time is been inserted.')</script>");
                            conn.Close();
                        }
                        else
                        {
                            SqlCommand timec = new SqlCommand("select time from Seatstatus where name='" + nametxt.Text + "' AND date='"+TextBox7.Text+"'", conn);
                            conn.Open();
                            string timecheck = timec.ExecuteScalar().ToString();
                            conn.Close();
                            string selectedtime = DropDownList1.SelectedValue.ToString();
                            if (timecheck.Trim() != selectedtime.Trim())//new time 
                            {
                                SqlCommand insnewt = new SqlCommand("insert into Seatstatus values('" + nametxt.Text + "','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','" + TextBox7.Text + "','" + DropDownList1.SelectedValue + "')", conn);
                                conn.Open();
                                insnewt.ExecuteNonQuery();
                                Response.Write("<script>alert('Movies old data is been taken and add,but only time is been inserted.')</script>");
                                conn.Close();
                            }
                            else
                            {
                                Response.Write("<script>alert('Movies date and time is been taken.')</script>");
                            }
                        }
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Enter date in correct format')</script> ");

                }
                
                //if (dateexist.Trim() != TextBox7.Text.Trim())
                //{
                //    Response.Write("<script>alert('date')</script>");
                //    
                //}
                //else//same date but new time
                //{
                //    
                //}
            }

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("adminmovie.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from movielist where Name='" + movienametxt.Text + "'", conn);
            conn.Open();
            SqlDataReader rdd = cmd.ExecuteReader();
            if (rdd.Read())
            {
                heronametxt.Text = rdd.GetValue(2).ToString();
                heroinnametxt.Text = rdd.GetValue(3).ToString();
                directornamttxt.Text = rdd.GetValue(4).ToString();
                storybytxt.Text = rdd.GetValue(5).ToString();
                gener2txt.Text = rdd.GetValue(6).ToString();
                cost2txt.Text = rdd.GetValue(7).ToString();
                rating2txt.Text = rdd.GetValue(8).ToString();
                duration2txt.Text = rdd.GetValue(9).ToString();
                PlaceHolder1.Visible = true;
                conn.Close();
            }
            else
            {
                conn.Close();
                Response.Write("<script>alert('Movie Does not exist,please add movie to update.')</script>");
                Response.AddHeader("REFRESH", "0.1;url=addmovie.aspx");
            }
        }
    }
}