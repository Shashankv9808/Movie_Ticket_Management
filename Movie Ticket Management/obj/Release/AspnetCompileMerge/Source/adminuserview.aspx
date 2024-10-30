<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminuserview.aspx.cs" Inherits="Movie_Ticket_Management.adminuserview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            top: 139px;
            left: 210px;
            position: absolute;
            height: 292px;
            width: 858px;
        }
        .auto-style2 {
            width: 67px;
            height: 42px;
            position: absolute;
            left: 1144px;
            top: 44px;
        }
    </style>
</head>
<body style="margin:0px auto 0px auto;width:100%;height:100%;background-image:url('/images/Black-Wallpapers.jpg');text-align:center;">
    <form id="form1" runat="server">
        <div style="height: 617px; width: 1366px">
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="Red" CssClass="auto-style1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                    <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                    <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
                    <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:movieConnectionString %>" SelectCommand="SELECT * FROM [register]"></asp:SqlDataSource>
            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style2" OnClick="ImageButton1_Click" ImageUrl="~/images/back.jpg" />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Engravers MT" Font-Size="X-Large" ForeColor="Lime" style="top: 48px; left: 315px; position: absolute; height: 61px; width: 488px" Text="No. of User And Details"></asp:Label>
        </div>
    </form>
</body>
</html>
