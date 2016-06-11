<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="pcs" TagName="UserC1" Src="PCSUserC1.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <pcs:UserC1 runat="server" ID="myUserControl" />
            <asp:RadioButtonList runat="server" ID="suitList" AutoPostBack="True" 
                onselectedindexchanged="suitList_SelectedIndexChanged">
                <asp:ListItem Value="Club" Selected="True">Club</asp:ListItem>
                <asp:ListItem Value="Diamond">Diamond</asp:ListItem>
                <asp:ListItem Value="Heart">Heart</asp:ListItem>
                <asp:ListItem Value="Spade">Spade</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    </form>
</body>
</html>
