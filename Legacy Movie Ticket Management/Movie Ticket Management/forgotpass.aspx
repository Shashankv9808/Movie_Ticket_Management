<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpass.aspx.cs" Inherits="Movie_Ticket_Management.forgotpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        html{font-family:Arial, Helvetica, sans-serif;color:red;width:100%;height:100%;}
        body{margin:0px auto 0px auto;width:99%;
height:100%;background-color:#F2F2F2;
        }
        div{width: 100%;height: 175%;
        }
        #container{width:156%;margin:0 auto;
        }
        #header{width:100%;height:89px;border-bottom:1px solid #c7c7c7;background-color:#333544;}
        marquee {            width: 1184px;
        }
        .button{border-radius: 13px;}
        .search{font-family:Lucida Calligraphy;text-decoration-color:gray;border-radius:13px;}
        .trans{background-color:transparent;text-align:center;color:white;border-color:transparent;font-family:Gigi;font-style:Bold Oblique;font-size:25px;}
        .movieimg{border-radius:12px;}
        .movielab{font-size:25px}
        .auto-style1 {
            width: 620px;
            height: 350px;
            top: 127px;
            left: 495px;
            position: absolute;
        }
        .auto-style2 {
            width: 360px;
            height: 298px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header"><!--header -->
           <asp:Button ID="logout" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Courier New" ForeColor="White" style="top: 57px; left: 1280px; position: absolute; height: 21px; width: 71px;background-color:transparent;" Text="Log Out" Visible="False" BorderColor="White" />
        <asp:Label ID="welcomeuser" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Harlow Solid Italic" Font-Size="X-Large" ForeColor="#00CC00" style="top: 4px; left: 1256px; position: absolute; height: 23px; width: 108px" Visible="False"></asp:Label>
        <asp:Label ID="usertxt" runat="server" Font-Names="Algerian" Font-Size="Larger" Font-Underline="True" ForeColor="#00CC00" style="top: 25px; left: 1254px; position: absolute; height: 20px; width: 36px" Visible="False"></asp:Label>
        <asp:Button ID="signinbtn" CssClass="button"  runat="server" style="top: 17px; left: 1271px; position: absolute; height: 28px; width: 75px; float: right; margin-top: 0px;" Text="Sign in" BackColor="#0078FF" BorderColor="#0078FF" ForeColor="White" OnClick="signinbtn_Click" />
        <asp:Button ID="aboutbtn" CssClass="trans" runat="server" style="top: 16px; left: 1001px; position: absolute; height: 35px; width: 112px; right: 10px;" Text="About Us" OnClick="aboutbtn_Click" />
            <asp:ImageButton ID="searchimgbtn" CssClass="search" runat="server" ImageUrl="~/images/Search.png" style="top: 9px; left: 901px; position: absolute; height: 41px; width: 45px" OnClick="searchimgbtn_Click" />
            <asp:TextBox ID="searchtxt" CssClass="search" runat="server" placeholder="Search Movies...." style="top: 10px; left: 290px; position: absolute; height: 34px; width: 603px"></asp:TextBox>
        <asp:Button ID="contactbtn" CssClass="trans" runat="server" style="top: 15px; left: 1126px; position: absolute; height: 34px; width: 126px; right: 193px;" Text="Contact Us" OnClick="contactbtn_Click" />
        <asp:ImageButton ID="logo" runat="server" Height="69px" ImageUrl="~/images/logo.jpg" Width="259px"/>
        <marquee>You will get 10% offer from paying in debit card and 10% cash back in paytm.Offer valid for today only book your tickets now!!!!</marquee>
        </div>
    </form>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="404  error" class="auto-style1" src="images/404-error.jpg" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img alt="duck" class="auto-style2" src="images/AS000745_04.gif" /></p>
</body>
</html>
