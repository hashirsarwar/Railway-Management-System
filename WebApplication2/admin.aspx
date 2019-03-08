<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication2.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form class="text-center" runat="server">
        <br />
        <h1>Welcome to admin panel</h1>
        <br /><br />
    <asp:Button class="btn btn-primary btn-lg"   Text="Add ticket type" runat="server" OnClick="Unnamed1_Click" /><br /><br />
    <asp:Button class="btn btn-primary btn-lg" Text="Add Train" runat="server" OnClick="Unnamed2_Click" /><br /><br />
    <asp:Button class="btn btn-primary btn-lg" Text="Add Route" runat="server" OnClick="Unnamed3_Click" /><br /><br />
    <asp:Button  class="btn btn-primary btn-lg" Text="View Users" runat="server" OnClick="Unnamed4_Click" /><br /><br />
        <asp:Button class="btn btn-primary btn-lg" Text="Logout" runat="server" OnClick="Unnamed5_Click" />

    </form>
</body>
</html>
