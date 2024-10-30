using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections;
using System.Configuration;

namespace Movie_Ticket_Management
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        ArrayList al = new ArrayList();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand gettime = new SqlCommand("select time from Seatstatus where name='kfg' AND date='02/02/2019'", con);
            con.Open();
            SqlDataReader rd = gettime.ExecuteReader();
            while (rd.Read())
            {
                al.Add(rd[0]);
            }
            con.Close();
            foreach (string i in al)
            {
                DropDownList1.Items.Add(i);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}