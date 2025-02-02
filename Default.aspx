<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Login_Form._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 300px; margin: 0 auto; padding-top: 50px;">
            <h2>Registration Form</h2>

            <div> 
                <label for="txtUsername">Username : </label>
                <asp:TextBox ID="txtUsername" runat="server" Width="200px" RequiredFieldValidator1="true"></asp:TextBox>
            </div>

            <div>
                <label for="txtPassword">Password : </label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px" RequiredFieldValidator2="true"></asp:TextBox>
            </div>

            <div>
                <label for="txtDisplayName">Display Name : </label>
                <asp:TextBox ID="txtDisplayName" runat="server" Width="200px" RequiredFieldValidator3="true"> </asp:TextBox>
            </div>

            <div>
                <label for="ddlUserType">User Type : </label>
                <asp:DropDownList ID="ddlUserType" runat="server" Width="200px">
                <asp:ListItem Text="Student" Value="1"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div>
                <asp:Button ID="btnSubmit" runat="server" Text="Register" />
            </div>
        </div>
    </form>

            <center>
                <asp:Table ID="Table1" runat="server">
                </asp:Table>
            </center>
</body>
</html>
