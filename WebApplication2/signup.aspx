<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="WebApplication2.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <link rel = "stylesheet" type = "text/css" href = "ss.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body>


    <!--Home Sections-->
        <script>
            function reg() {
                var name = document.getElementById('name').value;
                var id = document.getElementById('cnic').value;
                var age = document.getElementById('age').value;
                var ph = document.getElementById('phone').value;
                var pas = document.getElementById('pass').value;
                if (id == '' || pas == '' || age == '' || ph == '' || pas == '') {
                    window.alert("Write all fields");
                    return false;
                }
                else
                    return true;
            }
        </script>  
    <form runat="server">    
    <div>
            <h3><strong>REGISTER YOURSELF AS PAKISTAN RAILWAYS PASSENGER</strong></h3> 
        </div>
        <div>
            <label for="uname">Username</label>
            <asp:TextBox id="uname" runat="server" />
            <br/>
            <label for="fname">First Name</label>
            <asp:TextBox id="fname" runat="server" />
            <br/>
            <label for="lname">Last Name</label>
            <asp:TextBox id="lname" runat="server" />
            <br/>
            <label for="pass">Password</label>
            <asp:TextBox id="pass" runat="server" TextMode="Password" />
            <br />
            <label for="cnic">CNIC</label>
            <asp:TextBox id="cnic" runat="server"/>
            <br/>
                <label for="gender">Gender</label>
                <asp:RadioButtonList ID="gender" runat="server" RepeatLayout="Flow">
                <asp:ListItem Value="m">Male</asp:ListItem>
                <asp:ListItem Value="f">Female</asp:ListItem>
                </asp:RadioButtonList>
            <br />
            <label for="age" >Age</label>
            <asp:TextBox id="age" runat="server" />
            <br />
            <label for="phone" >Phone Number</label>
            <asp:TextBox id="phone" runat="server" />
            <br />
            


        </div>
        <div >
           <asp:Button id="Button1" OnClientClick="return reg()" OnClick="Btn_Click"  runat="server" Text="Submit"/>
        </div>
        </form>
        
</body>
</html>
