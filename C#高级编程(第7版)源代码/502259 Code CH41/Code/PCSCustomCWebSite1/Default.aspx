<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="pcs" Namespace="PCSCustomWebControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <pcs:RainbowLabel runat="server" ID="rainbowLabel1"
        Text="Multicolored label!" />
      <asp:Button Runat="server" ID="cycleButton" Text="Cycle colors"
        OnClick="cycleButton_Click" />
    </div>
    </form>
</body>
</html>
