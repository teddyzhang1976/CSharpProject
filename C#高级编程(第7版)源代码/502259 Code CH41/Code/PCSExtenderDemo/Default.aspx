<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
  TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Color Selector</title>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
      <asp:UpdatePanel runat="server" ID="updatePanel1">
        <ContentTemplate>
          <span style="display: inline-block; padding: 2px;">
            My favorite color is:
          </span>
          <asp:Label runat="server" ID="favoriteColorLabel" Text="green"
            style="color: #00dd00; display: inline-block; padding: 2px;
                   width: 70px; font-weight: bold;" />
          <ajaxToolkit:DropDownExtender runat="server" ID="dropDownExtender1"
            TargetControlID="favoriteColorLabel"
            DropDownControlID="colDropDown" />
          <asp:Panel ID="colDropDown" runat="server"
            Style="display: none; visibility: hidden; width: 60px;
                   padding: 8px; border: double 4px black;
                   background-color: #ffffdd; font-weight: bold;">
            <asp:LinkButton runat="server" ID="OptionRed" Text="red"
              OnClick="OnSelect" style="color: #ff0000;" /><br />
            <asp:LinkButton runat="server" ID="OptionOrange" Text="orange"
              OnClick="OnSelect" style="color: #dd7700;" /><br />
            <asp:LinkButton runat="server" ID="OptionYellow" Text="yellow"
              OnClick="OnSelect" style="color: #dddd00;" /><br />
            <asp:LinkButton runat="server" ID="OptionGreen" Text="green"
              OnClick="OnSelect" style="color: #00dd00;" /><br />
            <asp:LinkButton runat="server" ID="OptionBlue" Text="blue"
              OnClick="OnSelect" style="color: #0000dd;" /><br />
            <asp:LinkButton runat="server" ID="OptionPurple" Text="purple"
              OnClick="OnSelect" style="color: #dd00ff;" />
          </asp:Panel>
        </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
