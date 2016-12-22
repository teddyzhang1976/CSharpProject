<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ProCSharpSample.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Username:" AssociatedControlID="textUsername" runat="server" />
            <asp:TextBox ID="textUsername" runat="server" /><br />
            <asp:Label Text="Password:" AssociatedControlID="textPassword" runat="server" />
            <asp:TextBox TextMode="Password" ID="textPassword" runat="server" />
            <br />
            <asp:Button Text="Register" OnClick="OnRegister" runat="server" />
            <br />
        </div>
        <asp:Label ID="StatusText" runat="server"></asp:Label>
    </form>
</body>
</html>
