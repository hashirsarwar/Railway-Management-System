﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewRes.aspx.cs" Inherits="WebApplication2.viewRes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <form runat="server">
        <asp:GridView ID="GV" AutoGenerateColumns="false" runat="server" >
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Res ID"/>
                <asp:BoundField DataField="title" HeaderText="Ticket Class"/>
                <asp:BoundField DataField="train_id" HeaderText="Train ID"/>
                <asp:BoundField DataField="seat_no" HeaderText="Seat No"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
