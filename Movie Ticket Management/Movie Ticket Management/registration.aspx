<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="Movie_Ticket_Management.registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <script src="jquery-1.11.2.js"></script>
    <script type="text/javascript">
        function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }
        $(document).ready(function () {

            $('#username').keyup(function () {
                var userName = $(this).val();

                if (userName.length >= 1) {
                    $.ajax({
                        url: 'RegistrationService.asmx/UserNameExists',
                        method: 'post',
                        data: { userName: userName },
                        dataType: 'json',
                        success: function (data) {
                            var divElement = $('#divOutput');
                            if (data.UserNameInUse) {
                                divElement.text(data.UserName + ' already in use');
                                divElement.css('color', 'red');
                            }
                            else {
                                divElement.text(data.UserName + ' available')
                                divElement.css('color', 'green');
                            }
                        },
                        error: function (err) {
                            alert(err);
                        }
                    });
                }
            });
        });

    </script>

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
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/greatwork.gif" style="top: 225px; left: 997px; position: absolute; height: 281px; width: 328px" />
       
            <asp:Button ID="signupbtn" CssClass="search" runat="server" style="top: 600px; left: 567px; position: absolute; height: 36px; width: 266px; right: 283px;" Text="Sign Up" BackColor="#F4B401" Font-Bold="True" Font-Italic="True" Font-Names="Lucida Calligraphy" ForeColor="White" OnClick="signupbtn_Click" />
        <asp:TextBox ID="Emailtxtbox" placeholder="Email Id" runat="server" style="top: 310px; left: 567px; position: absolute; height: 31px; width: 260px; margin-top: 5px" Font-Names="Lucida Calligraphy" TextMode="Email"></asp:TextBox>
        <asp:TextBox ID="Phonetxtbox" placeholder="Mobile Number" runat="server" onkeypress="return isNumberKey(event)" style="top: 370px; left: 567px; position: absolute; height: 31px; width: 260px" Font-Names="Lucida Calligraphy" MaxLength="10"></asp:TextBox>
        <asp:TextBox ID="fnametxtbox" placeholder="First Name" runat="server" style="top: 430px; left: 567px; position: absolute; height: 31px; width: 260px; margin-top: 0px;" Font-Names="Lucida Calligraphy" MaxLength="30"></asp:TextBox>
        <asp:TextBox ID="lnametxtbox" placeholder="Last Name" runat="server" style="top: 490px; left: 567px; position: absolute; height: 31px; width: 260px; bottom: 156px" Font-Names="Lucida Calligraphy" MaxLength="20"></asp:TextBox>
        <asp:TextBox ID="passtxt" placeholder="Password" runat="server" style="top: 550px; left: 567px; position: absolute; height: 31px; width: 260px" Font-Names="Lucida Calligraphy" TextMode="Password"></asp:TextBox>
        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Emailtxtbox" ErrorMessage="* Enter E-mail id" style="top: 323px; left: 840px; position: absolute; height: 18px; width: 162px" Font-Names="Arial" Font-Size="Small" Font-Italic="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Phonetxtbox" ErrorMessage="* Enter Phone Number" style="top: 375px; left: 840px; position: absolute; height: 18px; width: 162px" Font-Names="Arial" Font-Size="Small" Font-Italic="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="fnametxtbox" ErrorMessage="* Enter First Name" style="top: 438px; left: 842px; position: absolute; height: 18px; width: 162px" Font-Names="Arial" Font-Size="Small" Font-Italic="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="lnametxtbox" ErrorMessage="* Enter Last Name" style="top: 498px; left: 841px; position: absolute; height: 18px; width: 162px" Font-Names="Arial" Font-Size="Small" Font-Italic="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="passtxt" ErrorMessage="* Enter Password" style="top: 559px; left: 840px; position: absolute; height: 18px; width: 162px" Font-Names="Arial" Font-Size="Small" Font-Italic="True"></asp:RequiredFieldValidator>
        
            
        
            </div>


        <asp:Label ID="signuplabel" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Lucida Calligraphy" ForeColor="Black" style="top: 159px; left: 653px; position: absolute; height: 17px; width: 130px" Text="Sign Up"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:RequiredFieldValidator ID="usernamevalid" runat="server" ControlToValidate="username" ErrorMessage="* Enter UserName" Font-Italic="True" Font-Names="Arial" Font-Size="Small" style="top: 257px; left: 840px; position: absolute; height: 18px; width: 162px"></asp:RequiredFieldValidator>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/dthumb.gif" style="top: 177px; left: 39px; position: absolute; height: 431px; width: 466px" />


        <asp:Label ID="divOutput" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Lucida Calligraphy" ForeColor="Black" style="top: 254px; left: 840px; position: absolute; height: 23px; width: 264px" Font-Size="Small"></asp:Label>
        <asp:TextBox ID="username" placeholder="UserName" runat="server" style="top: 250px; left: 567px; position: absolute; height: 31px; width: 260px" Font-Names="Lucida Calligraphy"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionofphone" runat="server" ValidationExpression="^(\([0-9]{3}\)|[0-9]{3}-)[0-9]{3}-[0-9]{4}|(\([0-9]{3}\)|[0-9]{3})[0-9]{3}[0-9]{4}$" ErrorMessage="* Enter 10 digits" style="top: 375px; left: 841px; position: absolute; height: 18px; width: 195px" ControlToValidate="Phonetxtbox"></asp:RegularExpressionValidator>    
    </form>
        
</body>
</html>
