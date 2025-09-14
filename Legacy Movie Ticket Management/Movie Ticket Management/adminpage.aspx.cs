using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Movie_Ticket_Management
{
    public partial class adminpage : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            int users;
            int online;
            int pay;
            int movies;
            int booked;
            SqlCommand cmd = new SqlCommand("Select max(id) from register",con);
            SqlCommand cmd4 = new SqlCommand("Select min(id) from register", con);
            SqlCommand cmd1 = new SqlCommand("Select max(id) from bookedinfo", con);
            SqlCommand cmd2 = new SqlCommand("Select max(id) from movielist", con);
            SqlCommand cmd3 = new SqlCommand("Select max(id) from cardinfo", con);
            con.Open();
            online = Convert.ToInt32(cmd4.ExecuteScalar());
            users=Convert.ToInt32(cmd.ExecuteScalar());
            booked = Convert.ToInt32(cmd1.ExecuteScalar());
            movies = Convert.ToInt32(cmd2.ExecuteScalar());
            pay = Convert.ToInt32(cmd3.ExecuteScalar());
            con.Close();
            Random rdn = new Random();

            Label6.Text = users.ToString();
            Label7.Text = rdn.Next(online, users).ToString();
            Label8.Text = movies.ToString();
            Label9.Text = booked.ToString();
            Label10.Text = pay.ToString();

        }
    }
}