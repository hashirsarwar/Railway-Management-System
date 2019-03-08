<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userPage.aspx.cs" Inherits="WebApplication2.userPage" %>

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
            <h1>Welcome, 
                <asp:Label ID="lb" runat="server"></asp:Label>
            </h1>
            
            <br /><br />
            <div class="text-center">
                <asp:Button class="btn btn-primary btn-lg" ID="addR" Text="Add reservation" runat="server" OnClick="addR_Click"/>
            </div>
            <br /><br />
            <div class="text-center">
                <asp:Button class="btn btn-primary btn-lg" ID="viewR" Text="View your reservations" runat="server" OnClick="viewR_Click"/>
            </div>
            <br /><br />
            <div class="text-center">
                <asp:Button class="btn btn-primary btn-lg" ID="Button2" Text="Delete reservation" runat="server" OnClick="del_Click"/>
            </div>
            <br /><br />
            <div class="text-center">
                <asp:Button class="btn btn-primary btn-lg" ID="Button1" Text="Logout" runat="server" OnClick="Button1_Click" />
            </div>
            <br /><br />
            <div class="text-center">
                <asp:Button class="btn btn-primary btn-lg" ID="Button3" Text="Update Password" runat="server" OnClick="Button3_Click" />
            </div>
        </div>
    </form>
</body>
</html>
