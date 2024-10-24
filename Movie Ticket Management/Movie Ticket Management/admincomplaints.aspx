<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admincomplaints.aspx.cs" Inherits="Movie_Ticket_Management.admincomplaints" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1132px;
            height: 222px;
            position: absolute;
            top: 231px;
            left: 114px;
            margin-top:0;
        }
        .auto-style2 {
            top: 130px;
            left: 342px;
            position: absolute;
            height: 61px;
            width: 488px;
        }
    </style>
</head>
<body style="width:100%;height:100%;background-image:url('/images/Black-Wallpapers.jpg');text-align:center;>
        <form id="form1" runat="server">
        <div>
        </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style1" DataKeyNames="Id" DataSourceID="SqlDataSource1"  Font-Names="Bell MT" Font-Size="XX-Large" ForeColor="Red">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="feedback" HeaderText="feedback" SortExpression="feedback" />
                    <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:movieConnectionString %>" DeleteCommand="DELETE FROM [feedback] WHERE [Id] = @Id" InsertCommand="INSERT INTO [feedback] ([Username], [feedback], [date]) VALUES (@Username, @feedback, @date)" SelectCommand="SELECT * FROM [feedback]" UpdateCommand="UPDATE [feedback] SET [Username] = @Username, [feedback] = @feedback, [date] = @date WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="feedback" Type="String" />
                    <asp:Parameter Name="date" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Username" Type="String" />
                    <asp:Parameter Name="feedback" Type="String" />
                    <asp:Parameter Name="date" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </form>
            <p>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Engravers MT" Font-Size="X-Large" ForeColor="Lime" Text="FeedBack By Users" CssClass="auto-style2"></asp:Label>
            </p>
            </body>
</html>
