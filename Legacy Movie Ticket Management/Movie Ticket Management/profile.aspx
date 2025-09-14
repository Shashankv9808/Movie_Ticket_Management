<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Movie_Ticket_Management.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html{font-family:Arial, Helvetica, sans-serif;width:100%;height:100%;}
        body{margin:0px auto 0px auto;width:100%;height:100%;background-color:#F2F2F2;}
        #container{width:101%;margin:0 auto;}
        #header{width:100%;height:89px;border-bottom:1px solid #c7c7c7;background-color:#333544;}
        marquee {width: 1237px;color:red;}
        .button{border-radius: 13px;}
        .search{font-family:Lucida Calligraphy;text-decoration-color:gray;border-radius:13px;}
        .trans{background-color:transparent;text-align:center;color:white;border-color:transparent;font-family:Gigi;font-style:Bold Oblique;font-size:25px;}
        .movieimg{border-radius:12px;}
        .movielab{font-size:25px}
        .overlay 
        {
            position: absolute;
            background-color: white;
            top: 0px;
            left: 0px;
            width: 100%;
            height: 100%;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=80)";
            z-index: 10000;
        }
        .example
        {
            color: #fff !important;
            text-transform: uppercase;
            background: #ed3330;
            padding: 20px;
            border-radius: 5px;
            display: inline-block;
            border: none;
        }
         .c1
         {
            width:200px;
            height:400px;
            padding-left:90px;
            padding-right:20px;
            float:left;
        }
        
        .example:hover 
        {
            background: #434343;
            letter-spacing: 10px;
            -webkit-box-shadow: 0px 5px 40px -10px rgba(0,0,0,0.57);
            -moz-box-shadow: 0px 5px 40px -10px rgba(0,0,0,0.57);
            box-shadow: 5px 40px -10px rgba(0,0,0,0.57);
            transition: all 0.4s ease 0s;
        }
        .sidenav {
  height: 100%;
  width: 0;
  position: fixed;
  z-index: 1;
  top: 0;
  right: 0;
  background-color: #111;
  overflow-x: hidden;
  transition: 0.5s;
  padding-top: 60px;
  opacity:0.96452
}

.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 25px;
  color: #818181;
  display: block;
  transition: 0.3s;
}

.sidenav a:hover {
  color: #f1f1f1;
}

.sidenav .closebtn {
  position: absolute;
  top: 0;
  right: 200px;
  font-size: 36px;
  margin-left: 50px;
}

