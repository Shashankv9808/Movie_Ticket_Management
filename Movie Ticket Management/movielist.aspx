<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="movielist.aspx.cs" Inherits="Movie_Ticket_Management.movielist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--movie name passing to another page-->
       <script type="text/javascript">
function somefunction(b)
{
     var a=b.attributes;
               for (var i = a.length; i--;)
               {
                   var n
                   if (a[i].name == 'name')
                   {
                       n = a[i].value;
                       window.location.href ="movieinfo.aspx?param=" + n;
                   }
               }
return true;
}
</script><!--movie name passing to another page-->

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
        .auto-style6 {
            top: 29px;
            left: 964px;
            position: absolute;
            height: 21px;
            width: 20px;
            border-radius:1px;
            
        }
        .auto-style7 {
            width: 100%;
        }
        
        .auto-style8 {
            width: 1311px;
        }
        
    </style>
</head>
<body style="width: 102%">
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
        <div>
            <br />
            <br />
            <br />
            <br />
&nbsp;
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>       
    </form>
        
</body>
</html>
