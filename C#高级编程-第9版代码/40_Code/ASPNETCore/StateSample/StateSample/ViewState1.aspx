<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState1.aspx.cs" Inherits="StateSample.ViewState1" %>

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
      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
      <br />
      <br />
      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
      <br />
      <br />
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
