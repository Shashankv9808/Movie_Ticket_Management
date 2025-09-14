<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="moviereop.aspx.cs" Inherits="Movie_Ticket_Management.moviereop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1018px;
            height: 304px;
            position: absolute;
            top: 142px;
            left: 113px;
        }
    </style>
</head>
<body style="margin:0px auto 0px auto;width:100%;height:100%;background-image:url('/images/Black-Wallpapers.jpg');text-align:center;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Engravers MT" Font-Size="X-Large" ForeColor="Lime" style="top: 48px; left: 315px; position: absolute; height: 61px; width: 488px" Text="No. of User And Details"></asp:Label>
       
            </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="auto-style1" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="Red">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="hero" HeaderText="hero" SortExpression="hero" />
                <asp:BoundField DataField="heroin" HeaderText="heroin" SortExpression="heroin" />
                <asp:BoundField DataField="director" HeaderText="director" SortExpression="director" />
                <asp:BoundField DataField="story" HeaderText="story" SortExpression="story" />
                <asp:BoundField DataField="gener" HeaderText="gener" SortExpression="gener" />
                <asp:BoundField DataField="cost" HeaderText="cost" SortExpression="cost" />
                <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                <asp:BoundField DataField="duration" HeaderText="duration" SortExpression="duration" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectString %>" DeleteCommand="DELETE FROM [movielist] WHERE [ID] = @ID" InsertCommand="INSERT INTO [movielist] ([Name], [hero], [heroin], [director], [story], [gener], [cost], [rating], [duration]) VALUES (@Name, @hero, @heroin, @director, @story, @gener, @cost, @rating, @duration)" SelectCommand="SELECT * FROM [movielist]" UpdateCommand="UPDATE [movielist] SET [Name] = @Name, [hero] = @hero, [heroin] = @heroin, [director] = @director, [story] = @story, [gener] = @gener, [cost] = @cost, [rating] = @rating, [duration] = @duration WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="hero" Type="String" />
                <asp:Parameter Name="heroin" Type="String" />
                <asp:Parameter Name="director" Type="String" />
                <asp:Parameter Name="story" Type="String" />
                <asp:Parameter Name="gener" Type="String" />
                <asp:Parameter Name="cost" Type="String" />
                <asp:Parameter Name="rating" Type="Decimal" />
                <asp:Parameter Name="duration" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="hero" Type="String" />
                <asp:Parameter Name="heroin" Type="String" />
                <asp:Parameter Name="director" Type="String" />
                <asp:Parameter Name="story" Type="String" />
                <asp:Parameter Name="gener" Type="String" />
                <asp:Parameter Name="cost" Type="String" />
                <asp:Parameter Name="rating" Type="Decimal" />
                <asp:Parameter Name="duration" Type="Decimal" />
                <asp:Parameter Name="ID" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="auto-style2" OnClick="ImageButton1_Click" ImageUrl="~/images/back.jpg" style="width: 78px; height: 48px; position: absolute; left: 1173px; top: 88px" />
            
    </form>
</body>
</html>
