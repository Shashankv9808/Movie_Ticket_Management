<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminmovie.aspx.cs" Inherits="Movie_Ticket_Management.adminmovie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 340px;
            height: 120px;
            position: absolute;
            left: 794px;
            top: 198px;
        }
        .auto-style2 {
            width: 340px;
            height: 120px;
            position: absolute;
            left: 115px;
            top: 198px;
        }
        .auto-style3 {
            width: 303px;
            height: 44px;
            position: absolute;
            left: 129px;
            top: 126px;
        }
        .auto-style4 {
            width: 303px;
            height: 44px;
            position: absolute;
            left: 796px;
            top: 126px;
        }
        .auto-style5 {
            width: 70px;
            height: 45px;
            position: absolute;
            left: 1170px;
            top: 50px;
        }
    </style>
</head>
<body style="background-image:url('/images/Black-Wallpapers.jpg');text-align:center;">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style2" ImageUrl="~/images/addme.jpg" OnClick="ImageButton1_Click" />
        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="auto-style1" ImageUrl="~/images/reportlogo.jpg" OnClick="ImageButton2_Click" />
        <asp:Label ID="Label1" runat="server" CssClass="auto-style3" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="Red" Text="Add Movie"></asp:Label>
        <asp:Label ID="Label2" runat="server" CssClass="auto-style4" Text="Movie Report" Font-Names="Bell MT" Font-Size="XX-Large" Font-Underline="True" ForeColor="Red"></asp:Label>
        <asp:ImageButton ID="ImageButton3" runat="server" CssClass="auto-style5" ImageUrl="~/images/back.jpg" OnClick="ImageButton3_Click" />
    </form>
</body>
</html>
