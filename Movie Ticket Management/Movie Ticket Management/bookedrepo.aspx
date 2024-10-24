<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bookedrepo.aspx.cs" Inherits="Movie_Ticket_Management.bookedrepo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 978px;
            height: 306px;
            position: absolute;
            top: 144px;
            left: 109px;
        }
        .auto-style2 {
            width: 80px;
            height: 46px;
            position: absolute;
            left: 1124px;
            top: 84px;
        }
    </style>
</head>
<body style="margin:0px auto 0px auto;width:100%;height:122px; background-image:url('/images/Black-Wallpapers.jpg');text-align:center;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Engravers MT" Font-Size="X-Large" ForeColor="Lime" style="top: 48px; left: 315px; position: absolute; height: 61px; width: 488px" Text="No. of User And Details"></asp:Label>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" DataKeyNames="Id" DataSourceID="SqlDataSource1" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="Red">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="seats" HeaderText="seats" SortExpression="seats" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:movieConnectionString %>" SelectCommand="SELECT * FROM [bookedinfo]"></asp:SqlDataSource>
        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style2" ImageUrl="~/images/back.jpg" OnClick="ImageButton1_Click" />
    </form>
</body>
</html>
