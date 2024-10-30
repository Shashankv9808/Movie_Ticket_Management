<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmovie.aspx.cs" Inherits="Movie_Ticket_Management.addmovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script> function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;    
         return true;
      }</script>
    <style type="text/css">
        #Button1{border-radius:12px;}
        .auto-style1 {
            height: 465px;
            width: 46%;
            top: 42px;
            left: 40px;
            position: absolute;
            margin-right: 0px;
            background:linear-gradient(90deg,rgba(119, 238, 238, 0.85),gray,rgba(88, 79, 79, 0.64),#394452);
            color:black;
        }
        .auto-style3 {
            height: 22px;
            width: 128px;
            top: 146px;
            left: 298px;
            position: absolute;
        }
        .auto-style4 {
            height: 15px;
            width: 141px;
            top: 380px;
            left: 325px;
            position: absolute;
        }
        .auto-style5 {
            height: 34px;
            width: 231px;
            top: 422px;
            left: 94px;
            position: absolute;
        }
        .auto-style6 {
            width: 574px;
            height: 465px;
            position: absolute;
            top: 43px;
            left: 711px;
            margin-right: 0px;
            background:linear-gradient(90deg,rgba(119, 238, 238, 0.85),gray,rgba(88, 79, 79, 0.64),#394452);
            color:black;
            }
        .auto-style7 {
            width: 253px;
            height: 39px;
            position: absolute;
            left: 214px;
            top: 14px;
        }
        .auto-style8 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 18px;
            top: 353px;
        }
        .auto-style9 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 17px;
            top: 70px;
        }
        .auto-style10 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 15px;
            top: 116px;
        }
        .auto-style11 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 19px;
            top: 201px;
        }
        .auto-style12 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 19px;
            top: 239px;
        }
        .auto-style13 {
            width: 136px;
            height: 23px;
            position: absolute;
            left: 17px;
            top: 276px;
        }
        .auto-style14 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 17px;
            top: 316px;
        }
        .auto-style15 {
            width: 136px;
            height: 22px;
            position: absolute;
            left: 20px;
            top: 160px;
        }
        .auto-style16 {
            width: 136px;
            height: 19px;
            position: absolute;
            left: 15px;
            top: 394px;
        }
        .auto-style17 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 164px;
            top: 68px;
            bottom: 369px;
        }
        .auto-style18 {
            height: 17px;
            width: 24%;
            top: 150px;
            left: 74px;
            position: absolute;
        }
        .auto-style19 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 164px;
            top: 108px;
            right: 274px;
        }
        .auto-style20 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 164px;
            top: 154px;
        }
        .auto-style21 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 165px;
            top: 193px;
        }
        .auto-style22 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 164px;
            top: 234px;
        }
        .auto-style23 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 164px;
            top: 270px;
        }
        .auto-style24 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 163px;
            top: 313px;
        }
        .auto-style25 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 162px;
            top: 351px;
        }
        .auto-style26 {
            width: 128px;
            height: 22px;
            position: absolute;
            left: 161px;
            top: 390px;
        }
        .auto-style27 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 329px;
            top: 74px;
        }
        .auto-style28 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 330px;
            top: 113px;
        }
        .auto-style29 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 330px;
            top: 160px;
        }
        .auto-style30 {
            position: absolute;
            left: 330px;
            top: 200px;
        }
        .auto-style31 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 330px;
            top: 241px;
        }
        .auto-style32 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 330px;
            top: 276px;
        }
        .auto-style33 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 331px;
            top: 317px;
        }
        .auto-style34 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 329px;
            top: 354px;
        }
        .auto-style35 {
            width: 141px;
            height: 19px;
            position: absolute;
            left: 328px;
            top: 396px;
        }
        .auto-style36 {
            width: 142px;
            height: 29px;
            position: absolute;
            left: 401px;
            top: 187px;
        }
        .auto-style37 {
            height: 19px;
            width: 13px;
            top: 76px;
            left: 500px;
            position: absolute;
        }
        .auto-style38 {
            width: 73px;
            height: 49px;
            position: absolute;
            top: 224px;
            left: 635px;
        }
        .auto-style41 {
            height: 22px;
            width: 128px;
            top: 300px;
            left: 317px;
            position: absolute;
            right: 100px;
        }
        .auto-style43 {
            height: 20px;
            width: 100px;
            top: 306px;
            left: 217px;
            position: absolute;
        }
        .auto-style45 {
            height: 22px;
            width: 217px;
            top: 377px;
            left: 52px;
            position: absolute;
        }
        .auto-style46 {
            width: 72px;
            height: 19px;
            position: absolute;
            top: 347px;
            left: 180px;
        }
        .auto-style47 {
            width: 77px;
            height: 22px;
            position: absolute;
            top: 343px;
            left: 284px;
        }
        .auto-style48 {
            width: 72px;
            height: 21px;
            position: absolute;
            left: 375px;
            top: 70px;
        }
        .auto-style49 {
            height: 22px;
            width: 135px;
            top: 294px;
            left: 70px;
            position: absolute;
        }
        .auto-style50 {
            height: 18px;
            width: 58px;
            top: 251px;
            left: 2px;
            position: absolute;
        }
        .auto-style51 {
            height: 18px;
            width: 58px;
            top: 299px;
            left: 3px;
            position: absolute;
        }
        .auto-style52 {
            height: 16px;
            width: 10px;
            top: 299px;
            left: 58px;
            position: absolute;
        }
        .auto-style53 {
            width: 96px;
            height: 21px;
            position: absolute;
            top: 302px;
            left: 458px;
        }
        .auto-style54 {
            width: 109px;
            height: 23px;
            position: absolute;
            top: 383px;
            left: 436px;
        }
    </style>
