<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtrain.aspx.cs" Inherits="WebApplication2.addtrain" %>

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
            <asp:Label ID="Label1" Text="Train Number" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
            <br />

            <asp:Label ID="Label2" Text="Available Seats" runat="server"></asp:Label>
            <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
            <br />

            <asp:Label ID="Label3" Text="Pickup Date" runat="server"></asp:Label>
            <asp:TextBox placeholder="dd/mm/yyyy" runat="server" ID="TextBox3"></asp:TextBox>
            <br />

            <asp:Label ID="Label4" Text="Pickup Time" runat="server"></asp:Label>
            <asp:TextBox placeholder="hh:mm" runat="server" ID="TextBox4"></asp:TextBox>
            <br />

            <asp:Label ID="Label5" Text="Route" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
            <br />

            <asp:Button Text="Enter" runat="server" ID="Button1" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
