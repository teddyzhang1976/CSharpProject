<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
          User Name:
      <asp:TextBox Runat="server" ID="userNameBox" /><br />
      Password:
      <asp:TextBox Runat="server" ID="passwordBox" /><br />
      <asp:Button Runat="server" ID="loginButton" Text="Log in" 
              onclick="loginButton_Click" /><br />
      <asp:Label Runat="server" ID="tokenLabel" /><br />
      <asp:Button Runat="server" ID="invokeButton"
        Text="Invoke DoSomething()" onclick="invokeButton_Click" /><br />
      <asp:Label Runat="server" ID="resultLabel" /><br />
    </div>
    </form>
</body>
</html>
