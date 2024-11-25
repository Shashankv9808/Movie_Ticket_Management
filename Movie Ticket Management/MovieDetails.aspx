<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MovieDetails.aspx.cs" Inherits="Movie_Ticket_Management.MovieDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }</script>
    <style>
        html {
            font-family: Arial, Helvetica, sans-serif;
            width: 100%;
            height: 100%;
        }

        body {
            margin: 0px auto 0px auto;
            width: 100%;
            height: 100%;
            background-color: #F2F2F2;
            background-image: url("/images/Black-Wallpapers.jpg");
            opacity: .898;
        }

        #container {
            width: 101%;
            margin: 0 auto;
        }

        #header {
            width: 100%;
            height: 89px;
            border-bottom: 1px solid #c7c7c7;
            background-color: #333544;
        }

        marquee {
            width: 1237px;
            color: red;
        }

        .button {
            border-radius: 13px;
        }

        .search {
            font-family: Lucida Calligraphy;
            text-decoration-color: gray;
            border-radius: 13px;
        }

        .trans {
            background-color: transparent;
            text-align: center;
            color: white;
            border-color: transparent;
            font-family: Gigi;
            font-style: Bold Oblique;
            font-size: 25px;
        }

        .movieimg {
            border-radius: 12px;
        }

        .movielab {
            font-size: 25px
        }

        .modal {
            background-color: rgba(0,0,0, .8);
            width: 100%;
            height: 100%;
            position: absolute;
            top: 0;
            left: 0;
            z-index: 10;
            opacity: 0;
            visibility: hidden;
            transition: all .5s;
        }

        .modal__content {
            width: 450px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            background: #191919;
            border-radius: 1em;
            opacity: 0;
            font-size: larger;
            visibility: hidden;
            transition: all .5s;
        }

        #modals:target {
            opacity: 1;
            visibility: visible;
        }

            #modals:target .modal__content {
                opacity: 1;
                visibility: visible;
            }

        #modal:target {
            opacity: 1;
            visibility: visible;
        }

            #modal:target .box {
                opacity: 1;
                visibility: visible;
            }

        .modal__close {
            color: #363636;
            font-size: 2em;
            position: absolute;
            top: .5em;
            right: 1em;
        }

        .modal__heading {
            color: dodgerblue;
            margin-bottom: 1em;
        }

        .modal__paragraph {
            line-height: 1.5em;
        }

        .modal-open {
            display: inline-block;
            color: dodgerblue;
            margin: 2em;
        }

        .c1 {
            width: 200px;
            height: 400px;
            padding-left: 90px;
            padding-right: 20px;
            float: left;
        }

        .sig {
            border-radius: 13px;
            top: 13px;
            left: 960px;
            position: absolute;
            height: 28px;
            width: 75px;
            float: right;
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
            opacity: 0.96452
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
            .sidenav {
                padding-top: 15px;
            }

                .sidenav a {
                    font-size: 18px;
                }
        }

        pre {
            font-family: Curlz MT;
            color: black;
            font-size: 20px;
            font-style: oblique italic;
            font: bold;
        }

        .auto-style1 {
            width: 80px;
            position: absolute;
            height: 90px;
            margin-top: 3px;
        }

        .auto-style4 {
            width: 20px;
        }

        .auto-style5 {
            width: 70px;
        }

        .auto-style7 {
            width: 70px;
            height: 50px;
        }

        .auto-style8 {
            width: 20px;
            height: 50px;
        }

        .auto-style10 {
            height: 50px;
            width: 3px;
        }

        .auto-style11 {
            width: 3px;
        }


        .box {
            width: 300px;
            padding: 40px;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%,-50%);
            background: #191919;
            text-align: center;
            border-radius: 1em;
        }

            .box h1 {
                color: white;
                text-transform: uppercase;
                font-weight: 500;
            }

        .txt {
            border: 0;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #3498db;
            padding: 14px 10px;
            width: 200px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
        }

            .txt:hover {
                width: 280px;
                border-color: #2ecc71;
            }

        .paymenttxt {
            border: 0;
            background: none;
            margin: 20px auto;
            border: 2px solid #3498db;
            padding: 14px;
            text-align: center;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
            width: 90%;
            font-size: x-large;
        }

        .btn {
            border: 0;
            background: none;
            display: block;
            margin: 20px auto;
            text-align: center;
            border: 2px solid #2ecc71;
            padding: 14px 40px;
            outline: none;
            color: white;
            border-radius: 24px;
            transition: 0.25s;
            cursor: pointer;
        }

            .btn:hover {
                background: #2ecc71;
            }

        .moviecarddiv
        {
            width: 107px;
            height: 24px;
            position: absolute;
            top: 396px;
            left: 150px;
        }
        .movieinfodiv
        {
            top: 396px;
            left: 400px;
            width:300px;
            height:300px;
            position: absolute;
        }
        .movieseatsdiv{
            max-width: fit-content;
            margin-left: auto;
            margin-right: auto;
            padding-top:396px;
        }
        .seatwrap {
            height: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .seat {
            width: 50px;
            height: 50px;
            font-family: 'Roboto', sans-serif;
            font-size: 11px;
            text-transform: uppercase;
            letter-spacing: 2.5px;
            font-weight: 500;
            color: #000;
            background-color: #fff;
            border: none;
            border-radius: 45px;
            box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
            transition: all 0.3s ease 0s;
            cursor: pointer;
            outline: none;
        }

            .seat:hover {
                background-color: #2EE59D;
                box-shadow: 0px 15px 20px rgba(46, 229, 157, 0.4);
                color: #fff;
                transform: translateY(-7px);
            }
    </style>
</head>
 <body style="width: 102%" >
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
        <asp:Label ID="welcomeuser" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Harlow Solid Italic" Font-Size="X-Large" ForeColor="#00CC00" Visible="False" CssClass="auto-style28"></asp:Label>
        <asp:Button ID="signinbtn" CssClass="sig"  runat="server" style="margin-top: 0px;" Text="Sign in " BackColor="#0078FF" BorderColor="#0078FF" ForeColor="White" OnClick="signinbtn_Click" />
        <asp:ImageButton ID="logoimgbtn" runat="server" Height="69px" Width="259px" ImageUrl="~/images/logo.jpg" OnClick="logoimgbtn_Click" />
            <asp:ImageButton ID="searchimgbtn" CssClass="search" runat="server" ImageUrl="~/images/Search.png" style="top: 9px; left: 901px; position: absolute; height: 41px; width: 45px" OnClick="searchimgbtn_Click" />
            <asp:TextBox ID="searchtxt" CssClass="search" runat="server" placeholder="Search Movies...." style="top: 10px; left: 290px; position: absolute; height: 34px; width: 603px"></asp:TextBox>
        <marquee style="width: 1311px;" >You will get 10% offer from paying in debit card and 10% cash back in paytm.Offer valid for today only book your tickets now!!!!</marquee>
         </div>
        <div class="moviecarddiv">
            <asp:Label ID="movienamelabel" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="arabic" Font-Size="X-Large" ForeColor="White"></asp:Label>
            <asp:Image ID="movieimg" runat="server" />
            <br /><br />
            <div style="height:10px;width:80px;">
                <asp:Image ID="heart" runat="server" ImageUrl="~/images/The-heart.png" style="height: 25px;width: 26px;float:left;" />
                 <asp:Label ID="ratinglabel" runat="server" Font-Names="Bernard MT Condensed" ForeColor="White" style="float:right;" ></asp:Label>
            </div>
            <br /><br />
            <asp:Button ID="generbtn" runat="server" BorderColor="White" Font-Names="Bahnschrift Condensed" ForeColor="Green" style="background-color:transparent; width:auto;" Enabled="False" Font-Bold="True" Font-Size="X-Large"  />           

        </div>
        <div class="movieinfodiv">
            <div style="float: left">

                <asp:Label ID="Label10" runat="server" Font-Names="Blackadder ITC" Font-Size="X-Large" ForeColor="White" Text="Duration:"></asp:Label><br />
                <asp:Label ID="Label11" runat="server" Font-Names="Blackadder ITC" Font-Size="XX-Large" ForeColor="White" Text="Cost:"></asp:Label><br />
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Blackadder ITC" Font-Size="XX-Large" ForeColor="White" Text="Caste"></asp:Label><br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Hero" Font-Names="Blackadder ITC" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Heroin" Font-Names="Blackadder ITC" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <asp:Label ID="Label6" runat="server" Text="Director" Font-Names="Blackadder ITC" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <asp:Label ID="Label8" runat="server" Text="Story By" Font-Names="Blackadder ITC" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <asp:Label ID="lblDate" runat="server" Font-Names="Blackadder ITC" Font-Size="XX-Large" ForeColor="White" Text="Choose Date:"></asp:Label><br /><br />
                <asp:Label ID="lblTime" runat="server" Font-Names="Blackadder ITC" Font-Size="XX-Large" ForeColor="White" Text="Choose Time:"></asp:Label><br /><br />
                <asp:Label ID="lblTotalAmount" runat="server" Font-Names="Blackadder ITC" Font-Size="XX-Large" ForeColor="White" Text="Total Amount:"></asp:Label><br /><br />
            </div>
            <div style="float: right;padding-top:5px">
                <asp:Label ID="durlab" runat="server" Font-Italic="True" Font-Names="Bernard MT Condensed" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <asp:Label ID="costlab" runat="server" Font-Bold="False" Font-Italic="True" Font-Names="Bernard MT Condensed" Font-Size="Large" ForeColor="White"></asp:Label><br /><br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="herolabel" runat="server" ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Names="Blackadder ITC" Font-Size="X-Large"></asp:Label><br /><br />
                <asp:Label ID="heroinlabel" runat="server" ForeColor="White" Font-Names="Blackadder ITC" Font-Size="Large" Font-Bold="True"></asp:Label><br /><br />
                <asp:Label ID="directorlabel" runat="server" ForeColor="White" Font-Names="Blackadder ITC" Font-Size="X-Large" Font-Bold="True"></asp:Label><br /><br />
                <asp:Label ID="storylabel" runat="server" ForeColor="White" Font-Names="Blackadder ITC" Font-Size="X-Large" Font-Bold="True"></asp:Label><br /><br />
                <asp:DropDownList ID="ddl_movie_date" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" Height="30px" Width="130px">
                    <asp:ListItem Selected="True" Value="0">Choose Date</asp:ListItem>
                </asp:DropDownList><br /><br />
                <asp:DropDownList ID="ddl_movie_time" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" Height="30px" Width="130px">
                    <asp:ListItem Selected="True" Value="0">Choose Time</asp:ListItem>
                </asp:DropDownList><br /><br /><br />
                <asp:Label ID="totaltxt" runat="server" Font-Italic="True" Font-Names="Bernard MT Condensed" Font-Size="Large" ForeColor="White" Text="0.00"></asp:Label>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnBookSeats" CssClass="button" runat="server" Style="height: 40px; width: 218px" Text="Book Tickets" OnClick="BookSeats_Click" BackColor="#0078FF" ForeColor="White" Enabled="False" />



            <asp:Label ID="Label9" runat="server" Style="color: gold" Text="Select Seats" Font-Bold="True" Font-Italic="True" Font-Names="Blackadder ITC" Font-Size="XX-Large" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <br />
           
            <br />
            <br />
            
            
            
            
            <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Languagelabel" runat="server" Font-Italic="True" Font-Names="Bahnschrift SemiLight Condensed" ForeColor="White" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>
        <div class="movieseatsdiv">
            <asp:PlaceHolder ID="phSeatDraw" runat="server" Visible="true">
                <asp:Label ID="lblSeatSelectionError" runat="server" ForeColor="Red" Text="*Please select one seat atleast" Visible="False"></asp:Label><br />
                <br />

                <table style="background-color: transparent">
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="s1" CssClass="seat" runat="server" BackColor="#999999" Text="01" OnClick="s1_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s2" CssClass="seat" runat="server" BackColor="#999999" Text="02" OnClick="s2_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s3" CssClass="seat" runat="server" BackColor="#999999" Text="03" OnClick="s3_Click" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="s4" CssClass="seat" runat="server" BackColor="#999999" Text="04" OnClick="s4_Click" />
                        </td>
                        <td class="auto-style11">
                            <asp:Button ID="s5" CssClass="seat" runat="server" BackColor="#999999" Text="05" OnClick="s5_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="s6" CssClass="seat" runat="server" BackColor="#999999" Text="06" OnClick="s6_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s7" CssClass="seat" runat="server" BackColor="#999999" Text="07" OnClick="s7_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s8" CssClass="seat" runat="server" BackColor="#999999" Text="08" OnClick="s8_Click" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="s9" CssClass="seat" runat="server" BackColor="#999999"  Text="09" OnClick="s9_Click" />
                        </td>
                        <td class="auto-style11">
                            <asp:Button ID="s10" CssClass="seat" runat="server" BackColor="#999999" Text="10" OnClick="s10_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="s11" CssClass="seat" runat="server" BackColor="#999999" Text="11" OnClick="s11_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s12" CssClass="seat" runat="server" BackColor="#999999" Text="12" OnClick="s12_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s13" CssClass="seat" runat="server" BackColor="#999999" Text="13" OnClick="s13_Click" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="s14" CssClass="seat" runat="server" BackColor="#999999" Text="14" OnClick="s14_Click" />
                        </td>
                        <td class="auto-style11">
                            <asp:Button ID="s15" CssClass="seat" runat="server" BackColor="#999999" Text="15" OnClick="s15_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="s16" CssClass="seat" runat="server" BackColor="#999999" Text="16" OnClick="s16_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s17" CssClass="seat" runat="server" BackColor="#999999" Text="17" OnClick="s17_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s18" CssClass="seat" runat="server" BackColor="#999999" Text="18" OnClick="s18_Click" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="s19" CssClass="seat" runat="server" BackColor="#999999" Text="19" OnClick="s19_Click" />
                        </td>
                        <td class="auto-style11">
                            <asp:Button ID="s20" CssClass="seat" runat="server" BackColor="#999999" Text="20" OnClick="s20_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Button ID="s21" CssClass="seat" runat="server" BackColor="#999999" Text="21" OnClick="s21_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s22" CssClass="seat" runat="server" BackColor="#999999" Text="22" OnClick="s22_Click" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="s23" CssClass="seat" runat="server" BackColor="#999999" Text="23" OnClick="s23_Click" />
                        </td>
                        <td class="auto-style4">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="s24" CssClass="seat" runat="server" BackColor="#999999" Text="24" OnClick="s24_Click" />
                        </td>
                        <td class="auto-style11">
                            <asp:Button ID="s25" CssClass="seat" runat="server" BackColor="#999999" Text="25" OnClick="s25_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Button ID="s26" CssClass="seat" runat="server" BackColor="#999999" Text="26" OnClick="s26_Click" />
                        </td>
                        <td class="auto-style7">
                            <asp:Button ID="s27" CssClass="seat" runat="server" BackColor="#999999" Text="27" OnClick="s27_Click" />
                        </td>
                        <td class="auto-style7">
                            <asp:Button ID="s28" CssClass="seat" runat="server" BackColor="#999999" Text="28" OnClick="s28_Click" />
                        </td>
                        <td class="auto-style8"></td>
                        <td class="auto-style7">
                            <asp:Button ID="s29" CssClass="seat" runat="server" BackColor="#999999" Text="29" OnClick="s29_Click" />
                        </td>
                        <td class="auto-style10">
                            <asp:Button ID="s30" CssClass="seat" runat="server" BackColor="#999999" Text="30" OnClick="s30_Click" />
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </div>
        
          
       
        <!--Login popup-->
        <div class="modal" id="modal">
    <div class="box">
      <h2 class="modal__heading" style="padding-left:40%;padding-right:50%;padding-bottom:10px;">Login</h2>
        <asp:TextBox ID="user" runat="server" placeholder="Username" CssClass="txt" BackColor="#191919" ></asp:TextBox>
        
        <asp:TextBox ID="pass" runat="server" placeholder="Password" TextMode="Password" CssClass="txt" BackColor="#191919" ></asp:TextBox>
        
        <asp:Button ID="log" runat="server" Text="Login" CssClass="btn" OnClick="log_Click"/>
        
        <asp:HyperLink ID="HyperLink1" runat="server" BorderStyle="Dashed" NavigateUrl="~/Registration.aspx">Signup</asp:HyperLink>
        <!--Login popup-->
        <!-- payment pop up-->
    </div>
     </div>
        <div class="modal" id="modals">
    <div class="modal__content">
      <h2 class="modal__heading" style="padding-left:40%;padding-right:50%;padding-bottom:10px;">Payment</h2>
      &nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="cardnumtxt" runat="server" CssClass="paymenttxt" MaxLength="12" TextMode="SingleLine" placeholder="Card number" BackColor="#191919" onkeypress="return isNumberKey(event)"
></asp:TextBox>
        <br />
      &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Nametxt" runat="server" CssClass="paymenttxt" placeholder="Owner Name" BackColor="#191919"></asp:TextBox>
        <br />
      &nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="expmonthtxt" onkeypress="return isNumberKey(event)"
 runat="server" CssClass="paymenttxt"  TextMode="SingleLine" placeholder="Expire Month" MaxLength="2" style="width:80px" BackColor="#191919"></asp:TextBox><asp:TextBox ID="expyear" runat="server" MaxLength="4" placeholder="Expire Year" CssClass="paymenttxt" style="width:100px" BackColor="#191919"></asp:TextBox><asp:Label ID="Label3" runat="server" Text="eg:08/1998" ForeColor="White"></asp:Label>
        <br />
      &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="cvvtxt" onkeypress="return isNumberKey(event)"
 runat="server" CssClass="paymenttxt" TextMode="SingleLine" placeholder="CVV" MaxLength="3" BackColor="#191919"></asp:TextBox>
        <br />
        <asp:Button ID="paybtn" runat="server" CssClass="btn" Text="Pay" OnClick="paybtn_Click" />
    </div>
      </div>
        
    </form> 
</body>
</html>
