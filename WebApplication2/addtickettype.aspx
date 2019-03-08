<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtickettype.aspx.cs" Inherits="WebApplication2.asstickettype" %>

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
            <asp:Label Text="Enter ticket type" runat="server"></asp:Label>
            <asp:TextBox ID="tb1" runat="server"></asp:TextBox>
            <asp:Button runat="server" Text="Enter" OnClick="Unnamed3_Click"/>
        </div>
    </form>
</body>
</html>
