<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>
    <script>
        function validate() {
            var un = document.getElementById('login_uname').value;
            var pas = document.getElementById('login_pass').value;
            if (un == '' || pas == '') {
                window.alert("Write all fields");
                return false;
            }
            else
                return true;
            }
    </script>  
    <div class="text-center">
    <h1>Login to Railway Management System</h1><br /><br />
    <form class="form-group" id="form1" runat="server">
        <h4><div>
            <label>
                Enter Username
            </label>
            <asp:TextBox ID="login_uname" runat="server"></asp:TextBox>
            <br /><br />
            <label>
                Enter Password
            </label>
            <asp:TextBox ID="login_pass" runat="server" TextMode="Password"></asp:TextBox>
            <br /><br /><br />
            <asp:Button class="btn btn-primary btn-lg" ID="login_btn" Text="login" runat="server" OnClientClick="return validate()" OnClick="login_btn_Click"/>
        </div></h4>
    </form>
        </div>
</body>
</html>
