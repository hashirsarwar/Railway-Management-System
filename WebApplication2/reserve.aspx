<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reserve.aspx.cs" Inherits="WebApplication2.reserve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <h1>Reserve your seat.</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Ticket class" ID="Label" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList" runat="server" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />

            <asp:Label Text="Pickup Date" ID="Label2" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />

            <asp:Label Text="Pickup Destination" ID="Label4" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />

            <asp:Label Text="Arrival Destination" ID="Label5" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />


            <asp:Label Text="Pickup Time" ID="Label3" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true"></asp:DropDownList>
            <br />

            <asp:Label Text="Seat No" ID="Label1" runat="server"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <br />
            <br />
            <asp:Button id="Button1" Text="Reserve Seat" runat="server" OnClick="Button1_Click"/>
        </div>
    </form>
</body>
</html>
