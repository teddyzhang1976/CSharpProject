<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieWrite.aspx.cs" Inherits="StateSample.CookieWrite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <br />
      <br />
      <br />
      <asp:CheckBox ID="CheckBox1" runat="server" />Persistent?
      <br />
      <br />
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