</head>
<body style="margin:0px auto 0px auto;width:100%;height:100%;background-image:url('/images/Black-Wallpapers.jpg');">
    <form id="form1" runat="server">
        <div class="auto-style1" >          
<br /><br />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" style="border-radius:12px;" CssClass="auto-style5" Font-Bold="True" Font-Italic="True" Font-Names="Blackadder ITC" Font-Size="X-Large" Font-Underline="True" ValidationGroup="Validate" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nametxt" ErrorMessage="*" ForeColor="Red" style="height: 16px; width: 14px; top: 79px; left: 226px; position: absolute; " ValidationGroup="Validate" BackColor="Transparent"> </asp:RequiredFieldValidator>
<br /><br />
<asp:Label ID="lblMessage" runat="server" style="height: 19px; width: 135px; top: 385px; left: 68px; position: absolute; "  BackColor="Transparent"></asp:Label>
            <asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Names="Eras Demi ITC" Font-Size="Large" Text="Name"></asp:Label>
            <asp:Label ID="Label11" runat="server" Font-Bold="False" Font-Italic="True" Font-Names="Eras Demi ITC" Font-Size="Large" style="height: 19px; width: 74px; top: 77px; left: 257px; position: absolute; " Text="Duration" BackColor="Transparent"></asp:Label>
            <asp:TextBox ID="durationtxt" runat="server" placeholder="in hrs" style="height: 22px; width: 148px; top: 74px; left: 343px; position: absolute; " BackColor="Transparent" BorderColor="White" onkeypress="return isNumberKey(event)" MaxLength="2"
