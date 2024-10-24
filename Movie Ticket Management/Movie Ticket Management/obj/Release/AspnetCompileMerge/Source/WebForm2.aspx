<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Movie_Ticket_Management.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .overlay 
{
 position: absolute;
 background-color: white;
 top: 0px;
 left: 0px;
 width: 100%;
 height: 100%;
 opacity: 0.8;
 -moz-opacity: 0.8;
 filter: alpha(opacity=80);
 -ms-filter: "progid:DXImageTransform.Microsoft.Alpha(Opacity=80)";
 z-index: 10000;
}
    </style>
</head>
<body CssClass="overlay" background="Black-Wallpapers.jpg" style="margin:0px auto 0px auto;width:100%;height:100%;">
    <form id="form1" runat="server">
        <div style="background-color:#f2f2f2;height:333px; width:40%; top: 49px; left: 68px; position: absolute;">
            <asp:Image ID="Image1" Height="156%" Width="145%" runat="server" />
        </div>
    </form>
</body>
</html>
