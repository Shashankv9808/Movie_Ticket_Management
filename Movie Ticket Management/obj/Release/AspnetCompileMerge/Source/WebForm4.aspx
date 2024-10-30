<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Movie_Ticket_Management.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
 function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return true;    
         return false;
      }</script>
    </head>
<body >
    <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
        </asp:DropDownList>

        <asp:TextBox ID="cvvtxt" onkeypress="return isNumberKey(event)"runat="server" TextMode="SingleLine" placeholder="CVV"></asp:TextBox>
    </form>

    </body>
</html>
