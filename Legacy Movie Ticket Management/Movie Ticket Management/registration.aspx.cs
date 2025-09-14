using Movie_Ticket_Management.DataAccess;
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
namespace Movie_Ticket_Management
{
    public partial class registration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Write("<script>alert('You have logged in already')</script");
                Response.AddHeader("REFRESH", "0.1;URL=home.aspx");
            }
        }
        protected void signinbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void searchimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void btnBeforeOk_ServerClick(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Registration.aspx");
        }
        protected void logoimgbtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void signupbtn_Click(object sender, EventArgs e)
        {
            //code implement
            var regexItem = new Regex("@|!#$%&/()=?»«@£§€{}.-;'<>_,[1-9]");
            if (Regex.IsMatch(username.Text, "^[a-zA-Z0-9\x20]+$") && Regex.IsMatch(fnametxtbox.Text, "^[a-zA-Z\x20]+$") && Regex.IsMatch(lnametxtbox.Text, "^[a-zA-Z\x20]+$"))
            {
                UserAccountInfos new_user_account_data = new UserAccountInfos
                { 
                    UserName = username.Text,
                    EncryptedPassword = UserAccountInfos.Encrypt(passtxt.Text),
                    FirstName = fnametxtbox.Text,
                    LastName = lnametxtbox.Text,
                    ContactNumber = Convert.ToInt64(Phonetxtbox.Text),
                    EmailAddress = Emailtxtbox.Text,
                };
                string result_message = string.Empty;
                if(RegisterDataAccess.RegisterNewUserAccount(new_user_account_data, out result_message))
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('"+ result_message + "')</script>");
                    Response.AddHeader("REFRESH", "0.1;URL=Registration.aspx");
                }
            }
            else
            {
                //special char
                Response.Write("<script>alert('Special Symbols are not allowed')</script>");
                Response.AddHeader("REFRESH", "0.1;URL=Registration.aspx");
            }
        }
    }
}