></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="durationtxt" ErrorMessage="*" ForeColor="Red" ValidationGroup="Validate" BackColor="Transparent" CssClass="auto-style37"></asp:RequiredFieldValidator>
<br /><br />
<asp:HyperLink ID="hyperlink" runat="server" style="height: 19px; width: 137px; top: 379px; left: 313px; position: absolute;"  BackColor="Transparent">View Uploaded Image</asp:HyperLink>
            <asp:FileUpload ID="FileUpload1" runat="server" style="background-color: #f2f2f2" CssClass="auto-style45" />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Lucida Calligraphy" Font-Size="Larger" style="height: 36px; width: 231px; top: 9px; left: 113px; position: absolute; text-decoration: underline; margin-top: 0px;" Text="ADD MOVIE"  BackColor="Transparent"></asp:Label>
            <asp:TextBox ID="nametxt" runat="server" style="height: 14px; width: 128px; top: 80px; left: 76px; position: absolute; bottom: 367px;" BackColor="Transparent" BorderColor="White"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="herointxt" ErrorMessage="*" ForeColor="Red" style="height: 12px; width: 8px; top: 201px; left: 63px; position: absolute; right: 384px; bottom: 254px;" ValidationGroup="Validate" BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:Label ID="Label12" runat="server" style="height: 19px; width: 63px; top: 97px; left: 260px; position: absolute;" Text="(In Hrs)" BackColor="Transparent"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Italic="True" Font-Names="eras demi itc, large" Font-Size="Large" style="height: 21px; width: 52px; top: 146px; left: 1px; position: absolute;" Text="Hero" BackColor="Transparent"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Italic="True" Font-Names="eras demi itc, large" Font-Size="Large" style="height: 21px; width: 42px; top: 117px; left: 105px; position: absolute;" Text="Cast" BackColor="Transparent"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="herotxt" ErrorMessage="*" ForeColor="Red" style="height: 19px; width: 8px; top: 149px; left: 51px; position: absolute;" ValidationGroup="Validate" BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:TextBox ID="herotxt" runat="server" BackColor="Transparent" BorderColor="White" CssClass="auto-style18"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Font-Italic="True" Font-Names="eras demi itc, large" Font-Size="Large" style="height: 19px; width: 43px; top: 198px; left: 2px; position: absolute;" Text="Heroin" BackColor="Transparent"></asp:Label>
            <asp:TextBox ID="herointxt" runat="server" style="height: 22px; width: 128px; top: 195px; left: 74px; position: absolute;" BackColor="Transparent" BorderColor="White"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Font-Italic="True" Font-Names="eras demi itc, large" Font-Size="Large" style="height: 19px; width: 34px; top: 150px; left: 224px; position: absolute;" Text="Director" BackColor="Transparent"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="directortxt" runat="server" CssClass="auto-style3" BackColor="Transparent" BorderColor="White"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="storytxt" runat="server" Font-Italic="True" Font-Names="eras demi itc,large" Font-Size="Large" style="height: 13px; width: 72px; top: 199px; left: 215px; position: absolute;" Text="Story By" BackColor="Transparent"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ForeColor="Red" style="height: 16px; width: 15px; top: 199px; left: 439px; position: absolute;" ValidationGroup="Validate"  BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" ErrorMessage="* Enter the image" ForeColor="Red"  ValidationGroup="Validate" CssClass="auto-style4"  BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:Label ID="Label7" runat="server" Font-Italic="True" Font-Names="Eras Demi ITC" Font-Size="Large" Text="Gener"  BackColor="Transparent" CssClass="auto-style50"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="genertxt" ErrorMessage="*" ForeColor="Red" style="height: 18px; width: 12px; top: 248px; left: 56px; position: absolute; right: 387px;" ValidationGroup="Validate"  BackColor="Transparent"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="TextBox5" runat="server" style="height: 22px; width: 128px; top: 194px; left: 296px; position: absolute; float: left;"  BackColor="Transparent" BorderColor="White"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="directortxt" ErrorMessage="*" ForeColor="Red" style="height: 16px; width: 13px; top: 151px; left: 440px; position: absolute; bottom: 300px;" ValidationGroup="Validate" BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:TextBox ID="genertxt" runat="server" style="height: 22px; width: 128px; top: 246px; left: 72px; position: absolute;"  BackColor="Transparent" BorderColor="White" MaxLength="2"></asp:TextBox>
            <asp:TextBox ID="ratingtxt" runat="server" onkeypress="return isNumberKey(event)" style="height: 22px; width: 128px; top: 248px; left: 295px; position: absolute;" MaxLength="2"  BackColor="Transparent" BorderColor="White"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ratingtxt" ErrorMessage="*" ForeColor="Red" style="height: 19px; width: 8px; top: 250px; left: 439px; position: absolute;" ValidationGroup="Validate"  BackColor="Transparent"></asp:RequiredFieldValidator>
            <asp:Label ID="Label8" runat="server" Font-Italic="True" Font-Names="Eras Demi ITC" Font-Size="Large" style="height: 17px; width: 71px; top: 251px; left: 213px; position: absolute;" Text="Rating" BackColor="Transparent"></asp:Label>
            <asp:Label ID="Label9" runat="server" Font-Italic="True" Font-Names="Eras Demi ITC" Font-Size="Large" Text="Date(using /)" BackColor="Transparent" CssClass="auto-style43"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="costtxt" ErrorMessage="*" ForeColor="Red" ValidationGroup="Validate"  BackColor="Transparent" CssClass="auto-style52"></asp:RequiredFieldValidator>
            <asp:TextBox ID="costtxt" runat="server" MaxLength="3" onkeypress="return isNumberKey(event)" BackColor="Transparent" BorderColor="White"  CssClass="auto-style49"
