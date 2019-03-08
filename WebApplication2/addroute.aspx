<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addroute.aspx.cs" Inherits="WebApplication2.addroute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Enter pickup destination" runat="server"></asp:Label>
            <asp:TextBox ID="tb1" runat="server"></asp:TextBox>
            <br />
            <asp:Label Text="Enter arrival destination" runat="server"></asp:Label>
            <asp:TextBox ID="tb2" runat="server"></asp:TextBox>
            <br />
            <asp:Button runat="server" Text="Enter" OnClick="Unnamed3_Click"/>
        </div>
    </form>
</body>
</html>
