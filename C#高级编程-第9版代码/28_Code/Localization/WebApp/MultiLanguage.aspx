<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiLanguage.aspx.cs" Inherits="WebApp.MultiLanguage" Culture="auto" UICulture="auto" meta:resourcekey="PageResource1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <asp:Label ID="Label1" runat="server" Text="Label" meta:resourcekey="Label1Resource1"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" meta:resourcekey="Button1Resource1" />

            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Messages, Greeting %>" meta:resourcekey="Label2Resource1"></asp:Label>

            <br />
            <br />

        </div>
    </form>
</body>
</html>