@media screen and (max-height: 450px) {
  .sidenav {padding-top: 15px;}
  .sidenav a {font-size: 18px;}
}
        .auto-style4 {
            top: 16px;
            left: 966px;
            position: absolute;
            height: 23px;
            width: 230px;
            margin-top: 0px;
        }
        .auto-style5 {
            border-radius: 13px;
            top: 13px;
            left: 960px;
            position: absolute;
            height: 28px;
            width: 75px;
            float: right;
        }
        .auto-style7 {
            width: 100%;
        }
        
        .auto-style8 {
            width: 1311px;
        }
        
        .auto-style9 {
            height: 192px;
            width: 1310px;
            margin-left: 0px;
        }
        .auto-style10 {
            width: 249px;
            height: 48px;
            position: absolute;
            left: 1014px;
            top: 190px;
            border-radius:12px;
            outline: none;
            transition: 0.35s;
        }
        .auto-style10:hover{
            width:20%;
            background-color:red;
            transform: scale(1.5);
            transition: 0.35s;
        }
        
        .auto-style11 {
            width: 95%;
            height: 753px;
            margin-left: 37px;
        }
        .auto-style12 {
            width: 268px;
            height: 42px;
            position: absolute;
            left: 80px;
            top: 353px;
        }
        .txt{
            padding: 10px;
            box-shadow: 5px 10px 8px #888888;
            border-radius:5px;
        }
        
        
        .auto-style13 {
            
            border-radius: 5px;
            width: 244px;
            height: 25px;
            position: absolute;
            left: 76px;
            top: 442px;
            right: 941px;transition: 0.35s;
        }
        .auto-style13:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        .auto-style14 {
            border-radius: 5px;
            width: 244px;
            height: 25px;
            position: absolute;
            left: 363px;
            top: 442px;transition: 0.35s;
        }
        .auto-style14:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        
        .auto-style15 {
            border-radius: 5px;
            width: 244px;
            height: 31px;
            position: absolute;
            left: 76px;
            top: 532px;transition: 0.35s;
        }
        .auto-style15:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        .auto-style16 {
            border-radius: 5px;
            width: 244px;
            height: 25px;
            position: absolute;
            left: 363px;
            top: 528px;transition: 0.35s;
        }
        
        .auto-style16:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        .auto-style18 {
            width: 557px;
            height: 35px;
            position: absolute;
            left: 80px;
            top: 634px;transition: 0.35s;
        }
        .auto-style18:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        
        .auto-style19 {
            border-radius: 5px;
            width: 388px;
            height: 41px;
            position: absolute;
            left: 273px;
            top: 807px;
            right: 389px;transition: 0.35s;
        }
        .auto-style19:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        
        .auto-style20 {
            border-radius:13px;
            width: 109px;
            height: 35px;
            position: absolute;
            left: 685px;
            top: 811px;
            right: 491px;transition: 0.35s;
        }
              .auto-style20:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}  
        
        .auto-style22 {
            border-radius: 5px;
            width: 244px;
            height: 24px;
            position: absolute;
            left: 388px;
            top: 723px;
            right: 418px;transition: 0.35s;
        }
        
        .auto-style22:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        .auto-style23 {            
            border-radius: 5px;
            width: 244px;
            height: 24px;
            position: absolute;
            left: 690px;
            top: 722px;transition: 0.35s;
        }
        .auto-style23:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        
        .auto-style25 {
            width: 137px;
            height: 20px;
            position: absolute;
            left: 408px;
            top: 685px;
        }
        .auto-style26 {
            width: 178px;
            height: 24px;
            position: absolute;
            left: 710px;
            top: 683px;
        }
        .auto-style27{position: absolute; left: 89px; border-radius: 5px;
top: 722px; 
width:244px;height: 24px;transition: 0.35s;
        }
        .auto-style27:hover{padding: 10px;
            box-shadow: 5px 10px 8px #888888;transition: 0.35s;}
        .auto-style29 {
            border:0;
            background: dodgerblue;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            color:white;
            border-radius:13px;
            width: 306px;
            height: 55px;
            position: absolute;
            left: 74px;
            top: 950px;
            transition: 0.35s;
            right: 905px;
        }
        .auto-style29:hover{width:20%;
            transform: scale(1.5);transition: 0.35s;}
        
        
        .auto-style30 {
            width: 262px;
            height: 28px;
            position: absolute;
            left: 685px;
            top: 765px;
        }
                
        
        .auto-style32 {
            width: 61px;
            height: 18px;
            position: absolute;
            left: 805px;
            top: 816px;
        }
        
        
        .auto-style33 {
            width: 226px;
            height: 41px;
            position: absolute;
            left: 38px;
            top: 806px;
        }
        
        
        .auto-style34 {
            width: 195px;
            height: 21px;
            position: absolute;
            left: 109px;
            top: 688px;
            right: 754px;
        }
        
        
        .auto-style35 {
            width: 15px;
            height: 21px;
            position: absolute;
            left: 626px;
            top: 448px;
        }
        .auto-style36 {
            width: 14px;
            height: 20px;
            position: absolute;
            left: 336px;
            top: 449px;
        }
        .auto-style37 {
            width: 12px;
            height: 12px;
            position: absolute;
            left: 335px;
            top: 538px;
        }
        .auto-style38 {
            width: 14px;
            height: 12px;
            position: absolute;
            left: 625px;
            top: 538px;
        }
                
        
        .auto-style39 {
            width: 311px;
            height: 20px;
            position: absolute;
            left: 889px;
            top: 824px;
        }
                
        
        .auto-style40 {
            width: 218px;
            height: 26px;
            position: absolute;
            left: 92px;
            top: 765px;
        }
                
        
        </style>
</head>
<body style="width: 102%; height: 280px;">
    <form id="form1" runat="server">
        <!--slidenav-->
        <div id="mySidenav" class="sidenav" runat="server">
  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">&times;</a>  

            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="False"> <!--server side enable or disable-->
  <a href="profile.aspx" id="profilea" visible="False">Profile</a>
  <a href="#">QuickPay(Comming Soon)</a>
  <a href="bookhistory.aspx" id="bookhis" visible="False">Booking History</a>
  <a href="feedback.aspx">Feedback</a>
                </asp:PlaceHolder>
  <a href="abt.aspx">About Us</a>
  <a href="Contact.aspx">Contact Us</a>
            <br />
            <br />
  <input type="button" id="btnBeforeOk" value="Logout" runat="server"  name="btnBeforeOk" style="width: 100%;height:35px;align-items:center;;background-color:rgb(0, 120, 255);border-color:rgb(0, 120, 255);border-radius:2px;text-decoration-color:white;color:white;" Visible="False" onserverclick="btnBeforeOk_ServerClick" />
</div>
 
<span style="font-size:30px;color:white;float:right;padding-right:50px;cursor:pointer" onclick="openNav()">&#9776;</span>

<script>
function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}
</script>
     <!--slidenav--> 

        <!--main-->
    <div id="header" class="auto-style7"><!--header -->
        <asp:Label ID="welcomeuser" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Harlow Solid Italic" Font-Size="X-Large" ForeColor="#00CC00" Visible="False" CssClass="auto-style4"></asp:Label>
        <asp:Button ID="signinbtn" CssClass="auto-style5"  runat="server" style="margin-top: 0px;" Text="Sign in " BackColor="#0078FF" BorderColor="#0078FF" ForeColor="White" OnClick="signinbtn_Click" />
        <asp:ImageButton ID="logoimgbtn" runat="server" Height="69px" Width="259px" ImageUrl="~/images/logo.jpg" OnClick="logoimgbtn_Click" />
            <asp:ImageButton ID="searchimgbtn" CssClass="search" runat="server" ImageUrl="~/images/Search.png" style="top: 9px; left: 901px; position: absolute; height: 41px; width: 45px" OnClick="searchimgbtn_Click" />
            <asp:TextBox ID="searchtxt" CssClass="search" runat="server" placeholder="Search Movies...." style="top: 10px; left: 290px; position: absolute; height: 34px; width: 603px"></asp:TextBox>
        <marquee class="auto-style8">You will get 10% offer from paying in debit card and 10% cash back in paytm.Offer valid for today only book your tickets now!!!!</marquee>
         </div>
        <div style="background-image:url('/images/user-profile.jpg');" class="auto-style9">

            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Names="Bell MT" Font-Size="X-Large" ForeColor="White" Text="Fell Free To Change With Your Information,"></asp:Label>
            <asp:Label ID="userlabel" runat="server" Font-Names="Bell MT" Font-Size="X-Large" ForeColor="White" Font-Bold="True" Font-Italic="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" CssClass="auto-style10" Font-Names="Bahnschrift" Font-Size="Large" Text="Deactivate Account" OnClick="Button1_Click" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label ID="phonelabel" runat="server" Font-Names="Bell MT" Font-Size="Large" ForeColor="White" Font-Bold="True" Font-Italic="True"></asp:Label>
            &nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Names="Bell MT" Font-Size="Large" ForeColor="White" OnClick="LinkButton1_Click">BookHistory</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </div>      
        <div style="background-color:white;" class="auto-style11">

            <asp:Label ID="Label2" runat="server" CssClass="auto-style12" Font-Names="Calisto MT" Font-Size="XX-Large" Font-Underline="True" Text="Edit Profile"></asp:Label>
            <asp:TextBox ID="txt_firstname" runat="server" CssClass="auto-style13" Font-Size="X-Large" placeholder="First Name"></asp:TextBox>

            <asp:TextBox ID="txt_lastname" runat="server" CssClass="auto-style14"  placeholder="Last Name" Font-Size="X-Large"></asp:TextBox>

            <asp:TextBox ID="txt_email" runat="server" CssClass="auto-style15"  placeholder="Email" Font-Size="X-Large"></asp:TextBox>
            <asp:TextBox ID="txt_phone" runat="server" CssClass="auto-style16" placeholder="Phone Number" Font-Size="X-Large"></asp:TextBox>

            
            <asp:TextBox ID="txt_passcom" runat="server" CssClass="auto-style19" placeholder="Enter PassWord" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style25" Font-Names="Bell MT" Font-Size="Large" Font-Underline="True" Text="Password" Visible="False"></asp:Label>
            <asp:Button ID="check_btn" runat="server" CssClass="auto-style20" Text="Log in" OnClick="check_btn_Click" BackColor="#0033CC" Font-Bold="False" Font-Italic="True" Font-Names="Algerian" Font-Size="Large" ForeColor="White" />

            
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False">
                 <asp:Label ID="Label3" runat="server" CssClass="auto-style18" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" Text="Change UserName And Password"></asp:Label>
           <%--<asp:TextBox ID="txt_update_user" runat="server" CssClass="auto-style27" placeholder="UserName" Visible="True"></asp:TextBox>--%>
                <asp:TextBox ID="txt_update_pass" runat="server" CssClass="auto-style22" Visible="True" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txt_update_comfpass" runat="server" CssClass="auto-style23" Visible="True" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="txt_currpass" runat="server" CssClass="auto-style27" placeholder="Current Password" OnTextChanged="txt_currpass_TextChanged" Height="20px" ></asp:TextBox>
            <asp:Label ID="Label11" runat="server" CssClass="auto-style28" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="Large" ForeColor="Red" Text="*Password is Incorrect, try again" Visible="False"></asp:Label>
            <asp:Label ID="Label6" runat="server" CssClass="auto-style26" Font-Names="Bell MT" Font-Size="Large" Font-Underline="True" Text="Comfirm Passowrd" Visible="True"></asp:Label>
            <asp:Label ID="Label13" runat="server" CssClass="auto-style39" Font-Italic="True" Font-Names="Bell MT" Font-Size="Large" ForeColor="Red" Text="*Enter All Fields" Visible="False"></asp:Label>
            <asp:Button ID="change_btn" runat="server" CssClass="auto-style31" Text="Change" ValidationGroup="change" Visible="False" OnClick="change_btn_Click" />
            <asp:Button ID="Button2" runat="server" Text="Check Current Password" CssClass="auto-style40" />
            </asp:PlaceHolder>
                
                
            
           
            <br />
            <br />
            <br />
            <br />
                
            
            
                
            
           
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_firstname" CssClass="auto-style36" ErrorMessage="*" ForeColor="Red" ValidationGroup="l"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_email" CssClass="auto-style37" ErrorMessage="*" ForeColor="Red" ValidationGroup="l"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_phone" CssClass="auto-style38" ErrorMessage="*" ForeColor="Red" ValidationGroup="l"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <br />
            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label12" runat="server" CssClass="auto-style34" Font-Names="Bell MT" Font-Size="Large" Font-Underline="True" Text="Current Password" Visible="False"></asp:Label>
            <br />


            <asp:Button ID="update_btn" runat="server" CssClass="auto-style29" Font-Names="Bell MT" Font-Size="XX-Large" Text="Update" OnClick="update_btn_Click" Enabled="False" />


            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_update_pass" ControlToValidate="txt_update_comfpass" CssClass="auto-style30" ErrorMessage="*Passwod does not match each other" ForeColor="Red" ValidationGroup="gg"></asp:CompareValidator>
            


        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        


            <asp:Label ID="Label9" runat="server" CssClass="auto-style32" ForeColor="Red" Text="*Log in First" Visible="False"></asp:Label>
            


            <asp:Label ID="Label10" runat="server" CssClass="auto-style33" Font-Italic="True" Text="Login To Update or Change Password"></asp:Label>
            


            
            


            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_lastname" CssClass="auto-style35" ErrorMessage="*" Font-Bold="False" Font-Italic="True" Font-Names="Bell MT" ForeColor="Red" ValidationGroup="l"></asp:RequiredFieldValidator>
            
            


            
            


            <asp:Label ID="Label14" runat="server" CssClass="auto-style39" Font-Italic="True" Font-Names="Bell MT" Font-Size="Large" Text="Successfully changed" Visible="False"></asp:Label>
            
            


            
            


        </div>
    </form>
        
</body
</html>
