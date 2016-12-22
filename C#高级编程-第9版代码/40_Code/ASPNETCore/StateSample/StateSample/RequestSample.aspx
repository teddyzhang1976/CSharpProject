<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestSample.aspx.cs" Inherits="StateSample.RequestSample" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
      <br />
      <br />
      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    </div>
    </form>
</body>
</html>
