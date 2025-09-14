<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="abt.aspx.cs" Inherits="Movie_Ticket_Management.abt" %>

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
        pre{font-family:Curlz MT;color:black;font-size:20px;font-style:oblique italic;font:bold;}
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
        <pre><center> Our Journey

20 years ago in South Africa a seed of an idea was planted, a dream was shared. Inception happened. 20 years on, 
            we look back at what we've built. Leave it up to us, and we'd love to do it all over again.
AUG
The Three Musketeers

What happens when 3 long-time friends go holidaying together in South Africa? The seed of a BigTree is planted. A company is planned, 
            from roots to fruits. Soon after the Eureka moment, C.E.O. Shashank V Murthy quits his job at JWT, Co-Founder Shreyas J C takes over Technology, 
            and Co-Founder Rajesh Balpande takes over Finance.
2000
2000 - 01
Gaining ground with Cinema


With the cinema industry on a high and multiplexes and large cinema chains starting to entertain Indian audiences around the country; 
            Bigtree takes over the rights to retail and service New Zealand based ticketing software, Vista in India.
2002
2002 - 2007
Fighting the rough seas

In the midst of the dot com bust that happened in 2002, the company offered technology solutions from the Customer Relationship 
            Management point of view to fight the storm. This business flourished under the leadership of our 3 musketeers.
2007
Mar
The Big Bucks


Network 18 invested in March 2007. In August, the same year an internal contest was held to coin a name for the new company. 
            A developer intern came up with the name MyBang'oreMovies.com and the rest as they say is history.
AUG
Launch of MyBang'oreMovies


Bigtree Entertainment Pvt. Ltd launches India's first ticketing aggregator - MyBang'oreMovies - in August 2007, now one of the 
            biggest ticketing portals in the country.
2010
March 2010
Yeh IPL Hai Boss


MyBang'oreMovies becomes the official ticketing partner for Mumbai Indians, Kings XI Punjab and Delhi Daredevils. Today we have 
            Pune Warriors and Rajasthan Royals too on board this high drama entertainment circus called the IPL.
2011
Mar
Need for Speed


MyBang'oreMovies becomes the exclusive ticketing partner for Formula 1, the Indian Grand Prix. After the grand success of 2011, 
            we are all geared up for 2012's extravaganza.
Mar
The Social Network


MyBang'oreMovies's FaceMyBang'oreMovies page has hit more than 1 Million fans and as of today, our page has over 3.3 Million fans.
Jul
Records are made to be broken


Records are meant to be broken - As it stands today, the highest number of tickets sold in a single month was October 2014 - 
            more than 5 Million - 5,696,685
2012
Jan
And the Award Goes To


MyBang'oreMovies is awarded 'The Hottest Company of the Year-2011-12' and 'The Company to watch out for' at the prestigious 
            CNBC Young Turks Award.
Feb
Mobile Entertainment


MyBang'oreMovies App has around 7.2 Million downloads that includes Windows, Android, iOS and Blackberry.
Aug
Money Matters


Accel Partners invests USD 18 Million Dollars i.e. Rs. 100 crores in MyBang'oreMovies.
2013
Mar
Acquisition


BigTree Entertainment acquires Chennai based online ticketing company Ticket Green.
Dec
Big Ticket


The highest number of tickets sold is for movie Dhoom 3 - 2.2 Million
2014
Jun
Money Matters


SAIF Partners invests USD 25 Million i.e. Rs. 150 crore valuing MyBang'oreMovies at Rs. 1000 crores.
2015
Feb
Acquisition


BigTree Entertainment acquires Bengaluru based Social Media Analytics firm Eventifier.
2016
Mar
Vanakkam Fantain


MyBang'oreMovies acquires a majority stake in Chennai based Fantain Sports Pvt. Ltd.
May
We love awards

MyBang'oreMovies awarded ‘Best Omni-channel Customer Experience Brand’ at the OneDirect Quest Customer Experience (QuestCX) Awards.
Jul
Bigtree grows taller

Raises largest single funding of INR 550 crs led by Stripes Group.
Dec
The all-new Android App


MyBang'oreMovies launches its newly designed Android app packed with some really cool features including Split Costs and Split Tickets.
Dec
Record High!


During the opening weekend of mega blockbuster Dangal, MyBang'oreMovies creates new records; sells over 3 million movie tickets in a 
            single weekend and for shows on Saturday & Sunday, MyBang'oreMovies sells over 1 Million tickets a day!
2017
Jan
Swagata MastiTickets


MyBang'oreMovies acquires Hyderabad based online ticketing platform MastiTickets.
Feb
Hello Townscript

MyBang'oreMovies acquires majority stake in Pune based DIY events ticketing and registration platform Townscript.
Apr
MyBang'oreMovies is the real Baahubali of online ticketing


MyBang'oreMovies alone sells over 15 million tickets for Baahubali 2. The film is also the first on MyBang'oreMovies 
            to generate more than 100 cr business in a single weekend.
Jul
Ed Sheeran tickets- Gone in 48 minutes!

Ed Sheeran Live in Mumbai are sold out on MyBang'oreMovies in a matter of just 48 minutes.
Jul
Welcome Burrp!
Picture

MyBang'oreMovies acquires India’s oldest food tech business Burrp!
Aug
MyBang'oreMovies acquires Nfusion!
Picture

MyBang'oreMovies acqui-hires Nfusion for its audio entertainment offering – Jukebox!</center>
</pre>
    </form>
</body>
</html>
