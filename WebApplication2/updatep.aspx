<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatep.aspx.cs" Inherits="WebApplication2.updatep" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter existing password"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter new password"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br />
            <asp:Button Text="Update" runat="server" OnClick="Unnamed1_Click" />
        </div>
    </form>
</body>
</html>
