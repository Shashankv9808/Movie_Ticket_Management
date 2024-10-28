<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="booked.aspx.cs" Inherits="Movie_Ticket_Management.booked" %>

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
.dam{padding-left:20%;padding-bottom:10px;}
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
        .modal{
   background-color: rgba(0,0,0, .8);
   width:100%;
   height: 160vh;
   position: absolute;
   top: 0;
   left: 0;
   z-index: 10;
   opacity: 0;
   visibility: hidden;
   transition: all .5s;
  }
  .modal__content{
   width: 30%;
   height: 40%;
   background-color: #fff;
   position: absolute;
   top: 50%;
   left: 50%;
   transform: translate(-50%, -50%);
   padding: 2em;
   border-radius: 1em;
   opacity: 0;
   visibility: hidden;
   transition: all .5s;
  }
  #modal:target{
   opacity: 1;
   visibility: visible;
  }
  #modal:target .modal__content{
   opacity: 1;
   visibility: visible;
  }
  .modal__close{
   color: #363636;
   font-size: 2em;
   position: absolute;
   top: .5em;
   right: 1em;
  }
  .modal__heading{
   color: dodgerblue;
   margin-bottom: 1em;
  }
  .modal__paragraph{
   line-height: 1.5em;
  }
.modal-open{
 display: inline-block;
 color: dodgerblue;
 margin: 2em;
}
        </style>
</head>
<body style="height: 644px; float: right;">
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
<div class="modal" id="modal">
    <div class="modal__content">
      <a href="HomePage.aspx" class="modal__close">&times;</a>
      <h2 class="modal__heading" style="padding-left:20%;padding-bottom:10px;color:forestgreen;">Successfully Booked</h2>
        <div class="dam" style="font-family:'Calisto MT';font-size:x-large;">Book Number: 
            <asp:Label ID="booknum" runat="server" Text="Label"></asp:Label></div>
        <br />
        <div class="dam" style="font-family:'Calisto MT';font-size:x-large;">Name: <asp:Label ID="name" runat="server" Text="" ></asp:Label></div>
        <br />
        <div class="dam" style="font-family:'Calisto MT';font-size:x-large;">Number of Seats Booked: <asp:Label ID="seatsb" runat="server" Text=""></asp:Label></div>
        <br />
        <div class="dam">
            <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" ImageUrl="~/images/qr.jpg" Height="200px" Width="200px" />
        </div>
        
    </div>
 </div>
        </div>
    </form>
</body>
</html>
