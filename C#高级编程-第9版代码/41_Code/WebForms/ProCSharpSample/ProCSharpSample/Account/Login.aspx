<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProCSharpSample.Secure.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="loginForm" runat="server">
        <div>
            <asp:Label Text="Username:" AssociatedControlID="textUsername" runat="server" />
            <asp:TextBox ID="textUsername" runat="server" /><br />
            <asp:Label Text="Password:" AssociatedControlID="textPassword" runat="server" />
            <asp:TextBox TextMode="Password" ID="textPassword" runat="server" />
            <br />
            <asp:Button Text="Login" OnClick="OnLogin" runat="server" />
            <br />
        </div>

    </form>
    <asp:Label ID="StatusText" runat="server"></asp:Label>
</body>
</html>
