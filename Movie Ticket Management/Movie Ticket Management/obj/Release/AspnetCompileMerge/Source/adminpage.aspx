<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="Movie_Ticket_Management.adminpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div{width:100%;height:auto;}
        .css
        {
border:0;
  background: none;
  display: block;
  margin: 20px auto;
  float:left;
  text-align: center;
  border: 2px solid #3498db;
  padding: 14px 10px;
  width: 200px;
  outline: none;
  color: white;
  border-radius: 24px;
  background-color:dodgerblue;
  transition: 0.35s;
  vertical-align:middle;
}
.css:hover{
width:20%;
transform: scale(1.5);
}
        .auto-style1 {
            top: 18px;
            left: 1184px;
            position: absolute;
        }
        .auto-style2 {
            width: 41%;
            height: 306px;
            position: absolute;
            top: 272px;
            left: 437px;
            margin-right: 0px;
        }
        .auto-style3 {
            width: 223px;
        }
        .auto-style4 {
            width: 223px;
            height: 50px;
        }
        .auto-style5 {
            height: 50px;
        }
    </style>
</head>
<body style="margin:0px auto 0px auto;width:100%;height:100%;background-image:url('/images/Black-Wallpapers.jpg');">
    <form id="form1" runat="server">
        <div style="height: 163px">
            <asp:Image ID="Image4" runat="server" ImageUrl="~/images/admin.png" style="top: 2px; left: 14px; position: absolute; height: 186px; width: 1354px" />
        </div>

            <asp:Image ID="Image2" runat="server" Height="183px" ImageUrl="~/images/LOL-GIF-Image-for-Whatsapp-and-Facebook-32.gif" Width="165px" style="top: 16px; left: 11px; position: absolute" />
            <asp:Image ID="Image3" runat="server" Height="183px" ImageUrl="~/images/LOL-GIF-Image-for-Whatsapp-and-Facebook-32.gif" Width="165px " CssClass="auto-style1" />
            <br />
            <br />
            <br />
            <br />
            <br />
        <div>
    <div><a href="adminuserview.aspx" class="css">Uers</a><br />
        <br />
        <br />
        <br />
        <br />
       <a href="adminmovie.aspx" class="css">Movie</a>
        <br />
        <br />
        <br />
        <br />
        <br />
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="#00CC00" Text="No of Users:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="#990099"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="#00CC00" Text="No of Online:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="#990099"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="#00CC00" Text="No of Movies:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="#990099"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="#00CC00" Text="No of Booked Tickets:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="#990099"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="#00CC00" Text="No of Payment:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="#990099"></asp:Label>
                    </td>
                </tr>
        </table>
            </div>
    <div><a href="bookedrepo.aspx" class="css">Booked</a><br />
        <br />
        <br />
        <br />
        <br />
            </div>
    <div><a href="admincomplaints.aspx" class="css">Complaints</a><br />
        <br />
        <br />
        <br />
        <br />
            </div>

</div>
    </form>
</body>
</html>
