<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminmovies.aspx.cs" Inherits="Movie_Ticket_Management.adminmovies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body background="Black-Wallpapers.jpg" style="margin:0px auto 0px auto;width:100%;height:100%;">
    <form id="form1" runat="server">
        <div style="height: 744px; width: 1355px">
            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" style="top: 145px; left: 40px; position: absolute; height: 42px; width: 469px" />
            <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" style="top: 144px; left: 628px; position: absolute; height: 40px; width: 545px" />
        </div>
    </form>
</body>
</html>
