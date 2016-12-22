<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProCSharpAjaxSample.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server" />
  <div>
    <asp:UpdatePanel runat="server" ID="updatePanel1">
      <ContentTemplate>
        <span style="display: inline-block; padding: 2px;">My favorite color is:
        </span>
      
        <asp:Label runat="server" ID="favoriteColorLabel" Text="green"
          Style="color: #00dd00; display: inline-block; padding: 2px; width: 70px; font-weight: bold;" />
<%--        <ajaxToolkit:DropDownExtender runat="server" ID="dropDownExtender1"
          TargetControlID="favoriteColorLabel"
          DropDownControlID="colDropDown" />--%>
<%--        <asp:Panel ID="colDropDown" runat="server"
          Style="display: none; visibility: hidden; width: 60px; padding: 8px; border: double 4px black; background-color: #ffffdd; font-weight: bold;">
          <asp:LinkButton runat="server" ID="OptionRed" Text="red"
            OnClick="OnSelect" Style="color: #ff0000;" /><br />
          <asp:LinkButton runat="server" ID="OptionOrange" Text="orange"
            OnClick="OnSelect" Style="color: #dd7700;" /><br />
          <asp:LinkButton runat="server" ID="OptionYellow" Text="yellow"
            OnClick="OnSelect" Style="color: #dddd00;" /><br />
          <asp:LinkButton runat="server" ID="OptionGreen" Text="green"
            OnClick="OnSelect" Style="color: #00dd00;" /><br />
          <asp:LinkButton runat="server" ID="OptionBlue" Text="blue"
            OnClick="OnSelect" Style="color: #0000dd;" /><br />
          <asp:LinkButton runat="server" ID="OptionPurple" Text="purple"
            OnClick="OnSelect" Style="color: #dd00ff;" />
        </asp:Panel>--%>
      </ContentTemplate>
    </asp:UpdatePanel>
  </div>
    </form>
</body>
</html>