></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server"  BackColor="Transparent" BorderColor="White" CssClass="auto-style41"></asp:TextBox>
            <asp:Label ID="Label26" runat="server" CssClass="auto-style46" Text="Time"></asp:Label>
            <asp:Label ID="Label28" runat="server" CssClass="auto-style53" Text="eg:02/05/2019"></asp:Label>
            <asp:Label ID="Label27" runat="server" Text="Cost" CssClass="auto-style51"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style47">
                <asp:ListItem Selected="True" Value="11">11AM</asp:ListItem>
                <asp:ListItem Value="12">12PM</asp:ListItem>
                <asp:ListItem Value="1">1PM</asp:ListItem>
                <asp:ListItem Value="2">2PM</asp:ListItem>
                <asp:ListItem Value="3">3PM</asp:ListItem>
                <asp:ListItem Value="4">4PM</asp:ListItem>
                <asp:ListItem Value="5">5PM</asp:ListItem>
                <asp:ListItem Value="6">6PM</asp:ListItem>
                <asp:ListItem Value="7">7PM</asp:ListItem>
                <asp:ListItem Value="8">8PM</asp:ListItem>
                <asp:ListItem Value="9">9PM</asp:ListItem>
                <asp:ListItem Value="10">10PM</asp:ListItem>
            </asp:DropDownList>
        </div>
        <p>
            &nbsp;</p>
        <div class="auto-style6">

            <asp:Label ID="Label13" runat="server" CssClass="auto-style7" Font-Bold="True" Font-Italic="True" Font-Names="Lucida Calligraphy" Font-Size="Large" Font-Underline="True" Text="Update"></asp:Label>

            <asp:Label ID="Label17" runat="server" CssClass="auto-style9" Font-Names="Eras Demi ITC">Movie Name</asp:Label>
            <asp:Label ID="Label18" runat="server" CssClass="auto-style10" Font-Names="Eras Demi ITC">Hero</asp:Label>
            <asp:Label ID="Label19" runat="server" CssClass="auto-style11" Font-Names="Eras Demi ITC">Director</asp:Label>
            <asp:Label ID="Label20" runat="server" CssClass="auto-style15" Font-Names="Eras Demi ITC">Heroin</asp:Label>
            <asp:Label ID="Label21" runat="server" CssClass="auto-style12" Font-Names="Eras Demi ITC">Story</asp:Label>
            <asp:Label ID="Label22" runat="server" CssClass="auto-style13" Font-Names="Eras Demi ITC">Gener</asp:Label>
            <asp:Label ID="Label23" runat="server" CssClass="auto-style14" Font-Names="Eras Demi ITC">Cost</asp:Label>
            <asp:Label ID="Label24" runat="server" CssClass="auto-style8" Font-Names="Eras Demi ITC">Rating</asp:Label>
            <asp:Label ID="Label25" runat="server" CssClass="auto-style16" Font-Names="Eras Demi ITC">Duration</asp:Label>
            <asp:TextBox ID="movienametxt" runat="server" CssClass="auto-style17" BackColor="Transparent" BorderColor="White"></asp:TextBox>

            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False">

                 <asp:TextBox ID="heronametxt" runat="server" CssClass="auto-style19" BackColor="Transparent" BorderColor="White"></asp:TextBox>

            <asp:TextBox ID="heroinnametxt" runat="server" CssClass="auto-style20" BackColor="Transparent" BorderColor="White"></asp:TextBox>


            <asp:TextBox ID="directornamttxt" runat="server" CssClass="auto-style21" BackColor="Transparent" BorderColor="White"></asp:TextBox>

            <asp:TextBox ID="storybytxt" runat="server" CssClass="auto-style22" BackColor="Transparent" BorderColor="White"></asp:TextBox>

            <asp:TextBox ID="gener2txt" runat="server" CssClass="auto-style23" BackColor="Transparent"  BorderColor="White" MaxLength="2"></asp:TextBox>

            <asp:TextBox ID="cost2txt" runat="server" CssClass="auto-style24" onkeypress="return isNumberKey(event)"  BackColor="Transparent" BorderColor="White" TextMode="Number" 
 MaxLength="3"></asp:TextBox>

            <asp:TextBox ID="rating2txt" runat="server" CssClass="auto-style25" onkeypress="return isNumberKey(event)" BackColor="Transparent" BorderColor="White" TextMode="Number" 
 MaxLength="3"></asp:TextBox>

            <asp:TextBox ID="duration2txt" runat="server" CssClass="auto-style26" onkeypress="return isNumberKey(event)" BackColor="Transparent" BorderColor="White" TextMode="Number" 
 MaxLength="2"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="auto-style27" ErrorMessage="*" BackColor="Transparent" ControlToValidate="movienametxt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="auto-style28" ErrorMessage="*" BackColor="Transparent" ControlToValidate="heroinnametxt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="auto-style29" ErrorMessage="*" BackColor="Transparent" ControlToValidate="heroinnametxt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="auto-style30" ErrorMessage="*" BackColor="Transparent" ControlToValidate="directornamttxt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" CssClass="auto-style31" ErrorMessage="*" BackColor="Transparent" ControlToValidate="storybytxt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" CssClass="auto-style32" ErrorMessage="*" BackColor="Transparent" ControlToValidate="gener2txt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" CssClass="auto-style33" ErrorMessage="*" BackColor="Transparent" ControlToValidate="cost2txt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" CssClass="auto-style34" ErrorMessage="*" BackColor="Transparent" ControlToValidate="rating2txt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>


            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" CssClass="auto-style35" ErrorMessage="*" BackColor="Transparent" ControlToValidate="duration2txt" ForeColor="Red" ValidationGroup="updatevalid"></asp:RequiredFieldValidator>

            </asp:PlaceHolder>

            <asp:Button ID="Button1" runat="server" CssClass="auto-style36" Font-Bold="True" Font-Italic="True" Font-Names="Blackadder ITC" Font-Size="X-Large" Font-Underline="True" Text="Update" OnClick="Button1_Click" ValidationGroup="updatevalid" />


            <asp:Button ID="Button2" runat="server" CssClass="auto-style48" OnClick="Button2_Click" Text="Button" />


        </div>
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style38" ImageUrl="~/images/back.jpg" OnClick="ImageButton1_Click" />
        <asp:Label ID="Label29" runat="server" CssClass="auto-style54" ForeColor="Red" Text="Enter Valid Date" Visible="False"></asp:Label>
    </form>
</body>
</html>
